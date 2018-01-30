using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		if(args.Length > 2)
		{
			float price = float.Parse(args[0]);
			short stock = short.Parse(args[1]);
			string name = args[2].ToUpper();

			TextWriter writer = new StreamWriter(File.Create("product.txt"));
			writer.WriteLine(price);
			writer.WriteLine(stock);
			writer.WriteLine(name);
			writer.Close();
		}
		else
		{
			TextReader reader = new StreamReader(File.OpenRead("product.txt"));
			float price = float.Parse(reader.ReadLine());
			short stock = short.Parse(reader.ReadLine());
			string name = reader.ReadLine();
			reader.Close();
			Console.WriteLine("{0} {1} {2}", price, stock, name);
		}
	}
}