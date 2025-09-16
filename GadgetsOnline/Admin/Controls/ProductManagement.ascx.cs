using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GadgetsOnline.Models;
using GadgetsOnline.Services;

namespace GadgetsOnline.Admin.Controls
{
    public partial class ProductManagement : UserControl
    {
        private GadgetsOnlineEntities db = new GadgetsOnlineEntities();
        private Inventory inventory = new Inventory();

        // Simple ViewState properties to avoid serialization issues
        private bool DataLoaded
        {
            get { return ViewState["DataLoaded"] != null && (bool)ViewState["DataLoaded"]; }
            set { ViewState["DataLoaded"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAndBindData();
                DataLoaded = true;
            }
        }

        // Helper method to get the correct image URL
        protected string GetProductImageUrl(object productArtUrl)
        {
            if (productArtUrl != null && !string.IsNullOrEmpty(productArtUrl.ToString()))
            {
                string imageUrl = productArtUrl.ToString();
                
                // Ensure the path starts with ~/ for proper resolution
                if (!imageUrl.StartsWith("~/"))
                {
                    imageUrl = "~/" + imageUrl.TrimStart('/');
                }
                
                // Check if the physical file exists
                string physicalPath = Server.MapPath(imageUrl);
                if (File.Exists(physicalPath))
                {
                    return ResolveUrl(imageUrl);
                }
            }
            
            // Return placeholder image if product image doesn't exist or is empty
            return ResolveUrl("~/Images/placeholder.jpg");
        }

        private void LoadAndBindData()
        {
            BindCategoryDropdown();
            BindProductGrid();
        }

        private List<Product> LoadProducts()
        {
            try
            {
                return db.Products.Include("Category").ToList();
            }
            catch (Exception ex)
            {
                ShowMessage("Error loading products: " + ex.Message, false);
                return new List<Product>();
            }
        }

        private List<Category> LoadCategories()
        {
            try
            {
                return db.Categories.ToList();
            }
            catch (Exception ex)
            {
                ShowMessage("Error loading categories: " + ex.Message, false);
                return new List<Category>();
            }
        }

        private void BindCategoryDropdown()
        {
            var categories = LoadCategories();
            DdlCategory.DataSource = categories;
            DdlCategory.DataBind();
            DdlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        }

        private void BindProductGrid()
        {
            var products = LoadProducts();
            GvProducts.DataSource = products;
            GvProducts.DataBind();
        }

        protected void GvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Handle edit mode dropdown binding
            if (e.Row.RowType == DataControlRowType.DataRow && GvProducts.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlEditCategory = (DropDownList)e.Row.FindControl("DdlEditCategory");
                if (ddlEditCategory != null)
                {
                    var categories = LoadCategories();
                    ddlEditCategory.DataSource = categories;
                    ddlEditCategory.DataBind();
                    
                    // Set the selected value based on the current product's category
                    Product product = (Product)e.Row.DataItem;
                    if (product != null && categories.Any(c => c.CategoryId == product.CategoryId))
                    {
                        ddlEditCategory.SelectedValue = product.CategoryId.ToString();
                    }
                }
            }
        }

        protected void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var product = new Product
                    {
                        Name = TxtProductName.Text.Trim(),
                        Price = decimal.Parse(TxtPrice.Text),
                        CategoryId = int.Parse(DdlCategory.SelectedValue)
                    };

                    // Handle file upload
                    if (FileUploadImage.HasFile)
                    {
                        string imageUrl = UploadProductImage(FileUploadImage);
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            product.ProductArtUrl = imageUrl;
                        }
                    }

                    db.Products.Add(product);
                    db.SaveChanges();

                    // Refresh grid
                    BindProductGrid();

                    // Clear form
                    ClearAddProductForm();

                    ShowMessage("Product added successfully!", true);
                }
                catch (Exception ex)
                {
                    ShowMessage("Error adding product: " + ex.Message, false);
                }
            }
        }

        private string UploadProductImage(FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.HasFile)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();

                    if (allowedExtensions.Contains(fileExtension))
                    {
                        // Create Images directory if it doesn't exist
                        string imagesPath = Server.MapPath("~/Images/Products/");
                        if (!Directory.Exists(imagesPath))
                        {
                            Directory.CreateDirectory(imagesPath);
                        }

                        // Generate unique filename
                        string fileName = Guid.NewGuid().ToString() + fileExtension;
                        string filePath = Path.Combine(imagesPath, fileName);

                        // Save file
                        fileUpload.SaveAs(filePath);

                        // Return relative URL
                        return "~/Images/Products/" + fileName;
                    }
                    else
                    {
                        ShowMessage("Please select a valid image file (JPG, PNG, GIF).", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error uploading image: " + ex.Message, false);
            }

            return null;
        }

        private void ClearAddProductForm()
        {
            TxtProductName.Text = "";
            TxtPrice.Text = "";
            DdlCategory.SelectedIndex = 0;
            LblMessage.Text = "";
        }

        protected void GvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Handle custom commands if needed
        }

        protected void GvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvProducts.EditIndex = e.NewEditIndex;
            BindProductGrid();
        }

        protected void GvProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int productId = (int)GvProducts.DataKeys[e.RowIndex].Value;
                GridViewRow row = GvProducts.Rows[e.RowIndex];

                TextBox txtName = (TextBox)row.FindControl("TxtEditName");
                TextBox txtPrice = (TextBox)row.FindControl("TxtEditPrice");
                DropDownList ddlCategory = (DropDownList)row.FindControl("DdlEditCategory");

                if (txtName != null && txtPrice != null && ddlCategory != null)
                {
                    var product = db.Products.Find(productId);
                    if (product != null)
                    {
                        product.Name = txtName.Text.Trim();
                        product.Price = decimal.Parse(txtPrice.Text);
                        product.CategoryId = int.Parse(ddlCategory.SelectedValue);

                        db.SaveChanges();

                        GvProducts.EditIndex = -1;
                        BindProductGrid();

                        ShowMessage("Product updated successfully!", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error updating product: " + ex.Message, false);
            }
        }

        protected void GvProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvProducts.EditIndex = -1;
            BindProductGrid();
        }

        protected void GvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int productId = (int)GvProducts.DataKeys[e.RowIndex].Value;
                var product = db.Products.Find(productId);

                if (product != null)
                {
                    // Check if product is used in any orders
                    bool hasOrders = db.OrderDetails.Any(od => od.ProductId == productId);
                    if (hasOrders)
                    {
                        ShowMessage("Cannot delete product. It's referenced in existing orders.", false);
                        return;
                    }

                    // Delete product image file if exists
                    if (!string.IsNullOrEmpty(product.ProductArtUrl))
                    {
                        string imagePath = Server.MapPath(product.ProductArtUrl);
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();

                    BindProductGrid();

                    ShowMessage("Product deleted successfully!", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error deleting product: " + ex.Message, false);
            }
        }

        protected void GvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvProducts.PageIndex = e.NewPageIndex;
            BindProductGrid();
        }

        private void ShowMessage(string message, bool isSuccess)
        {
            LblStatusMessage.Text = message;
            LblStatusMessage.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            PanelMessage.Visible = true;

            // Also show in add product section
            LblMessage.Text = message;
            LblMessage.ForeColor = isSuccess ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        protected override void OnUnload(EventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.OnUnload(e);
        }
    }
}