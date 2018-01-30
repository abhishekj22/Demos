using System;

enum RoomType {Economy, Business, Executive, Deluxe}

// reference type
class HotelRoom
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
	private static void Checkin(HotelRoom room)
	{
		if(room != null)
		{
			if(room.Taken)
				throw new ApplicationException("Room is occupied");
		
			room.Taken = true;
		}
	}
	
	public static void Main()
	{
		HotelRoom myroom = new HotelRoom();
		myroom.Number = 503;
		myroom.Taken = false;
		myroom.Category = RoomType.Business;
	
		myroom.Print();
		Console.WriteLine("Checking into room {0}...", myroom.Number);
		Checkin(myroom);
		myroom.Print();

		Checkin(null);
	}
}