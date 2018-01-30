#include <iostream>

using namespace std;

class Interval
{
public:
	
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

	long operator[](int index) const
	{
		if(index == 0)
			return seconds % 60;
		return seconds / 60;
	}
	
	operator float() const
	{
		return seconds / 60.0;
	}

private:
	long seconds; 
};


int main(void)
{
	Interval a(3, 45);
	a.Print();
	cout << a[1] // a.operator[](1)
		 << "m" 
		 << a[0] 
		 << "s" 
		 << endl;

	float b = a; // a.float()
	cout << b << endl;
}
