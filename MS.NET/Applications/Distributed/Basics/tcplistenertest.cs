using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

class ClientHandler : MarshalByRefObject
{
	public ClientHandler()
	{
		Console.WriteLine("-- ClientHandler instance initialized in app-domain<{0}>", AppDomain.CurrentDomain.FriendlyName);
	}

	public void Communicate(NetworkStream connection)
	{
		byte[] buffer = new byte[80];
		int n = connection.Read(buffer, 0, buffer.Length);
		for(int i = 0; i < n; ++i)
			buffer[i] = (byte)(buffer[i] ^ '#');
		connection.Write(buffer, 0, n);
	}

	~ClientHandler()
	{
		Console.WriteLine("-- ClientHandler instance finalized in app-domain<{0}>", AppDomain.CurrentDomain.FriendlyName);
	}

}

static class Program
{
	public static void Main()
	{
		TcpListener listener = new TcpListener(IPAddress.Any, 2055);
		listener.Start();
		
		for(int i = 1; i <= 3; ++i)
		{
			Thread servant = new Thread(delegate()
			{
				Service(listener);
			});
			servant.Name = "servant." + i;
			servant.Start();
		}
	}

	private static void Service(TcpListener server)
	{
		for(;;)
		{
			TcpClient client = server.AcceptTcpClient();
			client.ReceiveTimeout = 60000;
			NetworkStream connection = client.GetStream();
			//ClientHandler handler = new ClientHandler();
			
			AppDomain dom = AppDomain.CreateDomain(Thread.CurrentThread.Name);
			ClientHandler handler = (ClientHandler)dom.CreateInstanceAndUnwrap("tcplistenertest", "ClientHandler");
			try
			{
				handler.Communicate(connection);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			AppDomain.Unload(dom);
			
			connection.Close();
			client.Close();
		}
	}
}