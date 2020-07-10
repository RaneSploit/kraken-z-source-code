using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using KrakenAlert;
using ScintillaNET;

namespace KrakenX
{
	// Token: 0x02000007 RID: 7
	internal class Vegie_s_Functions
	{
		// Token: 0x06000040 RID: 64 RVA: 0x0000B2F0 File Offset: 0x0000B2F0
		public static void KillProcess(string process)
		{
			try
			{
				foreach (Process process2 in Process.GetProcessesByName(process))
				{
					process2.Kill();
				}
			}
			catch
			{
				MessageBox.Show("Error!", "No");
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000B34C File Offset: 0x0000B34C
		public static void PopulateListBox(ListBox listbox, string folder, string filetype)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(folder);
			FileInfo[] files = directoryInfo.GetFiles(filetype);
			foreach (FileInfo fileInfo in files)
			{
				listbox.Items.Add(fileInfo.Name);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000B394 File Offset: 0x0000B394
		public static void SaveFile(string content)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Lua Script (*.lua)|*.lua|Text File (*.txt)|*.txt|All Files (*.*)|*.*";
				saveFileDialog.Title = "Imperial API: Save";
				saveFileDialog.ShowDialog();
				try
				{
					string[] contents = new string[]
					{
						content
					};
					File.WriteAllLines(saveFileDialog.FileName, contents);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Couldn't Save To Directory. Security Error: " + ex.Message);
				}
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000B42C File Offset: 0x0000B42C
		public static void KillRoblox()
		{
			try
			{
				foreach (Process process in Process.GetProcessesByName("RobloxPlayerBeta"))
				{
					process.Kill();
				}
				SendNotification.Alert("Roblox Killed!", 0);
			}
			catch
			{
				SendNotification.Alert("Couldn't Kill Roblox!", 2);
			}
		}

		// Token: 0x06000044 RID: 68
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WaitNamedPipe(string name, int timeout);

		// Token: 0x06000045 RID: 69 RVA: 0x0000B494 File Offset: 0x0000B494
		public static bool CheckPipe(string pipe)
		{
			bool result;
			try
			{
				int timeout = 0;
				bool flag = !Vegie_s_Functions.WaitNamedPipe(Path.GetFullPath(string.Format("\\\\\\\\.\\\\pipe\\\\{0}", pipe)), timeout);
				if (flag)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					bool flag2 = lastWin32Error == 0;
					if (flag2)
					{
						result = false;
						return result;
					}
					bool flag3 = lastWin32Error == 2;
					if (flag3)
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000B514 File Offset: 0x0000B514
		public static void OpenFile(Scintilla TextBox)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "Documents";
			openFileDialog.Filter = "Lua File(*.lua)| *.lua | Text File(*.txt) | *.txt";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Title = "Imperial API: Open";
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				try
				{
					Stream stream;
					bool flag2 = (stream = openFileDialog.OpenFile()) != null;
					if (flag2)
					{
						using (stream)
						{
							string text = File.ReadAllText(openFileDialog.FileName);
							TextBox.Text = text;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000B5E8 File Offset: 0x0000B5E8
		public static void GetIndicium()
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile("https://cdn.discordapp.com/attachments/661734956271403028/701235546697105449/Indicium-Supra.dll", Directory.GetCurrentDirectory() + "\\bin\\krnl\\Indicium-Supra.dll");
				Console.WriteLine("Incidium Updated!");
			}
			catch
			{
				Console.WriteLine("Kraken Couldn't Get Indicium, krnl will not inject without it!");
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000B648 File Offset: 0x0000B648
		public static void InjectIndicium()
		{
			try
			{
				new Vegie_s_Injector().Inject("RobloxPlayerBeta", Directory.GetCurrentDirectory() + "\\Indicium-Supra.dll");
				Thread.Sleep(600);
			}
			catch
			{
				Console.WriteLine("Kraken Couldn't Inject Indicium, krnl will not inject without it!");
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000B6A4 File Offset: 0x0000B6A4
		public static void UpdateDLL()
		{
			Vegie_s_Functions.GetIndicium();
			try
			{
				WebClient webClient = new WebClient();
				string text = webClient.DownloadString("https://gist.githubusercontent.com/Bi-nz/634f1dffea429053af1db665adee2233/raw");
				string[] separator = new string[]
				{
					",",
					""
				};
				string[] array = text.Split(separator, 100, StringSplitOptions.RemoveEmptyEntries);
				foreach (string text2 in array)
				{
					bool flag = text2.Contains("krnl.dll");
					if (flag)
					{
						webClient.DownloadFile(text2, Directory.GetCurrentDirectory() + "\\krnl.dll");
						Console.WriteLine("KRNL Updated!");
					}
				}
			}
			catch
			{
				Console.WriteLine("Couldn't Get krnl.dll");
			}
		}
	}
}
