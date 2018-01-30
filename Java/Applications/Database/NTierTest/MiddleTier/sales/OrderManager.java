package sales;

import java.sql.*;
import javax.sql.*;
import javax.naming.*;
import javax.jws.*;

@WebService
public class OrderManager{
	
	@WebMethod
	public int placeOrder(String customerId, int productNo, int quantity){
		try{
			Context naming = new InitialContext();
			DataSource pool = (DataSource)naming.lookup("jdbc/SalesDB");
			Connection con = pool.getConnection();
			con.setAutoCommit(false);
			try{
				Date today = new Date(System.currentTimeMillis());
				Statement stmt = con.createStatement();
				stmt.executeUpdate("update counters set cur_val=cur_val+1 where ctr_name='orders'");
				ResultSet rs = stmt.executeQuery("select cur_val+1000 from counters where ctr_name='orders'");
				rs.next();
				int orderNo = rs.getInt(1);
				rs.close();
				stmt.close();
				PreparedStatement pstmt = con.prepareStatement("insert into orders values(?, ?, ?, ?, ?)");
				pstmt.setInt(1, orderNo);
				pstmt.setDate(2, today);
				pstmt.setString(3, customerId);
				pstmt.setInt(4, productNo);
				pstmt.setInt(5, quantity);
				pstmt.executeUpdate();
				pstmt.close();
				con.commit();
				return orderNo;
			}catch(SQLException e){
				con.rollback();
				throw e;
			}finally{
				con.close();
			}
		}catch(Exception e){
			throw new RuntimeException(e);
		}
	}
}

