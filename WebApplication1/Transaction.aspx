<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Transaction.aspx.vb" Inherits="WebApplication1.Transactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SMNP Console/Transactions</title>
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
        td.price{
            text-align:right;
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
    <p>Please select the action you want to choose for the transaction information.<br />
    Thenafter, please enter the required information then add or select the information you want to update/delete.</p>

    <form id="frmTransaction" runat="server">
        <asp:SqlDataSource ID="sqldsCustomer" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT * FROM [customer_info]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqldsEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT [EmployeeID], [EmployeeName] FROM [employee_info]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqldsItem" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT [ProductID], [ProductDescription], [ProductPrice], [ProductQuantity] FROM [product_info]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlInvoiceLinkStructure" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT customer_info.CustomerName, invoice_info.InvoiceID 
          FROM (customer_info INNER JOIN invoice_info ON customer_info.CustomerID = invoice_info.CustomerID)"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqldsInvoiceBase" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT invoice_info.InvoiceID, invoice_info.InvoiceDate, invoice_info.InvoiceUpdateDate, customer_info.CustomerID, customer_info.CustomerName, customer_info.CustomerPhone, customer_info.CustomerAddress, customer_info.CustomerEmail, employee_info.EmployeeID, employee_info.EmployeeName 
          FROM ((invoice_info INNER JOIN customer_info ON invoice_info.CustomerID = customer_info.CustomerID) INNER JOIN employee_info ON invoice_info.EmployeeID = employee_info.EmployeeID)
          ORDER BY invoice_info.InvoiceID ASC;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqldsInvoiceSupplementary" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT invoice_details.InvoiceDetailID, invoice_details.InvoiceID, invoice_details.ProductID, invoice_details.InvoiceProductQuantity, invoice_details.InvoiceProductTotal, invoice_info.InvoiceSubtotal, invoice_info.InvoiceTotal, product_info.ProductDescription, product_info.ProductPrice, product_info.ProductQuantity 
          FROM ((invoice_details INNER JOIN invoice_info ON invoice_details.InvoiceID = invoice_info.InvoiceID) INNER JOIN product_info ON invoice_details.ProductID = product_info.ProductID)
          ORDER BY invoice_details.InvoiceDetailID ASC;"></asp:SqlDataSource>
        <table>
            <tr>
                <td class="productmargin">Invoice Information</td>
                <td>Invoice Details</td>
            </tr>
            <tr>
                <td class="productmargin">
                    <asp:RadioButtonList ID="rblInvoiceInfo" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">Add</asp:ListItem>
                        <asp:ListItem Value="2">Update</asp:ListItem>
                        <asp:ListItem Value="3">Remove</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblInvoiceDetail" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">Add</asp:ListItem>
                        <asp:ListItem Value="2">Update</asp:ListItem>
                        <asp:ListItem Value="3">Remove</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="productmargin"><asp:Label ID="lblExistingInvoice" runat="server" Text="Please choose an existing invoice you want to update or remove." Visible="False"></asp:Label></td>
                <td><asp:Label ID="lblExistingInvoiceDetail" runat="server" Text="Please select the inventory detail to update or remove and press apply." Visible="False"></asp:Label></td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="productfragmentA"><asp:Label ID="lblExistingInvoiceInfoInside" runat="server" Text="Existing Invoice Info: " Visible="False"></asp:Label></td>
                <td class="productfragmentE"><asp:DropDownList ID="ddlInvoiceInfo" runat="server" DataSourceID="sqldsInvoiceBase" DataTextField="CustomerName" DataValueField="InvoiceID" Visible="False" AutoPostBack="True"></asp:DropDownList></td>
                <td class="productfragmentA"><asp:Label ID="lblExistingInvoiceDetailInside" runat="server" Text="Existing Invoice Details: " Visible="False"></asp:Label></td>
                <td><asp:DropDownList ID="ddlInvoiceDetails" runat="server" DataSourceID="sqldsInvoiceSupplementary" DataTextField="ProductDescription" DataValueField="InvoiceDetailID" Visible="False" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td class="productfragmentA">Customer ID:</td>
                <td class="productfragmentE"><asp:Label ID="lblCustomerID" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA">Invoice Detail ID:</td>
                <td><asp:Label ID="lblInvoiceDetailID" runat="server" Text="-"></asp:Label></td>
            </tr>
            <tr>
                <td class="productfragmentA">Customer Name:</td>
                <td class="productfragmentE"><asp:DropDownList ID="ddlCustomerName" runat="server" DataSourceID="sqldsCustomer" DataTextField="CustomerName" DataValueField="CustomerID" AutoPostBack="True"></asp:DropDownList></td>
                <td class="productfragmentA">Invoice Detail Link:</td>
                <td><asp:DropDownList ID="ddlInvoiceLink" runat="server" DataSourceID="sqlInvoiceLinkStructure" DataTextField="CustomerName" DataValueField="InvoiceID" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="productfragmentA">Customer Phone:</td>
                <td class="productfragmentE"><asp:Label ID="lblCustomerPhone" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA">Linked Invoice ID:</td>
                <td><asp:Label ID="lblLinkedInvoiceID" runat="server" Text="-"></asp:Label></td>
            </tr>
            <tr>
                <td class="productfragmentA">Customer Address:</td>
                <td class="productfragmentE"><asp:Label ID="lblCustomerAddress" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA">Item:</td>
                <td><asp:DropDownList ID="ddlInvoiceDetailItem" runat="server" DataSourceID="sqldsItem" DataTextField="ProductDescription" DataValueField="ProductID" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="productfragmentA">Customer Email:</td>
                <td class="productfragmentE"><asp:Label ID="lblCustomerEmail" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA">Item Price:</td>
                <td><asp:Label ID="lblItemPrice" runat="server" Text="-"></asp:Label></td>
            </tr>
            <tr>
                <td class="productfragmentA">Employee ID:</td>
                <td class="productfragmentE"><asp:DropDownList ID="ddlEmployeeID" runat="server" DataSourceID="sqldsEmployee" DataTextField="EmployeeName" DataValueField="EmployeeID"></asp:DropDownList></td>
                <td class="productfragmentA"><asp:Label ID="lblItemQuantity" runat="server" Text="Item Quantity:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtItemQuantity" runat="server" Width="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="productfragmentA">Invoice ID:</td>
                <td class="productfragmentE"><asp:Label ID="lblInvoiceID" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA">Item Price Total:</td>
                <td><asp:Label ID="lblItemPriceTotal" runat="server" Text="-"></asp:Label></td>
            </tr>
            <tr>
                <td class="productfragmentA">Invoice Subtotal:</td>
                <td class="productfragmentE"><asp:Label ID="lblInvoiceSubtotal" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA"><asp:Button ID="btnInvoiceDetailApply" runat="server" Text="Invoice Detail Apply" /></td>
                <td></td>
            </tr>
            <tr>
                <td class="productfragmentA">Invoice Total:</td>
                <td class="productfragmentE"><asp:Label ID="lblInvoiceTotal" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA"></td>
                <td></td>
            </tr>
            <tr>
                <td class="productfragmentA">Invoice Date:</td>
                <td class="productfragmentE"><asp:Label ID="lblInvoiceDate" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA"></td>
                <td></td>
            </tr>
            <tr>
                <td class="productfragmentA">Invoice Update Date:</td>
                <td class="productfragmentE"><asp:Label ID="lblInvoiceUpdateDate" runat="server" Text="-"></asp:Label></td>
                <td class="productfragmentA"></td>
                <td></td>
            </tr>
            <tr>
                <td class="productfragmentA"><asp:Button ID="btnInvoiceInfoApply" runat="server" Text="Invoice Info Apply" /></td>
                <td class="productfragmentE"></td>
                <td class="productfragmentA"></td>
                <td></td>
            </tr>
        </table>
        
        <br />
        <asp:Label ID="lblTransactionStatus" runat="server" Text="Ready for user input."></asp:Label>
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
