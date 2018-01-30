import java.util.*;
import java.lang.reflect.*;
import java.net.*;
import java.security.*;

class SecurityTest{

	static class SandboxPolicy extends Policy{
		
		@Override
		public Permissions getPermissions(ProtectionDomain domain){
			Permissions granted = new Permissions();
			if(domain.getClassLoader() == ClassLoader.getSystemClassLoader())
				granted.add(new AllPermission());
			return granted;
		}
	}

	public static void main(String[] args) throws Exception{
		URL[] codebase = {new URL("file:./cmd-classes/")};
		Scanner input = new Scanner(System.in);
		Policy.setPolicy(new SandboxPolicy());
		System.setSecurityManager(new SecurityManager());
		for(;;){
			System.out.print("COMMAND: ");
			String cmd = input.nextLine();
			if(cmd.length() == 0) continue;
			if(cmd.equals("Quit")) break;
			try{
				ClassLoader loader = new URLClassLoader(codebase);
				Class<?> c = Class.forName("commands." + cmd, false, loader);
				Method m = c.getMethod("execute", String.class);
				m.invoke(null, "SecurityTest");
			}catch(Exception e){
				System.out.printf("ERROR: %s%n", e);
			}
			System.out.println();
		}
	}
}

