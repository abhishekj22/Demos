﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="DBWebApp.Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Welcome Customer</h1>
    <form id="form1" runat="server">
        <asp:Login ID="CustomerLogin" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/Protected/Order.aspx" DisplayRememberMe="False" FailureText="Log in failed!" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="CustomerLogin_Authenticate" TextLayout="TextOnTop" TitleText="" UserNameLabelText="Customer ID:" >
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </form>
</body>
</html>
