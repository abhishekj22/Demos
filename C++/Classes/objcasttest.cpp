#include <iostream>

using namespace std;

class Interval
{
public:
	Interval(long m=0, long s=0)
	{
		id = 0;
		minutes = m + s / 60;
		seconds = s % 60;
	}

	int GetId() const
	{
		static int nid = 1;

		if(id == 0)
			id = ++nid;

		return id;
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

	static const Interval& First()
	{
		static Interval first;
		first.id = 1;
		
		return first;
	}

private:
	mutable int id; //this field can be modified in a const member function
	long minutes;
	long seconds;
};

void Show(const Interval& i)
{
	cout << "Interval " << i.GetId() << " = ";
	i.Print();
}

int main(void)
{
	Interval jack(3, 20);
	Show(jack);

	Interval john(4, 30);
	Show(john);

	Interval& f = const_cast<Interval&>(Interval::First());
	f.SetTime(70);
	struct _Interval
	{
		int id;
		long minutes;
		long seconds;
	};
	_Interval& ff = reinterpret_cast<_Interval&>(f);
	ff.id = 101;
	Show(f);
}
