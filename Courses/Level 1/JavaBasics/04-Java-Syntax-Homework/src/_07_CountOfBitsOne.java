import java.util.Scanner;

public class _07_CountOfBitsOne {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = str.nextInt();
		System.out.println(Integer.bitCount(n));
		
		//another way
		
		//int count = 0;
		//String bin = Integer.toBinaryString(n);
		//for (int i = 0; i < bin.length(); i++) {
			//if (bin.charAt(i) == '1') {
				//count++;
			//}
		//}
		//System.out.println(count);
	}
}
