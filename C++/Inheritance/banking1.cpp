#include "banking1.h"

namespace Banking
{
	double Account::Balance() const
	{
		return balance;
	}

	void Account::Transfer(double amount, Account* other) throw(InsufficientFunds)
	{
		if(this != other)
		{
			this->Withdraw(amount);
			other->Deposit(amount);
		}
	}

	CurrentAccount::CurrentAccount()
	{
		balance = 0;
	}

	void CurrentAccount::Withdraw(double amount) throw(InsufficientFunds)
	{
		balance -= amount;
	}

	void CurrentAccount::Deposit(double amount)
	{
		if(balance < 0)
			amount *= 0.9;
		balance += amount;
	}

	SavingsAccount::SavingsAccount()
	{
		balance = 5000;
	}

	void SavingsAccount::Deposit(double amount)
	{
		balance += amount;
	}

	void SavingsAccount::Withdraw(double amount) throw(InsufficientFunds)
	{
		if(balance - amount < 5000)
			throw InsufficientFunds();
		balance -= amount;
	}

	double SavingsAccount::GetInterest(short period) const
	{
		float rate = balance < 20000 ? 4 : 5;

		return balance * period * rate / 100;
	}
}

