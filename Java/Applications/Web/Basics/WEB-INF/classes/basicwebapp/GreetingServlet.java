package basicwebapp;

import java.util.*;
import java.io.*;
import javax.servlet.*;

public class GreetingServlet implements Servlet{
	
	private ServletConfig config;

	public void init(ServletConfig cfg) throws ServletException{
		config = cfg;
		// perform other one-time initializations 
	}

	public ServletConfig getServletConfig(){
		return config;
	}

	public String getServletInfo(){
		return "basicwebapp.GreetingServlet";
	}

	public void service(ServletRequest request, ServletResponse response) throws IOException, ServletException{
		String name = request.getParameter("visitor");
		if(name == null) name = "";
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println("<html>");
		out.println("<head><title>BasicWebApp</title></head>");
		out.println("<body>");
		out.printf("<h1>Welcome Visitor %s</h1>%n", name);
		out.printf("<b>Time on server: </b>%s%n", new Date());
		out.println("</body>");
		out.println("</html>");
	}

	public void destroy(){
		// perform uninitialization
	}
}

