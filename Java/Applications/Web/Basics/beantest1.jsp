<jsp:useBean id="uctr" class="basicwebapp.CounterBean" scope="session"/>
<jsp:useBean id="gctr" class="basicwebapp.CounterBean" scope="application"/>
<jsp:setProperty name="gctr" property="step" value="3"/>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1>Welcome Visitor</h1>
		<b>Number of requests: </b>${uctr.nextCount} / ${gctr.nextCount}
	</body>
</html>

