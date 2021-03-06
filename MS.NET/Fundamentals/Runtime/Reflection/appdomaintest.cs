using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

static class Program
{
	public static void Main()
	{
		AppDomainSetup setup = new AppDomainSetup();
		setup.ApplicationBase = "commands";

		PermissionSet policy = new PermissionSet(PermissionState.None);
		policy.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
		policy.AddPermission(new UIPermission(PermissionState.Unrestricted));

		for(;;)
		{
			Console.Write("COMMAND: ");
			string cmd = Console.ReadLine();
			if(cmd == "") continue;
			if(cmd == "quit") break;

			AppDomain sandbox = AppDomain.CreateDomain(cmd, null, setup, policy);			
			try
			{
				sandbox.ExecuteAssemblyByName(cmd);			
			}
			catch(Exception ex)
			{
				Console.WriteLine("ERROR: {0}", ex.Message);
			}
			AppDomain.Unload(sandbox);

			Console.WriteLine();
			
		}
	}
}