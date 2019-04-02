import java.util.Arrays;
import java.util.Scanner;

public class Timespan {
	static Scanner input;
	public static void main(String[] args) {
		input = new Scanner(System.in);	
		
		long beginSeconds = makeTimeToSeconds();
		long endSeconds = makeTimeToSeconds();
		long timeLeft = beginSeconds - endSeconds;
		int seconds = (int)(timeLeft % 60);
		int minutues = (int)(timeLeft % 3600 / 60);
		int hours = (int)(timeLeft / 3600);
		System.out.printf("%d:%s:%s", 
				hours, 
				minutues < 10 ? "0" + minutues : "" + minutues, 
				seconds < 10 ? "0" + seconds : "" + seconds);		
	}
	
	public static long makeTimeToSeconds() {
		String[] splitedString = input.nextLine().split(":");
		return Long.parseLong(splitedString[2]) +
				(Long.parseLong(splitedString[1]) * 60) +
				(Long.parseLong(splitedString[0]) * 3600);
	}
}
