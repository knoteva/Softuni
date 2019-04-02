package Problems3;

import java.util.ArrayList;
import java.util.Scanner;

public class Largest3Rectangles {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		String[] enter = input.nextLine().replace('x', ' ').split("");
		ArrayList<Integer> areas = new ArrayList<Integer>();
		int max = 0;
		
		for (int i = 1; i < enter.length; i += 2) {
			int rect = Integer.parseInt(enter[i]) * Integer.parseInt(enter[i + 1]);
			areas.add(rect);
		}
		for (int i = 0; i < areas.size() - 2; i++) {
			int sum = areas.get(i) + areas.get(i + 1) + areas.get(i + 2);
			max = Math.max(max, sum);
		}
		
		System.out.println(max);
	}
}
