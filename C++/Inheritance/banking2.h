#ifndef BANKING2_H
#define BANKING2_H

namespace Banking
{
	struct InsufficientFunds {};

	class Account
	{
	public:
		double Balance() const;
		virtual void Deposit(double) = 0; // pure virtual 
		virtual void Withdraw(double) throw(InsufficientFunds) = 0;
		void Transfer(double, Account*) throw(InsufficientFunds);
		virtual ~Account() {}
	protected:
		double balance;
	};

	class Profitable
	{
	public:
		virtual double GetInterest(short) const = 0;
		virtual ~Profitable(){}
	};


	//Factory functions

	Account* OpenCurrentAccount(void);

	Account* OpenSavingsAccount(void);

}

#endif

