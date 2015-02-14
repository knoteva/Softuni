import java.util.Scanner;


public class _05_AngleUnitConverter {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = str.nextInt();
		str.nextLine();
		String input = str.nextLine();
		double result = 0;
		for (int i = 0; i < n; i++) {
			String[] data = input.split(" ");
			if (data[1].equals("deg")) {
			    result = Double.parseDouble(data[0]) * Math.PI / 180;
				System.out.printf("%.6f rad\n", result);
				input = str.nextLine();
			}
			else {
			    result = Double.parseDouble(data[0]) * 180 / Math.PI;
				System.out.printf("%.6f deg\n", result);
				input = str.nextLine();
			}
			
		}
	}
}
