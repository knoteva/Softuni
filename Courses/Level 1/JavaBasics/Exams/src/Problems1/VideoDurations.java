package Problems1;

import java.util.Scanner;

public class VideoDurations {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		String input = str.nextLine();
		int minutes = 0;
		//do {
			//String[] time = input.split(":"); 
			//minutes += Integer.parseInt(time[1]) + Integer.parseInt(time[0]) * 60 ;
			
		//} while (time[0].contains("End"));
		while (!input.contains("End")) {
			String[] time = input.split(":"); 
			
			minutes += Integer.parseInt(time[1]) + Integer.parseInt(time[0]) * 60 ;
			input = str.nextLine();
		}
		System.out.printf("%d:%02d", minutes / 60, minutes % 60);
		
	}
}
