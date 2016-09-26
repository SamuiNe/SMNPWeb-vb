<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Homepage.aspx.vb" Inherits="WebApplication1.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMNP Console</title>
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
    <form id="frmHomepage">

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
                <a href="inventory.aspx">Inventory</a>
            </td>
            <td class="subheader">
                <a href="transaction.aspx">Transaction</a>
            </td>
        </tr>
    </table>
    </form>
    </div>
    <div class="main">
        <br />
        <p>Welcome to Super Mom N Pop Management Console.</p>
        <p>Please select the page you need to use by selecting the appropriate section below the top image.</p>
        <p>Customer - To add, update, or remove consumer informations.<br />
           Inventory - To add, update, or remove inventory informations.<br />
           Transaction - To add, update, or remove transaction informations.
        </p>
        <br />
        <p style="color:gray; text-align:center;">Program version 0.6 (6/10/2016) - File version 0.3 (6/1/2016)<br />
            Minor edits made at 9/26/2016<br />
            Credits to Professor Paz for some of the behind the scenes code and code structure.<br />
            Programming languages used: XHTML5, CSS, and Visual Basic(Visual Studio 2013).<br />
            Programmed by SamuiNe, course CISP14 and CISP14L.
        </p>
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
