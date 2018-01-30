class GenBoundTest{

	private static<T extends Comparable<T>> T select(T first, T second){
		if(first.compareTo(second) > 0)
			return first;
		return second;
	}

	public static void main(String[] args){
		String ss = select("monday", "tuesday"); 
		System.out.printf("Selected String = %s%n", ss);
		double sd = select(3.40, 2.30);
		System.out.printf("Selected double = %s%n", sd);
		Interval si = select(new Interval(5, 45), new Interval(6, 54));
		System.out.printf("Selected Interval = %s%n", si);
	}
}

