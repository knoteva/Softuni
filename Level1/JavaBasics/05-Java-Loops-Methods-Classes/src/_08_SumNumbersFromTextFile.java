import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Scanner;


public class _08_SumNumbersFromTextFile {
	public static void main(String[] args) {
		try (Scanner input = new Scanner(new FileReader("input.txt"))) {			
			int result = 0;
			while (input.hasNextInt()) {
				result += input.nextInt();
			}
			System.out.println(result);
		}
    	 catch (FileNotFoundException e) {
				System.out.println("Error");
		} 
	     catch (Exception e) {
				System.out.println("Error");
		}
	}
}
