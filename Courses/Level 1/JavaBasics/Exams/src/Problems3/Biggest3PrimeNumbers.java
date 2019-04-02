package Problems3;

import java.util.Arrays;
import java.util.Scanner;

public class Biggest3PrimeNumbers {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String inputLine = scanner.nextLine();
		String[] numbers = inputLine.split("[ ()]+");
		Integer[] nums = new Integer[numbers.length - 1];
		for (int i = 0; i < numbers.length - 1; i++) {
			nums[i] = Integer.parseInt(numbers[i + 1]);
		}
		Arrays.sort(nums);
		int sum1 = 0;
		int count = 0;
		int sum2 = 0;
		int sum = 0;
		for (int i = nums.length - 1; i >= 0; i--) {
			if (isPrime(nums[i]) ) {
				sum1 = nums[i];
				count++;
				break;
			}
		}
		for (int i = nums.length - 1; i >= 0; i--) {
			if (isPrime(nums[i]) && nums[i] != sum1) {
				sum2= nums[i];
				count++;
				break;
			}
		}
		for (int i = nums.length - 1; i >= 0; i--) {
			if (isPrime(nums[i]) && nums[i] != sum1 && nums[i] != sum2) {
				sum = sum1 + sum2 + nums[i];
				count++;
				break;
			}
		}
		
		
		if (count == 3) {
			System.out.println(sum);
		}else {
			System.out.println("No");
		}

//		@SuppressWarnings("resource")
//		Scanner str = new Scanner(System.in);
//		String inputLine = str.nextLine();
//		String[] numbers = inputLine.split("[ ()]+");
//		TreeSet<Integer> numberSet = new TreeSet<>(Collections.reverseOrder());
//		
//		for (int i = 1; i < numbers.length; i++) {
//			if ( isPrime(Integer.parseInt(numbers[i]))) {
//				int number = Integer.parseInt(numbers[i]);
//				numberSet.add(number);
//			}
//		}
//
//		int count = 0;
//		int sum = 0;
//		for (Integer possiblePrime : numberSet) {
//			if (count == 3) {
//				break;
//			}
//			sum += possiblePrime;
//			count++;
//		}
//
//		if (count == 3) {
//			System.out.println(sum);
//		} else {
//			System.out.println("No");
//		}
	}

	private static boolean isPrime(int number) {
		if (number == 2) {
			return true;
		}
		else if (number <= 1) {
			return false;
		} else if (number % 2 == 0)
			return false;
		for (int i = 3; i * i <= number; i += 2) {
			if (number % i == 0)
				return false;
		}
		return true;
	}
}
