package Problems2;

import java.math.BigInteger;
import java.util.Scanner;

public class Tribonacci {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		BigInteger a = BigInteger.valueOf(Integer.parseInt(input.nextLine()));
		BigInteger b = BigInteger.valueOf(Integer.parseInt(input.nextLine()));
		BigInteger c = BigInteger.valueOf(Integer.parseInt(input.nextLine()));
		int n = Integer.parseInt(input.nextLine());
		BigInteger d = BigInteger.valueOf(n);
		if (n == 1) {
			System.out.println(a);
		} else if (n == 2) {
			System.out.println(b);
		} else {
			for (int i = 4; i <= n; i++) {
				d = c.add(b).add(a);
				a = b;
				b = c;
				c = d;
			}
			System.out.println(c);
		}
	}
}
