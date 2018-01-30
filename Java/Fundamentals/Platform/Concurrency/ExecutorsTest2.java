import java.util.concurrent.*;

class ExecutorsTest2{

	static class Computation implements Callable<Long>{
		
		private int low, high;

		Computation(int l, int h){
			low = l;
			high = h;
		}

		public Long call(){
			long sum = 0;
			for(int value = low; value <= high; ++value){
				Worker.doWork(value);
				sum += value * value;
			}
			return sum;
		}
	}

	public static void main(String[] args) throws Exception{
		ExecutorService worker = Executors.newSingleThreadExecutor();
		System.out.print("Computing...");
		Computation c = new Computation(1, 20);
		//long r = c.call();
		Future<Long> job = worker.submit(c);
		while(!job.isDone()){
			System.out.print('.');
			Thread.sleep(500);
		}
		System.out.println("Done!");
		System.out.printf("Result = %d%n", job.get());
		worker.shutdown();
	}
}

