#include "payroll2.h"
#include <iostream>
#include <typeinfo>

using namespace Payroll;
using namespace std;

double GetTotalSales(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		//if(i == 2 || i == 4)
		if(typeid(*group[i]) == typeid(SalesPerson)) 
		{
			SalesPerson* s = static_cast<SalesPerson*>(group[i]);
			total += s->GetSales();
		}
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
	dept[4] = new SalesPerson(185, 65, 45000); 

	cout << "Total sales = "
		 << GetTotalSales(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
	{
		delete dept[i]; 
	}
}

