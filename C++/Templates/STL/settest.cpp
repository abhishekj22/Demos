#include "interval.h"
#include <set>
#include <iostream>
#include <functional>
#include <utility>

using namespace std;
using rel_ops::operator>;

typedef set<Interval, greater<Interval> > Store;

int main(void)
{
	Store items;
	items.insert(Interval(3, 41));
	items.insert(Interval(7, 32));
	items.insert(Interval(4, 53));
	items.insert(Interval(5, 24));
	items.insert(Interval(6, 15));
	items.insert(Interval(2, 101));

	for(Store::iterator i = items.begin(); i != items.end(); ++i)
		cout << *i << "\t" << i->Time() << endl;

}

