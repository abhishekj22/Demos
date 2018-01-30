#include <iostream>

using namespace std;

class Interval
{
public:
	
	// default(can be called with zero argument) constructor
	Interval()
	{
		seconds = 0;	
	}

	// conversion(can be called with single argument) constructor
	Interval(long value)
	{
		seconds = value;
	}

	// parameterized(can be called with multiple arguments) constructor 
	Interval(long s, long m)
	{
		seconds = s + m * 60;
	}

	void SetTime(long value) 
	{
		seconds = value; 
	}

	long GetTime()
	{
		return seconds;
	}

	void Print()
	{

		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}
private:
	long seconds;
};

int main(void)
{
	Interval jack; // automatic instantiation using default constructor 
	jack.SetTime(125);
	cout << "Jack's Interval = ";
	jack.Print(); 

	Interval john = 200; // automatic instantiation using conversion constructor
	cout << "John's Interval = ";
	john.Print();
	
	Interval jeff(70, 3); // automatic instantiation using parameterized constructor
	cout << "Jeff's Interval = ";
	jeff.Print();
}
