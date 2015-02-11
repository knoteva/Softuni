import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;


public class Frame_And_Buttons_New implements ActionListener {
	
	//Create buttons
	private JFrame 	frame = new JFrame("Tic-Tac-Toe");
	private JButton button1 = new JButton("");
	private JButton button2 = new JButton("");
	private JButton button3 = new JButton("");
	private JButton button4 = new JButton("");
	private JButton button5 = new JButton("");
	private JButton button6 = new JButton("");
	private JButton button7 = new JButton("");
	private JButton button8 = new JButton("");
	private JButton button9 = new JButton("");
	int playerTurn = 0 ;
	
	
	public Frame_And_Buttons_New() {

		//set frame parameters
		frame.setSize(600, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLayout(new GridLayout(3, 3));
		frame.setVisible(true);
		frame.setLocationRelativeTo(null);
		
		// add buttons
		frame.add(button1);
		frame.add(button2);
		frame.add(button3);
		frame.add(button4);
		frame.add(button5);
		frame.add(button6);
		frame.add(button7);
		frame.add(button8);
		frame.add(button9);
		
		// add action to buttons
		button1.addActionListener(this);
		button2.addActionListener(this);
		button3.addActionListener(this);
		button4.addActionListener(this);
		button5.addActionListener(this);
		button6.addActionListener(this);
		button7.addActionListener(this);
		button8.addActionListener(this);
		button9.addActionListener(this);
		
	}
	
	
	// what happens when we press button
	public void actionPerformed(ActionEvent a) {
		
		String xoMarks ="";
		
		playerTurn++;
		
		if (playerTurn == 1 || playerTurn == 3 || playerTurn == 5 || playerTurn == 7 || playerTurn == 9){
			xoMarks = "X";
		}
		else if (playerTurn == 2 || playerTurn == 4 || playerTurn == 6 || playerTurn == 8) { 
			xoMarks = "0";
		}
		if(a.getSource() == button1){
			button1.setText(xoMarks);
			button1.setEnabled(false);
			} 
			if(a.getSource() == button2){
			button2.setText(xoMarks);
			button2.setEnabled(false);
			} 
			if(a.getSource() == button3){
			button3.setText(xoMarks);
			button3.setEnabled(false);
			} 
			if(a.getSource() == button4){
			button4.setText(xoMarks);
			button4.setEnabled(false);
			} 
			if(a.getSource() == button5){
			button5.setText(xoMarks);
			button5.setEnabled(false);
			} 
			if(a.getSource() == button6){
			button6.setText(xoMarks);
			button6.setEnabled(false);
			} 
			if(a.getSource() == button7){				
			button7.setText(xoMarks);
			button7.setEnabled(false);
			} 
			if(a.getSource() == button8){
			button8.setText(xoMarks);
			button8.setEnabled(false);
			} 
			if(a.getSource() == button9){
			button9.setText(xoMarks);
			button9.setEnabled(false);
			}
		
	}
		
	
	
	public static void main(String[] args) {
		new Frame_And_Buttons_New();
	}
}

