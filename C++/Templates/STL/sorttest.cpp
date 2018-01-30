#include "interval.h"
#include <vector>
#include <algorithm>
#include <iostream>
#include <functional>
#include <utility>

using namespace std;
using rel_ops::operator>;

typedef vector<Interval> Store;

void Print(const Interval& i)
{
	cout << i << endl;
}

int main(void)
{
	Store items;
	items.push_back(Interval(3, 41));
	items.push_back(Interval(7, 32));
	items.push_back(Interval(4, 53));
	items.push_back(Interval(5, 24));
	items.push_back(Interval(6, 15));

	//sort(items.begin(), items.end());
	sort(items.begin(), items.end(), greater<Interval>()); 

	for_each(items.begin(), items.end(), Print);
}
