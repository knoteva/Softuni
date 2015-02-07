import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.Map.Entry;


public class SchoolSystem {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();

		TreeMap<String, TreeMap<String, ArrayList<Integer>>> students = new TreeMap<String, TreeMap<String, ArrayList<Integer>>>();
		for (int i = 0; i < n; i++) {
			String[] inputAsArray = input.nextLine().split(" ");
			
			String fullName = inputAsArray[0] + " " + inputAsArray[1];
			String subject = inputAsArray[2];
			int mark = Integer.parseInt(inputAsArray[3]);
			
			TreeMap<String, ArrayList<Integer>> subjects = new TreeMap<String, ArrayList<Integer>>();
			if (students.containsKey(fullName)) {
				subjects = students.get(fullName);
				if (!subjects.containsKey(subject)) {
					subjects.put(subject, new ArrayList<>());
				}

				subjects.get(subject).add(mark);
			} else {
				ArrayList<Integer> marks = new ArrayList<>();
				marks.add(mark);
				subjects.put(subject, marks);
				students.put(fullName, subjects);
			}
		}
		
		for ( Entry<String, TreeMap<String, ArrayList<Integer>>> student : students.entrySet() ) {
			String studentName = student.getKey();
			TreeMap<String, ArrayList<Integer>> subjects = student.getValue();
			String output  = studentName + ": [";
			ArrayList<Double> avrgMarks = new ArrayList<>();
			for (Entry<String, ArrayList<Integer> >subject : subjects.entrySet()) {
				String subjectName = subject.getKey();
				Object[] marks = subject.getValue().toArray();
			    output += subjectName + " - " + String.format("%.2f", averageOf(marks)) + ", ";
			    avrgMarks.add(averageOf(marks));
			}
			
			output = output.substring(0, output.length() - 2) + "]";
			System.out.print(output + "\n");
		}
	}
	

	public static double averageOf(Object[] arr) {
		double sum = 0;
		for (int i = 0; i < arr.length; i++) {
			sum += (int)arr[i];
		}

		double average = sum / arr.length;

		return average;
	}
}
