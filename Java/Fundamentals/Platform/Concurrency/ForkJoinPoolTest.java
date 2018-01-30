import java.util.concurrent.*;

class ForkJoinPoolTest{

	static class Computation extends RecursiveTask<Long>{
		
		private int low, high;

		Computation(int l, int h){
			low = l;
			high = h;
		}

		@Override
		public Long compute(){
			if(high - low > 5){
				int mid = (low + high) / 2;
				Computation left = new Computation(low, mid);
				Computation right = new Computation(mid + 1, high);
				right.fork();
				return left.compute() + right.join();
			}
			long sum = 0;
			for(int value = low; value <= high; ++value){
				System.out.printf("Processing value %d in worker-thread<%d>%n", value, Thread.currentThread().getId());
				Worker.doWork(value);
				sum += value * value;
			}
			return sum;
		}
	}
	public static void main(String[] args) throws Exception{
		ForkJoinPool pool = new ForkJoinPool();
		Computation c = new Computation(1, 20);
		long r = pool.invoke(c);
		System.out.printf("Result = %d%n", r);
	}
}

