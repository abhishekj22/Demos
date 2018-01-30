import java.util.Iterator;

class IterationTest{
	
	static class SimpleStack<V> implements Iterable<V>{
		
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

		public Iterator<V> iterator(){
			return new Iterator<V>(){
				private Node current = top;

				public boolean hasNext(){
					return current != null;
				}

				public V next(){
					V result = current.value;
					current = current.below;
					return result;
				}
			};
		}
	}

	public static void main(String[] args){
		int[] array = {1, 9, 16, 25, 49};
		System.out.println("All integers in array");
		for(int i : array)
			System.out.println(i);
		SimpleStack<Interval> stack = new SimpleStack<>();
		stack.push(new Interval(5, 31));
		stack.push(new Interval(3, 52));
		stack.push(new Interval(7, 43));
		stack.push(new Interval(6, 14));
		stack.push(new Interval(4, 25));
		System.out.println("All intervals on stack");
		for(Interval i : stack)
			System.out.println(i);
	}
}





