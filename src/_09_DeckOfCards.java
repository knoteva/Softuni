
import java.io.FileOutputStream;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.Font;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

 
public class _09_DeckOfCards {
       
        public static void main(String[] args) {
        	try {
        		// Създаване на pdf файл
        		Document document = new Document();
                PdfWriter.getInstance(document, new FileOutputStream("DeckOfCards.pdf"));
                document.open();
                
                //Създаване таблица
                PdfPTable table = new PdfPTable(4);
                table.setWidthPercentage(90);
                table.getDefaultCell().setFixedHeight(170);
                
        		//Създаване цветове
        		BaseFont baseFont = BaseFont.createFont("times.ttf", BaseFont.IDENTITY_H, true);
        		Font black = new Font(baseFont, 50f, 0, BaseColor.BLACK);
        		Font red = new Font(baseFont, 50f, 0, BaseColor.RED);
        		
        		char club = '\u2663';
        		char diamond = '\u2666';
        		char heart = '\u2665';
        		char spade = '\u2660';
        		String card = "";
        		for (int i = 2; i <= 14; i++) {
        			//System.out.printf("%1$d%2$s %1$d%3$s %1$d%4$s %1$d%5$s \n", i, club, diamond, heart, spade);	
        			//card = "" + i;
        			//System.out.println(card);
        			switch (i) {
        			case 11:
        				card = "J"; break;
        				//System.out.printf("J%1$s J%2$s J%3$s J%4$s \n", club, diamond, heart, spade);
        			case 12:
        				card = "D"; break;
        				//System.out.printf("D%1$s D%2$s D%3$s D%4$s \n", club, diamond, heart, spade);				
        			case 13:
        				card = "K"; break;
        				//System.out.printf("K%1$s K%2$s K%3$s K%4$s \n", club, diamond, heart, spade);	
        			case 14:
        				card = "A"; break;
        				//System.out.printf("A%1$s A%2$s A%3$s A%4$s \n", club, diamond, heart, spade);					
        			default: card = "" + i;
        			break;
        			}
        			for (int j = 1; j <= 4; j++) {
        				
        				switch (j) {
        				case 1: table.addCell(new Paragraph(card + club, black)); break;
        				case 2: table.addCell(new Paragraph(card + diamond, red)); break;
        				case 3: table.addCell(new Paragraph(card + heart, red)); break;
        				case 4: table.addCell(new Paragraph(card + spade, black)); break;
        				}
					
        			}
        		}
        		 document.add(table);
                 document.close();   
        	} catch (Exception e) {
                e.printStackTrace();
        	
        	}
        }
}