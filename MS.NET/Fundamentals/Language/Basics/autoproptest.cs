using System;

class Customer
{
	// automatic property
	public string Name {get; set;}

	// automatic property with initializer 
	public double Credit {get; set;} = 5000;
}

static class Program
{
	public static void Main()
	{
		// object initializer 
		Customer a = new Customer{Name = "Jack", Credit = 4000};
		Console.WriteLine("{0}'s credit is {1}", a.Name, a.Credit);	
		
		// implicitly typed local
		var b = new Customer{Name = "Jill"};
		Console.WriteLine("{0}'s credit is {1}", b.Name, b.Credit);	
		
		// anonymous type 
		var c = new {Id = 23, Score = 62};
		Console.WriteLine("Student with ID {0} has scored {1}", c.Id, c.Score);
		
		// reusing anonymous type 
		var d = new {Id = c.Id + 1, Score = 48};
		Console.WriteLine("Student with ID {0} has scored {1}", d.Id, d.Score);	
	}
}