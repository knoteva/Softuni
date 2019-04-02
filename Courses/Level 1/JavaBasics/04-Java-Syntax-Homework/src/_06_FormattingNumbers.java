import java.util.BitSet;
import java.util.Locale;
import java.util.Scanner;


@SuppressWarnings("unused")
public class _06_FormattingNumbers {
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT); 
		
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int a = str.nextInt();
		float b = str.nextFloat();
		float c = str.nextFloat();
		System.out.printf("|%-10X", a);
		System.out.printf(String.format("|%10s|", Integer.toBinaryString(a)).replace(" ", "0"));
		System.out.printf("%10.2f|", b);
		System.out.printf("%-10.3f|", c);
	}
}
