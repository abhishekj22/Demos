import java.io.*;

class DataIOTest{
	
	public static void main(String[] args) throws Exception{
		if(args.length > 2){
			float price = Float.parseFloat(args[0]);
			short stock = Short.parseShort(args[1]);
			String name = args[2].toUpperCase();
			DataOutputStream target = new DataOutputStream(
				new FileOutputStream("product.dat"));
			target.writeFloat(price);
			target.writeShort(stock);
			target.writeUTF(name);
			target.close();
		}else{
			DataInputStream source = new DataInputStream(
				new FileInputStream("product.dat"));
			float price = source.readFloat();
			short stock = source.readShort();
			String name = source.readUTF();
			source.close();
			System.out.printf("%s %s %s%n", price, stock, name);
		}
	}
}

