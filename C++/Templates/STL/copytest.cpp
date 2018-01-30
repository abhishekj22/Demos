#include "interval.h"
#include <vector>
#include <list>
#include <algorithm>
#include <iostream>
#include <iterator>

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
	
	vector<Interval> temp(items.size());
	copy(items.begin(), items.end(), temp.begin());
	sort(temp.begin(), temp.end());
	copy(temp.begin(), temp.end(), items.begin());
	copy(items.begin(), items.end(), ostream_iterator<Interval>(cout, "\n"));

}
