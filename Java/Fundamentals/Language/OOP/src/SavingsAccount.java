package edu.met.banking;

final class SavingsAccount extends Account implements Profitable{
	
	private static final double MIN_BALANCE = 5000;

	SavingsAccount(){
		balance = MIN_BALANCE;
	}

	public void deposit(double amount){
		balance += amount;
	}

	public void withdraw(double amount) throws InsufficientFundsException{
		if(balance - amount < MIN_BALANCE)
			throw new InsufficientFundsException();
		balance -= amount;
	}

	public double getInterest(int period){
		float rate = balance < 2 * MIN_BALANCE ? MIN_RATE : 4.5f;
		return balance * period * rate / 100;
	}
}


