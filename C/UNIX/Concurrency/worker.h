#include <time.h>

int DoWork(int n)
{
	clock_t t;

	if(n <= 0)
		n = time(NULL) % 10 + 1;
	
	t = clock() + n * CLOCKS_PER_SEC;
	while(clock() < t);

	return n;
}

