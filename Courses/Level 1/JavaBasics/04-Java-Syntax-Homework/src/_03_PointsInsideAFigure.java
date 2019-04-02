import java.util.Locale;
import java.util.Scanner;

public class _03_PointsInsideAFigure {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		float a = input.useLocale(Locale.US).nextFloat();
		float b = input.useLocale(Locale.US).nextFloat();
		if ((a >= 12.5 && a <= 22.5 && b >= 6 && b <= 8.5)
				|| (a >= 12.5 && a <= 17.5 && b >= 8.5 && b <= 13.5)
				|| (a >= 20 && a <= 22.5 && b >= 8.5 && b <= 13.5)) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}
}
