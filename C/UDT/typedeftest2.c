#include "box.h"
#include <stdio.h>

int main(void)
{
	long l, b, h, t, area, volume;
	Box mybox;
	
	printf("Enter box dimensions: ");
	scanf("%ld%ld%ld", &l, &b, &h);
	printf("Enter box thickness: ");
	scanf("%ld", &t);

	BoxSetDimensions(mybox, l, b, h);
	BoxSetThickness(mybox, t);
	area = BoxGetArea(mybox);
	volume = BoxGetVolume(mybox);

	printf("Area = %ld and Volume = %ld\n", area, volume);
}

