#include <stdio.h>

/*
void SwapLong(long* first, long* second)
{
	long third = *first;
	*first = *second;
	*second = third;
}

void SwapDouble(double* first, double* second)
{
	double third = *first;
	*first = *second;
	*second = third;
}
*/

void SwapAny(void* first, void* second, int sz)
{
	char* pf = first;
	char* ps = second;
	register int i;

	for(i = 0; i < sz; ++i)
	{
		char t = pf[i];
		pf[i] = ps[i];
		ps[i] = t;
	}
}

#define Swap(X, Y) SwapAny(&X, &Y, sizeof(X))

int main(void)
{
	long lx = 23, ly = 32;
	double dx = 4.56, dy = 5.67;

	printf("Original long values: lx = %ld, ly = %ld\n", lx, ly);
	//SwapLong(&lx, &ly);
	//SwapAny(&lx, &ly, sizeof(long));
	Swap(lx, ly);
	printf("Swapped long values: lx = %ld, ly = %ld\n", lx, ly);

	printf("Original double values: dx = %lf, dy = %lf\n", dx, dy);
	//SwapDouble(&dx, &dy);
	//SwapAny(&dx, &dy, sizeof(double));
	Swap(dx, dy);
	printf("Swapped double values: dx = %lf, dy = %lf\n", dx, dy);
}













