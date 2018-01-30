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

	try
	{
		int i = Lookup(names, name, 5);
		cout << "Balance: " << balances[i] << endl;
	}
	catch(string e)
	{
		cout << "Cannot find " << e << endl;
	}
	catch(BadName)
	{
		cout << "Invalid name" << endl; 
	}
}

int main(void)
{
	cout << "Welcome to our bank." << endl;
	Run();
	cout << "Goodbye!" << endl;
}

