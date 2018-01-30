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

unsafe static class Program 
{
	private static void Checkin(HotelRoom* room)
	{
		if(room->Taken)
			throw new ApplicationException("Room is occupied");
		
		room->Taken = true;
	}
	
	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? Convert.ToInt32(args[0]) : 10;
		//HotelRoom* myhotel = stackalloc HotelRoom[n];
		HotelRoom[] myhotel = new HotelRoom[n];

		for(int i = 0; i < n; ++i)
		{
			myhotel[i].Number = 501 + i;
			myhotel[i].Taken = false;
			myhotel[i].Category = RoomType.Business; 
		}
		
		myhotel[n - 1].Print();
		Console.WriteLine("Checking into room {0}", myhotel[n - 1].Number);
		//Checkin(&myhotel[n - 1]);
		fixed(HotelRoom* myroom = &myhotel[n - 1])
		{
			Checkin(myroom);
		}
		myhotel[n - 1].Print();
	}
}