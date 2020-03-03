namespace BensBranchBuilder
{
	partial class SettingsForm
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
			this.components = new System.ComponentModel.Container();
			this.consoleLocation = new System.Windows.Forms.ComboBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.solutionName = new System.Windows.Forms.TextBox();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// consoleLocation
			// 
			this.consoleLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleLocation.FormattingEnabled = true;
			this.consoleLocation.Location = new System.Drawing.Point(12, 23);
			this.consoleLocation.MaximumSize = new System.Drawing.Size(900, 0);
			this.consoleLocation.Name = "consoleLocation";
			this.consoleLocation.Size = new System.Drawing.Size(290, 21);
			this.consoleLocation.TabIndex = 10;
			this.toolTip1.SetToolTip(this.consoleLocation, "Please select the full path of the exe including the name of the file. e.g. ...\\\r" +
        "\n2017\\Community\\Common7\\Tools\\VsDevCmd.bat");
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(308, 23);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(29, 21);
			this.button5.TabIndex = 9;
			this.button5.Text = "+";
			this.toolTip1.SetToolTip(this.button5, "Add to Favourties");
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(343, 23);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(29, 21);
			this.button4.TabIndex = 8;
			this.button4.Text = "...";
			this.toolTip1.SetToolTip(this.button4, "Select Path");
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Visual Studio Dev Console Location:";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(343, 65);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(29, 21);
			this.button3.TabIndex = 16;
			this.button3.Text = "...";
			this.toolTip1.SetToolTip(this.button3, "Select Path");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(308, 93);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 21);
			this.button1.TabIndex = 12;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(12, 94);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(115, 21);
			this.button2.TabIndex = 13;
			this.button2.Text = "Clear Favourites";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Solution Name: ";
			// 
			// solutionName
			// 
			this.solutionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.solutionName.Location = new System.Drawing.Point(12, 65);
			this.solutionName.MaximumSize = new System.Drawing.Size(0, 21);
			this.solutionName.MinimumSize = new System.Drawing.Size(0, 21);
			this.solutionName.Name = "solutionName";
			this.solutionName.Size = new System.Drawing.Size(325, 21);
			this.solutionName.TabIndex = 15;
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.FileName = "openFileDialog1";
			this.openFileDialog2.Filter = "Solution Files | *.sln";
			// 
			// SettingsForm
			// 
			this.ClientSize = new System.Drawing.Size(384, 126);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.solutionName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.consoleLocation);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.MaximumSize = new System.Drawing.Size(900, 200);
			this.MinimumSize = new System.Drawing.Size(400, 165);
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox consoleLocation;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox solutionName;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
	}
}
