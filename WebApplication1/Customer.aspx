<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Customer.aspx.vb" Inherits="WebApplication1.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SMNP Console/Customer</title>
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
    <p>Please select the action you want to choose for the customer informations.<br />
    Thenafter, please enter the required information then add or select the information you want to update/delete.</p>
    Customer Tables
    <form id="frmCustomer" runat="server">
        <asp:SqlDataSource ID="sqldsCustomer" runat="server" ConnectionString="<%$ ConnectionStrings:Dev_connection_string %>" ProviderName="<%$ ConnectionStrings:Dev_connection_string.ProviderName %>" SelectCommand="SELECT * FROM [customer_info]"></asp:SqlDataSource>
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rblCustomerChoice" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="1">Add</asp:ListItem>
                        <asp:ListItem Value="2">Update</asp:ListItem>
                        <asp:ListItem Value="3">Remove</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExistingCustomer" runat="server" Text="Please choose an existing customer you want to update or remove." Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExistingCustomerInside" runat="server" Text="Existing Customer: " Visible="False"></asp:Label><asp:DropDownList ID="ddlExistingCustomer" runat="server" DataSourceID="sqldsCustomer" DataTextField="CustomerName" DataValueField="CustomerID" Visible="False" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <br>
        <table>
            <tr>
                <td>Customer ID:</td>
                <td><asp:Label ID="lblCustomerID" runat="server" Text="-"></asp:Label></td>
            </tr>
            <tr>
                <td>Customer Name:</td>
                <td><asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Customer Phone:</td>
                <td><asp:TextBox ID="txtCustomerPhone" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Customer Address:</td>
                <td><asp:TextBox ID="txtCustomerAddress" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Customer Email:</td>
                <td><asp:TextBox ID="txtCustomerEmail" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnConsumerApply" runat="server" Text="Apply" /><br />
        <asp:Label ID="lblConsumerStatus" runat="server" Text="Ready for user input."></asp:Label>
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
