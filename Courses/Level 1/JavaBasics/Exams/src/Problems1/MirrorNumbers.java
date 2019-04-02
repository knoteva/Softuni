package Problems1;

import java.util.Scanner;

public class MirrorNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner str = new Scanner(System.in);
		int n = Integer.parseInt(str.nextLine());
		int[] nums = new int[n];
		int reverse = 0;
		boolean noMatch = true;
		
		for (int i = 0; i < n; i++) {
			nums[i] = str.nextInt();		
		}
		for (int i1 = 0; i1 < n; i1++) {
			for (int i2 = i1 + 1; i2 < n; i2++) {
				int a = nums[i1];
				
				int b = nums[i2];
				if (a != b) {
					 while( a != 0 )
				      {
				          reverse = reverse * 10;
				          reverse = reverse + a%10;
				          a = a/10;
				      }
					 a = nums[i1];
					 if (reverse == b) {
						System.out.printf(a + "<!>"+ b);
						System.out.println();
						noMatch = false;
					}
					 reverse = 0;
					 
				}
			}
		}
		if (noMatch) {
			System.out.println("No");
		}
	}

}
