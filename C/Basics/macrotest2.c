#include "mymacro.h"
#include <stdio.h>

int main(void)
{
	long count, result;
	register int i;

	printf("Number of entries: ");
	scanf("%ld", &count);

	for(i = 1; i <= count; ++i)
	{
		#ifdef _HIGH
		result = CUBE(i);
		#else
		result = SQUARE(i);
		#endif

		printf("%d\t%ld\n", i, result);
	}		
}

