package HW04;

public class Fly {
	// the mass of the Fly in grams (it must allow decimal values)
	private double mass;
	// how quickly this Fly can maneuver through the air while flying, represented as a double
	private double speed;		
	
	//Contructors:
	// A constructor that takes in mass and speed of a Fly.
	public Fly(double mass, double speed) {			
		this(mass);		
		this.speed = speed;
	}
	// A constructor that takes in only mass.By default, the Fly will have 10 speed.
	public Fly(double mass) {	
		this();
		this.mass = mass;		
	}
	// A constructor that takes in no parameters. By default, the Fly will have 5 mass and 10 speed.
	public Fly() {
		super();
		this.mass = 5;
		this.speed = 10;
	}
	
	// Setters and getters (using appropriately named methods) for all variables in Fly.java.
	public double getMass() {
		return mass;
	}
	public void setMass(double mass) {
		this.mass = mass;
	}
	public double getSpeed() {
		return speed;
	}
	public void setSpeed(double speed) {
		this.speed = speed;
	}
	
	// toString
	// takes in no parameters and returns a String describing the Fly as follows:
	// If mass is 0: “I’m dead, but I used to be a fly with a speed of [speed].”
	// Otherwise: “I’m a speedy fly with [speed] speed and [mass] mass.”
	@Override
	public String toString() {
		String formatSpeed = String.format("%.2f", speed);
		String formatMass = String.format("%.2f", mass);
		if(mass == 0) {
			return "I'm dead, but I used to be a fly with a speed of " + formatSpeed + ".";
		}else {
			return "I'm a speedy fly with " + formatSpeed + " speed and " + formatMass + " mass.";
		}
	}
	
	
	// grow - takes in an integer parameter representing the added mass. 
	// Then it increases the mass of the Fly by the given number of mass. As mass increases, speed changes as follows:
	// * If mass is less than 20: increases speed by 1 for every mass the Fly grows until it reaches 20 mass.
	// * If the mass is 20 or more: decreases speed by 0.5 for each mass unit added over 20.
	public void grow(int addedMass) {	
		double oldMass = mass;
		mass += addedMass;
		if(mass < 20) {			
			speed += addedMass;
		}else {
			if(oldMass < 20) {
				speed += (int)(20 - oldMass);
				addedMass -= (int)(20 - oldMass);
			}			
			double m = 1;
			while(m <= addedMass) {
				speed -= 0.5;
				m++;
			}			
		}		
	}
	
	// isDead – if mass is zero, return true. Otherwise, return false.
	public boolean isDead() {
		return mass == 0 ? true : false;
	}
	
}
