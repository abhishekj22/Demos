#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V> // IndexedValue class template
class IndexedValue
{
public:
	IndexedValue(const I& i, const V& v) : index(i), value(v)
	{
	}

	void Print() const
	{
		cout << index << " : " << value << endl;
	}
private:
	I index;
	V value;
};

int main(void)
{
	IndexedValue<string, double> a("Monday", 8.9); // instantiating templated IndexedValue class with I=string, V=double
	a.Print();

	IndexedValue<int, string> b(1, "Tuesday");
	b.Print();

	IndexedValue<int, double> c(2, 9.8);
	c.Print();

}
