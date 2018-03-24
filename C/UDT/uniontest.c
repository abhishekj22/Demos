#include <stdio.h>

union Score
{
	float marks;
	char grade;
};

int main(void)
{
	union Score jack = {58.5};

	union Score jill;
	jill.grade = 'A';

	printf("Marks of first student is %.2f\n", jack.marks);
	printf("Grade of second student is %c\n", jill.grade);

	return sizeof(jack);
}

