Module App

	Sub Main()
	
		Dim greeter As New Greeting.Greeter(True)
		Dim name As String = InputBox("Enter your name:")
		Dim text As String = greeter.Greet(name) 	
		MsgBox(text)
	
	End Sub

End Module