import java.io.*;

class TextIOTest{
	
	public static void main(String[] args) throws Exception{
		if(args.length > 2){
			float price = Float.parseFloat(args[0]);
			short stock = Short.parseShort(args[1]);
			String name = args[2].toUpperCase();
			PrintWriter target = new PrintWriter(
				new OutputStreamWriter(
				new FileOutputStream("product.txt")));
			target.println(price);
			target.println(stock);
			target.println(name);
			target.close();
		}else{
			BufferedReader source = new BufferedReader(
				new InputStreamReader(
				new FileInputStream("product.txt")));
			float price = Float.parseFloat(source.readLine());
			short stock = Short.parseShort(source.readLine());
			String name = source.readLine();
			source.close();
			System.out.printf("%s %s %s%n", price, stock, name);
		}
	}
}

