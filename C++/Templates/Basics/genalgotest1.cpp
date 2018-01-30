#include "generic.h"
#include <iostream>

using namespace Generic;
using namespace std;

bool IsOdd(long n)
{
	return n % 2;
}

class IsGreaterThan
{
public:
	IsGreaterThan(long lim)
	{
		limit = lim;
	}

	bool operator()(long value) const
	{
		return value > limit;
	}
private:
	long limit;
};

int main(void)
{
	SimpleStack<long> squares;
	squares.Push(1);
	squares.Push(4);
	squares.Push(9);
	squares.Push(16);
	squares.Push(25);
	squares.Push(36);
	squares.Push(49);
	squares.Push(64);
	squares.Push(81);
	
	cout << "Number of odd squares: "
		 << Count(squares.Begin(), squares.End(), IsOdd)
		 << endl;
	
	cout << "Number of big squares: "
		 << Count(squares.Begin(), squares.End(), IsGreaterThan(40))
		 << endl;
}

