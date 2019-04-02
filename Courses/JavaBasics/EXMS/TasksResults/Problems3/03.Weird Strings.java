import java.util.Scanner;


public class WeirdStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputString = input.nextLine();
		inputString = inputString.replaceAll("[\\/\\|\\(\\)\\s]+", "");
		String[] words = inputString.split("[^a-zA-Z]+");		

		int maxWeight = 0;		
		String[] longestTwoWords = new String[2];
		for (int i = 0; i < words.length-1; i++) {
			String currentCouple = (words[i] + words[i+1]).toLowerCase();
			int currentWeight = 0;
			for (int j = 0; j < currentCouple.length(); j++) {
				currentWeight += currentCouple.charAt(j) - ('a'-1);
			}
			
			if (currentWeight >= maxWeight) {
				maxWeight = currentWeight;
				longestTwoWords[0] = words[i];
				longestTwoWords[1] = words[i+1];
			}
		}
		
		for (String string : longestTwoWords) {
			System.out.println(string);
		}
	}

}
