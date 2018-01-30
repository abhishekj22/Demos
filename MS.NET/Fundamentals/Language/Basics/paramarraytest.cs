using System;

static class Progam
{
	private static double Average(double first, double second)
	{
		return (first + second) / 2;		
	}

	private static double Average(double first, double second, double third) => (first + second + third) / 3;

	private static double Average(double first, double second, params double[] remaining)
	{
		double total = first + second;
		
		foreach(double value in remaining)
			total += value;
	
		return total / (remaining.Length + 2);
	}

	public static void Main()
	{
		Console.WriteLine("Average of two values = {0}", Average(29.4, 32.1));
		Console.WriteLine("Average of three values = {0}", Average(29.4, 32.1, 25.2));		
		Console.WriteLine("Average of five values = {0}", Average(29.4, 32.1, 25.2, 34.3, 21.8)); // Average(29.4, 32.1, new double[]{25.2, 34.3, 21.5})	
	}
}