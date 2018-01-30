#include <iostream>

using namespace std;

class Interval
{
public:
	
	Interval(long s=0, long m=0)
	{
		seconds = s + m * 60;
		++instances;
	}

	void SetTime(long value)	
	{
		seconds = value; 
	}

	long GetTime() const // long Interval::GetTime(const Interval* this)
	{
		return seconds; // return this->seconds;
	}

	void Print() const 
	{

		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}
	
	static int CountInstances()
	{
		return instances;
	}

	~Interval()
	{
		instances--;
	}

private:
	long seconds; 
	static int instances;  
};

int Interval::instances = 0;

float Speed(float distance, const Interval& duration)
{
	return 3.6 * distance / duration.GetTime(); // Interval::GetTime(&duration);
}

int main(void)
{
	cout << "Activating Interval jack" << endl; 
	Interval jack; 
	jack.SetTime(125);
	cout << "Jack's Interval = ";
	jack.Print(); 
	cout << "Jack's Speed = "
		 << Speed(500, jack)
		 << endl;

	cout << "Activating Interval john" << endl; 
	Interval john = 200; 
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = "
		 << Speed(500, john)
		 << endl;
	
	cout << "Number of active Interval instances = " 
		 << Interval::CountInstances()
		 << endl;

	cout << "Deactivating Interval john" << endl; 
	cout << "Deactivating Interval jack" << endl; 
}
