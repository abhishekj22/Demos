#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>

void End(void)
{
	puts("Goodbye User");
}

void Run(void)
{
	long value;
	long list[] = {111, 222, 333, 444, 555, 666, 777, 888};
	register int i;
	
	for(i = 1; i <= 3; ++i)
	{
		printf("Value %d: ", i);
		scanf("%ld", &value);

		printf("Result = %ld\n", 2520 / value);
		printf("Entry = %ld\n", list[value]);
	}
}

void MainHandler(int signo)
{
	switch(signo)
	{
	case SIGFPE:
		puts("ERROR: Illegal arithmatic operation.");
		break;
	case SIGSEGV:
		puts("ERROR: Illegal memory access.");
		break;
	case SIGINT:
		puts("Terminated.");
		break;
	}

	exit(signo);
}

int main(int argc, char* argv[])
{
	struct sigaction act = {MainHandler};

	puts("Welcome User");
	atexit(End);
	
	sigaction(SIGFPE, &act, NULL);
	sigaction(SIGSEGV, &act, NULL);
	sigaction(SIGINT, &act, NULL);

	Run();
}













