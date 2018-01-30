using System;

static class Progam
{
	private static double GetIncome(double invest, int period=3, string risk="medium")
	{
		float rate;

		switch(risk)
		{
			case "low":
				rate = 6;
				break;
			case "high":
				rate = 12;
				break;
			default:
				rate = 9;
				break;
		}

		double amount = invest * Math.Pow(1 + rate / 100, period);

		return amount - invest;
	}
	
	public static void Main(string[] args)
	{
		try
		{
			double p = Convert.ToDouble(args[0]);
			Console.WriteLine("Income in GOLD scheme = {0:0.00}", GetIncome(p, 4, "high"));			
			Console.WriteLine("Income in SILVER scheme = {0:0.00}", GetIncome(p));
			Console.WriteLine("Income in BRONZE scheme = {0:0.00}", GetIncome(p, risk:"low"));
		}
		catch(IndexOutOfRangeException)
		{
			Console.WriteLine("Error: missing input");
		}
		catch
		{
			Console.WriteLine("Error: invalid input");
		}
	}
}