<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="GadgetsOnline.Admin.ManageProducts" %>
<%@ Register Src="~/Admin/Controls/ProductManagement.ascx" TagName="ProductManagement" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Products - Gadgets Online Admin</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <style type="text/css">
        .admin-container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }
        .admin-header {
            background-color: #f5f5f5;
            padding: 15px;
            margin-bottom: 20px;
            border-radius: 5px;
        }
        .product-grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .product-grid th, .product-grid td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .product-grid th {
            background-color: #f2f2f2;
            font-weight: bold;
        }
        .product-grid img {
            max-width: 50px;
            max-height: 50px;
        }
        .btn {
            padding: 5px 10px;
            margin: 2px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            text-decoration: none;
            display: inline-block;
        }
        .btn-edit {
            background-color: #007bff;
            color: white;
        }
        .btn-delete {
            background-color: #dc3545;
            color: white;
        }
        .btn-add {
            background-color: #28a745;
            color: white;
            margin-bottom: 20px;
        }
        .form-section {
            background-color: #f9f9f9;
            padding: 20px;
            margin: 20px 0;
            border-radius: 5px;
            border: 1px solid #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
        
        <div class="admin-container">
            <div class="admin-header">
                <h1>Product Management</h1>
                <p>Manage products for Gadgets Online store</p>
                <nav>
                    <a href="~/Default.aspx" runat="server"> ← Back to Store</a>
                </nav>
            </div>

            <uc:ProductManagement ID="ProductManagementControl" runat="server" />
        </div>
    </form>
</body>
</html>