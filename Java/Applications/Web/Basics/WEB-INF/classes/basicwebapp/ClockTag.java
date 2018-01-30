package basicwebapp;

import java.util.*;
import java.io.*;
import java.text.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class ClockTag implements SimpleTag{
	
	private JspContext context;
	private JspFragment body;
	private JspTag parent;

	private SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

	public void setFormat(String value){
		formatter.applyPattern(value);
	}

	public void setJspContext(JspContext ctx){
		context = ctx;
	}

	public void setJspBody(JspFragment fragment){
		body = fragment;
	}

	public void setParent(JspTag tag){
		parent = tag;
	}

	public JspTag getParent(){
		return parent;
	}

	public void doTag() throws JspException, IOException{
		JspWriter out = context.getOut();
		Date now = new Date();
		out.print(String.format("<span>%s</span>", formatter.format(now)));
	}
}

