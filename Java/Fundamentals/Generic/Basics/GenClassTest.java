class GenClassTest{
	
	static class SimpleStack<V>{
		
		private Node top;

		class Node{
			V value;
			Node below;

			Node(V entry){
				value = entry;
				below = top;
			}
		}

		public void push(V item){
			top = new Node(item);
		}

		public V pop(){
			V item = top.value;
			top = top.below;
			return item;
		}

		public boolean empty(){
			return top == null;
		}
	}

	public static void main(String[] args){
		SimpleStack<String> a = new SimpleStack<String>();
		a.push("monday");
		a.push("tuesday");
		a.push("wednesday");
		a.push("thursday");
		a.push("friday");
		//a.push(4.56);
		SimpleStack<String> b = new SimpleStack<>();
		b.push("june");
		b.push("may");
		b.push("april");
		b.push("march");
		SimpleStack<Interval> c = new SimpleStack<>();
		c.push(new Interval(5, 31));
		c.push(new Interval(3, 52));
		c.push(new Interval(7, 43));
		c.push(new Interval(6, 14));
		c.push(new Interval(4, 25));
		SimpleStack<Object> d = new SimpleStack<>();
		d.push(new Interval(2, 30));
		d.push("sunday");
		d.push(4.56);
		while(!a.empty())
			System.out.println(a.pop());
		System.out.println("----------------------");
		while(!b.empty())
			System.out.println(b.pop());
		System.out.println("----------------------");
		while(!c.empty())
			System.out.println(c.pop());
		System.out.println("----------------------");
		while(!d.empty())
			System.out.println(d.pop());
	}
}





