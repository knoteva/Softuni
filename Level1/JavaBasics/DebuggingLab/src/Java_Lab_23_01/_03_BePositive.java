package Java_Lab_23_01;

import java.util.ArrayList;
import java.util.Scanner;

public class _03_BePositive {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int countSequences = scn.nextInt();
		//
		
		for (int i = 0; i < countSequences; i++) {
			scn.nextLine();
			String[] input = scn.nextLine().trim().split("[ ]+");
			int[] nums = new int[input.length];
			
			
			
			ArrayList<Integer> numbers = new ArrayList<>();
			
			for (int j = 0; j < input.length; j++) {
				if (!input[j].equals("") ) {
					int num = Integer.parseInt(input[i]);
					numbers.add(num);	
				}							
			}
			
			boolean found = false;
			
			for (int j = 0; j < numbers.size(); j++) {				
				int currentNum = numbers.get(j);
				
				if (currentNum > 0) {
					System.out.printf("%d%s", currentNum, j == numbers.size() - 1 ? " " : "\n");
					found = true;
				} else {
					currentNum += numbers.get(j + 1);					
					
					if (currentNum > 0) {
						System.out.printf("%d%s", currentNum, j == numbers.size() - 1 ? " " : "\n");
						found = true;
					}					
				}
			}
			
			if (!found) {
				System.out.println("(empty)");
			} 			
		}	
	}
}
