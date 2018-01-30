namespace Greeting
{
	public class Greeter
	{
		private bool formal;

		public Greeter(bool f)
		{
			formal = f;
		}

		public string Greet(string someone)
		{
			if(formal)
				return "Hello " + someone;
			return "Hi " + someone;
		}
	}
}