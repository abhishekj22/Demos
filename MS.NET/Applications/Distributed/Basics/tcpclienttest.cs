using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main(string[] args)
	{
		string host = args.Length > 0 ? args[0] : "localhost";
		TcpClient client = new TcpClient();
		client.Connect(host, 2055);
		NetworkStream connection = client.GetStream();
		
		Console.Write("REQUEST : ");
		string text = Console.ReadLine();
		byte[] request = Encoding.UTF8.GetBytes(text);
		connection.Write(request, 0, request.Length);
		byte[] response = new byte[80];
		int n = connection.Read(response, 0, response.Length);
		Console.WriteLine("RESPONSE: {0}", Encoding.UTF8.GetString(response, 0, n));
		
		connection.Close();
		client.Close();
	}
}