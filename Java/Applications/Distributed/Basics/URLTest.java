import java.util.*;
import java.io.*;
import java.net.*;

class URLTest{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		System.out.print("REQUEST : ");
		String symbol = input.nextLine();
		String addr = String.format("http://localhost/stock.php?symbol=%s", symbol);
		URL url = new URL(addr);
		InputStream in = url.openStream();
		BufferedReader reader = new BufferedReader(
			new InputStreamReader(in));
		System.out.printf("RESPONSE: %s%n", reader.readLine());
		reader.close();
	}
}

