package EdxJavaHomeWork;

public class Frog {
	// name - the name of this Frog, which can be made of any combination of characters
	private String name;
	// age - the age of the Frog as an integer number of months
	private int age;
	// tongueSpeed - how quickly this Frog’s tongue can shoot out of its mouth, represented as a double
	private double tongueSpeed;
	// isFroglet - a value that represents if this Frog is young enough to be a froglet (the stage between tadpole and adult frog), which must only have two possible values - true or false. 
	// A Frog is a froglet if it is more than 1 month old but fewer than 7 months old. Whenever age is changed, this variable must be updated accordingly.
	private boolean isFroglet;
	// species - the name of the species of this Frog, which must be the same for all instances of Frog (Hint: there is a keyword you can use to accomplish this). 
	// By default, its value must be “Rare Pepe”.
	private static String species = "Rare Pepe";
	
	//A constructor that takes in name, age, and tongueSpeed and sets all variables appropriately.
	public Frog(String name, int age, double tongueSpeed) {		
		this(name);		
		this.age = age;
		this.tongueSpeed = tongueSpeed;
		if(this.age > 1 && this.age < 7) {
			isFroglet = true;
		}else {
			isFroglet = false;
		}
	}
	
	// A constructor that takes in name, ageInYears representing the age of the Frog in years as a double, and tongueSpeed and sets all variables appropriately.
	// When converting ageInYears to age (in an integer number of months), round down to the nearest month without using any method calls (Hint: Java can automatically do this for you with casting).
	public Frog(String name, double ageInYears) {	
		this(name);		
		this.age = (int)(ageInYears * 12);
		if(this.age > 1 && this.age < 7) {
			isFroglet = true;
		}else {
			isFroglet = false;
		}
	}
	
	// A constructor that takes in just a name.
	// By default, a Frog is 5 months old and has a tongueSpeed of 5.
	public Frog(String name) {		
		super();
		this.name = name;
		this.age = 5;
		this.tongueSpeed = 5;
		this.isFroglet = true;
	}
	
	/*
	grow - takes in a whole number parameter representing the number of months.
		* Then it ages the Frog by the given number of months and increases tongueSpeed by 1 for every month the Frog grows until it becomes 12 months old.
		* If the Frog is 30 months old or more, then decrease tongueSpeed by 1 for every month that it ages beyond 30 months.
		* You must not decrease tongueSpeed to less than 5.
		* Remember to update isFroglet accordingly
	*/
	public void grow(int months) {	
		int m = 1;
		while(m <= months) {
			if(age < 12) {				
				age++;
				tongueSpeed++;
			}else if(age >= 30) {
				age++;
				tongueSpeed--;
				if(tongueSpeed < 5) {
					tongueSpeed = 5;
				}
			}else {
				age++;
			}			
			m++;
		}
		
		if(age > 1 && age < 7) {
			isFroglet = true;
		}else {
			isFroglet = false;
		}
	}
	
	// grow - takes in no parameters and ages the Frog by one month and updates tongueSpeed accordingly as for the other grow method
	public void grow() {		
		grow(1);		
	}
	
	/*
	eat – takes in a parameter of a Fly to attempt to catch and eat.
		* Check if Fly is dead, and if it is dead then terminate the method.
		* The Fly is caught if tongueSpeed is greater than the speed of the Fly.
		* If the Fly is caught and the mass is at least 0.5 times the age of the Frog, the Frog ages by one month using the method grow. If the Fly is caught, the mass of the Fly must be set to 0.
		* If the Fly is NOT caught, the mass of the Fly must be increased by 1 while updating the speed of the Fly using only one Fly method.
	*/
	public void eat(Fly fly) {
		// If the fly is dead, return;
		if(fly.isDead()) {
			return;
		}
		// the fly is caught
		if(this.tongueSpeed > fly.getSpeed()) {
			if(fly.getMass() >= age * 0.5) {
				grow();
			}
			fly.setMass(0);
		}else { // the fly is not caught			
			fly.grow(1);
		}
	}

	// toString
	@Override
	public String toString() {
		String formatSpeed = String.format("%.2f", tongueSpeed);
		if(isFroglet) {
			return "My name is " + name + " and I’m a rare froglet! I’m " + age + " months old and my tongue has a speed of " + formatSpeed + ".";
		}else {
			return "My name is " + name + " and I’m a rare frog. I’m " + age + " months old and my tongue has a speed of " + formatSpeed + ".";
		}
	}

	// Setter and getter for species which must change the value for all instances of the class. 
	// Points will be deducted if you include an unnecessary or inappropriate setter/getter.
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getAge() {
		return age;
	}

	public void setAge(int age) {
		this.age = age;
	}

	public double getTongueSpeed() {
		return tongueSpeed;
	}

	public void setTongueSpeed(double tongueSpeed) {
		this.tongueSpeed = tongueSpeed;
	}

	public boolean isFroglet() {
		return isFroglet;
	}

	public void setFroglet(boolean isFroglet) {
		this.isFroglet = isFroglet;
	}

	public static String getSpecies() {
		return species;
	}

	public static void setSpecies(String species) {
		Frog.species = species;
	}

	

	
	
	
	
	
	
	
}
