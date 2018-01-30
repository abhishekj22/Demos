#include <iostream>

using namespace std;

class Interval
{
public:
	Interval(long m=0, long s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
		cout << "Interval object initialized" << endl;
	}

	// copy constructor 
	Interval(const Interval& other)
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval object (copy) initialized" << endl;
	}

	void operator=(const Interval& other)
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval object assigned " << endl; 
	}

	~Interval()
	{
		cout << "Interval object finalized" << endl;
	}

	void SetTime(long value) 
	{
		minutes = value / 60;
		seconds = value % 60;
	}

	long GetTime() const
	{
		return 60 * minutes + seconds;
	}

	void Print() const
	{
		if(seconds < 10)
			cout << minutes << ":0" << seconds << endl;
		else
			cout << minutes << ":" << seconds << endl;
	}
private:
	long minutes;
	long seconds;
};

class Journey
{
public:
	Journey(float dst, const Interval& dur) : duration(dur)
	{
		distance = dst;
		//duration = dur;
		cout << "Journey object initialized" << endl;
	}

	float Speed() const
	{
		return 3.6 * distance / duration.GetTime();
	}

	~Journey()
	{
		cout << "Journey object finalized" << endl;
	}
private:
	float distance;
	Interval duration;
};

void Run(void)
{
	Interval i(3, 20);
	Journey j(500, i);
	cout << "Speed = " << j.Speed() << endl;
}

int main(void)
{
	/*
	Interval a(2, 75);
	Interval b = a; // Interval b(a)

	Interval c;
	c = a; // c.operator=(a)
	*/

	cout << "Journey begins..." << endl;
	Run();
	cout << "Journey ends." << endl;
}
