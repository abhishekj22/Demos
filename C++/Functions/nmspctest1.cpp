int age = 43;

namespace Jack
{
	int age = 25;
}

int main(void)
{
	int age = 34;
	
	return age + ::age + Jack::age;
}

