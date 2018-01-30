using System;
using System.Collections.Generic;

static class Program
{
	class IntervalComparer : IComparer<Interval>
	{
		public int Compare(Interval a, Interval b)
		{
			return a.Seconds - b.Seconds;
		}
	}

	public static void Main()
	{
		//ISet<Interval> store = new SortedSet<Interval>();
		ISet<Interval> store = new SortedSet<Interval>(new IntervalComparer());
		store.Add(new Interval(6, 41));
		store.Add(new Interval(4, 32));
		store.Add(new Interval(7, 23));
		store.Add(new Interval(3, 54));
		store.Add(new Interval(5, 15));
		store.Add(new Interval(2, 114));

		foreach(Interval entry in store)
			Console.WriteLine(entry);

	}
}