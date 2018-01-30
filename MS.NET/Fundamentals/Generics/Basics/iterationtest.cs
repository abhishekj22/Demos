using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleStack<V> : IEnumerable<V>
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

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.below)
			yield return n.value; // return an implementation of IEnumerator from returned values
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

static class Program
{
	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6};
		Console.WriteLine("All numbers in array");
		foreach(int n in numbers)
			Console.WriteLine(n);
	
		SimpleStack<Interval> intervals = new SimpleStack<Interval>();
		intervals.Push(new Interval(4, 31));
		intervals.Push(new Interval(7, 42));
		intervals.Push(new Interval(6, 23));
		intervals.Push(new Interval(3, 54));
		intervals.Push(new Interval(5, 15));
		Console.WriteLine("All intervals in stack");
		foreach(Interval i in intervals)
			Console.WriteLine(i);


	}
}