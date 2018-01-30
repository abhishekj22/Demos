using System;

class MessageEventArgs : EventArgs
{
	public string Text {get;}
	
	public string From {get;}

	public MessageEventArgs(string textArg, string fromArg)
	{
		Text = textArg;
		From = fromArg;
	}
}

delegate void MessageEventHandler(object sender, MessageEventArgs e);

// event source
class Messenger
{
	public string Owner {get; set;}

	public event MessageEventHandler Receive;

	public event EventHandler Sent;
	
	public void Send(string text, Messenger to)
	{
		to.OnReceive(text, Owner);
		Sent?.Invoke(this, EventArgs.Empty);
	}

	private void OnReceive(string text, string from)
	{
		MessageEventArgs e = new MessageEventArgs(text, from);		
		Receive?.Invoke(this, e);
	}
}

// event sink
class MessengerApp
{
	private Messenger first, second;

	public MessengerApp()
	{
		first = new Messenger();
		first.Owner = "Jack";
		first.Receive += first_Receive;
		first.Receive += ShowTime; // contravariant substitution for second parameter

		second = new Messenger();
		second.Owner = "Jill";
		second.Sent += second_Sent;
	}
	
	private void first_Receive(object sender, MessageEventArgs e)
	{
		Console.WriteLine(">> Jack received '{0}' from {1}", e.Text, e.From);
		//first.Receive -= first_Receive;
	}	

	private void ShowTime(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}

	private void second_Sent(object sender, EventArgs e)
	{
		Console.WriteLine(">> Jill's message sent");
	}

	public void Run()
	{
		second.Send("Hi Jack.", first);
	
		for(int t = Environment.TickCount + 5000; Environment.TickCount < t;);

		second.Send("Bye Jack!", first);
	}
}

static class Program
{
	public static void Main()
	{
		MessengerApp app = new MessengerApp();
		app.Run();		
	}
}