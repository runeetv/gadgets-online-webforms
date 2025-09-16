using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GadgetsOnline.Services;

namespace GadgetsOnline.CartPages
{
    public partial class ShoppingCartPage : Page
    {
        private Services.Inventory inventory;
        protected global::System.Web.UI.WebControls.Repeater CategoryRepeater;
        protected global::System.Web.UI.WebControls.GridView CartGrid;
        protected global::System.Web.UI.WebControls.Label CartTotalLabel;
        protected global::System.Web.UI.WebControls.Label UpdateMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadCart();
            }
        }

        private void LoadCategories()
        {
            inventory = new Services.Inventory();
            var categories = inventory.GetAllCategories();
            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }

        private void LoadCart()
        {
            var cart = Services.ShoppingCart.GetCart(new HttpContextWrapper(Context));
            CartGrid.DataSource = cart.GetCartItems();
            CartGrid.DataBind();
            CartTotalLabel.Text = cart.GetTotal().ToString("C");
        }

        protected void CartGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                var cart = Services.ShoppingCart.GetCart(new HttpContextWrapper(Context));
                int itemCount = cart.RemoveFromCart(productId);

                inventory = new Services.Inventory();
                string productName = inventory.GetProductNameById(productId);

                UpdateMessage.Text = Server.HtmlEncode(productName) + " has been removed from your shopping cart.";

                // Refresh the cart
                LoadCart();
            }
        }
    }
}