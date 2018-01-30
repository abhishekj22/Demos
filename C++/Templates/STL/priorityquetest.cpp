#include "interval.h"
#include <queue>
#include <vector>
#include <iostream>
#include <functional>
#include <utility>

using namespace std;
using rel_ops::operator>;

class IntervalComparision
{
public:
	bool operator()(Interval x, Interval y) const
	{
		return x.Seconds() < y.Seconds();
	}
};

//typedef priority_queue<Interval> Store;
//typedef priority_queue<Interval, vector<Interval>, greater<Interval> > Store;
typedef priority_queue<Interval, vector<Interval>, IntervalComparision > Store;
 
int main(void)
{
	Store items;
	items.push(Interval(3, 41));
	items.push(Interval(7, 32));
	items.push(Interval(4, 53));
	items.push(Interval(5, 24));
	items.push(Interval(6, 15));
	
	while(!items.empty())
	{
		cout << items.top() << endl;
		items.pop();
	}

}

