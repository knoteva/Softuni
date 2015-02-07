package Problems2;

import java.util.Scanner;

public class AddingAngles {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = str.nextInt();
		int[] nums = new int[n];
		boolean noMatch = true;
		for (int i = 0; i < nums.length; i++) {
			nums[i] = str.nextInt();
		}
		for (int i1 = 0; i1 < nums.length; i1++) {
			for (int i2 = i1 + 1; i2 < nums.length; i2++) {
				for (int i3 = i2 + 1; i3 < nums.length; i3++) {
					int sum = nums[i1] + nums[i2] + nums[i3];
					if (sum % 360 == 0) {
						noMatch = false;
						System.out.printf(nums[i1] + " + " + nums[i2] + " + " + nums[i3] + " = " + sum + " degrees" + "\n");
					}
				}
			}
		}
		if (noMatch) {
			System.out.println("No");
		}
	}
}
