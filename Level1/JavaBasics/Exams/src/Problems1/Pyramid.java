package Problems1;

import java.util.Arrays;
import java.util.Scanner;

public class Pyramid {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = str.nextInt();
	    str.nextLine();
	    int firstNumber = Integer.parseInt(str.nextLine().trim());
	    String output = "" + firstNumber;
	    
	    
		for (int i = 1; i < n; i++) {
			String nextLine = str.nextLine();
			String[] nextNums = nextLine.trim().split("[ ]+");
			int[] nums = new int[nextNums.length];
			for (int j = 0; j < nums.length; j++) {
				nums[j] = Integer.parseInt(nextNums[j]);
			}
			Arrays.sort(nums);
			boolean contains = true;
			for (int j = 0; j < nums.length; j++) {
				if (nums[j] > firstNumber) {
					firstNumber = nums[j];
					output += ", " + firstNumber;
					contains = false;
					break;
				}
			}
			if (contains) {
				firstNumber++;
			}
		}
		
		System.out.println(output);
	}
}
