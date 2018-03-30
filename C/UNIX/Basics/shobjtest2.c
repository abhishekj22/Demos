#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <dlfcn.h>

int main(int argc, char* argv[])
{
	void* lib;
	int (*pbfunc)(char[], int);

	if(argc < 2)
		return printf("USAGE: %s lib-name\n", argv[0]);
	
	lib = dlopen(argv[1], RTLD_NOW);
	if(lib == NULL)
		return printf("ERROR: Cannot load %s\n", argv[1]);

	pbfunc = dlsym(lib, "ProcessBuffer");
	if(pbfunc)
	{
		char text[80];

		printf("Text to process: ");
		scanf("%79[^\n]s", text);

		pbfunc(text, strlen(text));

		printf("Processed text: %s\n", text);
	}
	else
		puts("ERROR: Bad library");

	dlclose(lib);
}















