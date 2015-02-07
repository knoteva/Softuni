import java.util.Scanner;


public class MirrorNumbers2 {

	public static void main(String[] args) {
		
		// Read the input sequence of n integers		
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		int[] numbers = new int[n];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = str.nextInt();
		}
		
		// Find and print all mirror numbers {a<!>b}
		boolean validMatch = false;
		for (int i = 0; i < numbers.length; i++) {
			for (int j = i + 1; j < numbers.length; j++) {
				String a = Integer.toString(numbers[i]);
				String b = Integer.toString(numbers[j]);
				
				if (a.charAt(0) == b.charAt(3) && a.charAt(1) == b.charAt(2) &&
						a.charAt(2) == b.charAt(1) && a.charAt(3) == b.charAt(0)) {
					System.out.printf("%s<!>%s%n", a, b);
					validMatch = true;
				}
			}
		}
		
		if (!validMatch) {
			System.out.println("No");
		}
		
		
	}
}
