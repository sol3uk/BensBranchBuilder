using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BensBranchBuilder
{
	public partial class BensBranchBuilder : Form
	{
		public enum ProcessType
		{
			Restore = 1,
			Build = 2,
			Rebuild = 3
		}

		public string BatPath { get; set; } = @"BatFiles\";
		public string BuildCMDProject { get; set; } = @"MSBuild.exe .\web\Web\JobLogic\JobLogic.csproj /property:WarningLevel=0 -maxcpucount:4";
		public string BuildCMDSolution { get; set; } = @"Msbuild.exe .\web\JobLogic.Published.sln /property:WarningLevel=0 -maxcpucount:4";
		public string Vs2017DevCMD { get; set; } = @"""C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat""";
		public string CMDInstallLocation { get; set; }
		public string CachedFolderLocation { get; set; }
		public List<string> SavedFolders { get; set; }

		public BensBranchBuilder()
		{
			InitializeComponent();

			folderLocation.Text = "";
			folderLocation.Items.Clear();

			//Get setting from app config
			folderLocation.Text = ConfigurationManager.AppSettings["CachedFolderLocation"];
			CMDInstallLocation = @"""" + ConfigurationManager.AppSettings["CMDInstallLocation"] + @"""";
			SavedFolders = ConfigurationManager.AppSettings["SavedFolders"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
			folderLocation.Items.AddRange(SavedFolders.ToArray());
		}

		public void RefreshValues()
		{
			//Clear Values
			folderLocation.Text = "";
			folderLocation.Items.Clear();
			SavedFolders.Clear();
			//Get setting from app config
			folderLocation.Text = ConfigurationManager.AppSettings["CachedFolderLocation"];
			CMDInstallLocation = @"""" + ConfigurationManager.AppSettings["CMDInstallLocation"] + @"""";
			SavedFolders = ConfigurationManager.AppSettings["SavedFolders"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
			folderLocation.Items.AddRange(SavedFolders.ToArray());
		}

		private void BensBranchBuilder_Load(object sender, EventArgs e)
		{
			RefreshValues();
		}

		public string BuildBatFile(ProcessType process, string customPath)
		{
			//Initialise and set bat file name
			var batFileName = "";
			switch (process)
			{
				case ProcessType.Restore:
					batFileName = "BranchRestore.bat";
					break;
				case ProcessType.Build:
					batFileName = "BranchBuild.bat";
					break;
				case ProcessType.Rebuild:
					batFileName = "BranchRebuild.bat";
					break;
				default:
					break;
			}


			if (File.Exists(BatPath + batFileName))
				File.Delete(BatPath + batFileName);

			var batFile =
			@"call " + Vs2017DevCMD + Environment.NewLine +
			@"echo cd " + customPath + Environment.NewLine +
			@"cd " + customPath + Environment.NewLine +
			@"echo..\NuGet.exe restore .\web\JobLogic.Published.sln" + Environment.NewLine +
			@"..\NuGet.exe restore .\web\JobLogic.Published.sln" + Environment.NewLine;
			if (process == ProcessType.Build)
			{
				batFile += @"echo " + BuildCMDProject + Environment.NewLine +
								@"" + BuildCMDProject + Environment.NewLine;
				if (inputBox.Checked)
				{
					batFile += @"echo " + BuildCMDSolution + Environment.NewLine +
									@"" + BuildCMDSolution + Environment.NewLine;
				}
			}
			else if (process == ProcessType.Rebuild)
			{
				batFile += @"echo " + BuildCMDProject + " /t:rebuild" + Environment.NewLine +
								@"" + BuildCMDProject + " /t:rebuild" + Environment.NewLine;
				if (inputBox.Checked)
				{
					batFile += @"echo " + BuildCMDSolution + " /t:rebuild" + Environment.NewLine +
									@"" + BuildCMDSolution + " /t:rebuild" + Environment.NewLine;
				}
			}

			batFile += @"pause";
			// Creates new bat file
			using (FileStream fs = File.Create(BatPath + batFileName))
			{
				Byte[] fileData = new UTF8Encoding(true).GetBytes(batFile);
				fs.Write(fileData, 0, fileData.Length);
			}

			return batFileName;
		}

		public void SaveLastPath()
		{
			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			// Save the changes in App.config file.
			config.AppSettings.Settings["CachedFolderLocation"].Value = folderLocation.Text;
			config.AppSettings.Settings["SavedFolders"].Value = string.Join(",", SavedFolders);
			config.Save(ConfigurationSaveMode.Modified);
		}

		public void RunBatFile(ProcessType process)
		{
			var fileName = "";
			Process proc = null;
			try
			{
				if (Directory.Exists(folderLocation.Text))
				{
					fileName = BuildBatFile(process, folderLocation.Text);
					proc = new Process();
					proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\BatFiles";
					//proc.StartInfo.FileName = "BuildPrestaging.bat";
					proc.StartInfo.FileName = fileName;
					proc.StartInfo.CreateNoWindow = false;
					//MessageBox.Show(proc.StartInfo.WorkingDirectory);
					proc.Start();
					SaveLastPath();
					Application.Exit();
				}
				else
					MessageBox.Show("Directory doesn't exist!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace.ToString());
			}
		}

		#region Buttons
		//Folder Select
		private void button4_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				folderLocation.Text = folderBrowserDialog1.SelectedPath;
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			var process = ProcessType.Restore;
			RunBatFile(process);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var process = ProcessType.Build;
			RunBatFile(process);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var process = ProcessType.Rebuild;
			RunBatFile(process);
		}
		#endregion

		#region UnusedEvents
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}
		private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{

		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}


		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{

		}
		#endregion

		private void button5_Click(object sender, EventArgs e)
		{
			if (SavedFolders.Contains(folderLocation.Text))
			{
				MessageBox.Show("You've already added this folder!");
			}
			else if (string.IsNullOrEmpty(folderLocation.Text))
			{
				MessageBox.Show("Path empty!");
			}
			else
			{
				var confirm = MessageBox.Show("Are you sure?", "Add path to favourites", MessageBoxButtons.YesNo);
				if (confirm == DialogResult.Yes)
				{
					SavedFolders.Add(folderLocation.Text);
					folderLocation.Items.Add(folderLocation.Text);
				}
			}
		}

		//Settings button
		private void button6_Click(object sender, EventArgs e)
		{
			SettingsForm settings = new SettingsForm();
			settings.Show();
			settings.CMDInstallLocation = ConfigurationManager.AppSettings["CMDInstallLocation"];
			settings.SavedDevCMDs = ConfigurationManager.AppSettings["SavedDevCMDs"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
		}
	}
}
