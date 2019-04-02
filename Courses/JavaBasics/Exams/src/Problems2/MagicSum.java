package Problems2;

import java.util.ArrayList;
import java.util.Scanner;

public class MagicSum {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		String num = str.nextLine();
		ArrayList<Integer> numbers = new ArrayList<Integer>();
		int maxresult = Integer.MIN_VALUE;
		
		String output = "";
		boolean noMatch = true;
		while (!num.equals("End")) {
			numbers.add(Integer.parseInt(num));
			num = str.nextLine();
		}
		for (int i1 = 0; i1 < numbers.size(); i1++) {
			for (int i2 = i1 + 1; i2 < numbers.size(); i2++) {
				for (int i3 = i2 + 1; i3 < numbers.size(); i3++) {
					int result = numbers.get(i1) + numbers.get(i2)
							+ numbers.get(i3);
					if (result % n == 0) {
						if (result > maxresult) {
							maxresult = result;
							output = String.format("(%d + %d + %d) %% %d = 0",
									numbers.get(i1), numbers.get(i2),
									numbers.get(i3), n);
							noMatch = false;
						}
					}
				}
			}

		}
		if (noMatch) {
			System.out.println("No");
		} else {
			System.out.println(output);
		}
	}

}
