#include <iostream>

using namespace std;

double Average(double first, double second, double& dev)
{
	dev = first > second ? (first - second) / 2 : (second - first) / 2;

	return (first + second) / 2;
}

int main(void)
{
	double a, b, c, d;

	cout << "Input two real values: ";
	cin >> b >> c;

	a = Average(b, c, d);

	cout << "Average is " << a
		 << " with a deviation of " << d 
		 << endl;
}
