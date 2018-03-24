#include "mymacro.h"
#include <stdio.h>

int main(void)
{
	float value, square, cube;

	printf("Enter a real value: ");
	scanf("%f", &value);

	square = SQUARE(value);
	cube = CUBE(value);

	printf("Square = %f and Cube = %f\n", square, cube);
}

