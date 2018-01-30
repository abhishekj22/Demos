using QuadEq;
using System;
using System.Runtime.InteropServices;

static class Program
{
	
	[STAThread]
	public static void Main()
	{
		Console.Write("Perimeter: ");
		double perim = double.Parse(Console.ReadLine());
		Console.Write("Area     : ");
		double area = double.Parse(Console.ReadLine());
		double a = 1, b = -perim / 2, c = area;

		QuadraticEquationClass eqn = new QuadraticEquationClass(); //new operator returns RCW of COM object (since QuadraticEquationClass is COM imported);

		if(eqn.HasRealRoots(a, b, c) != 0)
		{
			double r1, r2;
			eqn.Solve(a, b, c, out r1, out r2);
			Console.WriteLine("Dimensions =  {0}, {1}", r1, r2);
		}
		else
			Console.WriteLine("No such rectangle!");
	}
}
