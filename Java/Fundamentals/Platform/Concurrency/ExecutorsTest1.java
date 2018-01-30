import java.util.*;
import java.util.concurrent.*;

class ExecutorsTest1{

	static class Translator implements Callable<String>{
		
		private String text;
		private int level;

		Translator(String text, int level){
			this.text = text;
			this.level = level;
		}

		public String call(){
			Worker.doWork(level);
			return text.toUpperCase();
		}
	}

	public static void main(String[] args) throws Exception{
		ExecutorService pool = Executors.newFixedThreadPool(2);
		Scanner input = new Scanner(System.in);
		System.out.print("Part (1/2): ");
		String w1 = input.nextLine();
		Translator t1 = new Translator(w1, 90);
		//String r1 = t1.call();
		Future<String> r1 = pool.submit(t1);
		System.out.print("Part (2/2): ");
		String w2 = input.nextLine();
		Translator t2 = new Translator(w2, 60);
		//String r2 = t2.call();
		Future<String> r2 = pool.submit(t2);
		String r = r1.get() + " AND " + r2.get();
		System.out.printf("Result = %s%n", r);
		pool.shutdown();
	}
}

