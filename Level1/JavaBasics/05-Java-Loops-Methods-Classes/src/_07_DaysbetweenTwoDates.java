import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;


public class _07_DaysbetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);	
		String start = input.nextLine();		
		String end = input.nextLine();
		SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy");
		Date startDate = format.parse(start);
		Date endDate = format.parse(end);		
		long days = endDate.getTime() - startDate.getTime();
	    System.out.println (TimeUnit.DAYS.convert(days, TimeUnit.MILLISECONDS));	
	}
}