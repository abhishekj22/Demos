using System;
using System.Linq;
using System.Xml.Linq;

static class Program
{
	public static void Main(string[] args)
	{
		int limit = args.Length > 0 ? int.Parse(args[0]) : 0;
		XElement source = XElement.Load("dept.xml");
		
		var selection = from e in source.Element("Employees").Elements("Employee")
				where (int)e.Element("Experience") > limit
				select new 
				{
					Id = (string)e.Attribute("Code"),
					Income = (double)e.Element("Salary")
				};

		foreach(var entry in selection)
			Console.WriteLine("{0}\t{1:0.00}", entry.Id, entry.Income);
	}
}