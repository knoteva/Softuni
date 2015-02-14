import java.util.Scanner;

public class _01_SymmetricNumbersInRange {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int firstNum = str.nextInt();
		int endNum = str.nextInt();
		String allNum = "";
		String symmetric = "";
		for (int i = firstNum; i <= endNum; i++) {
			allNum = new Integer(i).toString();
			symmetric = allNum + " ";
			for (int j = 0; j < allNum.length(); j++) {
				if (allNum.charAt(j) != allNum.charAt(allNum.length() - 1 - j)) {
					symmetric = "";
				}
			}
			System.out.print(symmetric);
		}
	}
}
