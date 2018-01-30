<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Greeter.aspx.cs" Inherits="BasicUIApp.Greeter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BasicUIApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <p>
                    <asp:Label ID="OutputLabel" Text="Welcome Visitor" Font-Size="X-Large" runat="server" />
                </p>
                <p>
                    <b>Person:</b>
                    <asp:TextBox ID="PersonTextBox" runat="server" />
                    <asp:RequiredFieldValidator ControlToValidate="PersonTextBox" ErrorMessage="*" Display="Dynamic" runat="server" />
                </p>
                <p>
                    <b>Period:</b>
                    <asp:DropDownList ID="PeriodDropDownList" runat="server">
                        <asp:ListItem Text="Night" />
                        <asp:ListItem Text="Morning" />
                        <asp:ListItem Text="Afternoon" />
                        <asp:ListItem Text="Evening" />
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Button ID="GreetButton" Text="Greet" runat="server" OnClick="GreetButton_Click" />
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
