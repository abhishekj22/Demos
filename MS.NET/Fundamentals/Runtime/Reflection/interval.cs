using System;

partial class Interval
{
	private int min, sec;

	partial void OnInitialize();

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
		OnInitialize();
	}

	public int Minutes => min;

	public int Seconds => sec;

	public int GetTime() => 60 * min + sec;
	
	public override string ToString()
	{
		return $"{min}:{sec:00}"; //string.Format("{0}:{1:00}", min, sec)
	}

	public override int GetHashCode()
	{
		return 1000 * GetTime();
	}

	public override bool Equals(object other)
	{
		if(other is Interval that)
			return (this.min == that.min) && (this.sec == that.sec);
		
		return false;
	}
		
}
