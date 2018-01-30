class VarArgTest{
	
	private static double average(double first, double second){
		return (first + second) / 2;
	}
	
	private static double average(double first, double second, double third){
		return (first + second + third) / 3;
	}

	private static double average(double first, double second, double... other){
		double sum = first + second;
		for(double value : other)
			sum += value;
		return sum / (other.length + 2);
	}

	public static void main(String[] args){
		System.out.printf("Average of two values: %.3f%n", average(19.7, 26.4));
		System.out.printf("Average of three values: %.3f%n", average(19.7, 26.4, 22.5));
		System.out.printf("Average of five values: %.3f%n", average(19.7, 26.4, 22.5, 17.6, 28.3)); //average(19.7, 26.4, new double[]{22.5, 17.6, 28.3})
	}
}

