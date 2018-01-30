<%@ Page Inherits="BasicWebApp.WebFormTestPage" %>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1><asp:Label ID="GreetLabel" Text="Welcome Visitor" runat="server"/></h1>
		<form runat="server">
			<b>Name: </b>
			<asp:TextBox ID="VisitorTextBox" runat="Server"/>
			<asp:Button ID="GreetButton" Text="Greet" OnClick="GreetButton_Click" runat="server"/>
		</form>
		<p>
			<asp:Label ID="StateLabel" runat="server" />
		</p>
	</body>
</html>