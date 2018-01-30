using System;

enum RoomType {Economy, Business, Executive, Deluxe}

struct HotelRoom
{
	public int Number;
	
	public bool Taken;

	public RoomType Category;

	public void Print()
	{
		Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, Taken ? "Occupied" : "Available");
	}

}

static class Program 
{
	private static int count;

	private static bool OpenBusinessRoom(out HotelRoom room) 
	{
		room.Number = ++count + 500;
		room.Taken = false;
		room.Category = RoomType.Business;

		return count <= 10;	
	}
	
	private static void Checkin(ref HotelRoom room)
	{
		if(room.Taken)
			throw new ApplicationException("Room is occupied");
		
		room.Taken = true;
	}
	
	public static void Main()
	{
		HotelRoom myroom;
		if(OpenBusinessRoom(out myroom))
		{	
			myroom.Print();
			Console.WriteLine("Checking into room {0}...", myroom.Number);
			Checkin(ref myroom);
			myroom.Print();
		}
	}
}