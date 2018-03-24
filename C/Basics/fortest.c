#include <stdio.h>

int main(void)
{
	long limit, total = 0;
	register int count;

	printf("Enter limit: ");
	scanf("%ld", &limit);

	for(count = 0; count <= limit; ++count)
	{
		total += count;
	}

	printf("Total = %ld\n", total);

}
