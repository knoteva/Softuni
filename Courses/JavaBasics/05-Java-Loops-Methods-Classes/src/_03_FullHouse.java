
public class _03_FullHouse {
	public static void main(String[] args) {
		String[] face = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J","Q", "K", "A" };
		char[] suit = { '\u2665', '\u2663', '\u2666', '\u2660' };
		int count = 0;
		
		for (int i = 0; i < face.length; i++) {
			for (int j = 0; j < face.length; j++) {					
				if (i == j) {
					continue;
				}
				for (int s1 = 0; s1 < suit.length; s1++) {
					for (int s2 = s1 + 1; s2 < suit.length; s2++) {
						for (int s3 = s2 + 1; s3 < suit.length; s3++) {
							for (int s4 = 0; s4 < suit.length; s4++) {
								for (int s5 = s4 + 1; s5 < suit.length; s5++) {
									
									System.out.printf("(%s%c %s%c %s%c %s%c %s%c)\n", face[i], suit[s1], face[i], suit[s2],
											face[i], suit[s3], face[j], suit[s4], face[j], suit[s5]);
									count++;
								}
							}
						}
					}
				}
			}
		}	
		System.out.println(count + " full houses");
	}
}
