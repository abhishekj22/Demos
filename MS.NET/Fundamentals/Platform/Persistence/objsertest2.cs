using HR;
using System;

[Serializable]
public class Office
{
	public Employee Manager {get; set;}
	
	public void Show()
	{
		Console.WriteLine("Credentials of Manager in app-domain<{0}> is {1}/{2}", AppDomain.CurrentDomain.Id, Manager.Code, Manager.Password);
	}
}

static class Program
{
	public static void Main()
	{
		Office myoffice = new Office();
		myoffice.Manager = new Employee{Code = "FIN1234", Password = "a1b2c3d4"};
		myoffice.Show();

		AppDomain second = AppDomain.CreateDomain("second");
		second.DoCallBack(myoffice.Show);
		AppDomain.Unload(second);
	}
}