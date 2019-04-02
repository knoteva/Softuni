package Problems1;

import java.util.Scanner;

public class StuckNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		int[] nums = new int[n];
		boolean match = false;
		for (int i = 0; i < n; i++) {
			nums[i] = str.nextInt();
		}
		for (int i1 = 0; i1 < nums.length; i1++) {
			for (int i2 = 0; i2 < nums.length; i2++) {
				for (int i3 = 0; i3 < nums.length; i3++) {
					for (int i4 = 0; i4 < nums.length; i4++) {
						int a = nums[i1];
						int b = nums[i2];
						int c = nums[i3];
						int d = nums[i4];	
						
						if (a != b && a != c && a != d && b != c && b != d && c != d ) {
							String right = "" + a + b;
							String left = "" + c + d;
							if (right.equals(left)) {
								System.out.println(a + "|" + b + "==" + c + "|" + d);
								match = true;
							}
						}
					}
				}
			}
		}
		if (!match) {
			System.out.println("No");
		}
	}

}
