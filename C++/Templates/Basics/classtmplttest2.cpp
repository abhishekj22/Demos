#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V> 
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

int nid = 0;

template<typename V> // partial specialization of IndexedValue class template for I=int
class IndexedValue<int, V>
{
public:
	IndexedValue(const V& v) : value(v)
	{
		index = ++nid;
	}

	void Print() const
	{
		cout << "[" << index << "] : " << value << endl;
	}
private:
	int index;
	V value;
};

int main(void)
{
	IndexedValue<string, double> a("Monday", 8.9); 
	a.Print();

	IndexedValue<int, string> b("Tuesday");
	b.Print();

	IndexedValue<int, double> c(9.8);
	c.Print();

}
