import hr.*;
import java.io.*;

class ObjSerTest{

	public static void main(String[] args) throws Exception{
		if(args.length > 0){
			Department dept = new Department();
			dept.setTitle(args[0]);
			dept.addEmployee(4, 43000);
			dept.addEmployee(3, 32000);
			dept.addEmployee(5, 54000);
			dept.addEmployee(2, 21000);
			dept.addEmployee(6, 65000);
			ObjectOutputStream target = new ObjectOutputStream(
				new FileOutputStream("dept.dat"));
			target.writeObject(dept);
			target.close();
		}else{
			ObjectInputStream source = new ObjectInputStream(
				new FileInputStream("dept.dat"));
			Department dept = (Department)source.readObject();
			source.close();
			System.out.printf("Employees of %s department%n", dept.getTitle());
			for(Employee emp : dept.getEmployees())
				System.out.println(emp);
		}
	}
}

