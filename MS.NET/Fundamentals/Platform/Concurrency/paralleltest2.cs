using System;
using System.Linq;
using System.Threading.Tasks;

static class Program
{
	private static long ProcessedValue(int i)
	{
		Console.WriteLine("Processing value {0} in task<{1}>", i, Task.CurrentId);
		Worker.DoWork(i);
		return i * i;
	}

	public static void Main()
	{
		var source = Enumerable.Range(1, 20);
		long result = (from i in source.AsParallel() select ProcessedValue(i)).Sum();
		
		Console.WriteLine("Result = {0}", result);
	}
}