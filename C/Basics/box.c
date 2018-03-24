#include "box.h"

long BoxGetArea(long length, long breadth, long height)
{
	return 2 * (length * breadth + breadth * height + height * length);
}

long BoxGetVolume(long length, long breadth, long height)
{
	return length * breadth * height;
}

