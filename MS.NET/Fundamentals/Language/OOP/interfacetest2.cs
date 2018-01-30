using System;

interface ITaxPayer
{
	double GetAnnualIncome();
}

static class TaxPayer
{
	//extension method for ITaxPayer (this qualified first parameter type)
	public static double GetIncomeTax(this ITaxPayer that, int age)
	{
		float rate = age < 60 ? 0.15f : 0.12f;
		double extra = that.GetAnnualIncome() - 120000;

		return extra > 0 ? rate * extra : 0;
	}
}

class Consultant : Payroll.Employee, ITaxPayer
{
	public Consultant(int h, float r) : base(h, r){}

	public double GetAnnualIncome()
	{
		return 12 * base.GetIncome();
	}
}

class Dealer : ITaxPayer
{
	private double sales;

	public Dealer(double s)
	{
		sales = s;
	}

	public double GetAnnualIncome()
	{
		return 0.15 * sales;
	}
}

static class Program
{
	public static void Main()
	{
		ITaxPayer jill = new Consultant(190, 210);
		ITaxPayer jack = new Dealer(5800000);

		Console.WriteLine("Jill's annual income is {0:0.00} and income tax is {1:0.00}", jill.GetAnnualIncome(), jill.GetIncomeTax(36)); //TaxPayer.GetIncomeTax(jill, 36);			
		Console.WriteLine("Jack's annual income is {0:0.00} and income tax is {1:0.00}", jack.GetAnnualIncome(), jack.GetIncomeTax(63)); 
	}
}
