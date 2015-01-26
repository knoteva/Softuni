package Java_Lab_23_01;

import java.util.Scanner;

public class _02_InstructionSet {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String opCode = input.nextLine();

		while (!opCode.equals("END")) {
			String[] codeArgs = opCode.split(" ");

			long result = 0;
			switch (codeArgs[0]) {
			case "INC": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				//if the operand has limit value, int overflows; if calculate result = operandOne++, first result = operandOne, then operandOne++;
				result = (long)operandOne + 1;
				break;
			}
			case "DEC": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				//if the operand has limit value, int overflows; if calculate result = operandOne--, first result = operandOne, then operandOne--; 
				result = (long)operandOne - 1;
				break;
			}
			case "ADD": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				int operandTwo = Integer.parseInt(codeArgs[2]);
				//if the operands have limits valueñ, int overflows
				result = (long)operandOne + (long)operandTwo;
				break;
			}
			case "MLA": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				int operandTwo = Integer.parseInt(codeArgs[2]);
				//if the operands have limits valueñ, int overflows
				result = (long)operandOne * (long)operandTwo;
				break;
			}
			default:
				break;
			}
			//read next line
			opCode = input.nextLine();
			System.out.println(result);
		}
	}
}
