enum RoomType{
	ECONOMY, BUSINESS, EXECUTIVE, DELUXE;	
}

class SwitchEnumTest{

	private static double getRent(int stay, RoomType room){
		float rate;
		switch(room){
			case ECONOMY:
				rate = 450;
				break;
			case BUSINESS:
				rate = 575;
				break;
			case EXECUTIVE:
				rate = 750;
				break;
			default:
				rate = 925;
		}
		return 1.06 * stay * rate;
	}

	public static void main(String[] args){
		System.out.printf("Payment for ECONOMY type room: %.2f%n", getRent(3, RoomType.ECONOMY));
		System.out.printf("Payment for BUSINESS type room: %.2f%n", getRent(3, RoomType.BUSINESS));
		System.out.printf("Payment for EXECUTIVE type room: %.2f%n", getRent(3, RoomType.EXECUTIVE));
		System.out.printf("Payment for DELUXE type room: %.2f%n", getRent(3, RoomType.DELUXE));
	}
}


