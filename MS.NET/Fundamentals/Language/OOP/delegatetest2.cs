using System;

delegate bool Filter(int value);

static class ArrayCounter
{
	public static int CountIf(int[] values, Filter allowed)
	{
		int count = 0;

		foreach(int value in values)
		{
			if(allowed(value))
				count += 1;
		}	

		return count;
	}
}

static class Program
{

	public static void Main()
	{
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
		Console.Write("All squares:");
		foreach(int s in squares)
			Console.Write(" {0}", s);
		Console.WriteLine();
		
		// passing anonymous method (closure)
		Console.WriteLine("Number of odd squares: {0}", ArrayCounter.CountIf(squares, delegate(int n){ return (n % 2) == 1;}));

		// passing lambda expression 
		Console.WriteLine("Number of big squares: {0}", ArrayCounter.CountIf(squares, n => n > 50));

	}
}