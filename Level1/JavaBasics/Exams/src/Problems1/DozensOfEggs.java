package Problems1;

import java.util.Scanner;

public class DozensOfEggs {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int eggs = 0;
		int dozens = 0;
		for (int i = 0; i < 7; i++) {
			String input = str.nextLine();
			String[] line = input.split(" ");
			if (line[1].contains("dozens")) {
				dozens += Integer.parseInt(line[0]);
				
				} else {
					eggs += Integer.parseInt(line[0]);
			}
		}
		while (eggs >= 12 ) {
			dozens += 1;
			eggs -=12;
			
		}
		System.out.println(dozens + " dozens + " + eggs + " eggs");
	}
}
