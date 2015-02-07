package Problems3;

import java.math.BigDecimal;
import java.util.Scanner;

public class SimpleExpression {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		String input = str.nextLine().replaceAll("[ ]", "");
		String[] signs = input.split("[\\d.]+");
		String[] num = input.split("[+-]");
		BigDecimal sum = new BigDecimal((num[0])); 
		
		for (int i = 1; i < num.length; i++) {
			if (signs[i].equals("+")) {
				sum = sum.add(new BigDecimal("" + num[i]));
			}
			else {
				sum = sum.subtract(new BigDecimal("" + num[i]));
			}
		}
		System.out.println(sum);
	}
}
