using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace GadgetsOnline.Admin
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sign out the user
            FormsAuthentication.SignOut();
            
            // Clear the session
            Session.Clear();
            Session.Abandon();
            
            // Clear any authentication cookies
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                cookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie);
            }
        }
    }
}