#include <stdio.h>

int main(void)
{
	long inner = 0;
	long outer = 10;
	long frame;

	printf("Enter inner and outer widths: ");
	scanf("%ld%ld", &inner, &outer);

	frame = outer * outer - inner * inner;

	printf("Frame area = %ld\n", frame);
}




