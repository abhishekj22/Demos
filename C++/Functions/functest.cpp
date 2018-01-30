#include <iostream>

using namespace std;

extern long Power(long, short);

int main(void)
{
	long b;
	short i;

	cout << "Input base and index: ";
	cin >> b >> i;

	cout << "Result = "
	     << Power(b, i)
	     << endl;

}
