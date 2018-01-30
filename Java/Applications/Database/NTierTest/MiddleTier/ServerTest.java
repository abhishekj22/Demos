import sales.client.*;

interface ServerTest{

	public static void main(String[] args) throws Exception{
		String customerId = args[0].toUpperCase();
		int productNo = Integer.parseInt(args[1]);
		int quantity = Integer.parseInt(args[2]);
		OrderManagerService service = new OrderManagerService();
		OrderManager client = service.getOrderManagerPort();
		try{
			int orderNo = client.placeOrder(customerId, productNo, quantity);
			System.out.printf("New Order Number: %s%n", orderNo);
		}catch(Exception e){
			System.out.println("Order Failed!");
		}
	}
}

