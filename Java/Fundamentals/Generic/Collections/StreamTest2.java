import java.util.*;

class StreamTest2{

	static class Journey{
		
		private float distance = 500;
		private Interval duration;

		Journey(Interval i){
			duration = i;
		}

		public Interval getDuration(){
			return duration;
		}

		public float getSpeed(){
			return 3.6f * distance / duration.time();
		}
	}

	public static void main(String[] args){
		int limit = args.length > 0 ? Integer.parseInt(args[0]) : 0;
		List<Interval> store = new ArrayList<>();
		store.add(new Interval(5, 41));
		store.add(new Interval(3, 52));
		store.add(new Interval(6, 23));
		store.add(new Interval(7, 14));
		store.add(new Interval(4, 35));
		store.add(new Interval(2, 46));
		store.stream()
			 .filter(i -> i.time() > limit)
			 .sorted()
			 .map(Journey::new) // .map(i -> new Journey(i))
			 .forEach(j -> System.out.printf("%s\t%.1f%n", j.getDuration(), j.getSpeed()));
		Interval total = store.stream()
							  .filter(i -> i.time() > limit)
							  .reduce(Interval.ZERO, Interval::add);
		System.out.printf("Total Interval = %s%n", total);
	}
}

