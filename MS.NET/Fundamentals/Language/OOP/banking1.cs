namespace Banking 
{
	using System;
	
	public enum FaultType {InsufficientFunds, IllegalTransfer}
	
	public class AccountException : ApplicationException
	{
		public FaultType Cause {get;}

		public AccountException(FaultType ft) : base(ft.ToString())
		{
			Cause = ft;
		}
	}
	
	// non-activatable type 
	public abstract class Account
	{
		public int Id {get; internal set;}

		public double Balance {get; protected set;}
		
		// must override method
		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(ReferenceEquals(this, that))
				throw new AccountException(FaultType.IllegalTransfer);

			this.Withdraw(amount);
			that.Deposit(amount);
		}

	}

	// non-inheritable type 
	sealed class CurrentAccount : Account
	{
		public override void Deposit(double amount)
		{
			Balance += amount;
		}	

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}	

	}

	sealed class SavingsAccount : Account
	{
		const double MinimumBalance = 5000;

		internal SavingsAccount()
		{
			Balance = MinimumBalance;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
		}	

		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinimumBalance)
				throw new AccountException(FaultType.InsufficientFunds);
			
			Balance -= amount;
		}	
		
	}

	//static factory class
	public static class Banker
	{
		private static int nid = Environment.TickCount % 1000000;

		public static Account OpenCurrentAccount()
		{
			Account acc = new CurrentAccount();
			acc.Id = 10000000 + nid++;

			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			Account acc = new SavingsAccount();
			acc.Id = 20000000 + nid++;

			return acc;
		}

	}
}