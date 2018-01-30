#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

class SalesAgent : public SalesPerson 
{
public:
	SalesAgent(double s) : SalesPerson(0, 0, s) {}

	double GetIncome() const
	{
		return 0.15 * GetSales();
	}
};

double GetTotalSales(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		SalesPerson* s = dynamic_cast<SalesPerson*>(group[i]); // explicit downcasting using RTTI
		if(s)
			total += s->GetSales();
	}

	return total;
}

int main(void)
{
	Employee* dept[5];
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(175, 225);
	dept[2] = new SalesPerson(155, 55, 55000); 
	dept[3] = new Employee(195, 85);
	dept[4] = new SalesAgent(145000); 

	cout << "Total sales = "
		 << GetTotalSales(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
	{
		delete dept[i]; 
	}
}

