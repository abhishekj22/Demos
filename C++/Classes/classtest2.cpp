#include <iostream>

using namespace std;

class Interval
{
public:
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
		long m = seconds / 60;
		long s = seconds % 60;

		if(s < 10)
			cout << m << ":0" << s << endl;
		else
			cout << m << ":" << s << endl;
	}
private:
	long seconds;
};

double Speed(float distance, Interval duration)
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval jack; 
	jack.SetTime(125);
	cout << "Jack's Interval = ";
	jack.Print(); 
	cout << "Jack's Speed = "
		 << Speed(1000, jack)
		 << endl;

	Interval john;
	john.SetTime(200);
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = "
		 << Speed(1000, john)
		 << endl;
}
