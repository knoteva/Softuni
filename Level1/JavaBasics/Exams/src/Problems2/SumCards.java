package Problems2;

import java.util.Scanner;

public class SumCards {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		String[] line = str.nextLine().split("[ SCHD]+");// [\dAJQD]+
		int sum = 0;

		for (int i = 0; i < line.length; i++) {
			switch (line[i]) {
			case "J":
				line[i] = "12";
				break;
			case "Q":
				line[i] = "13";
				break;
			case "K":
				line[i] = "14";
				break;
			case "A":
				line[i] = "15";
				break;
			default:
				break;
			}
		}	
		int equal = 1;
		for (int i = 0; i < line.length; i += equal) {
			int currentSum = 0;
			equal = 1;
			for (int j = i + 1; j < line.length; j++) {
				if (line[i].equals(line[j])) {
					equal++;
				} else {
					break;
				}
			}
			currentSum = Integer.parseInt(line[i]) * equal;
			if (equal != 1) {
				currentSum *= 2;
			}
			sum += currentSum;
		}
		System.out.println(sum);
	}
}
