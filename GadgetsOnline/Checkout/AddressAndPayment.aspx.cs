using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GadgetsOnline.Models;
using GadgetsOnline.Services;

namespace GadgetsOnline.Checkout
{
    public partial class AddressAndPayment : Page
    {
        private Services.Inventory inventory;
        protected global::System.Web.UI.WebControls.Repeater CategoryRepeater;
        protected global::System.Web.UI.WebControls.TextBox FirstName;
        protected global::System.Web.UI.WebControls.TextBox LastName;
        protected global::System.Web.UI.WebControls.TextBox Address;
        protected global::System.Web.UI.WebControls.TextBox City;
        protected global::System.Web.UI.WebControls.TextBox State;
        protected global::System.Web.UI.WebControls.TextBox PostalCode;
        protected global::System.Web.UI.WebControls.TextBox Country;
        protected global::System.Web.UI.WebControls.TextBox Phone;
        protected global::System.Web.UI.WebControls.TextBox Email;
        protected global::System.Web.UI.WebControls.Label ErrorMessage;

        private OrderProcessing orderProcessing;
        private OrderProcessing GetOrderProcess()
        {
            if (this.orderProcessing == null)
            {
                this.orderProcessing = new OrderProcessing();
            }
            return this.orderProcessing;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            inventory = new Services.Inventory();
            var categories = inventory.GetAllCategories();
            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(FirstName.Text))
            {
                ErrorMessage.Text = "First Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(LastName.Text))
            {
                ErrorMessage.Text = "Last Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Address.Text))
            {
                ErrorMessage.Text = "Address is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(City.Text))
            {
                ErrorMessage.Text = "City is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(State.Text))
            {
                ErrorMessage.Text = "State is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(PostalCode.Text))
            {
                ErrorMessage.Text = "Postal Code is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Country.Text))
            {
                ErrorMessage.Text = "Country is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Phone.Text))
            {
                ErrorMessage.Text = "Phone is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                ErrorMessage.Text = "Email is required.";
                return false;
            }

            // Validate email format
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$";
            if (!Regex.IsMatch(Email.Text, emailPattern))
            {
                ErrorMessage.Text = "Email is not valid.";
                return false;
            }

            return true;
        }

        protected void SubmitOrder_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var order = new Order
                    {
                        FirstName = FirstName.Text.Trim(),
                        LastName = LastName.Text.Trim(),
                        Address = Address.Text.Trim(),
                        City = City.Text.Trim(),
                        State = State.Text.Trim(),
                        PostalCode = PostalCode.Text.Trim(),
                        Country = Country.Text.Trim(),
                        Phone = Phone.Text.Trim(),
                        Email = Email.Text.Trim(),
                        Username = "Anonymous",
                        OrderDate = DateTime.Now
                    };

                    bool result = GetOrderProcess().ProcessOrder(order, new HttpContextWrapper(Context));
                    Response.Redirect($"~/Checkout/Complete.aspx?id={order.OrderId}");
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "An error occurred while processing your order. Please try again.";
                }
            }
        }
    }
}