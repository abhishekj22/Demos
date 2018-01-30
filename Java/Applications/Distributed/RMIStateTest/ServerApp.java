import java.rmi.*;

class ServerApp{
	
	public static void main(String[] args) throws Exception{
		Naming.rebind("cartFactory", new shopping.CartFactoryImpl());
	}
}

