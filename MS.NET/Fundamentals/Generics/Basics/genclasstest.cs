using System;

public class SimpleStack<V>
{
	class Node
	{
		internal V value;
		internal Node below;

		internal Node(V v, Node n)
		{
			value = v;
			below = n;
		}
	}

	private Node top;

	public void Push(V element)
	{
		top = new Node(element, top);
	}

	public V Pop()
	{
		V element = top.value;
		top = top.below;
	
		return element;
	}

	public bool Empty()
	{
		return top == null;
	}
}

static class Program
{
	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("monday");
		a.Push("tuesday");
		a.Push("wednesday");
		a.Push("thursday");
		a.Push("friday");
		//a.Push(12.3);

		SimpleStack<string> b = new SimpleStack<string>();
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");

		var c = new SimpleStack<Interval>();
		c.Push(new Interval(4, 31));
		c.Push(new Interval(7, 42));
		c.Push(new Interval(6, 23));
		c.Push(new Interval(3, 54));
		c.Push(new Interval(5, 15));

		var d = new SimpleStack<object>();
		d.Push("saturday");
		d.Push(new Interval(2, 30));
		d.Push(12.3);

		while(!a.Empty())
			Console.WriteLine(a.Pop());
		Console.WriteLine("----------------------");

		while(!b.Empty())
			Console.WriteLine(b.Pop());
		Console.WriteLine("----------------------");

		while(!c.Empty())
			Console.WriteLine(c.Pop());
		Console.WriteLine("----------------------");

		while(!d.Empty())
			Console.WriteLine(d.Pop());
		
	}
}