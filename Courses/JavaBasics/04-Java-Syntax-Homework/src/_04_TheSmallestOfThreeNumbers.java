import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;


public class _04_TheSmallestOfThreeNumbers {
		public static void main(String[] args) {
			
			Locale.setDefault(Locale.ROOT); 
			DecimalFormat format = new DecimalFormat();
		    format.setDecimalSeparatorAlwaysShown(false);
		        
			@SuppressWarnings("resource")
			Scanner str = new Scanner(System.in);
			double a = str.nextDouble();
			double b = str.nextDouble();
			double c = str.nextDouble();
			double smallest = Math.min(a, Math.min(b, c));
			System.out.printf(format.format(smallest));
		}
}
