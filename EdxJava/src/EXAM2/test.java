package EXAM2;

import EdxJavaHomeWork.ArrayList;

public class test {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
//		String[] nums = new String[5];
//		for (String num : nums) {
//		    System.out.println(num.toUpperCase());
//		}
		System.out.println(f(3,4));
		
	}
	public static int f(int x, int y) {
	    if (x == 0) {
	        return y;
	    } else {
	        return f(x - 1, y + 2);
	    }
	}
	
	public static void letsGetEven( ArrayList<Integer> nums ) {
	    for (int i = nums.size()-1; i >= 0; i--) {
	        if (nums.get(i) / 2 == 0) {
	            nums.delete(i);
	        }
	    }
	 }

}
