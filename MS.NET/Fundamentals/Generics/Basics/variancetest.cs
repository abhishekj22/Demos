using System;

public interface IStackReader<out V>
{
	V Pop();
	bool Empty();
}

public interface IStackWriter<in V>
{
	void Push(V element);
}

public class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
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

	public void Copy(IStackWriter<V> target)
	{
		for(Node n = top; n != null; n = n.below)
			target.Push(n.value);
	}
}

public class FiniteStack<V> : IStackReader<V>, IStackWriter<V>
{
	private int count;
	private V[] elements;

	public FiniteStack(int size)
	{
		elements = new V[size];
	}

	public void Push(V element)
	{
		elements[count++] = element;
	}

	public V Pop()
	{
		return elements[--count];
	}

	public bool Empty()
	{
		return count == 0;
	}
}

static class Program
{
	private static void PrintStack(IStackReader<object> stack)
	{
		for(int i = 0; !stack.Empty(); ++i)
		{
			if(i > 0) Console.Write(", ");
			Console.Write(stack.Pop());
		}
		Console.WriteLine();
	}

	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("monday");
		a.Push("tuesday");
		a.Push("wednesday");
		a.Push("thursday");
		a.Push("friday");

		FiniteStack<string> b = new FiniteStack<string>(10);
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");
		a.Copy(b);

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
		c.Copy(d);
		
		PrintStack(a);
		PrintStack(b);
		PrintStack(c);
		PrintStack(d);
	}
}