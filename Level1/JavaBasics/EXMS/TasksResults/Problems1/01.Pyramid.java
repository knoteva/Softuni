import java.util.Arrays;
import java.util.Scanner;

public class Pyramid {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		String firstLine = input.nextLine();

		int currentNumber = Integer.parseInt(firstLine.trim());
		String output = "" + currentNumber;

		for (int i = 1; i < n; i++) {
			String nextLine = input.nextLine();
			String[] numbersAsString = nextLine.trim().split("[ ]+");
			int[] numbers = new int[numbersAsString.length];
			for (int j = 0; j < numbersAsString.length; j++) {
				numbers[j] = Integer.parseInt(numbersAsString[j]);
			}

			Arrays.sort(numbers);
			boolean isBreak = false;
			for (int j = 0; j < numbersAsString.length; j++) {
				if (numbers[j] > currentNumber) {
					currentNumber = numbers[j];
					output += ", " + currentNumber;
					isBreak = true;
					break;
				}
			}

			if (!isBreak) {
				currentNumber++;
			}
		}

		System.out.print(output);
	}
}
