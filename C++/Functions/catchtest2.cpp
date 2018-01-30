#include <iostream>
#include <string>

using namespace std;

struct BadName {}; 

int Lookup(string entries[], string entry, int count)
{
	if(entry.size() < 4)
	{
		BadName bn;
		throw bn;
	}
	for(int i = 0; i < count; ++i)
	{
		if(entries[i] == entry)
			return i;
	}

	throw entry;
}

void Run()
{
	string names[] = {"jack", "jill", "john", "jane", "jeff"};
	long balances[] = {13000, 15000, 17000, 14000, 12000};

	string name;
	cout << "Name: ";
	cin >> name;

	int i = Lookup(names, name, 5);
	cout << "Balance: " << balances[i] << endl;
}

int main(void)
{
	cout << "Welcome to our bank." << endl;
	try
	{
		Run();
	}
	catch(...)
	{
		cout << "Lookup operation failed!" << endl; 
	}
	cout << "Goodbye!" << endl;
}

