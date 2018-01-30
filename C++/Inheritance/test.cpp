#include<iostream>

using namespace std;

class base
{
	public:
			virtual void show()
			{
				cout << " base show method is called" << endl;
			}
};

class derive : public base
{
		public:
				void show()
				{
					cout << " derive show method is called " << endl;
				}
};

int main(void)
{
	base *jack = new derive;
	//jack.show();
	
//derive jill;
//	jack = &jill;
	jack->show();
}
