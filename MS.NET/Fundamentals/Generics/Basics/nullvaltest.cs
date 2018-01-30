using System;

static class Program
{
	//private static Nullable<double> GetBalance(string name)
	private static double? GetBalance(string name)
	{
		string[] names = {"jack", "jill", "john", "jane"};
		double[] balances = {12000, 17000, 15000, 9000};
		int i = Array.IndexOf(names, name);
		
		if(i >= 0)
			return balances[i];

		return null;
	}
	
	public static void Main()
	{
		Console.Write("Name: ");
		string name = Console.ReadLine();
		
		double? bal = GetBalance(name);
		if(bal == null)
			Console.WriteLine("Cannot find {0}", name);
		else
			Console.WriteLine("Balance: {0:0.00}", bal);
		Console.WriteLine("Interest: {0:0.00}", 0.04 * (bal ?? 0)); // bal != null ? bal : 0
	}
}