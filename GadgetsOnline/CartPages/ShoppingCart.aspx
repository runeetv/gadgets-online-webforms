<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GadgetsOnline.CartPages.ShoppingCartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
        
        <div id="header" style="margin-top:10px">
            <h1 class="font-italic">
                <a href="~/Default.aspx" runat="server">Welcome to Gadgets Online!</a>
            </h1>
            <ul id="navlist">
                <li><a href="~/Default.aspx" runat="server">Home</a></li>
                <li><a href="~/CartPages/ShoppingCart.aspx" runat="server" id="current">ShoppingCart</a></li>
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
            <h3><em>Review</em> your cart:</h3>
            <p class="button">
                <asp:HyperLink ID="CheckoutLink" runat="server" Text="Checkout >>" NavigateUrl="~/Checkout/AddressAndPayment.aspx" />
            </p>
            <div id="update-message">
                <asp:Label ID="UpdateMessage" runat="server" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="CartGrid" runat="server" AutoGenerateColumns="False" 
                        OnRowCommand="CartGrid_RowCommand" DataKeyNames="ProductId"
                        GridLines="None" CellPadding="4">
                        <Columns>
                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:HyperLink ID="ProductLink" runat="server" 
                                        NavigateUrl='<%# "~/Store/Details.aspx?id=" + Eval("ProductId") %>'
                                        Text='<%# Eval("Product.Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Product.Price" HeaderText="Price (each)" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="Count" HeaderText="Quantity" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="RemoveLink" runat="server" CommandName="Remove" 
                                        CommandArgument='<%# Eval("ProductId") %>'
                                        Text="Remove from cart" CssClass="RemoveLink" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div id="cart-total">
                        <strong>Total:</strong> <asp:Label ID="CartTotalLabel" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="footer">
            <a href="https://aws.amazon.com/developer/language/net/"> AWS ❤️ ASP.NET </a>
        </div>
    </form>
</body>
</html>