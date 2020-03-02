using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BensBranchBuilder
{
	public partial class SettingsForm : Form
	{
		public string CMDInstallLocation { get; set; }
		public List<string> SavedDevCMDs { get; set; }

		public SettingsForm()
		{
			InitializeComponent();

			ConfigurationManager.RefreshSection("appSettings");
			consoleLocation.Text = ConfigurationManager.AppSettings["CMDInstallLocation"];
			SavedDevCMDs = ConfigurationManager.AppSettings["SavedDevCMDs"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
			consoleLocation.Items.AddRange(SavedDevCMDs.ToArray());
		}

		public void RefreshValues()
		{
			ConfigurationManager.RefreshSection("appSettings");
			//Clear Values
			consoleLocation.Text = "";
			consoleLocation.Items.Clear();
			SavedDevCMDs.Clear();

			//Reassign Values
			consoleLocation.Text = ConfigurationManager.AppSettings["CMDInstallLocation"];
			SavedDevCMDs = ConfigurationManager.AppSettings["SavedDevCMDs"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
			consoleLocation.Items.AddRange(SavedDevCMDs.ToArray());
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			RefreshValues();
		}
		public void AddToCombo()
		{
			if (string.IsNullOrEmpty(consoleLocation.Text))
			{
				MessageBox.Show("Path empty!");
			}
			else
			{
				SavedDevCMDs.Add(consoleLocation.Text);
				consoleLocation.Items.Add(consoleLocation.Text);
			}
		}
		public void SaveSettings()
		{
			if (!SavedDevCMDs.Contains(consoleLocation.Text))
				AddToCombo();
			if (!string.IsNullOrEmpty(consoleLocation.Text))
			{
				System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

				// Save the changes in App.config file.
				config.AppSettings.Settings["CMDInstallLocation"].Value = consoleLocation.Text;
				config.AppSettings.Settings["SavedDevCMDs"].Value = string.Join(",", SavedDevCMDs);
				config.Save(ConfigurationSaveMode.Modified);
				MessageBox.Show("Dev Console Set");
				this.Close();
			}

		}

		//Add to Favourites
		private void button5_Click(object sender, EventArgs e)
		{
			if (SavedDevCMDs.Contains(consoleLocation.Text))
			{
				MessageBox.Show("You've already added this dev console!");
			}
			else
			{
				AddToCombo();
			}
		}
		//Select Path
		private void button4_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				consoleLocation.Text = openFileDialog1.FileName;
			}
		}

		//Clear Favourites
		private void button2_Click(object sender, EventArgs e)
		{
			ClearFavourites();
		}

		//Save
		private void button1_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}


		public void ClearFavourites()
		{
			var confirm = MessageBox.Show("Are you sure?", "Are you sure you want to clear favourite locations?", MessageBoxButtons.YesNo);
			if (confirm == DialogResult.Yes)
				ConfigurationManager.AppSettings["SavedFolders"] = "";
		}





		private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{

		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

	}
}
