<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductManagement.ascx.cs" Inherits="GadgetsOnline.Admin.Controls.ProductManagement" %>

<div class="product-management-control">
    <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <!-- Add New Product Section -->
            <div class="form-section">
                <h3>Add New Product</h3>
                <asp:Panel ID="PanelAddProduct" runat="server" DefaultButton="BtnAddProduct">
                    <table>
                        <tr>
                            <td><asp:Label ID="LblProductName" runat="server" Text="Product Name:" AssociatedControlID="TxtProductName" /></td>
                            <td><asp:TextBox ID="TxtProductName" runat="server" Width="200px" /></td>
                            <td><asp:RequiredFieldValidator ID="RfvProductName" runat="server" ControlToValidate="TxtProductName" 
                                ErrorMessage="Product name is required" ForeColor="Red" ValidationGroup="AddProduct" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LblPrice" runat="server" Text="Price:" AssociatedControlID="TxtPrice" /></td>
                            <td><asp:TextBox ID="TxtPrice" runat="server" Width="100px" /></td>
                            <td><asp:RequiredFieldValidator ID="RfvPrice" runat="server" ControlToValidate="TxtPrice" 
                                ErrorMessage="Price is required" ForeColor="Red" ValidationGroup="AddProduct" />
                                <asp:RangeValidator ID="RvPrice" runat="server" ControlToValidate="TxtPrice" 
                                MinimumValue="0.01" MaximumValue="10000" Type="Currency" 
                                ErrorMessage="Price must be between $0.01 and $10,000" ForeColor="Red" ValidationGroup="AddProduct" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LblCategory" runat="server" Text="Category:" AssociatedControlID="DdlCategory" /></td>
                            <td><asp:DropDownList ID="DdlCategory" runat="server" Width="200px" DataTextField="Name" DataValueField="CategoryId" /></td>
                            <td><asp:RequiredFieldValidator ID="RfvCategory" runat="server" ControlToValidate="DdlCategory" 
                                InitialValue="0" ErrorMessage="Please select a category" ForeColor="Red" ValidationGroup="AddProduct" /></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="LblImage" runat="server" Text="Product Image:" AssociatedControlID="FileUploadImage" /></td>
                            <td><asp:FileUpload ID="FileUploadImage" runat="server" /></td>
                            <td><asp:Label ID="LblImageInfo" runat="server" Text="(Optional - JPG, PNG, GIF)" ForeColor="Gray" /></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="BtnAddProduct" runat="server" Text="Add Product" CssClass="btn btn-add" 
                                    OnClick="BtnAddProduct_Click" ValidationGroup="AddProduct" />
                                <asp:Label ID="LblMessage" runat="server" ForeColor="Green" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <!-- Products Grid Section -->
            <div class="grid-section">
                <h3>Existing Products</h3>
                <asp:GridView ID="GvProducts" runat="server" AutoGenerateColumns="False" CssClass="product-grid"
                    DataKeyNames="ProductId" OnRowCommand="GvProducts_RowCommand" OnRowEditing="GvProducts_RowEditing"
                    OnRowUpdating="GvProducts_RowUpdating" OnRowCancelingEdit="GvProducts_RowCancelingEdit"
                    OnRowDeleting="GvProducts_RowDeleting" OnRowDataBound="GvProducts_RowDataBound" AllowPaging="True" PageSize="10" 
                    OnPageIndexChanging="GvProducts_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="True" />
                        
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="ImgProduct" runat="server" 
                                    ImageUrl='<%# GetProductImageUrl(Eval("ProductArtUrl")) %>' 
                                    Width="50px" Height="50px" 
                                    AlternateText='<%# Eval("Name") %>'
                                    style="object-fit: cover; border: 1px solid #ccc;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="LblName" runat="server" Text='<%# Eval("Name") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtEditName" runat="server" Text='<%# Bind("Name") %>' Width="150px" />
                                <asp:RequiredFieldValidator ID="RfvEditName" runat="server" ControlToValidate="TxtEditName" 
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="EditProduct" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="LblPrice" runat="server" Text='<%# String.Format("{0:C}", Eval("Price")) %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TxtEditPrice" runat="server" Text='<%# Bind("Price") %>' Width="80px" />
                                <asp:RequiredFieldValidator ID="RfvEditPrice" runat="server" ControlToValidate="TxtEditPrice" 
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="EditProduct" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="LblCategory" runat="server" Text='<%# Eval("Category.Name") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DdlEditCategory" runat="server" DataTextField="Name" DataValueField="CategoryId" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-edit" />
                                <asp:LinkButton ID="LnkDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this product?');" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LnkUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-edit" 
                                    ValidationGroup="EditProduct" />
                                <asp:LinkButton ID="LnkCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; padding: 20px;">
                            <p>No products found.</p>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>

            <!-- Status Messages -->
            <asp:Panel ID="PanelMessage" runat="server" Visible="False">
                <asp:Label ID="LblStatusMessage" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>