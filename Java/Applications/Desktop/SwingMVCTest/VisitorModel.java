package app;

public class VisitorModel extends javax.swing.table.AbstractTableModel{

		private Document<Visitor> store;

		public VisitorModel(){
			store = Document.open(Visitor.class, "visitors.xml");
		}

		@Override
		public int getColumnCount(){
			return 3;
		}

		@Override
		public String getColumnName(int i){
			String[] names = {"Name", "Frequency", "Recent"};
			return names[i];
		}

		@Override
		public int getRowCount(){
			return store.size();
		}

		@Override
		public Object getValueAt(int i, int j){
			Visitor entry = store.get(i);
			Object[] values = {entry.name, entry.frequency, entry.recent};
			return values[j];
		}

		public void register(String id){
			Visitor visitor = store.find(entry -> entry.name.equals(id));
			if(visitor == null)
				store.add(new Visitor(id));
			else
				visitor.revisit();
			store.save();
			fireTableDataChanged();
		}
}


