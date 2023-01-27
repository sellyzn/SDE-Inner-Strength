package EdxJavaHomeWork;
import java.util.Scanner;

public class Calculator {

	public static void main(String[] args) {		
		Scanner input = new Scanner(System.in);
        String errorMessage = "Invalid input entered. Terminating...";
        System.out.println("List of operations: add subtract multiply divide alphabetize");       
        System.out.println("Enter an operation:");
        String operation = input.next();
        switch(operation.toLowerCase()){
            case "add":
                System.out.println("Enter two integers:");
                if(input.hasNextInt()){
                    int int1 = input.nextInt();
                    if(input.hasNextInt()){
                        int int2 = input.nextInt();
                        System.out.println("Answer: " + (int1 + int2));
                    }else{
                        System.out.println(errorMessage);
                    }
                }else{
                    System.out.println(errorMessage);
                }
                break;
            case "subtract":
                System.out.println("Enter two integers:");
                if(input.hasNextInt()){
                    int int1 = input.nextInt();
                    if(input.hasNextInt()){
                        int int2 = input.nextInt();
                        System.out.println("Answer: " + (int1 - int2));
                    }else{
                        System.out.println(errorMessage);
                    }
                }else{
                    System.out.println(errorMessage);
                }
                break;
            case "multiply":
                System.out.println("Enter two doubles:");
                if(input.hasNextDouble()){
                    double double1 = input.nextDouble();
                    if(input.hasNextDouble()){
                        double double2 = input.nextDouble();
                        System.out.printf("Answer: %.2f\n", double1 * double2);
                    }else{
                        System.out.println(errorMessage);
                    }
                }else{
                    System.out.println(errorMessage);
                }
                break;
            case "divide":
                System.out.println("Enter two doubles:");
                if(input.hasNextDouble()){
                    double double1 = input.nextDouble();
                    if(input.hasNextDouble()){
                        double double2 = input.nextDouble();
                        if(double2 != 0){
                            System.out.printf("Answer: %.2f\n", double1 / double2);
                        }else{
                            System.out.println(errorMessage);
                        }
                        
                    }else{
                        System.out.println(errorMessage);
                    }
                }else{
                    System.out.println(errorMessage);
                }
                break;
            case "alphabetize":
                System.out.println("Enter two words:");
                if(input.hasNext()){
                    String word1 = input.next();
                    if(input.hasNext()){
                        String word2 = input.next();
                        int res = word1.toLowerCase().compareTo(word2.toLowerCase());
                        if(res > 0){
                            System.out.println("Answer: " + word2 + " comes before " + word1 + " alphabetically.");
                        }else if(res < 0){
                            System.out.println("Answer: " + word1 + " comes before " + word2 + " alphabetically.");
                        }else{
                            System.out.println("Answer: Chicken or Egg.");
                        }
                    }else{
                        System.out.println(errorMessage);
                    }
                }else{
                    System.out.println(errorMessage);
                }                
                break;
            default:
                System.out.println(errorMessage);
                break;            
        }        
	}
	
}
