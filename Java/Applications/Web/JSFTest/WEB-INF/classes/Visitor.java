package app;

import java.util.*;

public class Visitor{
	
	String name;
	int frequency;
	Date recent;

	public Visitor(){
		frequency = 1;
		recent = new Date();
	}

	Visitor(String id){
		this();
		name = id;
	}

	public final String getName(){return name;}
	public final void setName(String value){name = value;}

	public final int getFrequency(){return frequency;}
	public final void setFrequency(int value){frequency = value;}

	public final Date getRecent(){return recent;}
	public final void setRecent(Date value){recent = value;}

	public void revisit(){
		frequency += 1;
		recent = new Date();
	}
}

