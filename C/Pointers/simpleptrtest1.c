#include <stdio.h>

double values[] = {11.1, 22.2, 33.3, 44.4, 55.5, 66.6, 77.7, 88.8};

int main(void)
{
	double* p = &values[3];
	double* q = p + 3;

	printf("%p ---> %lf\n", p, *p);
	printf("%p ---> %lf\n", q, *q);
	printf("%p[-2] = %lf\n", p, p[-2]);
}





