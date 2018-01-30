using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingApp
{
    public class Visitor
    {
        public string Name { get; set; }

        public int Frequency { get; set; }

        public DateTime Recent { get; set; }

        public Visitor()
        {
            Frequency = 1;
            Recent = DateTime.Now;
        }

        public void Revisit()
        {
            Frequency += 1;
            Recent = DateTime.Now;
        }
    }

    public class VisitorModel
    {
        private Document<Visitor> dataStore;

        public VisitorModel()
        {
            dataStore = Document.Open<Visitor>("visitors.xml");
        }

        public Visitor[] ReadVisitors()
        {
            return dataStore.ToArray();
        }

        public void WriteVisitor(string id)
        {
            Visitor visitor = dataStore.Find(entry => entry.Name == id);

            if (visitor == null)
                dataStore.Add(new Visitor { Name = id });
            else
                visitor.Revisit();

            dataStore.Save();
        }
    }
}
