package shopping;

import javax.jws.*;

@WebService(name="CustomerSupport", serviceName="CustomerService", portName="CustomerSoap")
public class CustomerWS{

	@WebMethod(operationName="Inquire")
	public int getStock(String item){
		int id = Store.find(item);
		return id >= 0 ? Store.stockOf(id) : 0;
	}

	@WebMethod(operationName="Purchase")
	public OrderInfo processOrder(String item, int quantity){
		OrderInfo info = new OrderInfo();
		int id = Store.find(item);
		if(id >= 0 && quantity <= Store.stockOf(id)){
			info.code = (int)(1000000 + System.currentTimeMillis() % 1000000);
			info.amount = 1.06 * quantity * Store.priceOf(id);
		}
		return info;
	}
}

