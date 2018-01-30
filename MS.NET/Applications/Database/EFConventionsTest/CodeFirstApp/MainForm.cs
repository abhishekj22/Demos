using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstApp
{
    public partial class MainForm : Form
    {
        EstateEntities db = new EstateEntities();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            houseTypeComboBox.SelectedIndex = 0;

            var selection = from h in db.Houses where h.Area >= 1000 select h.Id;
            MessageBox.Show($"Number of big houses = {selection.Count()}", "CodeFirstApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void houseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();

        }

        private void acquireButton_Click(object sender, EventArgs e)
        {
            int count = int.Parse(countTextBox.Text);

            House house;
            if (houseTypeComboBox.SelectedIndex == 0)
                house = new Apartment { Floor = count };
            else
                house = new Bungalow { Floors = count };
            house.Area = float.Parse(areaTextBox.Text);

            db.Houses.Add(house);
            db.SaveChanges();

            PopulateGrid();
        }

        private void PopulateGrid()
        {
            if (houseTypeComboBox.SelectedIndex == 0)
                housesDataGridView.DataSource = db.Houses.OfType<Apartment>().ToList();
            else
                housesDataGridView.DataSource = db.Houses.OfType<Bungalow>().ToList();
        }
    }
}
