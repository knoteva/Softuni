import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Nuts {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int numbersLenght = Integer.parseInt(input.nextLine());
		
		String[] inputs = new String[numbersLenght];
		Map<String, Map<String, Integer>> ordersMap = new TreeMap<>();
	
		for (int i = 0; i < numbersLenght; i++) {
			String[] splitedStrings = input.nextLine().split(" ");
			String company = splitedStrings[0];
			String nuts = splitedStrings[1];
			int amount = Integer.parseInt(splitedStrings[2].substring(0, splitedStrings[2].length()-2));
			
			if (ordersMap.get(company) == null) {
				ordersMap.put(company, new LinkedHashMap<>());
				ordersMap.get(company).put(nuts, amount);
			} else {
				if (ordersMap.get(company).get(nuts) == null) {
					ordersMap.get(company).put(nuts, amount);
				} else {
					int oldAmount = ordersMap.get(company).get(nuts);
					ordersMap.get(company).put(nuts, (amount + oldAmount));					
				}
			}
		}
		
		for (String key: ordersMap.keySet()) {
			String result = key + ": ";
			Map<String, Integer> innerMap = ordersMap.get(key);
			for (String innerKey : innerMap.keySet()) {
				result += String.format("%s-%dkg, ", innerKey, innerMap.get(innerKey));

			}
			System.out.println(result.substring(0, result.length()-2));
		}
		
	}
}
