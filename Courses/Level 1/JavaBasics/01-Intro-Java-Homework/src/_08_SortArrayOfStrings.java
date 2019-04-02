import java.util.Arrays;
import java.util.Scanner;

public class _08_SortArrayOfStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		//int n = Integer.parseInt(input.nextLine());
		String[] towns = new String[n];
		for (int i = 0; i < n; i++) {
			towns[i] = input.nextLine();
		}
		Arrays.sort(towns);
		for (int i = 0; i < n; i++) {
			System.out.println(towns[i]);
		}
	}
}
	
