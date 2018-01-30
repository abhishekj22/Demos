// functional interface(containing exactly one abstract method)
// can be replaced by a method reference 
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

class LambdaTest{

	private static boolean isOdd(int value){
		return (value % 2) == 1;
	}

	public static void main(String[] args){
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81};
		// passing method reference 
		System.out.printf("Number of odd squares: %d%n", Counter.countIf(squares, LambdaTest::isOdd));
		// passing lambda expression: (arguments) -> expression
		System.out.printf("Number of big squares: %d%n", Counter.countIf(squares, n -> n > 35));
	}
}

