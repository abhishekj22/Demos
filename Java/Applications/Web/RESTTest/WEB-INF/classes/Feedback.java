package app;

public class Feedback{

	String from;

	String comment;

	public Feedback(){}

	Feedback(String name, String text){
		from = name;
		comment = text;
	}

	public final String getFrom(){return from;}
	public final void setFrom(String value){from = value;}

	public final String getComment(){return comment;}
	public final void setComment(String value){comment = value;}

}

