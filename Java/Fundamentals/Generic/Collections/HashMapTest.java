import java.util.*;

class HashMapTest{
	
	public static void main(String[] args){
		Map<String, Interval> store = new HashMap<>();
		store.put("monday", new Interval(5, 31));
		store.put("tuesday", new Interval(3, 42));
		store.put("wednesday", new Interval(7, 23));
		store.put("thursday", new Interval(6, 14));
		store.put("friday", new Interval(4, 55));
		store.put("tuesday", new Interval(2, 42));
		for(Map.Entry<String, Interval> e : store.entrySet())
			System.out.printf("%s ==> %s%n", e.getKey(), e.getValue());
		Scanner input = new Scanner(System.in);
		System.out.print("Key: ");
		String key = input.next();
		Interval val = store.get(key);
		if(val != null)
			System.out.printf("Value = %s%n", val);
		else
			System.out.println("Key not found!");
	}
}

