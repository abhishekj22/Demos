interface Filter{
	boolean allowed(int value);
}

class Counter{

	public static int countIf(int[] values, Filter check){
		int count = 0;
		for(int value : values)
			if(check.allowed(value)) count += 1;
		return count;
	}
}

class InnerClassTest{

	// inner nested class
	// can only refer to static members of outer class
	// can define static and non-static members
	static class OddFilter implements Filter{

		public boolean allowed(int value){
			return (value % 2) == 1;
		}
	}

	// inner member class
	// can refer to static and non-static members of outer class
	// can only define non-static members
	class MidFilter implements Filter{
		
		private int low, high;

		MidFilter(int l, int h){
			low = l;
			high = h;
		}

		public boolean allowed(int value){
			return (value > low) && (value < high);
		}
	}

	public static void main(String[] args){
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81};
		System.out.printf("Number of odd squares: %d%n", Counter.countIf(squares, new InnerClassTest.OddFilter()));
		System.out.printf("Number of mid squares: %d%n", Counter.countIf(squares, new InnerClassTest().new MidFilter(15, 45)));
		int limit = 30; // if effectively final since it is captured by method of local inner class  
		// passing an instance of an inner local anonymous class 
		System.out.printf("Number of big squares: %d%n", Counter.countIf(squares, new Filter(){
			public boolean allowed(int value){
				return value > limit;
			}
		}));
		//limit += 10;
	}
}

