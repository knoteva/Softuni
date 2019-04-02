import java.util.Scanner;


public class _05_DecimalToHexadecimal {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int num = str.nextInt();
		//System.out.printf("%X", num);
		String hexNum = Integer.toHexString(num).toUpperCase();
		System.out.println(hexNum);
	}
}
