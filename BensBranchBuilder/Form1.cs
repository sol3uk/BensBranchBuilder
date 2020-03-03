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

		const string noSolutionError = "Solution not found. Solution can be changed in settings.";

		public string BatPath { get; set; } = @"BatFiles\";
		public string BuildCMDProject { get; set; } = @"MSBuild.exe .\web\Web\JobLogic\JobLogic.csproj /property:WarningLevel=0 -maxcpucount:4";
		public string SolutionName { get; set; }
		public string BuildCMDSolution { get; set; }
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
			SolutionName = ConfigurationManager.AppSettings["SolutionName"];
			BuildCMDSolution = @"Msbuild.exe .\web\" + SolutionName + ".sln /property:WarningLevel=0 -maxcpucount:4";
			SavedFolders = ConfigurationManager.AppSettings["SavedFolders"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
			folderLocation.Items.AddRange(SavedFolders.ToArray());
		}

		public void RefreshValues()
		{
			//Forces access to the config file and allows them to be re-evaluated
			ConfigurationManager.RefreshSection("appSettings");
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
			RefreshValues();

			//Checks if nuget.exe is available
			var nuGetCheck = customPath.Substring(0, customPath.LastIndexOf(@"\")) + @"\nuget.exe";
			//Checks if solution is available
			var solutionCheck = customPath + @"\web\" + SolutionName + ".sln";
			if (File.Exists(nuGetCheck) && File.Exists(solutionCheck))
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
				@"@echo off" + Environment.NewLine;
				//Checks custom install location and uses 2017 by default if none found
				var emptySetting = @"""" + @"""";
				if (string.IsNullOrEmpty(CMDInstallLocation) || CMDInstallLocation == emptySetting)
				{
					MessageBox.Show("Custom dev console not found. Attempting to use VS 2017.");
					batFile += @"call " + Vs2017DevCMD + Environment.NewLine;
				}
				else
				{
					batFile += @"call " + CMDInstallLocation + Environment.NewLine;
				}
				batFile +=
				//@"echo cd " + customPath + Environment.NewLine +
				@"cd " + customPath + Environment.NewLine +
				//@"echo..\nuget.exe restore .\web\" + SolutionName + ".sln" + Environment.NewLine +
				@"..\nuget.exe restore .\web\" + SolutionName + ".sln" + Environment.NewLine;
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
				Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\BatFiles");
				using (FileStream fs = File.Create(BatPath + batFileName))
				{
					Byte[] fileData = new UTF8Encoding(true).GetBytes(batFile);
					fs.Write(fileData, 0, fileData.Length);
				}

				return batFileName;
			}
			else if (!File.Exists(nuGetCheck))
			{
				MessageBox.Show("nuget.exe not found. Please ensure you have a copy of nuget.exe placed in : " + customPath.Substring(0, customPath.LastIndexOf(@"\")));
				return null;
			}
			else if (!File.Exists(solutionCheck))
			{
				MessageBox.Show(noSolutionError);
				return null;
			}
			else
			{
				MessageBox.Show("Something unexpected went wrong!");
				return null;
			}
		}

		public void SaveLastPath()
		{
			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			// Save the changes in App.config file.
			config.AppSettings.Settings["CachedFolderLocation"].Value = CachedFolderLocation;
			config.AppSettings.Settings["SavedFolders"].Value = string.Join(",", SavedFolders);
			config.Save(ConfigurationSaveMode.Modified);
		}


		public void RunBatFile(ProcessType process)
		{
			var fileName = "";
			Process proc = null;
			try
			{
				cleanInputBox();
				if (Directory.Exists(folderLocation.Text))
				{
					fileName = BuildBatFile(process, folderLocation.Text);
					if (!string.IsNullOrEmpty(fileName))
					{
						proc = new Process();
						Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\BatFiles");
						proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\BatFiles";
						//proc.StartInfo.FileName = "BuildPrestaging.bat";
						proc.StartInfo.FileName = fileName;
						proc.StartInfo.CreateNoWindow = false;
						//MessageBox.Show(proc.StartInfo.WorkingDirectory);
						proc.Start();
					}
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

		private void cleanInputBox()
		{
			var path = folderLocation.Text;
			if (path[path.Length - 1].ToString() == @"\") 
				path = path.Remove(path.Length - 1, 1);

			folderLocation.Text = path;
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
		//nuget Restore
		private void button1_Click(object sender, EventArgs e)
		{
			var process = ProcessType.Restore;
			RunBatFile(process);
		}
		//Build
		private void button2_Click(object sender, EventArgs e)
		{
			var process = ProcessType.Build;
			RunBatFile(process);
		}
		//Rebuild
		private void button3_Click(object sender, EventArgs e)
		{
			var process = ProcessType.Rebuild;
			RunBatFile(process);
		}

		//Add Folder to Favourites
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
				//Checks if nuget.exe is available
				var nuGetPathCheck = folderLocation.Text.Substring(0, folderLocation.Text.LastIndexOf(@"\")) + @"\nuget.exe";
				//Checks if solution is available
				var solutionCheck = folderLocation.Text + @"\web\" + SolutionName + ".sln";

				if (!File.Exists(nuGetPathCheck)) CopyNuGetToPath(nuGetPathCheck);

				if (File.Exists(nuGetPathCheck) && File.Exists(solutionCheck))
				{
					var confirm = MessageBox.Show("Are you sure you want to add this path to your favourites?", "Are you sure?", MessageBoxButtons.YesNo);
					if (confirm == DialogResult.Yes)
					{
						CachedFolderLocation = folderLocation.Text;
						SavedFolders.Add(folderLocation.Text);
						folderLocation.Items.Add(folderLocation.Text);
						SaveLastPath();
					}
				}
				else
				{
					if (!File.Exists(nuGetPathCheck))
						MessageBox.Show("nuget.exe not found. Please ensure you have a copy of nuget.exe placed in : " + folderLocation.Text.Substring(0, folderLocation.Text.LastIndexOf(@"\")));
					if (!File.Exists(solutionCheck))
						MessageBox.Show(noSolutionError);
				}
			}
		}

		private static void CopyNuGetToPath(string copyToPath)
		{
			File.Copy(Directory.GetCurrentDirectory() + @"\Resources\nuget.exe", copyToPath, true);

			MessageBox.Show("nuget.exe copied to: " + copyToPath);
		}

		//Settings button
		private void button6_Click(object sender, EventArgs e)
		{
			SettingsForm settings = new SettingsForm();
			settings.Show();
			settings.CMDInstallLocation = ConfigurationManager.AppSettings["CMDInstallLocation"];
			settings.SavedDevCMDs = ConfigurationManager.AppSettings["SavedDevCMDs"].Split(',').Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()).ToList();
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

	}
}
