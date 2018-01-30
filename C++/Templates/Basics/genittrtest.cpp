#include "generic.h"
#include <iostream>
#include <string>

using namespace Generic;
using namespace std;

int main(void)
{
	SimpleStack<double> scores;
	scores.Push(52.1);
	scores.Push(63.2);
	scores.Push(71.3);
	scores.Push(48.4);
	scores.Push(36.5);
	scores.Push(24.6);

	for(SimpleStack<double>::Iterator i = scores.Begin(); i != scores.End(); ++i)
		cout << *i << endl;

	double total = 0;
	while(!scores.Empty())
		total += scores.Pop();
	cout << "Total score = " << total << endl;

	SimpleStack<string> days;
	days.Push("Monday");
	days.Push("Tuesday");
	days.Push("Wednesday");
	days.Push("Thursday");
	days.Push("Friday");

	for(SimpleStack<string>::Iterator i = days.Begin(); i != days.End(); ++i)
		cout << i->size() << "\t" << *i << endl; 
}


