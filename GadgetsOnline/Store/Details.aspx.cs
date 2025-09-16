using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GadgetsOnline.Store
{
    public partial class Details : Page
    {
        private Services.Inventory inventory;
        protected global::System.Web.UI.WebControls.Repeater CategoryRepeater;
        protected global::System.Web.UI.WebControls.Literal ProductName;
        protected global::System.Web.UI.WebControls.Image ProductImage;
        protected global::System.Web.UI.WebControls.Literal CategoryName;
        protected global::System.Web.UI.WebControls.Literal CategoryDescription;
        protected global::System.Web.UI.WebControls.Literal ProductPrice;
        protected global::System.Web.UI.WebControls.HyperLink AddToCartLink;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProductDetails();
            }
        }

        private void LoadCategories()
        {
            inventory = new Services.Inventory();
            var categories = inventory.GetAllCategories();
            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }

        private void LoadProductDetails()
        {
            string idStr = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idStr) || !int.TryParse(idStr, out int id))
            {
                Response.Redirect("~/");
                return;
            }

            inventory = new Services.Inventory();
            var product = inventory.GetProductById(id);
            if (product == null)
            {
                Response.Redirect("~/");
                return;
            }

            ProductName.Text = product.Name;
            ProductImage.ImageUrl = ResolveUrl(product.ProductArtUrl);
            ProductImage.AlternateText = product.Name;
            CategoryName.Text = product.Category.Name;
            CategoryDescription.Text = product.Category.Description;
            ProductPrice.Text = string.Format("{0:F}", product.Price);
            AddToCartLink.NavigateUrl = ResolveUrl($"~/CartPages/AddToCart.aspx?id={product.ProductId}");
        }
    }
}