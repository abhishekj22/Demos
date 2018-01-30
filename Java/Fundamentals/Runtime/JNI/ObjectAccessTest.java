class LegacyBox{
	
	private int length, breadth, height;

	LegacyBox(int l, int b, int h){
		length = l;
		breadth = b;
		height = h;
	}

	public native int getInnerVolume(int thickness);

	public boolean validate(int thickness){
		return (thickness < length / 2)
			&& (thickness < breadth / 2)
			&& (thickness < height / 2);
	}

	static{
		System.loadLibrary("lbox");
	}
}

class ObjectAccessTest{
	
	public static void main(String[] args) throws Exception{
		int l = Integer.parseInt(args[0]);
		int b = Integer.parseInt(args[1]);
		int h = Integer.parseInt(args[2]);
		int t = Integer.parseInt(args[3]);
		LegacyBox box = new LegacyBox(l, b, h);
		try{
			System.out.printf("Inner volume = %d%n", box.getInnerVolume(t));
		}catch(IllegalArgumentException e){
			System.out.println(e.getMessage());
		}
	}
}


