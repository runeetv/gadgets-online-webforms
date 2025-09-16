<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GadgetsOnline.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login - Gadgets Online</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .login-container {
            max-width: 400px;
            margin: 100px auto;
            padding: 30px;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        .login-header {
            text-align: center;
            margin-bottom: 30px;
            color: #333;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }
        .form-group input[type="text"], 
        .form-group input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 14px;
        }
        .btn-login {
            width: 100%;
            padding: 12px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 10px;
        }
        .btn-login:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: #dc3545;
            font-size: 14px;
            margin-top: 10px;
            text-align: center;
        }
        .back-link {
            text-align: center;
            margin-top: 20px;
        }
        .back-link a {
            color: #007bff;
            text-decoration: none;
        }
        .back-link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-header">
                <h2>Admin Login</h2>
                <p>Gadgets Online Administration</p>
            </div>
            
            <div class="form-group">
                <label for="TxtUsername">Username:</label>
                <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" placeholder="Enter username" />
                <asp:RequiredFieldValidator ID="RfvUsername" runat="server" 
                    ControlToValidate="TxtUsername" 
                    ErrorMessage="Username is required" 
                    ForeColor="Red" 
                    Display="Dynamic" />
            </div>
            
            <div class="form-group">
                <label for="TxtPassword">Password:</label>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password" />
                <asp:RequiredFieldValidator ID="RfvPassword" runat="server" 
                    ControlToValidate="TxtPassword" 
                    ErrorMessage="Password is required" 
                    ForeColor="Red" 
                    Display="Dynamic" />
            </div>
            
            <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="btn-login" OnClick="BtnLogin_Click" />
            
            <asp:Label ID="LblMessage" runat="server" CssClass="error-message" Visible="False" />
            
            <div class="back-link">
                <a href="~/Default.aspx" runat="server">? Back to Store</a>
            </div>
        </div>
    </form>
</body>
</html>