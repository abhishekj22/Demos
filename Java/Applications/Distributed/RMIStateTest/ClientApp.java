import shopping.*;
import java.util.*;
import java.rmi.*;

class ClientApp{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		CartFactory service = (CartFactory)Naming.lookup(args[0]);
		Cart client = service.create();
		for(int i = 1;; ++i){
			System.out.printf("Item %d: ", i);
			String item = input.nextLine();
			if(item.length() == 0) break;
			System.out.printf("Adding %s to the cart...", item);
			try{
				client.addItem(item);
				System.out.println("succeeded.");
			}catch(IllegalArgumentException e){
				System.out.println("failed!");
			}
		}
		System.out.printf("Total payment: %.2f%n", client.checkout());
	}
}

