package Problems3;

import java.util.Scanner;
//import java.util.regex.Matcher;
//import java.util.regex.Pattern;

public class LongestOddEvenSequence {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String inputLine = scanner.nextLine();

		// Pattern pat = Pattern.compile("\\d+");
		// Matcher match = pat.matcher(inputLine);
		// while (match.find()) {
		// int num = Integer.parseInt(match.group());
		// System.out.println();
		// }

		String[] numbers = inputLine.split("[ ()]+");
		Integer[] nums = new Integer[numbers.length - 1];

		for (int i = 0; i < numbers.length - 1; i++) {
			nums[i] = Integer.parseInt(numbers[i + 1]);
		}
		int max = 0;
		int sub = 1;
		boolean even = nums[0] % 2 == 0;
		for (int i = 1; i < nums.length; i++) {
			if (even) {
				if (Math.abs(nums[i] % 2) == 1 || nums[i] == 0) {
					sub++;
					even = !even;
				} else {
					max = Math.max(max, sub);
					sub = 1;
					even = nums[i] % 2 == 0;
				}
			} else {
				if (Math.abs(nums[i] % 2) == 0 || nums[i] == 0) {
					sub++;
					even = !even;
				} else {
					max = Math.max(max, sub);
					sub = 1;
					even = nums[i] % 2 == 0;
				}
			}
		}
		max = Math.max(max, sub);

		System.out.println(max);
	}
}
