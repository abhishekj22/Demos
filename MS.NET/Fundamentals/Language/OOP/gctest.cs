using System;

class SomeResource : IDisposable 
{
	private string id;
	
	// class constructor 
	static SomeResource()
	{
		#if TESTING
		Console.WriteLine("SomeResource class initialized");
		#endif	
	}

	// instance constructor 
	public SomeResource(string name)
	{
		id = name;
		#if TESTING
		Console.WriteLine("{0} resource acquired and object initialized", id);
		#endif	
	}

	public void Consume(int action)
	{
		if(id != null)
			Console.WriteLine("Action {0} performed on {1} resource", action, id);
	}

	public void Dispose()
	{
		#if TESTING
		Console.WriteLine("{0} resource released and object disposed", id);
		#endif
	
		id = null;
		GC.SuppressFinalize(this);
	}

	// instance finalizer 
	~SomeResource()
	{
		#if TESTING
		Console.WriteLine("{0} resource released and object finalized", id);
		#endif				
	}
}

static class Program
{
	
	private static void Run()
	{
		SomeResource b = new SomeResource("second");
		b.Consume(2);
	}	

	private static void Run(string action)
	{
		/*
		SomeResource d = new SomeResource("fourth");
		try
		{
			d.Consume(int.Parse(action));
		}
		finally
		{
			d.Dispose();
		}
		*/

		using(SomeResource d = new SomeResource("fourth"))
		{
			d.Consume(int.Parse(action));
		}
		
	}

	public static void Main(string[] args)
	{
		SomeResource a = new SomeResource("first");
		Run();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		a.Consume(1);	

		SomeResource c = new SomeResource("third");
		c.Consume(3);
		c.Dispose();	

		try
		{
			Run(args[0]);
		}
		catch{}
	}
}