import java.util.Scanner;

public class P02_Move_the_Arrows {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int rows = Integer.parseInt(input.nextLine());
		char[][] matrix = new char[rows][];
		
		for (int i = 0; i < rows; i++) {
			String line = input.nextLine();
			matrix[i] = line.toCharArray();
		}
		
		boolean hasMoved = true;
		while (hasMoved) {
			hasMoved = false;
			for (int row = 0; row < matrix.length; row++) {
				for (int col = 0; col < matrix[row].length; col++) {
					int currentRow = row, currentCol = col;
					char symbol = matrix[currentRow][currentCol];
					if (symbol != 'o') {
						int dirRow = 0, dirCol = 0, 
							nextRow = 0, nextCol = 0;
						
						switch (symbol) {
							case '^':
								dirRow = -1;
								break;
							case '>':
								dirCol = 1;
								break;
							case '<':
								dirCol = -1;
								break;
							case 'v':
								dirRow = 1;
								break;
							default:
								break;
						}
						
						nextRow = currentRow + dirRow;
						nextCol = currentCol + dirCol;
						if (nextCol >= 0 && nextCol < matrix[currentRow].length
								&& nextRow >= 0 && nextRow < matrix.length
								&& matrix[nextRow][nextCol] == 'o') {
							
							matrix[nextRow][nextCol] = symbol;
							matrix[currentRow][currentCol] = 'o';
							hasMoved = true;
						} 
					}
				}
			}
		}
		
		printMatrix(matrix);
	}
	
	private static void printMatrix(char[][] matrix) {
		for (int r = 0; r < matrix.length; r++) {
			for (int c = 0; c < matrix[r].length; c++) {
				System.out.print(matrix[r][c]);
			}
			System.out.println();
		}
	}

}