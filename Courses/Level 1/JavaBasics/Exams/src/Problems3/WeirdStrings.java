package Problems3;

import java.util.Scanner;

public class WeirdStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		String input = str.nextLine().replaceAll("[\\/()| ]+", "");
		String[] words = input.split("[^A-Z, a-z]+");
		int[] weight = new int[words.length];
		for (int i = 0; i < words.length; i++) {
			weight[i] = getWeight(words[i]);
		}
		int sum = 0;
		String maxOne = "";
		String maxTwo = "";
		int maxSum = 0;
		
		for (int i = 0; i < weight.length - 1; i++) {
			sum = weight[i] + weight[i + 1];
			if (sum > maxSum) {
				maxOne = words[i];
				maxTwo = words[i + 1];
				maxSum = sum;
			}
		}
		System.out.println(maxOne);
		System.out.println(maxTwo);
	}
	public static int getWeight(String word) {
		int weight = 0;
		word = word.toLowerCase();

		for (int i = 0; i < word.length(); i++) {
			weight += Character.getNumericValue(word.charAt(i)) - 9;
		}
		return weight;
	}
}
