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

public class Game implements ActionListener {

	// Create frame, buttons etc.
	private JFrame frame = new JFrame("GREAT_WALL-Tic-Tac-Toe");
	private JButton buttons[] = new JButton[9];
	static Icon imageNull;
	static ImageIcon carM = new ImageIcon("./res/carM.png");
	static ImageIcon carR = new ImageIcon("./res/carR.png");		
	private int playerTurn = 0;	
	private boolean win = false;
	String winner = "";
	
	public Game() {
		// set frame parameters
		frame.setSize(600, 600);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLayout(new GridLayout(3, 3));		
		ImageIcon windows = new ImageIcon("./res/tic.jpg");
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
				but.setIcon(carM);
				music("./res/tic3.wav");
			} else {
				but.setIcon(carR);
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
			if (buttons[0].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[3].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[5].getIcon()
				&& buttons[3].getIcon() != imageNull) {
			win = true;
			if (buttons[3].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[6].getIcon() == buttons[7].getIcon()
				&& buttons[7].getIcon() == buttons[8].getIcon()
				&& buttons[6].getIcon() != imageNull) {
			win = true;
			if (buttons[6].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
			// vertical
		} else if (buttons[0].getIcon() == buttons[3].getIcon()
				&& buttons[3].getIcon() == buttons[6].getIcon()
				&& buttons[0].getIcon() != imageNull) {
			win = true;
			if (buttons[0].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[1].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[7].getIcon()
				&& buttons[1].getIcon() != imageNull) {
			win = true;
			if (buttons[1].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[2].getIcon() == buttons[5].getIcon()
				&& buttons[5].getIcon() == buttons[8].getIcon()
				&& buttons[2].getIcon() != imageNull) {
			win = true;
			if (buttons[2].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
			// diagonal
		} else if (buttons[0].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[8].getIcon()
				&& buttons[0].getIcon() != imageNull) {
			win = true;
			if (buttons[0].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else if (buttons[2].getIcon() == buttons[4].getIcon()
				&& buttons[4].getIcon() == buttons[6].getIcon()
				&& buttons[2].getIcon() != imageNull) {
			win = true;
			if (buttons[2].getIcon() == carM) {
				winner = "Modern";
			} else {
				winner = "Retro";
			}
		} else {
			win = false;
		}
		// end massage
		if (win == true) {
			music("./res/winner.wav");
			JOptionPane.showMessageDialog(frame, winner + " WINS!", "Result", JOptionPane.INFORMATION_MESSAGE);
			frame.setVisible(false);			
		} else if (playerTurn == 9 && win == false) {
			music("./res/next.wav");
			JOptionPane.showMessageDialog(frame, "NO WINNER!", "Result", JOptionPane.ERROR_MESSAGE);
			frame.setVisible(false);
		}
	}
	//  set audio
	public static void music(String sound) {
		try {
			AudioInputStream audio = AudioSystem.getAudioInputStream(new File(sound));
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
		new Game();
	}
}
