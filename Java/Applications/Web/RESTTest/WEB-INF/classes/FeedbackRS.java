package app;

import java.util.*;
import javax.ws.rs.*;
import javax.ws.rs.core.*;

@Path("/feedbacks")
public class FeedbackRS{

	private Document<Feedback> doc;

	public FeedbackRS(){
		doc = Document.open(Feedback.class, "feedbacks.xml");
	}

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public List<Feedback> readFeedbacks(){
		return doc;
	}

	@GET
	@Path("/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response readFeedback(@PathParam("id") String name){
		Feedback info = doc.find(entry -> entry.from.equals(name));
		if(info != null)
			return Response.ok(info).build();
		return Response.status(Response.Status.NOT_FOUND).build();
	}

	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public String writeFeedback(Feedback feedback){
		String result;
		Feedback info = doc.find(entry -> entry.from.equals(feedback.from));
		if(info == null){
			doc.add(feedback);
			result = "Accepted";
		}else{
			info.comment = feedback.comment;
			result = "Modified";
		}
		doc.save();
		return result;
	}
}

