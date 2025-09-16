using System;
using System.Web;
using System.Web.UI;
using GadgetsOnline.Services;

namespace GadgetsOnline.CartPages
{
    public partial class AddToCart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idStr = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idStr) && int.TryParse(idStr, out int id))
            {
                var cart = Services.ShoppingCart.GetCart(new HttpContextWrapper(Context));
                cart.AddToCart(id);
            }

            // Redirect back to the shopping cart
            Response.Redirect("~/CartPages/ShoppingCart.aspx");
        }
    }
}