#include "interval.h"
#include <map>
#include <iostream>
#include <string>

using namespace std;

typedef map<string, Interval> Store;

int main(void)
{
	Store items;
	items.insert(make_pair("monday", Interval(3, 41)));
	items.insert(make_pair("tuesday", Interval(7, 32)));
	items.insert(make_pair("wednesday", Interval(4, 53)));
	items.insert(make_pair("thursday", Interval(5, 24)));
	items.insert(make_pair("friday", Interval(6, 15)));
	items.insert(make_pair("monday", Interval(1, 20)));

	for(Store::iterator i = items.begin(); i != items.end(); ++i)
		cout << i->second << "\t" << i->first << endl;

	string key;
	cout << "Key: ";
	cin >> key;

	Store::iterator j = items.find(key);
	if(j != items.end())
		cout << "Value = " << j->second << endl;
	else
		cout << "Key not found!" << endl;
}

