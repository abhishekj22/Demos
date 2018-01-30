using System;
using System.Text;
using System.Net;

static class Program
{
	public static void Main(string[] args)
	{
		WebClient client = new WebClient();
		byte[] request = Encoding.UTF8.GetBytes(args[0]);
		byte[] response = client.UploadData("http://khussain.met.edu/encode.asp", request);
		Console.WriteLine(Encoding.UTF8.GetString(response));
	}
}