using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicUIApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void personTextBox_TextChanged(object sender, EventArgs e)
        {
            greetButton.Enabled = personTextBox.TextLength > 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            greeterBindingSource.Add(simpleGreeter);
        }

        private void greetButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = simpleGreeter.Greet();
        }
    }
}
