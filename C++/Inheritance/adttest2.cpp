#include "banking1.h"
#include <iostream>

using namespace Banking;
using namespace std;

void DeductTax(Account* accounts[], int count)
{
	for(int i = 0; i < count; ++i)
	{
		double ex = accounts[i]->Balance() - 30000;
		if(ex > 0)
			accounts[i]->Withdraw(0.05 * ex);
	}
}

void PayAnnualInterest(Account* accounts[], int count)
{
	for(int i = 0; i < count; ++i)
	{
		SavingsAccount* p = dynamic_cast<SavingsAccount*>(accounts[i]);
		if(p)
		{
			double interest = p->GetInterest(1);
			accounts[i]->Deposit(interest);
		}
	}
}

int main(void)
{
	Account* bank[4];
	bank[0] = new SavingsAccount;
	bank[0]->Deposit(10000);
	bank[1] = new CurrentAccount;
	bank[1]->Deposit(25000);
	bank[2] = new CurrentAccount;
	bank[2]->Deposit(35000);
	bank[3] = new SavingsAccount;
	bank[3]->Deposit(40000);

	DeductTax(bank, 4);
	PayAnnualInterest(bank, 4);

	for(int i = 0; i < 4; ++i)
	{
		cout << (i + 1) << "\t" << bank[i]->Balance() << endl;
		delete bank[i];
	}
}


