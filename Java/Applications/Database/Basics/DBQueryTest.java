import java.util.*;
import java.io.*;
import java.sql.*;

class DBQueryTest{

	public static void main(String[] args) throws Exception{
		Properties settings = new Properties();
		try(FileInputStream fin = new FileInputStream("db.properties")){
			settings.load(fin);
		}
		Class.forName(settings.getProperty("jdbc.driver"));
		Connection con = DriverManager.getConnection(settings.getProperty("jdbc.url"), settings.getProperty("jdbc.user"), settings.getProperty("jdbc.password"));
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery("select pno, price, stock from products");
		while(rs.next())
			System.out.printf("%d\t%.2f\t%d%n", rs.getInt(1), rs.getDouble(2), rs.getInt("stock"));
		rs.close();
		stmt.close();
		con.close();
	}
}

