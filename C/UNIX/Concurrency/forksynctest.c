#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <semaphore.h>
#include <sys/wait.h>
#include <sys/mman.h>

sem_t* lock;

void FinalizeJob(void)
{
	sem_destroy(lock);
	munmap(lock, sizeof(sem_t));
}

void InitializeJob(void)
{
	lock = mmap(NULL, sizeof(sem_t), PROT_READ | PROT_WRITE, MAP_SHARED | MAP_ANONYMOUS, -1, 0);
	sem_init(lock, 1, 3);
	atexit(FinalizeJob);
}

void HandleJob(int jid)
{
	sem_wait(lock);
	printf("Process <%d/%d> has accepted job:%d\n", getpid(), getppid(), jid);
	DoWork(jid);
	printf("Process <%d/%d> has finished job:%d\n", getpid(), getppid(), jid);
	sem_post(lock);
}

int main(void)
{
	register int i;

	InitializeJob();

	for(i = 1; i <= 5; ++i)
	{
		if(fork() == 0)
		{
			HandleJob(i);
			exit(i);
		}
	}

	while(wait(NULL) > 0);
}













