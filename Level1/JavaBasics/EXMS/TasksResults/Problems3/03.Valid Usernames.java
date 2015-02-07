import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class ValidUsernames {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputString = input.nextLine();
		String[] usernames = inputString.split("[\\s()/\\\\]+");
		ArrayList<String> validUserNames = new ArrayList<>();
		
		Pattern pattern = Pattern.compile("\\b[a-zA-Z][\\w_]{2,25}\\b");
		for (String str : usernames) {
			Matcher matcher = pattern.matcher(str);
			if (matcher.find()) {
				validUserNames.add(str);
			}
		}
		
		int maxLenght = 0;
		String[] longestTwoWords = new String[2];
		for (int i = 0; i < validUserNames.size()-1; i++) {
			int currentLenght = validUserNames.get(i).length() +
					validUserNames.get(i+1).length();
			if (currentLenght > maxLenght) {
				maxLenght = currentLenght;
				longestTwoWords[0] = validUserNames.get(i);
				longestTwoWords[1] = validUserNames.get(i+1);
			}
		}
		
		for (String string : longestTwoWords) {
			System.out.println(string);
		}
	}
}
