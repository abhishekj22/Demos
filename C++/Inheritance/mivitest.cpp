#include <iostream>

using namespace std;

class TaxPayer
{
public:
	virtual double Income() const = 0;

	double Tax() const
	{
		float tx = age < 60 ? 0.15 : 0.12;
		double i = Income();

		return i > 120000 ? tx * (i - 120000) : 0;
	}

	static int Count()
	{
		return count;
	}

	virtual ~TaxPayer()
	{
		count--;
	}

protected:
	TaxPayer(int ag)
	{
		age = ag;
		++count;
	}
private:
	short age;
	static int count;
};

int TaxPayer::count = 0;

void Print(const TaxPayer& t)
{
	cout << "Income is " 
		 << t.Income()
		 << " and Tax is "
		 << t.Tax()
		 << endl;
}

//virtual inheritance: object will require its own base subobject (at bottom)
//but subobject will share base subobject
class Employee : public virtual TaxPayer
{
public:
	Employee(double sy, short ag) : TaxPayer(ag)
	{
		salary = sy;
	}

	double Income() const
	{
		return 12 * salary + 25000;
	}
private:
	double salary;
};

class Dealer : public virtual TaxPayer
{
public:
	Dealer(double ss, short ag) : TaxPayer(ag)
	{
		sales = ss;
	}

	double Income() const
	{
		return 0.15 * sales;
	}
private:
	double sales;
};

class SalesPerson : public Employee, public Dealer
{
public:
	SalesPerson(double sy, double ss, short ag) : Employee(sy, ag), Dealer(ss, ag), TaxPayer(ag)
	{
	}

	double Income() const
	{
		return Employee::Income() - 25000 + Dealer::Income() / 3;
	}
};

int main(void)
{
	Employee jill(32000, 26);
	Dealer jack(2700000, 62);
	SalesPerson john(18000, 1500000, 35);

	cout << "Jill the Employee: ";
	Print(jill);
	cout << "Jack the Dealer: ";
	Print(jack);
	cout << "John the SalesPerson: ";
	Print(john);

	cout << "Number of TaxPayers = " << TaxPayer::Count() << endl;
}


