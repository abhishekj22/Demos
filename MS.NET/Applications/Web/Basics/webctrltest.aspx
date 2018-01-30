<%@ Page Inherits="BasicWebApp.WebCtrlTestPage" CodeFile="webctrltest.aspx.cs" %>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1><asp:Label ID="GreetLabel" Text="Welcome Visitor" runat="server"/></h1>
		<b>Time on server: </b><asp:Label ID="TimeLabel" runat="server"/>
	</body>
</html>