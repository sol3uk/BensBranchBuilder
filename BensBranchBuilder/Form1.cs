using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public BensBranchBuilder()
		{
			InitializeComponent();
			if (File.Exists("cache.txt"))
			{
				// Open the stream and read it back.    
				using (StreamReader sr = File.OpenText("cache.txt"))
				{
					string s = "";
					while ((s = sr.ReadLine()) != null)
					{
						textBox1.Text = s;
					}
				}
			}
		}

		public enum ProcessType
		{
			Restore = 1,
			Build = 2,
			Rebuild = 3
		}

		public string batPath { get; set; } = @"BatFiles\";
		public string buildCMDProject { get; set; } = @"MSBuild.exe .\web\Web\JobLogic\JobLogic.csproj /property:WarningLevel=0 -maxcpucount:4";
		public string buildCMDSolution { get; set; } = @"Msbuild.exe .\web\JobLogic.Published.sln /property:WarningLevel=0 -maxcpucount:4";

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
			
			var vs2017DevCMD = @"""C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat""";
			if (File.Exists(batPath + batFileName))
				File.Delete(batPath + batFileName);

			var batFile =
			@"call " + vs2017DevCMD + Environment.NewLine +
			@"echo cd " + customPath + Environment.NewLine +
			@"cd " + customPath + Environment.NewLine +
			@"echo..\NuGet.exe restore .\web\JobLogic.Published.sln" + Environment.NewLine +
			@"..\NuGet.exe restore .\web\JobLogic.Published.sln" + Environment.NewLine;
			if (process == ProcessType.Build)
			{
				batFile += @"echo " + buildCMDProject + Environment.NewLine +
								@"" + buildCMDProject + Environment.NewLine;
				if (checkBox1.Checked)
				{
					batFile += @"echo " + buildCMDSolution + Environment.NewLine +
									@"" + buildCMDSolution + Environment.NewLine;
				}
			}
			else if (process == ProcessType.Rebuild)
			{
				batFile += @"echo " + buildCMDProject + " /t:rebuild" + Environment.NewLine +
								@"" + buildCMDProject + " /t:rebuild" + Environment.NewLine;
				if (checkBox1.Checked)
				{
					batFile += @"echo " + buildCMDSolution + " /t:rebuild" + Environment.NewLine +
									@"" + buildCMDSolution + " /t:rebuild" + Environment.NewLine;
				}
			}

			batFile += @"pause";
			// Creates new bat file
			using (FileStream fs = File.Create(batPath + batFileName))
			{
				Byte[] fileData = new UTF8Encoding(true).GetBytes(batFile);
				fs.Write(fileData, 0, fileData.Length);
			}

			return batFileName;
		}

		public void SaveLastPath()
		{
			// Creates new file
			using (FileStream fs = File.Create(@"cache.txt"))
			{
				Byte[] fileData = new UTF8Encoding(true).GetBytes(textBox1.Text);
				fs.Write(fileData, 0, fileData.Length);
			}
		}

		public void RunBatFile(ProcessType process)
		{
			var fileName = "";
			Process proc = null;
			try
			{
				if (Directory.Exists(textBox1.Text))
				{
					fileName = BuildBatFile(process, textBox1.Text);
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
				textBox1.Text = folderBrowserDialog1.SelectedPath;
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
		#endregion
	}
}
