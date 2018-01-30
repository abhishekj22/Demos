import java.util.*;
import java.awt.*;
import java.awt.event.*;

class AWTPaintTest{
	
	static class MainFrame extends Frame{
		
		MainFrame(){
			super("Hello AWT");
			setSize(400, 400);
			enableEvents(AWTEvent.WINDOW_EVENT_MASK);
			setBackground(new Color(255, 255, 255));
		}

		@Override
		public void paint(Graphics g){
			Date now = new Date();
			g.setColor(Color.BLUE);
			g.drawRect(40, 40, 200, 20);
			g.setColor(Color.RED);
			g.drawString(now.toString(), 55, 55);
		}

		@Override
		protected void processWindowEvent(WindowEvent e){
			if(e.getID() == WindowEvent.WINDOW_CLOSING)
				System.exit(0);
			super.processWindowEvent(e);
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
		for(;;){
			Thread.sleep(1000);
			frame.repaint();
		}
	}
}

