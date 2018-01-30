using System;

static class Program
{
	/*
	private static string Select(int selector, string first, string second)
	{
		if(selector < 0)
			return first;
		return second;
	}

	private static double Select(int selector, double first, double second)
	{
		if(selector < 0)
			return first;
		return second;
	}
	*/

	private static object Select(int selector, object first, object second)
	{
		if(selector < 0)
			return first;
		return second;
	}
	
	public static void Main(string[] args)
	{
		int s = args.Length > 0 ? int.Parse(args[0]) : 0;
			
		string ss = (string)Select(s, "monday", "tuesday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = (double)Select(s, 4.5, 3.4); // boxing/unboxing
		Console.WriteLine("Selected double = {0}", sd);

		int si = (int)Select(s, 123, "ABC");
		Console.WriteLine("Selected int = {0}", si);


	}
}