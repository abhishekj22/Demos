#include <iostream>
#include <string>

using namespace std;
/*
void Swap(long& first, long& second)
{
	long third = first;

	first = second;
	second = third;
}

void Swap(double& first, double& second)
{
	double third = first;

	first = second;
	second = third;
}
*/

template<typename T> // Swapped function template
void Swap(T& first, T& second)
{
	T third = first;

	first = second;
	second = third;
}

int main(void)
{
	long lx = 43, ly = 34;
	cout << "Original long values: " << lx << ", " << ly << endl;
	Swap<long>(lx, ly); // calling templated Swap function with T=long
	cout << "Swapped long values: " << lx << ", " << ly << endl;

	double dx = 8.9, dy = 9.8;
	cout << "Original double values: " << dx << ", " << dy << endl;
	Swap(dx, dy); // Swap<double>(dx, dy) - implicit type deduction 
	cout << "Swapped double values: " << dx << ", " << dy << endl;

	string sx = "Monday", sy = "Tuesday";
	cout << "Original string values: " << sx << ", " << sy << endl;
	Swap(sx, sy);
	cout << "Swapped string values: " << sx << ", " << sy << endl;

	//Swap(dx, sy);
}
