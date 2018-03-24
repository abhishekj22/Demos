#include <stdio.h>

long AddAll(long first, long last)
{
	long total = 0;
	register long entry;

	for(entry = first; entry <= last; ++entry)
	{
		total += entry;
	}

	return total;
}

/*
long AddOdd(long first, long last)
{
	long total = 0;
	register long entry;

	for(entry = first; entry <= last; ++entry)
	{
		if(entry % 2)
			total += entry;
	}

	return total;
}
*/

long AddIf(long first, long last, int (*allowed)(long)) 
{
	long total = 0;
	register long entry;

	for(entry = first; entry <= last; ++entry)
	{
		if(allowed(entry)) 
			total += entry;
	}

	return total;
}

int IsOdd(long n)
{
	return n & 1;
}

int main(void)
{
	long limit, sum;

	printf("Enter a positive integer: ");
	scanf("%ld", &limit);

	sum = AddAll(1, limit);
	printf("Sum of all integers upto %ld is %ld\n", limit, sum);

	//sum = AddOdd(1, limit);
	sum = AddIf(1, limit, IsOdd);
	printf("Sum of odd integers upto %ld is %ld\n", limit, sum);
}














