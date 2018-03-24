#include <stdio.h>

struct Student
{
	long id;
	short course;
};

int main(void)
{
	struct Student jack = {23, 31};
	
	struct Student jill;
	jill.id = 32;
	jill.course = 43;

	printf("Student with ID %ld has enrolled for course number %hd\n", jack.id, jack.course);
	printf("Student with ID %ld has enrolled for course number %hd\n", jill.id, jill.course);

	return sizeof(jack);
}

