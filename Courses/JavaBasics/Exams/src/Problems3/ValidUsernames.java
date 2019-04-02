package Problems3;

import java.util.ArrayList;
import java.util.Scanner;

public class ValidUsernames {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		String[] input = str.nextLine().split("[\\\\/() ]+");
		ArrayList<String> word = new ArrayList<String>();
		
		for (int i = 0; i < input.length; i++) {
			if (input[i].matches("[a-z, A-Z][a-z, A-Z, 0-9_]{2,24}")) {
				word.add(input[i]);
			}
		}
		int maxLengthSum = 0;
		String longestWord1 = "";	
		String longestWord2 = "";
		
		for (int i = 0; i < word.size() - 1; i++) {
			int sum = word.get(i).length() + word.get(i + 1).length();
			
			if (sum > maxLengthSum) {
				longestWord1 = word.get(i);
				longestWord2 = word.get(i + 1);
				maxLengthSum = sum;
			}
		}
		
		System.out.println(longestWord1);
		System.out.println(longestWord2);
	}
}

