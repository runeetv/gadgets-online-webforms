using System;
using System.Web.UI;

namespace GadgetsOnline.Admin
{
    public partial class ManageProducts : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Display welcome message with current user
                if (User.Identity.IsAuthenticated)
                {
                    LblWelcome.Text = $"Welcome, {User.Identity.Name}";
                }
                
                Page.Title = "Manage Products - Admin";
            }
        }
    }
}