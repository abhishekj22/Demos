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
	
	public abstract class Account
	{
		public int Id {get; internal set;}

		public double Balance {get; protected set;}
		
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

	public interface IProfitable
	{
		double GetInterest(int period);
	}

	public interface ITaxable
	{
		void Deduct();
	}

	public interface IFineable
	{
		void Deduct();
	}

	public abstract class BankAccount : Account
	{
		public override void Deposit(double amount)
		{
			Balance += amount;
		}
	}

	sealed class CurrentAccount : BankAccount, ITaxable, IFineable
	{

		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}	

		//explict interface implementation
		void ITaxable.Deduct()
		{
			if(Balance > 25000)
				Balance -= 0.05 * (Balance - 25000);
		}

		void IFineable.Deduct()
		{
			if(Balance < 0)
				Balance *= 1.1;
		}
	}
		


	sealed class SavingsAccount : BankAccount, IProfitable
	{
		const double MinimumBalance = 5000;

		internal SavingsAccount()
		{
			Balance = MinimumBalance;
		}
	

		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinimumBalance)
				throw new AccountException(FaultType.InsufficientFunds);
			
			Balance -= amount;
		}

		public double GetInterest(int period)
		{
			float rate = Balance < 2 * MinimumBalance ? 4 : 5;
			
			return Balance * period * rate / 100;
			
		}	
		
	}

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