import javax.xml.ws.*;

class ServerApp{

	public static void main(String[] args) throws Exception{
		System.setErr(null); // disable exception logging
		Endpoint.publish("http://localhost:8031/shopping/customerws", new shopping.CustomerWS());
	}
}

