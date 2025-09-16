using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using GadgetsOnline.Services;

namespace GadgetsOnline.Admin
{
    public partial class Login : Page
    {
        private AuthenticationService authService = new AuthenticationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // If user is already authenticated, redirect to admin page
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/Admin/ManageProducts.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text.Trim();
            string password = TxtPassword.Text.Trim();

            if (authService.ValidateUser(username, password))
            {
                // Create authentication ticket
                FormsAuthentication.SetAuthCookie(username, false);

                // Redirect to requested page or default admin page
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    Response.Redirect("~/Admin/ManageProducts.aspx");
                }
            }
            else
            {
                LblMessage.Text = "Invalid username or password. Please try again.";
                LblMessage.Visible = true;
                TxtPassword.Text = ""; // Clear password field
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            authService?.Dispose();
            base.OnUnload(e);
        }
    }
}