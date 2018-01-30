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

template<> // full specialization of IndexedValue class template for I=int, V=bool
class IndexedValue<int, bool>
{
public:
	IndexedValue(bool v) : value(v)
	{
		index = ++nid;
	}

	void Print() const
	{
		cout << "[" << index << "] : " << (value ? "true" : "false") << endl;
	}
private:
	int index;
	bool value;
};

int main(void)
{
	IndexedValue<string, double> a("Monday", 8.9); 
	a.Print();

	IndexedValue<int, bool> b(true);
	b.Print();
	
}

