<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressAndPayment.aspx.cs" Inherits="GadgetsOnline.Checkout.AddressAndPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout - Address and Payment</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
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
            <h2>Address and Payment</h2>
            
            <asp:Label ID="ErrorMessage" runat="server" CssClass="error" />

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="FirstName" MaxLength="160" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="LastName" MaxLength="160" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="Address">Address:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="Address" MaxLength="70" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="City">City:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="City" MaxLength="40" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="State">State:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="State" MaxLength="40" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="PostalCode">Postal Code:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="PostalCode" MaxLength="10" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="Country">Country:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="Country" MaxLength="40" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="Phone">Phone:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="Phone" MaxLength="24" />
            </div>

            <div class="editor-label">
                <asp:Label runat="server" AssociatedControlID="Email">Email:</asp:Label>
            </div>
            <div class="editor-field">
                <asp:TextBox runat="server" ID="Email" MaxLength="160" />
            </div>

            <p class="button">
                <asp:Button runat="server" Text="Submit Order" OnClick="SubmitOrder_Click" />
            </p>
        </div>

        <div id="footer">
            <a href="https://aws.amazon.com/developer/language/net/"> AWS ❤️ ASP.NET </a>
        </div>
    </form>
</body>
</html>