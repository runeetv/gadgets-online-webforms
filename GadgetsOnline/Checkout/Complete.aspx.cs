using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GadgetsOnline.Services;

namespace GadgetsOnline.Checkout
{
    public partial class Complete : Page
    {
        private Services.Inventory inventory;
        protected global::System.Web.UI.WebControls.Repeater CategoryRepeater;
        protected global::System.Web.UI.WebControls.Literal OrderId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadOrderId();
            }
        }

        private void LoadCategories()
        {
            inventory = new Services.Inventory();
            var categories = inventory.GetAllCategories();
            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }

        private void LoadOrderId()
        {
            string idStr = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idStr) && int.TryParse(idStr, out int id))
            {
                OrderId.Text = id.ToString();
            }
        }
    }
}