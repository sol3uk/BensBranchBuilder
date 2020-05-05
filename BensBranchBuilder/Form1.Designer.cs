using System.IO;

namespace BensBranchBuilder
{
	partial class BensBranchBuilder
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.folderLocation = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "NuGet Restore";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Build";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "Rebuild";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(267, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 21);
            this.button4.TabIndex = 4;
            this.button4.Text = "...";
            this.toolTip1.SetToolTip(this.button4, "Select Path");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // inputBox
            // 
            this.inputBox.AutoSize = true;
            this.inputBox.Location = new System.Drawing.Point(13, 48);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(140, 17);
            this.inputBox.TabIndex = 5;
            this.inputBox.Text = "Check To Build Solution";
            this.inputBox.UseVisualStyleBackColor = true;
            this.inputBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(232, 21);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 21);
            this.button5.TabIndex = 6;
            this.button5.Text = "+";
            this.toolTip1.SetToolTip(this.button5, "Add to Favourties");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // folderLocation
            // 
            this.folderLocation.FormattingEnabled = true;
            this.folderLocation.Location = new System.Drawing.Point(12, 21);
            this.folderLocation.Name = "folderLocation";
            this.folderLocation.Size = new System.Drawing.Size(214, 21);
            this.folderLocation.TabIndex = 7;
            this.toolTip1.SetToolTip(this.folderLocation, "Please ensure the path is the root of the branch. e.g. C:\\JL\\TMS\\PreStaging\r\n");
            this.folderLocation.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(232, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Settings";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Solution Folder Location:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(157, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(139, 47);
            this.button7.TabIndex = 13;
            this.button7.Text = "Clean Solution";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // BensBranchBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 179);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.folderLocation);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "BensBranchBuilder";
            this.Text = "Bens Branch Builder";
            this.Load += new System.EventHandler(this.BensBranchBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.CheckBox inputBox;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ComboBox folderLocation;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
    }
}

