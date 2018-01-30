#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetIncomeTax(const Employee& member)
{
	double i = member.GetIncome(); // member.vptr->GetIncome(&member)

	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack(186, 52);
	cout << "Jack's income is "
		 << jack.GetIncome()
		 << " and tax is "
		 << GetIncomeTax(jack)
		 << endl;

	SalesPerson jill(186, 52, 48000);
	cout << "Jill's income is "
		 << jill.GetIncome()
		 << " and tax is "
		 << GetIncomeTax(jill)
		 << endl;
}

