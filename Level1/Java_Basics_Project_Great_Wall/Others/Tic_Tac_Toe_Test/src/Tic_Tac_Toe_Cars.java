import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;

import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.sound.sampled.LineUnavailableException;
import javax.sound.sampled.UnsupportedAudioFileException;
import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class Tic_Tac_Toe_Cars implements ActionListener {

	// Create buttons
	private JFrame frame = new JFrame("Tic-Tac-Toe");
	private JButton buttons[] = new JButton[9];
	private boolean win = false;
	private int playerTurn = 0;
	static Icon imageNull;
	static ImageIcon car1 = new ImageIcon("./res/car1.png");
	static ImageIcon car2 = new ImageIcon("./res/car3.png");
	String winner = "";
			
	public Tic_Tac_Toe_Cars() {
		// set frame parameters
		frame.setSize(600, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLayout(new GridLayout(3, 3));		
		ImageIcon windows = new ImageIcon("./res/tic1.jpg");
		frame.setIconImage(windows.getImage());
		frame.setVisible(true);
		frame.setLocationRelativeTo(null);
		
		// add buttons and action
		for (int i = 0; i < 9; i++) {
			buttons[i] = new JButton();
			frame.add(buttons[i]);
			buttons[i].addActionListener(this);
		}
		imageNull = (new JButton("").getIcon());
		for (int i = 0; i < 9; i++) {
			buttons[i].setIcon(imageNull);
		}		
	}

	// what happens when we press button
	public void actionPerformed(ActionEvent a) {
		
		JButton but = (JButton) a.getSource();
		if (but.getIcon() == imageNull) {
			playerTurn++;
			if (playerTurn % 2 == 1) {
				but.setIcon(car1);
				music("./res/tic3.wav");
			} else {
				but.setIcon(car2);
				music("./res/tic2.wav");
			}
		}

		for (int i = 0; i < 9; i++) {
			if (a.getSource() == buttons[i]) {
				buttons[i] = but;		
			}
		}
		// horizontal
		if (buttons[0].getIcon() == buttons[1].getIcon()
				&& buttons[1].getIcon() == buttons[2].getIcon()
				&& buttons[0].getIcon() != imageNull) {
			win = true;
			if (buttons[0].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[3].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[5].getIcon()
				&& buttons[3].getIcon() != imageNull) {
			win = true;
			if (buttons[3].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[6].getIcon() == buttons[7].getIcon()
				&& buttons[7].getIcon() == buttons[8].getIcon()
				&& buttons[6].getIcon() != imageNull) {
			win = true;
			if (buttons[6].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
			// vertical
		} else if (buttons[0].getIcon() == buttons[3].getIcon()
				&& buttons[3].getIcon() == buttons[6].getIcon()
				&& buttons[0].getIcon() != imageNull) {
			win = true;
			if (buttons[0].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[1].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[7].getIcon()
				&& buttons[1].getIcon() != imageNull) {
			win = true;
			if (buttons[1].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[2].getIcon() == buttons[5].getIcon()
				&& buttons[5].getIcon() == buttons[8].getIcon()
				&& buttons[2].getIcon() != imageNull) {
			win = true;
			if (buttons[2].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
			// diagonal
		} else if (buttons[0].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[8].getIcon()
				&& buttons[0].getIcon() != imageNull) {
			win = true;
			if (buttons[0].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[2].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[6].getIcon()
				&& buttons[2].getIcon() != imageNull) {
			win = true;
			if (buttons[2].getIcon() == car1) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else {
			win = false;
		}

		if (win == true) {
			music("./res/winner.wav");
			JOptionPane.showMessageDialog(null, winner + " WINS!");
			frame.setVisible(false);
			
		} else if (playerTurn == 9 && win == false) {
			music("./res/next.wav");
			JOptionPane.showMessageDialog(null, "NO WINNER!");
			
			frame.setVisible(false);
		}
	}

	public static void music(String sound) {
		try {
			AudioInputStream audio = AudioSystem.getAudioInputStream(new File(
					sound));
			Clip clip = AudioSystem.getClip();
			clip.open(audio);
			clip.start();
		}
		catch (UnsupportedAudioFileException uns) {
			System.out.println(uns);
		} catch (IOException ioe) {
			System.out.println(ioe);
		} catch (LineUnavailableException lua) {
			System.out.println(lua);
		}
	}

	public static void main(String[] args) {
		new Tic_Tac_Toe_Cars();
	}
}
