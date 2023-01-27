package HW06;

public abstract class Pet {
	private String name;
	private double health;
	private int painLevel;
	
	public Pet(String name, double health, int painLevel) {
		this.name = name;
		if(health >= 1.0) {
			this.health = 1.0;
		}else if(health <= 0.0) {
			this.health = 0.0;
		}else {
			this.health = health;
		}
		if(painLevel >= 10) {
			this.painLevel = 10;
		}else if(painLevel <= 1) {
			this.painLevel = 1;
		}else {
			this.painLevel = painLevel;
		}
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public double getHealth() {
		return health;
	}

	public void setHealth(double health) {
		this.health = health;
	}

	public int getPainLevel() {
		return painLevel;
	}

	public void setPainLevel(int painLevel) {
		this.painLevel = painLevel;
	}
	
	public abstract int treat();
	
	public void speak() {
		if(painLevel > 5) {
			System.out.println(("Hello! My name is " + name).toUpperCase()); 
		}else {
			System.out.println("Hello! My name is " + name);
		}
	}
	
	protected void heal() {
		health = 1.0;
		painLevel = 1;
	}
	
	public boolean equals(Object o) {
		if(o == null) {
			return false;
		}
		if(!(o instanceof Pet)) {
			return false;
		}
		Pet p = (Pet)o;
		return p.getName().equals(name);
	}
	
	
}
