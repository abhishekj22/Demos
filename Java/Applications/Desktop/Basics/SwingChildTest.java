import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

class SwingChildTest{
	
	static class MainFrame extends JFrame{
		
		JButton timeButton = new JButton("Time");

		MainFrame(){
			super("Hello JFC");
			setSize(400, 400);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			setLayout(null);
			timeButton.setBounds(40, 20, 80, 25);
			add(timeButton);
			timeButton.addActionListener(new ActionListener(){
				public void actionPerformed(ActionEvent e){
					Date now = new Date();
					JOptionPane.showMessageDialog(MainFrame.this, now, "Current Time", JOptionPane.INFORMATION_MESSAGE);
				}
			});
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
	}
}

