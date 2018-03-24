#include "box.h"

/*
void BoxSetDimensions(Box box, long length, long breadth, long height)
{
	box[0] = length;
	box[1] = breadth;
	box[2] = height;
}

long BoxGetArea(Box box)
{
	long length = box[0], breadth = box[1], height = box[2];

	return 2 * (length * breadth + breadth * height + height * length);
}

long BoxGetVolume(Box box)
{
	long length = box[0], breadth = box[1], height = box[2];

	return length * breadth * height;
}
*/

void BoxSetDimensions(Box box, long length, long breadth, long height)
{
	box[0] = length;
	box[1] = breadth;
	box[2] = height;
	box[3] = 0;
}

void BoxSetThickness(Box box, long thickness)
{
	box[3] = thickness;
}

long BoxGetArea(Box box)
{
	long length = box[0], breadth = box[1], height = box[2];

	return 2 * (length * breadth + breadth * height + height * length);
}

long BoxGetVolume(Box box)
{
	long length = box[0] - 2 * box[3], breadth = box[1] - 2 * box[3], height = box[2] - 2 * box[3];

	return length * breadth * height;
}

