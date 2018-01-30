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
	
	// can be invoked on the class using :: operator 
	// it does not receive this argument and as such it 
	// cannot refer to other non-static members 
	static int CountInstances()
	{
		return instances;
	}

	// Destructor 
	~Interval()
	{
		instances--;
	}

private:
	long seconds; // each object gets a separate value 
	static int instances; // all objects share a single value 
};

int Interval::instances = 0;

void Run()
{
	cout << "Activating Interval jeff" << endl; 
	Interval jeff(70, 3); 
	cout << "Jeff's Interval = ";
	jeff.Print();
	cout << "Deactivating Interval jeff" << endl; 
}

int main(void)
{
	cout << "Activating Interval jack" << endl; 
	Interval jack; // Interval jack(0, 0)
	jack.SetTime(125);
	cout << "Jack's Interval = ";
	jack.Print(); 

	Run();
	
	cout << "Activating Interval john" << endl; 
	Interval john = 200; // Interval john(200, 0)
	cout << "John's Interval = ";
	john.Print();
	
	cout << "Number of active Interval instances = " 
		 << Interval::CountInstances()
		 << endl;

	cout << "Deactivating Interval john" << endl; 
	cout << "Deactivating Interval jack" << endl; 
}
