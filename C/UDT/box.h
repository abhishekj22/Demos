/*
typedef long Box[3];

void BoxSetDimensions(Box, long, long, long);

long BoxGetArea(Box);

long BoxGetVolume(Box);
*/

typedef long Box[4];

void BoxSetDimensions(Box, long, long, long);

void BoxSetThikness(Box, long);

long BoxGetArea(Box);

long BoxGetVolume(Box);


