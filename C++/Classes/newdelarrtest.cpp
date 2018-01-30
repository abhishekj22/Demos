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

	Interval(const Interval& other)
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval object (copy) initialized" << endl;
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


int main(void)
{
	int n;
	cout << "Number of Intervals: ";
	cin >> n;

	Interval* store = new Interval[n];

	for(int i = 0; i < n; ++i)
	{
		store[i].SetTime(20 * i + 350);
		store[i].Print();
	}

	//return *(((int*)store) - 1); 
	delete[] store;
}
