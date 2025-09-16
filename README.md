**GadgetsOnline-WebForms** is An ASP.NET 4.7.2 Web Forms based sample application. It uses EntityFramework and SQL Server for data persistence. 

Application Setup
--
Run following commands from Package Manager console to setup the initial DB. 

```
add-migration v1
update-database
```



 Application Pages
 ---
 - **Default.aspx (Homepage)** : Main landing page for customers

 - **Store/Browse.aspx (Category Browser)**: Browse products by category

 - **Store/Details.aspx (Product Details)** : View detailed product information

 - **CartPages/AddToCart.aspx (Shopping Cart)** : Handle adding products to shopping cart

 - **CartPages/ShoppingCart.aspx (Cart Review)** : Review and manage shopping cart contents

 - **Checkout/AddressAndPayment.aspx (Checkout Form)** : Collect customer information and process orders

 - **Checkout/Complete.aspx (Order Confirmation)** : Order completion confirmation

 - **Admin/Login.aspx (Admin Login)** : Secure admin authentication

 - **Admin/Logout.aspx (Admin Logout)** : Secure logout functionality

 - **Admin/ManageProducts.aspx (Product Administration)** : Complete product management interface

 - **Admin/Controls/ProductManagement.ascx (Product Management Control)** : Modular product management functionality



