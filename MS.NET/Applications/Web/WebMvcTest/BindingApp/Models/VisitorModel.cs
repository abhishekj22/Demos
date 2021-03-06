﻿using System;

namespace BindingApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Visitor
    {
        [Display(Name = "Visitor Name")]
        public string Name { get; set; }

        [Display(Name = "Visit Count")]
        public int Frequency { get; set; } = 1;

        [Display(Name = "Last Visit")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Recent { get; set; } = DateTime.Now;

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