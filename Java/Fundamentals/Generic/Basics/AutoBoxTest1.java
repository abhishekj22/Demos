class AutoBoxTest1{
	
	private static Double getBalance(String name){
		String[] names = {"jack", "jill", "john", "jane"};
		double[] balances = {9000, 13000, 11000, 7000};
		for(int i = 0; i < names.length; ++i){
			if(names[i].equals(name))
				return balances[i]; // Double.valueOf(balances[i])
		}
		return null;
	}

	public static void main(String[] args){
		Double result = getBalance(args[0]);
		if(result != null){
			double bal = result; // result.doubleValue()
			System.out.printf("Balance is %.2f%n", bal);
		}
	}
}

