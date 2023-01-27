package EdxJavaHomeWork;

public class exam1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
//		String pos = "guard";
//		int val = (4 / 6) / 2 + pos.indexOf("pointguard");
//		System.out.println(val);
//		final int daysUntil2021 = 106;
//		int inTwoDays = daysUntil2021 - 2;
//		System.out.println(inTwoDays);
//		
//		int upNext = 1332;
//		switch (upNext) {
//		    case 1:
//		        upNext -= 1;
//		    case 3:
//		        upNext -= 2;
//		    case 13:
//		        upNext -= 3;
//		    case 1332:
//		        upNext++;
//		    case 1333:
//		        upNext--;
//		}
//		System.out.println(upNext);
//		
//		System.out.println(2 < 2 ? "<" : ":");
//		
//		System.out.println(-24 % -6);
		
		String first = "1";
		String second = "2";
		int third = 1;
		System.out.println(first + second + third);
		
		int x = 100; 
		if (x > 0) 
		    System.out.println("launch"); 
		else if (x >= 100) 
		    System.out.println("lift off"); 
		else 
		  System.out.println("float");
		
		System.out.println(false || "jackets".equals("Jackets"));
		
		String funnyStr = "south, long island";
		funnyStr.replace("!"," ");
		funnyStr.replace("the beach","");
		funnyStr.replace(", long", "");
		funnyStr.replace("wal","roc");
		funnyStr.toUpperCase();
		System.out.println(funnyStr);
		
		
		
	}

	String[][] board = new String[8][8];
	public static boolean stillRed(String[][] board) {
	    for (int r = 0; r < 8; r++) {
	        for (int c = 0; c < 8; c++) {
	            if (board[r][c] != null && board[r][c].equals("red")) {
	                return true;
	            }
	        }
	    }
	    return false;
	}
	
}
