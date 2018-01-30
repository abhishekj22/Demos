using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IDictionary<string, Interval> store = new Dictionary<string, Interval>();
		store.Add("monday", new Interval(6, 41));
		store.Add("tuesday", new Interval(4, 32));
		store.Add("wednesday", new Interval(7, 23));
		store.Add("thursday", new Interval(3, 54));
		store.Add("friday", new Interval(5, 15));
		//store.Add("tuesday", new Interval(2, 30));

		foreach(var entry in store)
			Console.WriteLine("{0, -12}{1}", entry.Key, entry.Value);
		
		Console.Write("Key: ");
		string key = Console.ReadLine();
		try
		{
			Console.WriteLine("Value = {0}", store[key]);
		}
		catch(KeyNotFoundException)
		{
			Console.WriteLine("No such key!");
		}
		
	}
}