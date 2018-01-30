<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="DBWebApp.Protected.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DBWebApp</title>
</head>
<body>
    <h1>Welcome Customer <asp:Label ID="CustomerIdLabel" runat="server" /></h1>
    <form id="form1" runat="server">
        <p>
            <b>Product No</b><br />
            <asp:DropDownList ID="ProductNoDropDownList" runat="server" DataSourceID="ProductDataSource" DataTextField="ProductNo" DataValueField="ProductNo" />
            <asp:ObjectDataSource ID="ProductDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DBWebApp.Models.ShopDataSetTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
        </p>
        <p>
            <b>Quantity</b><br />
            <asp:TextBox ID="QuantityTextBox" runat="server" />
            <asp:RequiredFieldValidator ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="input required!" runat="server" />
            <asp:RegularExpressionValidator ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="number expected!" ValidationExpression="[1-9][0-9]*" runat="server" />
        </p>
        <p>
            <asp:Button ID="OrderButton" Text="Order" OnClick="OrderButton_Click" runat="server" />
        </p>
        <p>
            <asp:Label ID="ResultLabel" Font-Bold="true" runat="server" />
        </p>
    </form>
    <p>
        <asp:HyperLink Text="View Invoice" NavigateUrl="Invoice.aspx" runat="server" />
    </p>
</body>
</html>
