#include <iostream>

using namespace std;

int nid = 0;

template<typename T>
void PrintIndexed(T value)
{
	cout << "[" << (++nid) << "] = " << value << endl;
}

template<> // explicit specialization of PrintIndexed function template for T=bool
void PrintIndexed(bool value) // PrintIndexed<bool>
{
	cout << "[" << (++nid) << "] = " << (value ? "true" : "false") << endl;	
}

int main(void)
{
	long a = 34;
	PrintIndexed(a);

	long b = 43;
	PrintIndexed(b);

	double c = 9.8;
	PrintIndexed(c);

	bool d = true;
	PrintIndexed(d);
}


