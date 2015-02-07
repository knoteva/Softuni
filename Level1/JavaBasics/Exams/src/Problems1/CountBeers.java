package Problems1;

import java.util.Scanner;

public class CountBeers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in); 
		String input = str.nextLine();
		int beer = 0;
		while (!input.equals("End")) {
			String[] beers = input.split(" ");
			if (beers[1].contains("stacks")) {
				beer += Integer.parseInt(beers[0]) * 20;
				input = str.nextLine();
			}else {
				beer += Integer.parseInt(beers[0]);
				input = str.nextLine();
			}						
		}
		System.out.println(beer / 20 + " stacks + " + beer % 20 + " beers");
	}
}
