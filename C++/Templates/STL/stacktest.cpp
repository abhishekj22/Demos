#include "interval.h"
#include <stack>
#include <list>
#include <iostream>

using namespace std;

//typedef stack<Interval> Store;
typedef stack<Interval, list<Interval> > Store;
 
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

