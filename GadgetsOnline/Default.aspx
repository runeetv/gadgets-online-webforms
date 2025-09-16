<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GadgetsOnline.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Gadgets Online!</title>
    <link href="Content/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" style="margin-top:10px">
            <h1 class="font-italic">
                <a href="~/Default.aspx" runat="server">Welcome to Gadgets Online!</a>
            </h1>
            <ul id="navlist">
                <li><a href="~/Default.aspx" runat="server" id="current">Home</a></li>
                <li><a href="~/CartPages/ShoppingCart.aspx" runat="server">ShoppingCart</a></li>
                <li><a href="~/Admin/ManageProducts.aspx" runat="server" style="color: #ff6600;">Admin</a></li>
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
            <div id="promotion">
            </div>

            <h3><em>Our best selling </em>Gadgets Online.</h3>

            <div class="row">
                <ul id="album-list">
                    <asp:Repeater ID="ProductRepeater" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# ResolveUrl("~/Store/Details.aspx?id=" + Eval("ProductId")) %>'>
                                    <img alt='<%# Eval("Name") %>' src='<%# ResolveUrl(Eval("ProductArtUrl").ToString()) %>' />
                                    <span><%# Eval("Name") %></span>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>

        <div id="footer">
            <a href="https://aws.amazon.com/developer/language/net/"> AWS ❤️ ASP.NET </a>
        </div>
    </form>
</body>
</html>