import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;


public class PossibleTriangles {

	public static void main(String[] args) {
		
		// Define the initials		
		Scanner str = new Scanner(System.in);
		String input = str.nextLine();
		ArrayList<String> trinagles = new ArrayList<>();
		
		//Read the lines and evaluate them
		while (!input.equals("End")) {
			String[] sides = input.split(" ");
			BigDecimal[] numSides = new BigDecimal[sides.length];
			
			for (int i = 0; i < numSides.length; i++) {
				numSides[i] = new BigDecimal(sides[i]);
			}
			
			//sorting the sides and comparing them
			Arrays.sort(numSides);
			BigDecimal a = numSides[0];
			BigDecimal b = numSides[1];
			BigDecimal c = numSides[2];
			
			if (a.add(b).compareTo(c) > 0) {
				trinagles.add(String.format("%.2f+%.2f>%.2f", a, b, c));
			}			
			input = str.nextLine();
		}
		
		//Printing out the result if any or No if not
		if (trinagles.size() > 0) {
			
			for (String string : trinagles) {
				System.out.println(string);
			}
			
		} else {
			System.out.println("No");
		}
	}
}
