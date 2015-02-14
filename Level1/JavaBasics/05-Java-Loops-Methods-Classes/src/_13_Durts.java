
import java.util.Scanner;

public class _13_Durts {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		int cX = input.nextInt();
		int cY = input.nextInt();
		int r = input.nextInt();
		int n = input.nextInt();
		input.nextLine();
		String[] line = input.nextLine().split("[ ]+");
		int[] coord = new int[2 * n];

		for (int i = 0; i < coord.length; i += 2) {
			coord[i] = Integer.parseInt(line[i]);
			coord[i + 1] = Integer.parseInt(line[i + 1]);
			if ((coord[i] >= cX - r / 2 && coord[i] <= cX + r / 2
					&& coord[i + 1] >= cY - r && coord[i + 1] <= cY + r)
					|| (coord[i] >= cX - r && coord[i] <= cX - r / 2
							&& coord[i + 1] >= cY - r / 2 && coord[i + 1] <= cY
							+ r / 2)
					|| (coord[i] >= cX + r / 2 && coord[i] <= cX + r
							&& coord[i + 1] >= cY - r / 2 && coord[i + 1] <= cY
							+ r / 2)) {
				System.out.println("yes");
			} else {
				System.out.println("no");
			}
		}
	}
}
