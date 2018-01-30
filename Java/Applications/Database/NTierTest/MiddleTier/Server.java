import java.rmi.registry.*;
import javax.naming.*;
import javax.xml.ws.*;
import oracle.jdbc.pool.*;

class Server{
	
	public static void main(String[] args) throws Exception{
		OracleConnectionPoolDataSource pool = new OracleConnectionPoolDataSource();
		pool.setURL("jdbc:oracle:thin:@//localhost/xe");
		pool.setUser("scott");
		pool.setPassword("tiger");
		LocateRegistry.createRegistry(2099);
		System.setProperty("java.naming.factory.initial", "com.sun.jndi.rmi.registry.RegistryContextFactory");
		System.setProperty("java.naming.provider.url", "rmi://localhost:2099");
		Context naming = new InitialContext();
		naming.bind("jdbc/SalesDB", pool);
		System.setErr(new java.io.PrintStream("server.log"));
		Endpoint.publish("http://localhost:8032/sales/ordermanager", new sales.OrderManager());
	}
}


