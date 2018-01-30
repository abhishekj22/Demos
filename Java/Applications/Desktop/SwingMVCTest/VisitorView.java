package app;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.table.*;

public class VisitorView extends JFrame{

	JTextField nameTextField = new JTextField();
	JButton registerButton = new JButton("Register");
	JTable visitorsTable = new JTable();

	public VisitorView(ActionListener listener){
		super("SwingMVCTest");
		setSize(300, 300);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setUndecorated(true);
		rootPane.setWindowDecorationStyle(JRootPane.FRAME);
		JPanel topPanel = new JPanel(new BorderLayout());
		topPanel.add(new JLabel("Name: "), BorderLayout.WEST);
		topPanel.add(nameTextField);
		topPanel.add(registerButton, BorderLayout.EAST);
		add(topPanel, BorderLayout.NORTH);
		add(new JScrollPane(visitorsTable));
		registerButton.addActionListener(listener);
	}

	public String getInput(){
		return nameTextField.getText();
	}

	public void bind(TableModel model){
		visitorsTable.setModel(model);
	}
}

