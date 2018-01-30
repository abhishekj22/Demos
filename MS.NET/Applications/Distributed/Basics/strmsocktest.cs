using System;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		EndPoint local = new IPEndPoint(IPAddress.Any, 2055); // IPAddress.Any == IPAddress.Parse("0.0.0.0")
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		server.Bind(local);
		server.Listen(10);

		for(;;)
		{
			Socket client = server.Accept();
			client.ReceiveTimeout = 20000;
			
			try
			{
				byte[] buffer = new byte[80];
				int n = client.Receive(buffer);
				for(int i = 0; i < n; ++i)
					buffer[i] = (byte)(buffer[i] ^ '#');
				client.Send(buffer);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		
			client.Close();
		}
	}
}