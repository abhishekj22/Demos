#include <time.h>

void DoWork(int count)
{
	clock_t t = clock() + count * CLOCKS_PER_SEC;

	while(clock() < t);
}




