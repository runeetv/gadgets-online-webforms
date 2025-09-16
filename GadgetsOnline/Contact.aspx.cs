using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GadgetsOnline
{
    public partial class Contact : Page
    {
        protected global::System.Web.UI.WebControls.Literal MessageLiteral;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MessageLiteral.Text = "Your contact page.";
            }
        }
    }
}