using System;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		EndPoint local = new IPEndPoint(IPAddress.Any, 2055); // IPAddress.Any == IPAddress.Parse("0.0.0.0")
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		server.Bind(local);

		for(;;)
		{
			EndPoint remote = new IPEndPoint(IPAddress.Any, 0);			
			
			try
			{
				byte[] buffer = new byte[80];
				int n = server.ReceiveFrom(buffer, ref remote);
				for(int i = 0; i < n; ++i)
					buffer[i] = (byte)(buffer[i] ^ '#');
				server.SendTo(buffer, remote);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		
		}
	}
}