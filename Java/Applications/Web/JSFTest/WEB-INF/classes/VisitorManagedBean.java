package app;

import java.util.*;
import javax.faces.bean.*;

@ManagedBean(name="visitorModel")
@RequestScoped
public class VisitorManagedBean{
	
	private Document<Visitor> store;

	public VisitorManagedBean(){
		store = Document.open(Visitor.class, "visitors.xml");
	}

	public Iterable<Visitor> getVisitors(){
		return store;
	}

	public String putVisitor(String id){
		Visitor visitor = store.find(entry -> entry.name.equals(id));
		if(visitor == null)
			store.add(new Visitor(id));
		else
			visitor.revisit();
		store.save();
		return "view";
	}
}

