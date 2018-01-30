package shopping;

import javax.xml.bind.annotation.*;

@XmlType(name="Receipt")
public class OrderInfo{

	int code;
	double amount;

	@XmlElement(name="Status")
	public int getCode(){return code;}
	public void setCode(int value){code = value;}

	@XmlElement(name="Payment")
	public double getAmount(){return amount;}
	public void setAmount(double value){amount = value;}
}

