#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>

int pfd[2];

void Produce(void)
{
	long value;

	printf("Producer <%d/%d> ready...\n", getpid(), getppid());
	value = DoWork(0);
	write(pfd[1], &value, sizeof(value));
}

void Consume(void)
{
	long value;

	printf("Consumer <%d/%d> ready...\n", getpid(), getppid());
	read(pfd[0], &value, sizeof(value));
	printf("Processed value = %ld\n", value * value);
}

int main(void)
{
	pid_t child;

	pipe(pfd);
	child = fork();

	if(child == 0)
		Consume();
	else
	{
		Produce();
		waitpid(child, NULL, 0);
	}

	close(pfd[1]);
	close(pfd[0]);
}











