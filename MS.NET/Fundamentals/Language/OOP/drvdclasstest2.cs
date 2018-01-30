using Payroll;
using System;

static class Program
{
	private static double GetAverageIncome(Employee[] group)
	{
		double total = 0;
		
		foreach(Employee emp in group)
		{
			total += emp.GetIncome();
		}

		return total / group.Length;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double total = 0;
		
		foreach(Employee emp in group)
		{
			SalesPerson sp = emp as SalesPerson;
			if(sp != null)
				total += sp.Sales;
		}

		return total;
	}

	private static double GetTotalBonus(Employee[] group)
	{
		double total = 0;
		
		foreach(Employee emp in group)
		{
			if(emp is SalesPerson)
				total += 0.04 * emp.GetIncome();
			else
				total += 0.05 * emp.GetIncome();
		}

		return total;
	}

	public static void Main()
	{
		Employee[] dept = new Employee[5];
		dept[0] = new Employee(186, 52);
		dept[1] = new Employee(195, 205);
		dept[2] = new SalesPerson(175, 45, 55000);
		dept[3] = new Employee(180, 90);
		dept[4] = new SalesPerson(165, 55, 45000);

		Console.WriteLine("Average income = {0:0.00}", GetAverageIncome(dept));
		Console.WriteLine("Total sales = {0:0.00}", GetTotalSales(dept));
		Console.WriteLine("Total bonus = {0:0.00}", GetTotalBonus(dept));

	}
}