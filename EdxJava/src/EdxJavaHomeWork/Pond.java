package EdxJavaHomeWork;

public class Pond {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		// create Frog objects:
		Frog frog1 = new Frog("Peepo");
		Frog frog2 = new Frog("Pepe", 10, 15);
		Frog frog3 = new Frog("Peepaw", 4.6);
		frog3.setTongueSpeed(5);
		Frog frog4 = new Frog("Leapfrog");
		
		// create Fly objects:
		Fly fly1 = new Fly(1, 3);
		Fly fly2 = new Fly(6);
		Fly fly3 = new Fly();
		
		// Operations:
		// 1. Set the species of any Frog to “1331 Frogs”		
		Frog.setSpecies("1331 Frogs");	
		
		// 2. Print out on a new line the description of the Frog named Peepo given by the toString method.
		System.out.println(frog1.toString());
		
		// 3. Have the Frog named Peepo attempt to eat the Fly with a mass of 6.
		frog1.eat(fly2);
		
		// 4. Print out on a new line the description of the Fly with a mass of 6 given by the toString method.		
		System.out.println(fly2.toString());
		
		// 5. Have the Frog named Peepo grow by 8 months.
		frog1.grow(8);
		
		// 6. Have the Frog named Peepo attempt to eat the Fly with a mass of 6.
		frog1.eat(fly2);
		
		// 7. Print out on a new line the description of the Fly with a mass of 6 given by the toString method.
		System.out.println(fly2.toString());
		
		// 8. Print out on a new line the description of the Frog named Peepo given by the toString method.
		System.out.println(frog1.toString());
		
		// 9. Print out on a new line the description of your own Frog given by the toString method.
		System.out.println(frog4.toString());
		
		// 10. Have the Frog named Peepaw grow by 4 months.
		frog3.grow(4);
		
		// 11. Print out on a new line the description of the Frog named Peepaw given by the toString method.
		System.out.println(frog3.toString());
		
		// 12. Print out on a new line the description of the Frog named Pepe given by the toString method.
		System.out.println(frog2.toString());
		
		Fly fly4 = new Fly(10, 50);
		fly4.grow(45);
		System.out.println(fly4.toString());
		
	}

}
