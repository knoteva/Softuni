import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

public class Frame_And_Buttons_4x4 implements ActionListener {

	// Create buttons
	private JFrame frame = new JFrame("Tic-Tac-Toe Advanced");
	private JButton button1 = new JButton("");
	private JButton button2 = new JButton("");
	private JButton button3 = new JButton("");
	private JButton button4 = new JButton("");
	private JButton button5 = new JButton("");
	private JButton button6 = new JButton("");
	private JButton button7 = new JButton("");
	private JButton button8 = new JButton("");
	private JButton button9 = new JButton("");
    private JButton button10 = new JButton("");
    private JButton button11 = new JButton("");
    private JButton button12 = new JButton("");
    private JButton button13 = new JButton("");
    private JButton button14 = new JButton("");
    private JButton button15 = new JButton("");
    private JButton button16 = new JButton("");



	private boolean win = false;
	private String xoMarks = "";
	private int playerTurn = 0;

	public Frame_And_Buttons_4x4() {

		// set frame parameters
		frame.setSize(600, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLayout(new GridLayout(4, 0));
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
        frame.add(button10);
        frame.add(button11);
        frame.add(button12);
        frame.add(button13);
        frame.add(button14);
        frame.add(button15);
        frame.add(button16);

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
        button10.addActionListener(this);
        button11.addActionListener(this);
        button12.addActionListener(this);
        button13.addActionListener(this);
        button14.addActionListener(this);
        button15.addActionListener(this);
        button16.addActionListener(this);
		frame.setVisible(true);

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
		if (a.getSource() == button10) {
			button10.setText(xoMarks);
			button10.setEnabled(false);
        }
        if (a.getSource() == button11) {
            button11.setText(xoMarks);
            button11.setEnabled(false);
        }
        if (a.getSource() == button12) {
            button12.setText(xoMarks);
            button12.setEnabled(false);
        }
        if (a.getSource() == button13) {
            button13.setText(xoMarks);
            button13.setEnabled(false);
        }
        if (a.getSource() == button14) {
            button14.setText(xoMarks);
            button14.setEnabled(false);
        }
        if (a.getSource() == button15) {
            button15.setText(xoMarks);
            button15.setEnabled(false);
        }
        if (a.getSource() == button16) {
            button16.setText(xoMarks);
            button16.setEnabled(false);
        }

			// horizontal
		if (button1.getText() == button2.getText()
				&& button2.getText() == button3.getText()
				&& button1.getText() != "") {
			win = true;
		} else if (button2.getText() == button3.getText()
				&& button3.getText() == button4.getText()
				&& button2.getText() != "") {
			win = true;
		} else if (button5.getText() == button6.getText()
				&& button6.getText() == button7.getText()
				&& button5.getText() != "") {
			win = true;
        } else if (button6.getText() == button7.getText()
                && button7.getText() == button8.getText()
                && button6.getText() != "") {
            win = true;
        } else if (button9.getText() == button10.getText()
                && button10.getText() == button11.getText()
                && button9.getText() != "") {
            win = true;
        } else if (button10.getText() == button11.getText()
                && button11.getText() == button12.getText()
                && button10.getText() != "") {
            win = true;
        } else if (button13.getText() == button14.getText()
                && button14.getText() == button15.getText()
                && button13.getText() != "") {
            win = true;
        } else if (button14.getText() == button15.getText()
                && button15.getText() == button16.getText()
                && button14.getText() != "") {
            win = true;
			//virticle
		} else if (button1.getText() == button5.getText()
				&& button5.getText() == button9.getText()
				&& button1.getText() != "") {
			win = true;
		} else if (button5.getText() == button9.getText()
				&& button9.getText() == button13.getText()
				&& button5.getText() != "") {
			win = true;
		} else if (button2.getText() == button6.getText()
				&& button6.getText() == button10.getText()
				&& button2.getText() != "") {
			win = true;
        } else if (button6.getText() == button10.getText()
                && button10.getText() == button14.getText()
                && button6.getText() != "") {
            win = true;
        } else if (button3.getText() == button7.getText()
                && button7.getText() == button11.getText()
                && button3.getText() != "") {
            win = true;
        } else if (button7.getText() == button11.getText()
                && button11.getText() == button15.getText()
                && button7.getText() != "") {
            win = true;
        } else if (button4.getText() == button8.getText()
                && button8.getText() == button12.getText()
                && button4.getText() != "") {
            win = true;
        } else if (button8.getText() == button12.getText()
                && button12.getText() == button16.getText()
                && button8.getText() != "") {
            win = true;
			// diagonal
		} else if (button1.getText() == button6.getText()
				&& button6.getText() == button11.getText()
				&& button1.getText() != "") {
			win = true;
		} else if (button6.getText() == button11.getText()
				&& button11.getText() == button16.getText()
				&& button6.getText() != "") {
			win = true;
        } else if (button2.getText() == button7.getText()
                && button7.getText() == button12.getText()
                && button2.getText() != "") {
            win = true;
        } else if (button3.getText() == button6.getText()
                && button6.getText() == button9.getText()
                && button3.getText() != "") {
            win = true;
        } else if (button4.getText() == button7.getText()
                && button7.getText() == button10.getText()
                && button4.getText() != "") {
            win = true;
        } else if (button7.getText() == button10.getText()
                && button10.getText() == button13.getText()
                && button7.getText() != "") {
            win = true;
        } else if (button5.getText() == button10.getText()
                && button10.getText() == button15.getText()
                && button5.getText() != "") {
            win = true;
        } else if (button8.getText() == button11.getText()
                && button11.getText() == button14.getText()
                && button8.getText() != "") {
            win = true;
		} else {
			win = false;
		}

		if (win == true) {
			JOptionPane.showMessageDialog(null, xoMarks + " WINS!");
		} else if (playerTurn == 9 && win == false) {
			JOptionPane.showMessageDialog(null, "Tie Game!");
			frame.setVisible(false);

		}
	}

	public static void main(String[] args) {
		new Frame_And_Buttons_4x4();

	}
}
