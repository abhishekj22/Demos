#include <stdio.h>

int main(void)
{
	long array[] = {111, 222, 333, 444, 555, 666, 777, 888};
	int index;
	long value;

	printf("Index (0-7): ");
	scanf("%d", &index);

	if(index < 8)
	{
		value = array[index];
		printf("Value = %ld\n", value);
	}

	puts("Goodbye.");
}


