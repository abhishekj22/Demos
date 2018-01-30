using System;
using System.Text;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport(@"legacy\x86\hashenc", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode)]
	private extern static int HashOfString(string str);

	[DllImport(@"legacy\x86\hashenc", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi)]
	private extern static int EncodeBuffer(StringBuilder buf, int sz);

	public static void Main()
	{
		Console.Write("Original string: ");
		string text = Console.ReadLine();

		Console.WriteLine("Hash of string : {0:X}", HashOfString(text));

		StringBuilder buf = new StringBuilder(text);
		EncodeBuffer(buf, buf.Length);
		Console.WriteLine("Encoded string : {0}", buf);

	}
}
