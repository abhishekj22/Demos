import shopping.client.*;
import java.util.*;

public class ClientApp{

	public static void main(String[] args) throws Exception{
		CustomerService service = new CustomerService();
		CustomerSupport client = service.getCustomerSoap();
		Scanner input = new Scanner(System.in);
		System.out.print("Item: ");
		String item = input.nextLine();
		int stock = client.inquire(item);
		if(stock == 0)
			System.out.println("Not available!");
		else{
			System.out.print("Quantity: ");
			int qty = input.nextInt();
			if(qty > stock)
				System.out.println("Not in stock!");
			else{
				Receipt receipt = client.purchase(item, qty);
				System.out.printf("Status is %d and Payment is %.2f%n", receipt.getStatus(), receipt.getPayment());
			}
		}
	}
}

