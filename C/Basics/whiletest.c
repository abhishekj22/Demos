#include <stdio.h>

int main(void)
{
	long limit, total = 0;
	register int count = 0;

	printf("Enter limit: ");
	scanf("%ld", &limit);

	while(count <= limit)
	{
		total += count; // total = total + count;
		count += 1;
	}

	printf("Total = %ld\n", total);

}
