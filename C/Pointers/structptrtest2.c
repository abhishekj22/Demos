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

typedef struct Manager
{
	long id;
	float rate;
	short hours;
	long secid;
}Mgr;

/*
void ManagerInit(Mgr* emp, float r, short h)
{
	static long count = 0;

	emp->id = 101 + count++;
	emp->rate = r;
	(*emp).hours = h;
}

double ManagerGetIncome(const Mgr* emp)
{
	double income = emp->hours * emp->rate;
	short ot = emp->hours - 180;

	if(ot > 0)
		income += 50 * ot;
	
	return income;
}
*/

int main(void)
{
	Emp jack;
	Mgr jill;

	EmployeeInit(&jack, 52, 186);
	//ManagerInit(&jill, 65, 175);
	EmployeeInit((Emp*)&jill, 65, 175);
	jill.secid = jack.id;

	printf("Jack's ID is %ld and Income is %.2lf\n", jack.id, EmployeeGetIncome(&jack));
	//printf("Jill's ID is %ld and Income is %.2lf\n", jill.id, ManagerGetIncome(&jill));
	printf("Jill's ID is %ld and Income is %.2lf\n", jill.id, EmployeeGetIncome((Emp*)&jill));
}











