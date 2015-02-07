import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class OfficeStuff {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int linesLenghtLenght = Integer.parseInt(input.nextLine());
		
		String[] inputs = new String[linesLenghtLenght];
		Map<String, Map<String, Integer>> ordersMap = new TreeMap<>();
	
		for (int i = 0; i < linesLenghtLenght; i++) {
			String[] splitedStrings = input.nextLine().split(" - ");
			String company = splitedStrings[0].substring(1, splitedStrings[0].length());
			String product = splitedStrings[2].substring(0, splitedStrings[2].length()-1);
			int amount = Integer.parseInt(splitedStrings[1]);
			
			if (ordersMap.get(company) == null) {
				ordersMap.put(company, new LinkedHashMap<>());
				ordersMap.get(company).put(product, amount);
			} else {
				if (ordersMap.get(company).get(product) == null) {
					ordersMap.get(company).put(product, amount);
				} else {
					int oldAmount = ordersMap.get(company).get(product);
					ordersMap.get(company).put(product, (amount + oldAmount));					
				}
			}
		}
		
		for (String key: ordersMap.keySet()) {
			String result = key + ": ";
			Map<String, Integer> innerMap = ordersMap.get(key);
			for (String innerKey : innerMap.keySet()) {
				result += String.format("%s-%d, ", innerKey, innerMap.get(innerKey));
			}
			System.out.println(result.substring(0, result.length()-2));
		}
		
	}
}
