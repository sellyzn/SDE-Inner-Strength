package HW06;

public class Dog extends Pet {
	private double droolRate;
	public Dog(String name, double health, int painLevel, double droolRate) {
		super(name, health, painLevel);
		this.droolRate = droolRate;
	}
	
	public Dog(String name, double health, int painLevel) {
		this(name, health, painLevel, 5.0);
	}

	public double getDroolRate() {
		return droolRate;
	}

	public int treat() {
		int treatmentTime;
		if(droolRate < 3.5) {
			treatmentTime = (int)Math.ceil((super.getPainLevel() * 2) / super.getHealth());
		}else if(droolRate <= 7.5) {
			treatmentTime = (int)Math.ceil(super.getPainLevel() / super.getHealth());
		}else {
			treatmentTime = (int)Math.ceil(super.getPainLevel() / (super.getHealth() * 2));
		}
		super.heal();
		return treatmentTime;
	}
	
	public void speak() {
		super.speak();
		String sound = (super.getPainLevel() > 5) ? "BARK" : "bark";
		String output = "";
		for(int i = 1; i <= super.getPainLevel(); i++) {
			output += sound + " ";
		}
		System.out.println(output.trim());
	}
	
	public boolean equals(Object o) {
		return super.equals(o) && ((Dog) o).droolRate == droolRate;
	}
	
}
