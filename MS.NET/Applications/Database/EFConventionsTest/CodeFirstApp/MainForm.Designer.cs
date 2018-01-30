namespace CodeFirstApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.houseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.housesDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.acquireButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.housesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "House Type:";
            // 
            // houseTypeComboBox
            // 
            this.houseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.houseTypeComboBox.FormattingEnabled = true;
            this.houseTypeComboBox.Items.AddRange(new object[] {
            "Apartment",
            "Bungalow"});
            this.houseTypeComboBox.Location = new System.Drawing.Point(95, 12);
            this.houseTypeComboBox.Name = "houseTypeComboBox";
            this.houseTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.houseTypeComboBox.TabIndex = 1;
            this.houseTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.houseTypeComboBox_SelectedIndexChanged);
            // 
            // housesDataGridView
            // 
            this.housesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.housesDataGridView.Location = new System.Drawing.Point(16, 49);
            this.housesDataGridView.Name = "housesDataGridView";
            this.housesDataGridView.RowHeadersVisible = false;
            this.housesDataGridView.Size = new System.Drawing.Size(200, 122);
            this.housesDataGridView.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Floor(s)";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(95, 189);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(121, 20);
            this.countTextBox.TabIndex = 4;
            // 
            // areaTextBox
            // 
            this.areaTextBox.Location = new System.Drawing.Point(95, 215);
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(121, 20);
            this.areaTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Area:";
            // 
            // acquireButton
            // 
            this.acquireButton.Location = new System.Drawing.Point(88, 247);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(53, 23);
            this.acquireButton.TabIndex = 7;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.UseVisualStyleBackColor = true;
            this.acquireButton.Click += new System.EventHandler(this.acquireButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 282);
            this.Controls.Add(this.acquireButton);
            this.Controls.Add(this.areaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.housesDataGridView);
            this.Controls.Add(this.houseTypeComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeFirstApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.housesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox houseTypeComboBox;
        private System.Windows.Forms.DataGridView housesDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button acquireButton;
    }
}

