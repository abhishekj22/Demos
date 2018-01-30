using System;

static class Program
{
	private static T Select<T>(T first, T second) where T : IComparable<T>
	{
		if(first.CompareTo(second) > 0)
			return first;
		return second;
	}

	public static void Main()
	{
		double sd = Select(4.5, 3.4);
		Console.WriteLine("Selected double = {0}", sd);

		string ss = Select("monday", "tuesday");
		Console.WriteLine("Selected string = {0}", ss);
		
		Interval si = Select(new Interval(3, 20), new Interval(2, 30));
		Console.WriteLine("Selected Interval = {0}", si);


	}
}