import java.util.Scanner;


public class _08_CountOfEqualBitPairs {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = str.nextInt();
		String bin = Integer.toBinaryString(n);
		int equal = 0;
		for (int i = 0; i < bin.length() - 1; i++) {
			if (bin.charAt(i) == bin.charAt(i + 1))
				equal++;
		}
		System.out.println(equal);
	}
}
