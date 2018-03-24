#include <stdio.h>

extern int CountPrimes(long, long);

int main(void)
{
	long l, h;
	int n;

	printf("Enter low and high: ");
	scanf("%ld%ld", &l, &h);
	
	n = CountPrimes(l, h);

	printf("Number of primes in range = %ld\n", n);
}

