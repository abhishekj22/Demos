class SomeResource implements AutoCloseable{
	
	private String id;

	static{
		System.out.println("SomeResource class initialized");
	}

	SomeResource(String name){
		id = name;
		System.out.printf("%s resource acquired%n", name);
	}

	public void consume(int action){
		if(id != null)
			System.out.printf("Action %d performed on %s resource%n", action, id);
	}

	public void close(){
		if(id != null){
			System.out.printf("%s resource released%n", id);
			id = null;
		}
	}

	public void finalize(){
		close();
	}
}

class GCTest{

	private static void run(){
		SomeResource b = new SomeResource("second");
		b.consume(2);
	}

	private static void run(String action){
		try(SomeResource c = new SomeResource("third")){
			c.consume(Integer.parseInt(action));
		}
	}

	public static void main(String[] args){
		SomeResource a = new SomeResource("first");
		run();
		a.consume(1);
		a.close();
		System.gc();
		try{
			run(args[0]);
		}catch(Exception e){}
	}
}


