<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="GadgetsOnline.Admin.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout - Gadgets Online Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>You have been logged out successfully.</p>
            <a href="Login.aspx">Login Again</a> | 
            <a href="~/Default.aspx" runat="server">Go to Store</a>
        </div>
    </form>
</body>
</html>