package EdxJavaHomeWork;

public class StringOperations {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		// a)
        String s = "Ning Zhang";
        System.out.println(s);
        
        // b)
        String first = "A";
        String last = "Z";
        s = first + s.substring(1, s.length() - 1) + last;
        System.out.println(s);
        
        // c) 
        String url = "www.gatech.edu";
        System.out.println(url);
        
        // d)        
        
        String name = url.substring(url.indexOf('.') + 1, url.indexOf('.') + url.substring(url.indexOf('.') + 1).indexOf('.') + 1) + 1331;
        System.out.println(name);
	}

}
