class ForEachTest{

	public static void main(String[] args){
		/*
		for(int i = 0; i < args.length; ++i){
			System.out.printf("Hello %s%n", args[i]);
		}
		*/
		for(String name : args){
			System.out.printf("Hello %s%n", name);
		}
	}
}


