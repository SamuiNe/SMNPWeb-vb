<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inventory.aspx.vb" Inherits="WebApplication1.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SMNP Console/Inventory</title>
    <style>
        body{
            width:100%;
            background-color:#ffffff;
        }
        div.header{
            background-color:#a3ff91;
            width:1028px;
            margin:auto;
        }
        div.footer{
            background-color:#a3ff91;
            width:1028px;
            margin:auto;
            text-align:center;
        }
        div.endimage{
            background-color:#ffffff;
            width:1028px;
            margin:auto;
        }
        div.main{
            background-color:#ceffc4;
            width:1028px;
            margin:auto;
        }
        td.subheader{
            width:257px;
            text-align:center;
        }
        td.productmargin{
            width:530px;
        }
        td.productfragmentA{
            width:175px;
        }
        td.productfragmentE{
            width:355px;
        }
    </style>
</head>
<body>
    <div class="header">

    <img alt="Welcome to Super Mom N Pop Management console. (Image failed to load.)" src="./images/Header.png" />
    <table>
        <tr>
            <td class="subheader">
                <a href="Homepage.aspx">Homepage</a>
            </td>
            <td class="subheader">
                <a href="Customer.aspx">Customer</a>
            </td>
            <td class="subheader">
                <a href="Inventory.aspx">Inventory</a>
            </td>
            <td class="subheader">
                <a href="Transaction.aspx">Transaction</a>
            </td>
        </tr>
    </table>
    </div>
    <div class="main">
    <br />
    <p>Please select the action you want to choose for the inventory information.<br />
    Thenafter, please enter the required information then add or select the information you want to update/delete.</p>

    <form id="frmInventory" runat="server">
        <asp:SqlDataSource ID="sqldsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT * FROM [product_info]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqldsVendor" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT * FROM [vendor_info]"></asp:SqlDataSource>
        <table>
            <tr>
                <td class="productmargin">Product Table</td>
                <td>Vendor Table</td>
            </tr>
            <tr>
                <td class="productmargin">
                    <asp:RadioButtonList ID="rblProductChoice" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">Add</asp:ListItem>
                        <asp:ListItem Value="2">Update</asp:ListItem>
                        <asp:ListItem Value="3">Remove</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblVendorChoice" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">Add</asp:ListItem>
                        <asp:ListItem Value="2">Update</asp:ListItem>
                        <asp:ListItem Value="3">Remove</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="productmargin"><asp:Label ID="lblExistingProduct" runat="server" Text="Please choose an existing product you want to update or remove." Visible="False"></asp:Label></td>
                <td><asp:Label ID="lblExistingVendor" runat="server" Text="Please choose an existing vendor you want to update or remove." Visible="False"></asp:Label></td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="productfragmentA"><asp:Label ID="lblExistingProductInside" runat="server" Text="Existing Product: " Visible="False"></asp:Label></td>
                <td class="productfragmentE"><asp:DropDownList ID="ddlExistingProduct" runat="server" DataSourceID="sqldsProduct" DataTextField="ProductDescription" DataValueField="ProductID" Visible="False" AutoPostBack="True"></asp:DropDownList></td>
                <td class="productfragmentA"><asp:Label ID="lblExistingVendorInside" runat="server" Text="Existing Vendor: " Visible="False"></asp:Label></td>
                <td><asp:DropDownList ID="ddlExistingVendor" runat="server" DataSourceID="sqldsVendor" DataTextField="VendorCompanyName" DataValueField="VendorID" Visible="False" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
        </table>
        <br/>
        <table>
            <tr>
                <td class="productfragmentA">Product ID:</td>
                <td class="productfragmentE"><asp:Label ID="lblProductID" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA">Vendor ID:</td>
                <td><asp:Label ID="lblVendorID" runat="server" Text="-"></asp:Label></td>
            </tr>
            <tr>
                <td class="productfragmentA">Product Description:</td>
                <td class="productfragmentE"><asp:TextBox ID="txtProductDescription" runat="server" Width="275px"></asp:TextBox></td>
                <td class="productfragmentA">Vendor Name:</td>
                <td><asp:TextBox ID="txtVendorName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="productfragmentA">Product Price (US$):</td>
                <td class="productfragmentE"><asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox></td>
                <td class="productfragmentA">Vendor Address:</td>
                <td><asp:TextBox ID="txtVendorAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="productfragmentA">Product Quantity:</td>
                <td class="productfragmentE"><asp:TextBox ID="txtProductQuantity" runat="server"></asp:TextBox></td>
                <td class="productfragmentA">Vendor Contact Name:</td>
                <td><asp:TextBox ID="txtVendorContactName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="productfragmentA">Linked Vendor:</td>
                <td class="productfragmentE"><asp:DropDownList ID="ddlLinkedVendor" runat="server" DataSourceID="sqldsVendor" DataTextField="VendorCompanyName" DataValueField="VendorID" Value="0"></asp:DropDownList></td>
                <td class="productfragmentA">Vendor Contact Phone:</td>
                <td><asp:TextBox ID="txtVendorContactPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="productfragmentA"></td>
                <td class="productfragmentE"></td>
                <td class="productfragmentA">Vendor Account #:</td>
                <td><asp:TextBox ID="txtVendorAccountNumber" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="productfragmentA"><asp:Button ID="btnProductApply" runat="server" Text="Product Apply" /></td>
                <td class="productfragmentE"></td>
                <td class="productfragmentA"><asp:Button ID="btnVendorApply" runat="server" Text="Vendor Apply" /></td>
                <td></td>
            </tr>
        </table>
        <asp:Label ID="lblInventoryStatus" runat="server" Text="Ready for user input."></asp:Label>
        </form>
    <br />
    </div>
    <div class="footer">
        ©2016 Super Mom N Pop Corporation. For internal use only.
    </div>
    <div class="endimage">
        <img alt="Thank you for using Super Mom N Pop Management console. (Image failed to load.)" src="./images/Footer.png" />
    </div>
</body>
</html>
