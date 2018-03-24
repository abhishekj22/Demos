#include <stdio.h>

struct Student
{
	long id;
	short course;
	union
	{
		float marks;
		char grade;
	};
};

void PrintResult(struct Student entry)
{
	if((entry.course % 2) == 0)
		printf("Grade of student %ld is %c\n", entry.id, entry.grade);
	else
		printf("Marks of student %ld is %.2f\n", entry.id, entry.marks);
}

int main(void)
{
	struct Student jack = {23, 31, 58.5};

	struct Student jill;
	jill.id = 32;
	jill.course = 44;
	jill.grade = 'A';


	PrintResult(jack);
	PrintResult(jill);

	return sizeof(jack);
}


