package HW06;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

public class Clinic {
	private File patientFile;
	private int day;
	
	public Clinic(File file) {
		patientFile = file;
		day = 1;
	}
	
	public Clinic(String fileName) {
		this(new File(fileName));
	}
	
	/**
	 * 
	 * @param f
	 * @return
	 * @throws FileNotFoundException
	 */
	public String nextDay(File f) throws FileNotFoundException {
		day++;
		String output = " ";
		
		Scanner fileScan = new Scanner(f);
		Scanner input = new Scanner(System.in);
		String line = null;
		while(fileScan.hasNextLine()) {
			line = fileScan.nextLine();
			String[] pInfo = line.split(",");
			String name = pInfo[0];
			String typeOfPet = pInfo[1];
			String stat = pInfo[2];
			String timeIn = pInfo[3];
			// contents: {name, species, stat, timeIn}
			
			if(!(typeOfPet.equals("Dog") || typeOfPet.equals("Cat"))) {
				throw new InvalidPetException();
			}
			
			System.out.printf("Consultation for %s the %s at %s.\n", name, typeOfPet, timeIn);
			
			double health = 0;
			int painLevel = 0;
			boolean validHealth = false;
			boolean validPain = false;
			while(!validHealth) {
				System.out.printf("What is the health of %s?\n", name);
				if(input.hasNextDouble()) {
					health = input.nextDouble();
					validHealth = true;
				}else {
					// discards the invalid input
					input.nextLine();
					System.out.println("Please enter a number:");
				}
			}
			
			while(!validPain) {
				System.out.printf("On a scale of 1 to 10 how much pain is %s in right now?\n", name);
				if(input.hasNextInt()) {
					painLevel = input.nextInt();
					validPain = true;
				}else {
					input.nextLine();
					System.out.println("Please enter a number:");
				}
			}
			
			// instance the appropriate pet object with new info
			Pet petPatient;
			switch(typeOfPet) {
			case "Dog":
				petPatient = new Dog(name, health, painLevel, Double.parseDouble(stat));
				break;
			case "Cat":
				petPatient = new Cat(name, health, painLevel, Integer.parseInt(stat));
				break;
			default:
				throw new InvalidPetException();
			}
			
			// correct it just in case a value that is too high or low was entered
			health = petPatient.getHealth();
			painLevel = petPatient.getPainLevel();
			petPatient.speak();
			int treatmentTime = petPatient.treat();
			String timeOut = addTime(timeIn, treatmentTime);
			output += String.format("%s, %s, %s, Day %d, %s, %s, %d\n", name, typeOfPet, stat, day, timeIn, timeOut, String.valueOf(health), painLevel);
			
		}
		fileScan.close();
		input.close();
		return output.trim();
	}
	public String nextDay(String fileName) throws FileNotFoundException{
		return nextDay(new File(fileName));
	}
	
	/**
	 * 
	 * @param patientInfo
	 * @return
	 */
	public boolean addToFile(String patientInfo) {
		Scanner fileScan = null;
		PrintWriter filePrint = null;
		String stringOutput = "";
		
		try{
			fileScan = new Scanner(patientFile);
			//
			boolean newPatient = true;
			int firstDelimiter = patientInfo.indexOf(",");
			String name = patientInfo.substring(0, firstDelimiter);
			
			while(fileScan.hasNextLine()) {
				String line = fileScan.nextLine();
				if(line.startsWith(name)) {
					newPatient = false;
					// 
					int currentDelim = firstDelimiter;
					for(int i = 2; i <= 3; i++) {
						// 
						int nextDelim = patientInfo.indexOf(",", currentDelim + 1);
						currentDelim = nextDelim;
					}
					// value of currentDelim is index of the third delimiter
					line += patientInfo.substring(currentDelim);
				}
				stringOutput += (line + "\n");
			}
			//
			if(newPatient) {
				stringOutput += patientInfo;
			}
			// we can't read and write the file at the same time, so we close the Scanner and open the PrintWriter
			fileScan.close();
			filePrint = new PrintWriter(patientFile);
			filePrint.print(stringOutput);
			return true;
		}catch(Exception e) {
			return false;
		}finally {
			if(fileScan != null)
				fileScan.close();
			if(filePrint != null)
				filePrint.close();
		}
	}
	
	/**
	 * 
	 * @param timeIn
	 * @param treatmentTime
	 * @return
	 */
	public static String addTime(String timeIn, int treatmentTime) {
		int hours = Integer.parseInt(timeIn.substring(0, 2));
		int minutes = Integer.parseInt(timeIn.substring(2));
		int hourOut = hours + (int)((minutes + treatmentTime) / 60);
		int minOut = (minutes + treatmentTime) % 60;
		
		String output = "";
		output += (hourOut < 10) ? ("0" + hourOut) : hourOut;
		output += (minOut < 10) ? ("0" + minOut) : minOut;
		return output;
	}
}
