<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="GadgetsOnline.Store.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Details</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" style="margin-top:10px">
            <h1 class="font-italic">
                <a href="~/Default.aspx" runat="server">Welcome to Gadgets Online!</a>
            </h1>
            <ul id="navlist">
                <li><a href="~/Default.aspx" runat="server">Home</a></li>
                <li><a href="~/ShoppingCart" runat="server">ShoppingCart</a></li>
            </ul>
        </div>

        <div>
        <ul id="categories">
     <asp:Repeater ID="CategoryRepeater" runat="server">
         <ItemTemplate>
             <li>
                 <a href='<%# ResolveUrl("~/Store/Browse.aspx?Category=" + Eval("Name")) %>'>
                     <%# Eval("Name") %>
                 </a>
             </li>
         </ItemTemplate>
     </asp:Repeater>
 </ul>
        </div>

        <div id="main">
            <h2><asp:Literal ID="ProductName" runat="server" /></h2>

            <p>
                <asp:Image ID="ProductImage" runat="server" />
            </p>

            <div id="album-details">
                <p>
                    <em>Type:</em>
                    <asp:Literal ID="CategoryName" runat="server" />
                </p>
                <p>
                    <em>Description:</em>
                    <asp:Literal ID="CategoryDescription" runat="server" />
                </p>
                <p>
                    <em>Price:</em>$
                    <asp:Literal ID="ProductPrice" runat="server" />
                </p>
                <p class="button">
                    <asp:HyperLink ID="AddToCartLink" runat="server" Text="Add to cart" />
                </p>
            </div>
        </div>

        <div id="footer">
            <a href="https://aws.amazon.com/developer/language/net/"> AWS ?? ASP.NET </a>
        </div>
    </form>
</body>
</html>