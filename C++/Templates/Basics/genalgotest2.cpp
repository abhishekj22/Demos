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
	long squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81};

	cout << "Number of odd squares: "
		 << Count(squares, squares + 9, IsOdd)
		 << endl;
	
	cout << "Number of big squares: "
		 << Count(squares, squares + 9, IsGreaterThan(40))
		 << endl;
}

