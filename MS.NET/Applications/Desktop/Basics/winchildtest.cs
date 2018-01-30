using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

class Computation
{
	public long Compute(int low, int high)
	{
		long total = 0;

		for(int value = low; value <= high; ++value)
		{
			Worker.DoWork(value);
			total += value * value;
		}

		return total;
	}

	public Task<long> ComputeAsync(int low, int high)
	{
		return Task<long>.Run(() => Compute(low, high));
	}

}

class MainForm : Form
{
	private Label resultLabel;
	private Button computeButton;

	public MainForm()
	{
		this.Text = "Hello WinForms";
		
		resultLabel = new Label();
		resultLabel.Text = "Ready";
		resultLabel.Location = new Point(20, 20);
		resultLabel.Size = new Size(200, 20);
		this.Controls.Add(resultLabel);

		computeButton = new Button();
		computeButton.Text = "Compute";
		computeButton.Location = new Point(20, 50);
		computeButton.Size = new Size(80, 25);
		computeButton.Click += computeButton_Click;
		this.Controls.Add(computeButton);
	}
		
	private async void computeButton_Click(object sender, EventArgs e)
	{
		computeButton.Enabled = false;
		resultLabel.Text = "Busy...";

		int m = Environment.TickCount % 10 + 20;
		Computation c = new Computation();
		long r = await c.ComputeAsync(1, m);
		
		resultLabel.Text = $"Result = {r}";
		computeButton.Enabled = true;
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}