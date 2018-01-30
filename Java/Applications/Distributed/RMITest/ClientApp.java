import shopping.*;
import java.util.*;
import java.rmi.*;

class ClientApp{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		ShopKeeper client = (ShopKeeper)Naming.lookup("rmi://localhost/shopKeeper");
		System.out.print("Item: ");
		String i = input.nextLine();
		ItemInfo info = client.getItemInfo(i);
		if(info != null){
			System.out.print("Quantity: ");
			int q = input.nextInt();
			if(q > info.getCurrentStock())
				System.out.println("Out of stock!");
			else{
				float d = client.getBulkDiscount(q);
				System.out.printf("Total payment: %.2f%n", q * info.getUnitPrice() * (1 - d / 100));
			}
		}else{
			System.out.println("No such item!");
		}
	}
}

