using HR;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

static class Program
{
	public static void Main(string[] args)
	{
		BinaryFormatter serializer = new BinaryFormatter();
		
		if(args.Length > 0)
		{
			Department dept = new Department();
			dept.Title = args[0];
			dept.AddEmployee(4, 43000);
			dept.AddEmployee(5, 54000);
			dept.AddEmployee(2, 21000);
			dept.AddEmployee(3, 32000);
			dept.AddEmployee(6, 65000);
			Stream target = File.Create("dept.dat");
			serializer.Serialize(target, dept);
			target.Close();
		}
		else
		{
			Stream source = File.OpenRead("dept.dat");
			Department dept = (Department)serializer.Deserialize(source);
			source.Close();
			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(Employee emp in dept.Employees)
				Console.WriteLine(emp);
		}
	}
}