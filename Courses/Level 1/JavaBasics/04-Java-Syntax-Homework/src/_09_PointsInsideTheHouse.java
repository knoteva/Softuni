import java.util.Locale;
import java.util.Scanner;


public class _09_PointsInsideTheHouse {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		double a = str.useLocale(Locale.US).nextDouble();
		double b = str.useLocale(Locale.US).nextDouble();
		
		double aX = 12.5f;
        double aY = 8.5f;
        double bX = 22.5f;
        double bY = 8.5f;
        double cX = 17.5f;
        double cY = 3.5f;
        
        double ABC = Math.abs(aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY));
        double ABP = Math.abs(aX * (bY - b) + bX * (b - aY) + a* (aY - bY));
        double APC = Math.abs(aX * (b - cY) + a * (cY - aY) + cX * (aY - b));
        double PBC = Math.abs(a * (bY - cY) + bX * (cY - b) + cX * (b - bY));
        boolean inTriangle = ABC == ABP + APC + PBC;
        
		if ((a >= 12.5 && a <= 17.5 || a >= 20 && a <= 22.5) && b >= 8.5 && b <= 13.5 || inTriangle) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
	}
}
