package EdxJavaHomeWork;
import java.util.Random;
public class Exam2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Random random = new Random();
        System.out.println(random.nextInt(8) + 3);
        
	}

	public static double add(int i, int j) {
	    return i+j;
	}
	public static String add(String i, double j) {
	    return i+j;
	}
}
