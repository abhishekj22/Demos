#define _TESTING
#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetAverageIncome(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		total += group[i]->GetIncome();
	}

	return total / count;
}

int main(void)
{
	Employee* dept[5];
	dept[0] = new Employee(186, 52);
	cout << "---------------------" << endl;
	dept[1] = new Employee(175, 225);
	cout << "---------------------" << endl;
	dept[2] = new SalesPerson(155, 55, 55000); // implicit upcasting 
	cout << "---------------------" << endl;
	dept[3] = new Employee(195, 85);
	cout << "---------------------" << endl;
	dept[4] = new SalesPerson(185, 65, 45000); 
	cout << "---------------------" << endl;

	cout << "Average income = "
		 << GetAverageIncome(dept, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
	{
		delete dept[i]; 
		cout << "---------------------" << endl;
	}
}

