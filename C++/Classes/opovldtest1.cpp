#include <iostream>

using namespace std;

class Interval
{
public:
	
	// can be called with one argument but cannot be used as a conversion constructor
	explicit Interval(long s=0)
	{
		seconds = s;
	}

	Interval(long m, long s)
	{
		seconds = 60 * m + s;
	}

	void SetTime(long value)	
	{
		seconds = value; 
	}

	long GetTime() const 
	{
		return seconds; 
	}

	void Print() const 
	{

		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}

	//Interval Add(const Interval& other) const
	Interval operator+(const Interval& other) const
	{
		return Interval(seconds + other.seconds);
	}

	Interval operator++()
	{
		return Interval(++seconds);
	}

	Interval operator++(int)
	{
		return Interval(seconds++);
	}
	
private:
	long seconds; 

// a non-member function defined by author of a class 
// which can access private members that class  
friend Interval operator*(long, const Interval&);
};

Interval operator*(long lhs, const Interval& rhs) 
{
	return Interval(lhs * rhs.seconds);
}

int main(void)
{
	Interval a(3, 45);
	a.Print();

	Interval b(1, 90);
	b.Print();

	//Interval c = a.Add(b);
	Interval c = a + b; // a.operator+()
	c.Print();

	Interval d = 5 * c; // operator*(5, c)
	d.Print();

	Interval e = ++d; // d.operator++()
	d.Print();
	e.Print();

	Interval f = e++; // e.operator++(0)
	e.Print();
	f.Print();
}
