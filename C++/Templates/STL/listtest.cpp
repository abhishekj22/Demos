#include "interval.h"
#include <list>
#include <iostream>

using namespace std;

typedef list<Interval> Store;

int main(void)
{
	Store items;
	items.push_back(Interval(3, 41));
	items.push_back(Interval(7, 32));
	items.push_back(Interval(4, 53));
	items.push_back(Interval(5, 24));
	items.push_back(Interval(6, 15));
	items.push_front(Interval(2, 10));

	for(Store::iterator i = items.begin(); i != items.end(); ++i)
		cout << *i << "\t" << i->Time() << endl;

	//Store::iterator j = items.begin();
	//cout << "Third Interval = " << j[2] << endl;
}

