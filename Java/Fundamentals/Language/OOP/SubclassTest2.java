import payroll.*;

class SubclassTest2{
	
	private static double getAverageIncome(Employee[] group){
		double total = 0;
		for(Employee emp : group){
			total += emp.getIncome();
		}
		return total / group.length;
	}
	
	private static double getTotalSales(Employee[] group){
		double total = 0;
		for(Employee emp : group){
			if(emp instanceof SalesPerson){
				SalesPerson sp = (SalesPerson)emp; // explicit narrowing 
				total += sp.getSales();
			}
		}
		return total;
	}

	public static void main(String[] args){
		Employee[] dept = new Employee[5];
		dept[0] = new Employee(186, 52);
		dept[1] = new Employee(205, 105);
		dept[2] = new SalesPerson(175, 65, 55000); //implicit widening 
		dept[3] = new Employee(160, 110);
		dept[4] = new SalesPerson(195, 55, 45000);
		System.out.printf("Average income: %.2f%n", getAverageIncome(dept));
		System.out.printf("Total sales: %.2f%n", getTotalSales(dept));
	}
}


