using System;
using System.Reflection;
using System.Dynamic;

class EchoProxy : DynamicObject
{
	private object target;

	internal EchoProxy(object original)
	{
		target = original;
	}

	public override bool TryInvokeMember(InvokeMemberBinder method, object[] arguments, out object result)
	{
		Type t = target.GetType();
		Console.WriteLine(">> Invoking {0}.{1}", t.Name, method.Name);
		
		try
		{
			result = t.InvokeMember(method.Name, BindingFlags.InvokeMethod, null, target, arguments);
			return true;
		}
		catch(MissingMethodException)
		{
			result = null;
			return false;
		}
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		Type t = Type.GetType(args[0], true);
		object og = Activator.CreateInstance(t);
		dynamic g = new EchoProxy(og); // Compiler will generate DLR bindings (no type checking) for g

		Console.WriteLine(g.Meet("Jack"));
		Console.WriteLine(g.Leave("Jack"));
		if(args.Length > 1) g.Kill(args[1]);
	}
}