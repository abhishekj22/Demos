#ifndef PAYROLL1_H
#define PAYROLL1_H

#include <iostream>

namespace Payroll
{
	class Employee
	{
	public:
		Employee(long h, float r)
		{
			hours = h;
			rate = r;
			#ifdef _TESTING
			std::cout << "Employee initialized" << std::endl;
			#endif
		}

		long GetHours() const
		{
			return hours;
		}

		virtual float GetRate() const
		{
			return rate;
		}
		
		// an overridable member function 
		virtual double GetIncome() const
		{
			double income = hours * rate;
			long ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		virtual ~Employee()
		{
			#ifdef _TESTING
			std::cout << "Employee finalized" << std::endl;
			#endif
		}
	private:
		long hours;
		float rate;
	};

	class SalesPerson : public Employee
	{
	public:
		SalesPerson(long h, float r, double s) : Employee(h, r)
		{
			sales = s;
			#ifdef _TESTING
			std::cout << "SalesPerson initialized" << std::endl;
			#endif
		}

		virtual double GetSales() const
		{
			return sales;
		}

		// overriding (by signature) base class member function
		double GetIncome() const
		{
			double income = Employee::GetIncome();

			if(sales >= 20000)
				income += 0.05 * sales;

			return income;
		}

		~SalesPerson()
		{
			#ifdef _TESTING
			std::cout << "SalesPerson finalized" << std::endl;
			#endif
		}
	private:
		double sales;
	};
}

#endif

