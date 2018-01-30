class AutoBoxTest2{

	private static Object select(int sign, Object first, Object second){
		if(sign < 0)
			return first;
		return second;
	}

	public static void main(String[] args){
		int s = Integer.parseInt(args[0]);
		String ss = (String)select(s, "monday", "tuesday"); 
		System.out.printf("Selected String = %s%n", ss);
		double sd = (double)select(s, 3.40, 2.30); // automatic boxing(arguments) and unboxing(result)
		System.out.printf("Selected double = %s%n", sd);
		int si = (int)select(s, 1234, "ABCD");
		System.out.printf("Selected int = %s%n", si);
	}
}

