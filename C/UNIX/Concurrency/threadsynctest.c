#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

long result = 0;
pthread_mutex_t monitor = PTHREAD_MUTEX_INITIALIZER;

void HandleJob(int jid)
{
	long value;

	printf("Thread <%x> has accepted job:%d\n", pthread_self(), jid);
	pthread_mutex_lock(&monitor);
	value = result;
	DoWork(jid);
	result = value + jid;
	pthread_mutex_unlock(&monitor);
	printf("Thread <%x> has finished job:%d\n", pthread_self(), jid);
}

typedef struct{
	int id;
}ThreadArg;

void* ChildStart(void* arg)
{
	ThreadArg* targ = arg;
	HandleJob(targ->id);
}

int main(void)
{
	pthread_t child[5];
	ThreadArg args[5];
	register int i;

	for(i = 0; i < 5; ++i)
	{
		args[i].id = i + 1;
		pthread_create(&child[i], NULL, ChildStart, &args[i]);
		//HandleJob(i + 1);
	}

	for(i = 0; i < 5; ++i)
		pthread_join(child[i], NULL);
	
	printf("Result = %ld\n", result);
}















