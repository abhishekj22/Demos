using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IList<Interval> store = new List<Interval>();
		store.Add(new Interval(6, 41));
		store.Add(new Interval(4, 32));
		store.Add(new Interval(7, 23));
		store.Add(new Interval(3, 54));
		store.Add(new Interval(5, 15));

		foreach(Interval entry in store)
			Console.WriteLine(entry);

		Console.WriteLine("Third Interval = {0}", store[2]);

	}
}