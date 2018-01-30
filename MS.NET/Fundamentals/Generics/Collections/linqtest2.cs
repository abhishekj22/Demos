using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
	private static Interval CombineIntervals(Interval a, Interval b)
	{
		return new Interval(a.Minutes + b.Minutes, a.Seconds + b.Seconds);
	}

	public static void Main(string[] args)
	{
		int limit = args.Length > 0 ? int.Parse(args[0]) : 0;
		double distance = 500.0;
		List<Interval> store = new List<Interval>
		{
			new Interval(4, 31),
			new Interval(3, 12),
			new Interval(7, 43),
			new Interval(5, 24),
			new Interval(6, 35),
			new Interval(2, 56)
		};

		var selection = from i in store
				where i.Time > limit
				orderby i.Seconds
				select new 
				{
					Duration = i,
					Speed = 3.6 * distance / i.Time
				};
		foreach(var entry in selection)
			Console.WriteLine("{0}\t{1:0.0}", entry.Duration, entry.Speed);

		Interval result = (from i in store where i.Time > limit select i).Aggregate(CombineIntervals);
		Console.WriteLine("Total Interval = {0}", result);
	}
}