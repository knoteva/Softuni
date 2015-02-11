import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class Frame_And_Buttons_First implements ActionListener {

	// Create buttons
	private JFrame frame = new JFrame("Tic-Tac-Toe");
	private JPanel gpanel = new JPanel();
	private JPanel endPanel = new JPanel();
	private JButton button1 = new JButton("");
	private JButton button2 = new JButton("");
	private JButton button3 = new JButton("");
	private JButton button4 = new JButton("");
	private JButton button5 = new JButton("");
	private JButton button6 = new JButton("");
	private JButton button7 = new JButton("");
	private JButton button8 = new JButton("");
	private JButton button9 = new JButton("");
	private JButton newGameButton = new JButton("New Game");
	private JButton quitGameButton = new JButton("Quit Game");
	private boolean win = false;
	private String xoMarks = "";
	private int playerTurn = 0;

	public Frame_And_Buttons_First() {

		// set frame parameters
		frame.setSize(600, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		gpanel.setLayout(new GridLayout(3, 3));
		frame.setVisible(true);
		frame.setLocationRelativeTo(null);
		endPanel.setSize(200, 200);
		endPanel.setBackground(Color.blue);

		// add buttons
		frame.add(gpanel);
		gpanel.add(button1);
		gpanel.add(button2);
		gpanel.add(button3);
		gpanel.add(button4);
		gpanel.add(button5);
		gpanel.add(button6);
		gpanel.add(button7);
		gpanel.add(button8);
		gpanel.add(button9);
		endPanel.add(newGameButton);
		endPanel.add(quitGameButton);

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
		newGameButton.addActionListener(this);
		newGameButton.setSize(200, 200);
		quitGameButton.addActionListener(this);
		quitGameButton.setSize(200, 200);;
		frame.setVisible(true);
		gpanel.setVisible(true);
		frame.add(endPanel);
		endPanel.setVisible(false);

	}

	// what happens when we press button
	public void actionPerformed(ActionEvent a) {

		playerTurn++;

		if (playerTurn == 1 || playerTurn == 3 || playerTurn == 5
				|| playerTurn == 7 || playerTurn == 9) {
			xoMarks = "X";
		} else if (playerTurn == 2 || playerTurn == 4 || playerTurn == 6
				|| playerTurn == 8) {
			xoMarks = "0";
		}
		if (a.getSource() == button1) {
			button1.setText(xoMarks);
			button1.setEnabled(false);
		}
		if (a.getSource() == button2) {
			button2.setText(xoMarks);
			button2.setEnabled(false);
		}
		if (a.getSource() == button3) {
			button3.setText(xoMarks);
			button3.setEnabled(false);
		}
		if (a.getSource() == button4) {
			button4.setText(xoMarks);
			button4.setEnabled(false);
		}
		if (a.getSource() == button5) {
			button5.setText(xoMarks);
			button5.setEnabled(false);
		}
		if (a.getSource() == button6) {
			button6.setText(xoMarks);
			button6.setEnabled(false);
		}
		if (a.getSource() == button7) {
			button7.setText(xoMarks);
			button7.setEnabled(false);
		}
		if (a.getSource() == button8) {
			button8.setText(xoMarks);
			button8.setEnabled(false);
		}
		if (a.getSource() == button9) {
			button9.setText(xoMarks);
			button9.setEnabled(false);
		}
			// horizontal 
		if (button1.getText() == button2.getText()
				&& button2.getText() == button3.getText()
				&& button1.getText() != "") {
			win = true;
		} else if (button4.getText() == button5.getText()
				&& button5.getText() == button6.getText()
				&& button4.getText() != "") {
			win = true;
		} else if (button7.getText() == button8.getText()
				&& button8.getText() == button9.getText()
				&& button7.getText() != "") {
			win = true;
			//virticle
		} else if (button1.getText() == button4.getText()
				&& button4.getText() == button7.getText()
				&& button1.getText() != "") {
			win = true;
		} else if (button2.getText() == button5.getText()
				&& button5.getText() == button8.getText()
				&& button2.getText() != "") {
			win = true;
		} else if (button3.getText() == button6.getText()
				&& button6.getText() == button9.getText()
				&& button3.getText() != "") {
			win = true;
			// diagonal 
		} else if (button1.getText() == button5.getText()
				&& button5.getText() == button9.getText()
				&& button1.getText() != "") {
			win = true;
		} else if (button3.getText() == button5.getText()
				&& button5.getText() == button7.getText()
				&& button3.getText() != "") {
			win = true;
		} else {
			win = false;
		}

		if (win == true) {
			JOptionPane.showMessageDialog(null, xoMarks + " WINS!");
			frame.setVisible(true);
			gpanel.setVisible(false);
			endPanel.setVisible(true);
			win = false;
		} else if (playerTurn == 9 && win == false) {
			JOptionPane.showMessageDialog(null, "Tie Game!");
			frame.setVisible(true);
			gpanel.setVisible(false);
			endPanel.setVisible(true);
			win = false;
		}
	}

	public static void main(String[] args) {
		new Frame_And_Buttons_First();

	}
}
