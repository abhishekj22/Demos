#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

void HandleJob(int jid)
{
	printf("Process <%d/%d> has accepted job:%d\n", getpid(), getppid(), jid);
	DoWork(jid);
	printf("Process <%d/%d> has finished job:%d\n", getpid(), getppid(), jid);
}

int main(void)
{
	HandleJob(6);
	HandleJob(5);
}

