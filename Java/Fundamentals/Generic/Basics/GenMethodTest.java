class GenMethodTest{

	private static<T> T select(int sign, T first, T second){
		if(sign < 0)
			return first;
		return second;
	}

	public static void main(String[] args){
		int s = Integer.parseInt(args[0]);
		String ss = select(s, "monday", "tuesday"); 
		System.out.printf("Selected String = %s%n", ss);
		double sd = select(s, 3.40, 2.30); // automatic boxing(arguments) and unboxing(result)
		System.out.printf("Selected double = %s%n", sd);
		int si = select(s, 1234, 0xABCD);
		System.out.printf("Selected int = %s%n", si);
	}
}

