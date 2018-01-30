import java.util.*;
import java.net.*;

class DatagramSocketTest{
	
	public static void main(String[] args) throws Exception{
		Random rdm = new Random();
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		DatagramSocket publisher = new DatagramSocket();
		InetAddress addr = InetAddress.getByName("230.0.0.1"); // Class D address: 224-239.*.*.*
		for(;;){
			int i = rdm.nextInt(symbols.length);
			String text = String.format("%s : %.2f", symbols[i], 0.01 * (1000 + rdm.nextInt(9000)));
			DatagramPacket message = new DatagramPacket(text.getBytes(), text.length(), addr, 4032);
			publisher.send(message);
			Thread.sleep(10000);
		}
	}
}

