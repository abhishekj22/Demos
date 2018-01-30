using Banking;
using System;
using static Banking.Banker;

static class Program
{
	private static void DeductTax(Account[] accounts)
	{
		foreach(Account entry in accounts)
		{
			ITaxable t = entry as ITaxable;
			t?.Deduct(); //if(t != null) t.Deduct()
		}
	}

	private static void PayAnnualInterest(Account[] accounts)
	{
		foreach(Account entry in accounts)
		{
			IProfitable p = entry as IProfitable;
			if(p != null)
			{
				double interest = p.GetInterest(1);
				entry.Deposit(interest);
			}
		}
	}

	public static void Main()
	{
		Account[] bank = new Account[4];
		bank[0] = OpenCurrentAccount();
		bank[0].Deposit(20000);
		bank[1] = OpenSavingsAccount();
		bank[1].Deposit(25000);
		bank[2] = OpenSavingsAccount();
		bank[2].Deposit(35000);
		bank[3] = OpenCurrentAccount();
		bank[3].Deposit(50000);

		DeductTax(bank);
		PayAnnualInterest(bank);

		foreach(Account acc in bank)
			Console.WriteLine("{0}\t{1}", acc.Id, acc.Balance);

	}
}
