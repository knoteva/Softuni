package Problems2;

import java.util.Scanner;

public class PythagoreanNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		int[] nums = new int[n];
		boolean noMatch = true;
		for (int i = 0; i < nums.length; i++) {
			nums[i] = str.nextInt();
		}
		for (int i1 = 0; i1 < nums.length; i1++) {
			for (int i2 = 0; i2 < nums.length; i2++) {
				for (int i3 = 0; i3 < nums.length; i3++) {
					int a = nums[i1];
					int b = nums[i2];
					int c = nums[i3];
					if (a <= b) {
						if (a * a + b * b == c * c ) {
							noMatch = false;
							System.out.printf(a + "*" + a + " + " + b + "*" + b + " = " + c + "*" + c);
							System.out.println();
						}
					}
				}
			}
		}
		if (noMatch) {
			System.out.println("No");
		}
	}
}
