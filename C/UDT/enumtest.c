#include <stdio.h>

enum RoomType {Economy=1, Business, Executive, Deluxe};

double GetPayment(short stay, enum RoomType room)
{
	float rate;

	switch(room)
	{
	case Economy:
		rate = 850;
		break;
	case Business:
		rate = 975;
		break;
	case Executive:
		rate = 1200;
		break;
	default:
		rate = 1500;
	}

	return 1.12 * stay * rate;
}

int main(void)
{
	short days;

	printf("Number of days: ");
	scanf("%hd", &days);

	printf("Payment for Economy room will be %.2lf\n", GetPayment(days, Economy));
	printf("Payment for Business room will be %.2lf\n", GetPayment(days, Business));
	printf("Payment for Executive room will be %.2lf\n", GetPayment(days, Executive));
	printf("Payment for Deluxe room will be %.2lf\n", GetPayment(days, Deluxe));
}

