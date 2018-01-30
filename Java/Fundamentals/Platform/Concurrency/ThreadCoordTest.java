class ThreadCoordTest{

	private static volatile int value = 0;
	private static Object coordinator = new Object();

	private static void consume() throws InterruptedException{
		System.out.printf("Consumer<%d> ready...%n", Thread.currentThread().getId());
		//while(value == 0) Thread.yield();
		synchronized(coordinator){
			coordinator.wait();
			System.out.printf("Processed value = %d%n", value * value);
		}
	}

	private static void produce(){
		System.out.printf("Producer<%d> ready...%n", Thread.currentThread().getId());
		int result = Worker.doWork();
		synchronized(coordinator){
			value = result;
			coordinator.notify();
		}
	}

	public static void main(String[] args) throws Exception{
		Thread child = new Thread(ThreadCoordTest::produce);
		child.start();
		consume();
	}
}












