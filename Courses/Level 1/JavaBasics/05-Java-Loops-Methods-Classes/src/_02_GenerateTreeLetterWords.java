import java.util.Scanner;

public class _02_GenerateTreeLetterWords {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		String letters = str.nextLine();

		for (int i = 0; i < letters.length(); i++) {
			for (int j = 0; j < letters.length(); j++) {
				for (int k = 0; k < letters.length(); k++) {
					System.out.printf("" + letters.charAt(i)
							+ letters.charAt(j) + letters.charAt(k) + " ");
				}
			}
		}
	}
}
