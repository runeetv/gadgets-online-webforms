<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complete.aspx.cs" Inherits="GadgetsOnline.Checkout.Complete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Complete</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" style="margin-top:10px">
            <h1 class="font-italic">
                <a href="~/Default.aspx" runat="server">Welcome to Gadgets Online!</a>
            </h1>
            <ul id="navlist">
                <li><a href="~/Default.aspx" runat="server">Home</a></li>
                <li><a href="~/CartPages/ShoppingCart.aspx" runat="server">ShoppingCart</a></li>
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
            <h2>Order Complete</h2>
            <p>Thanks for your order! Your order number is: <asp:Literal ID="OrderId" runat="server" /></p>
            <p>How about shopping for some more great gadgets in our <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Store</asp:HyperLink>?</p>
        </div>

        <div id="footer">
            <a href="https://aws.amazon.com/developer/language/net/"> AWS ❤️ ASP.NET </a>
        </div>
    </form>
</body>
</html>