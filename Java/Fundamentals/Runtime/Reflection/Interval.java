class Interval{

	private int minute, second;

	public Interval(int m, int s){
		minute = m + s / 60;
		second = s % 60;
	}

	public int minutes(){
		return minute;
	}

	public int seconds(){
		return second;
	}

	public int time(){
		return 60 * minute + second;
	}

	public String toString(){
		return String.format("%d:%02d", minute, second);
	}

	public int hashCode(){
		return 1000 * time();
	}

	public boolean equals(Object other){
		if(other instanceof Interval){
			Interval that = (Interval)other;
			return (this.minute == that.minute) && (this.second == that.second);
		}
		return false;
	}
}


