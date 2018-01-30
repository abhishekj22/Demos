using System;

class Interval
{
	private int min, sec;

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
	}

	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);
	}

	public static Interval operator*(int lhs, Interval rhs)
	{
		return new Interval(lhs * rhs.min, lhs * rhs.sec);
	}

	public static Interval operator++(Interval value)
	{
		return new Interval(value.min, value.sec + 1);
	}
	
	public static bool operator<(Interval lhs, Interval rhs)
	{
		int tl = 60 * lhs.min + lhs.sec;
		int tr = 60 * rhs.min + rhs.sec;

		return tl < tr;
	}

	public static bool operator>(Interval lhs, Interval rhs)
	{
		int tl = 60 * lhs.min + lhs.sec;
		int tr = 60 * rhs.min + rhs.sec;

		return tl > tr;
	}

	//public static implicit operator double(Interval value)
	public static explicit operator double(Interval value)
	{
		return value.min + value.sec / 60.0;
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
		Interval a = new Interval(4, 45);
		a.Print();		

		Interval b = new Interval(3, 30);
		b.Print();		

		Interval c = a + b;
		c.Print();

		Interval d = 5 * c;
		d.Print();

		Interval e = ++d;
		d.Print();
		e.Print();

		Interval f = e++;
		e.Print();
		f.Print();

		//double g = a;
		double g = (double)a;
		Console.WriteLine(g);
	}
}