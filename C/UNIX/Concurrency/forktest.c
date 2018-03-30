#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>

void HandleJob(int jid)
{
	printf("Process <%d/%d> has accepted job:%d\n", getpid(), getppid(), jid);
	DoWork(jid);
	printf("Process <%d/%d> has finished job:%d\n", getpid(), getppid(), jid);
}

int main(void)
{
	pid_t child = fork();
	//printf("In process <%d/%d>, child=%d\n", getpid(), getppid(), child);
	//sleep(1);
	
	if(child == 0)
	{
		HandleJob(6); //executes in child process
	}
	else
	{
		HandleJob(5); //executes in parent process
		waitpid(child, NULL, 0); //reaping the child
	}
}















