import edu.met.banking.*;

class InterfaceTest1{

	private static void payAnnualInterest(Account[] accounts){
		for(Account acc : accounts){
			if(acc instanceof Profitable){
				Profitable p = (Profitable)acc;
				double amt = p.getInterest(1);
				acc.deposit(amt);
			}
		}
	}

	public static void main(String[] args){
		Account[] bank = new Account[4];
		bank[0] = Banker.openCurrentAccount();
		bank[0].deposit(10000);
		bank[1] = Banker.openSavingsAccount();
		bank[1].deposit(15000);
		bank[2] = Banker.openSavingsAccount();
		bank[2].deposit(25000);
		bank[3] = Banker.openCurrentAccount();
		bank[3].deposit(40000);
		payAnnualInterest(bank);
		for(Account acc : bank)
			System.out.printf("%d\t%.2f%n", acc.getId(), acc.getBalance());
	}
}


