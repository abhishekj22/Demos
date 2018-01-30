import java.util.*;
import java.awt.*;
import javax.swing.*;

class SwingPaintTest{
	
	static class MainFrame extends JFrame{
		
		MainFrame(){
			super("Hello JFC");
			setSize(400, 400);
			setBackground(Color.WHITE);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			setUndecorated(true);
			rootPane.setWindowDecorationStyle(JRootPane.FRAME);
			setContentPane(new Clock());
		}

		class Clock extends JPanel{
			
			@Override
			public void paintComponent(Graphics g){
				Date now = new Date();
				g.setColor(Color.BLUE);
				g.drawRect(40, 40, 200, 20);
				g.setColor(Color.RED);
				g.drawString(now.toString(), 55, 55);
			}
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
		for(;;){
			Thread.sleep(1000);
			SwingUtilities.invokeLater(new Runnable(){
				public void run(){
					frame.repaint();
				}
			});
		}
	}
}

