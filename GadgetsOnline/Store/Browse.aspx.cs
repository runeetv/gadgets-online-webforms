using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GadgetsOnline.Store
{
    public partial class Browse : Page
    {
        private Services.Inventory inventory;
        protected global::System.Web.UI.WebControls.Repeater ProductRepeater;
        protected global::System.Web.UI.WebControls.Repeater CategoryRepeater;
        protected global::System.Web.UI.WebControls.Literal CategoryTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProductsByCategory();
            }
        }

        private void LoadCategories()
        {
            inventory = new Services.Inventory();
            var categories = inventory.GetAllCategories();
            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }

        private void LoadProductsByCategory()
        {
            string category = Request.QueryString["Category"];
            if (string.IsNullOrEmpty(category))
            {
                Response.Redirect("~/");
                return;
            }

            inventory = new Services.Inventory();
            var products = inventory.GetAllProductsInCategory(category);
            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();
            CategoryTitle.Text = category;
        }
    }
}