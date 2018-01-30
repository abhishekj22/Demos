using System;

partial class Interval 
{
	private static int count;

	partial void OnInitialize()
	{
		Console.WriteLine($"Interval instance<{++count}> activated");
	}

	public static bool operator==(Interval lhs, Interval rhs)
	{
		return lhs.GetHashCode() == rhs.GetHashCode() && lhs.Equals(rhs);
	}

	public static bool operator!=(Interval lhs, Interval rhs) => !(lhs == rhs);
}

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(4, 5);
		Interval b = new Interval(3, 45);
		Interval c = new Interval(3, 65);
		Interval d = b;

		Console.WriteLine("Interval a = {0}", a.ToString());	
		Console.WriteLine("Interval b = {0}", b);
		Console.WriteLine("Interval c = {0}", c);	
		Console.WriteLine("Interval d = {0}", d);	

		Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
		Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));

		Console.WriteLine("a is equal to b: {0}", a.GetHashCode() == b.GetHashCode() && a.Equals(b));
		Console.WriteLine("a is equal to c: {0}", a == c);
		Console.WriteLine("d is equal to b: {0}", d == b);



	}
}