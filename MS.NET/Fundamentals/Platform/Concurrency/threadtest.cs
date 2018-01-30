using System;
using System.Threading;

static class Program
{
	private static void HandleJob(int jid)
	{
		Console.WriteLine("Thread<{0}> has accepted job:{1}", Thread.CurrentThread.ManagedThreadId, jid);
		Worker.DoWork(jid);
		Console.WriteLine("Thread<{0}> has finished job:{1}", Thread.CurrentThread.ManagedThreadId, jid);
	}

	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? int.Parse(args[0]) : 50;
		
		//HandleJob(n);
		Thread child = new Thread(delegate(){HandleJob(n);});
		child.IsBackground = n > 75;
		child.Start();
		
		HandleJob(40);
	}
}