#include <stdio.h>

struct Employee
{
	long id;
	float rate;
	short hours;
};

typedef struct Employee Emp;

void EmployeeInit(Emp* emp, float r, short h)
{
	static long count = 0;

	emp->id = 101 + count++;
	emp->rate = r;
	(*emp).hours = h;
}

double EmployeeGetIncome(const Emp* emp)
{
	double income = emp->hours * emp->rate;
	short ot = emp->hours - 180;

	if(ot > 0)
		income += 50 * ot;
	
	return income;
}

int main(void)
{
	Emp jack, jill;

	EmployeeInit(&jack, 52, 186);
	EmployeeInit(&jill, 65, 175);

	printf("Jack's ID is %ld and Income is %.2lf\n", jack.id, EmployeeGetIncome(&jack));
	printf("Jill's ID is %ld and Income is %.2lf\n", jill.id, EmployeeGetIncome(&jill));
}











