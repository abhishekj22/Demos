class ThreadLocalTest{

	static class PrintItem{

		//private static String text;
		private static ThreadLocal<String> text = new ThreadLocal<>();

		public static void write(String value){
			//text = value;
			text.set(value);
		}

		public static String read(){
			//return text;
			return text.get();
		}
	}

	static class Printer{

		public static void print(int copies){
			for(int i = 1; i <= copies; ++i){
				System.out.printf("%d:%s from thread<%d>%n", i, PrintItem.read(), Thread.currentThread().getId());
				Worker.doWork(i);
			}
		}
	}

	public static void main(String[] args) throws Exception{
		Thread child = new Thread(() -> {
			PrintItem.write("monday");
			Printer.print(5);
		});
		child.start();
		PrintItem.write("sunday");
		Printer.print(5);
	}
}











