using System;

static class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		double w = double.Parse(args[0]);
		double d = double.Parse(args[1]);
		Type t = Type.GetTypeFromProgID("METLogistics.AirCargo");
		dynamic cargo = Activator.CreateInstance(t);

		Console.WriteLine("Payment: {0:0.00}", cargo.QuoteTariff(w, d));
	}
}
