package Problems1;

import java.util.Scanner;

public class Timespan {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scr = new Scanner(System.in);
		String[] firstTime = scr.nextLine().split(":");
		String[] secondTime = scr.nextLine().split(":");
		long firstSeconds = Long.parseLong(firstTime[2])
				+ Long.parseLong(firstTime[1]) * 60
				+ Long.parseLong(firstTime[0]) * 3600;
		long secondSeconds = Long.parseLong(secondTime[2])
				+ Long.parseLong(secondTime[1]) * 60
				+ Long.parseLong(secondTime[0]) * 3600;
		long allSeconds = Math.abs(firstSeconds - secondSeconds);
		System.out.printf("%d:%02d:%02d", allSeconds / 3600, allSeconds / 60 % 60, allSeconds % 60);
		System.out.println(1000000 * 3600);
	}
}
