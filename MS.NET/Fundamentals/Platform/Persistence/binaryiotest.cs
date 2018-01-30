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

			BinaryWriter writer = new BinaryWriter(File.Create("product.dat"));
			writer.Write(price);
			writer.Write(stock);
			writer.Write(name);
			writer.Close();
		}
		else
		{
			BinaryReader reader = new BinaryReader(File.OpenRead("product.dat"));
			float price = reader.ReadSingle();
			short stock = reader.ReadInt16();
			string name = reader.ReadString();
			reader.Close();
			Console.WriteLine("{0} {1} {2}", price, stock, name);
		}
	}
}