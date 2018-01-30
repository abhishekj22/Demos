using System;

class Interval
{
	private int min, sec;
	
	// property - methods invoked using field access syntax 
	public int Time
	{
		get 
		{
			return 60 * min + sec;
		}
		
		set
		{
			min = value / 60;
			sec = value % 60;
		}
	}
	
	// indexer - default (Item) parameterized property
	public int this[int index]
	{
		get
		{
			return index == 0 ? sec : min;
		}
	}

	public void Print()
	{
		Console.WriteLine("{0}:{1:00}", min, sec);
	}
}

static class Program 
{
	public static void Main()
	{
		Interval jack = new Interval();
		jack.Time = 125; // jack.set_Time(125)
		Console.Write("Jack's Interval = ");
		jack.Print();		

		Interval john = new Interval();
		john.Time = 200;
		Console.Write("John's Interval = ");
		Console.WriteLine("{0} minutes and {1} seconds.", john[1], john[0]); // john.get_Item(1)
	}
}