interface TaxPayer{
	
	double getAnnualIncome();

	default double getIncomeTax(int age){
		float rate = age < 60 ? 0.15f : 0.12f;
		double income = getAnnualIncome();
		return income > 120000 ? rate * (income - 120000) : 0;
	}
}

class Consultant extends payroll.Employee implements TaxPayer{
	
	public Consultant(int h, float r){
		super(h, r);
	}

	public double getAnnualIncome(){
		return 12 * super.getIncome() + 25000;
	}
}

class Dealer implements TaxPayer{
	
	private double sales;

	public Dealer(double s){
		sales = s;
	}

	public double getAnnualIncome(){
		return 0.15 * sales;
	}
}

class InterfaceTest2{

	public static void main(String[] args){
		TaxPayer jill = new Consultant(200, 105);
		TaxPayer jack = new Dealer(5800000);
		System.out.printf("Income tax of Jill the consultant: %.2f%n", jill.getIncomeTax(36));
		System.out.printf("Income tax of Jack the dealer    : %.2f%n", jack.getIncomeTax(63));
	}
}

