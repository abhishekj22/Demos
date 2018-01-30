#include <iostream>
#include <cmath>

using namespace std;

double GetIncome(double invest, short period, float rate=4)
{
	double amount = invest * pow(1 + rate / 100, period);
	
	return amount - invest;
}

int main(void)
{
	double p;
	short n;
	
	cout << "Input investment and period: ";
	cin >> p >> n;

	cout << "Income in fixed-deposit: "
	     << GetIncome(p, n, 8.5)
	     << endl;
	
	cout << "Income in savings-account: "
	     << GetIncome(p, n) //GetIncome(p, n, 4)
	     << endl;
}

