package Problems2;

import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;

public class ThreeLargestNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		BigDecimal[] nums = new BigDecimal[n];

		for (int i = 0; i < nums.length; i++) {
			nums[i] = new BigDecimal(str.nextLine());
		}
		Arrays.sort(nums);
		

		if (n == 1) {
			System.out.println(nums[0]);
		} else if (n == 2) {
			System.out.println(nums[1] + "\n" + nums[0]);
		} else {
			System.out.printf("%s%n%s%n%s",
					nums[nums.length - 1].toPlainString(),
					nums[nums.length - 2].toPlainString(),
					nums[nums.length - 3].toPlainString());

		}
	}
}
