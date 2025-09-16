using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GadgetsOnline
{
    public partial class Default : Page
    {
        private Services.Inventory inventory;
        protected global::System.Web.UI.WebControls.Repeater ProductRepeater;
        protected global::System.Web.UI.WebControls.Repeater CategoryRepeater;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBestSellers();
                LoadCategories();
            }
        }

        private void LoadBestSellers()
        {
            inventory = new Services.Inventory();
            var products = inventory.GetBestSellers(6);
            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();
        }

        private void LoadCategories()
        {
            inventory = new Services.Inventory();
            var categories = inventory.GetAllCategories();
            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }
    }
}