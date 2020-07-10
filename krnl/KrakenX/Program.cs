using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KrakenX
{
	// Token: 0x02000003 RID: 3
	internal static class Program
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00006710 File Offset: 0x00006710
		[STAThread]
		private static void Main()
		{
			bool flag = Process.GetProcessesByName("Kraken").Length != 0;
			if (flag)
			{
				foreach (Process process in Process.GetProcessesByName("Kraken"))
				{
					process.Kill();
				}
				bool flag2 = !Environment.Is64BitOperatingSystem;
				if (flag2)
				{
					MessageBox.Show("Warning, your system is running in a 32 bit platform. Kraken was designed to run on 64 bit platforms. If you experience problems, you may contact support but we do not guarantee a solution.", "Vegie is senpai :3");
				}
				Application.SetCompatibleTextRenderingDefault(false);
				bool flag3 = !Vegie_s_Dependency_Checker.IsInstalled(RedistributablePackageVersion.VC2015x86);
				if (flag3)
				{
					bool flag4 = !Vegie_s_Dependency_Checker.IsInstalled(RedistributablePackageVersion.VC2017x86);
					if (flag4)
					{
						bool flag5 = !Vegie_s_Dependency_Checker.IsInstalled(RedistributablePackageVersion.VC2015to2019x86);
						if (flag5)
						{
							MessageBox.Show("Kraken is missing a dependency, Please install VCRedist X86 - 2015, 2017, or 2019", "Vegie's Dependency Checker");
							Application.Exit();
						}
					}
				}
				bool flag6 = !File.Exists("discord-rpc-w32.dll");
				if (flag6)
				{
					MessageBox.Show("Missing discord-rpc-w32.dll!", "Vegie Is Senpai :3");
				}
				else
				{
					try
					{
						Vegie_s_Scanner.ScanAndKill();
					}
					catch
					{
						Console.WriteLine("Security!, Krakens's Scanner Failed!");
						Vegie_s_Functions.KillProcess(AppDomain.CurrentDomain.FriendlyName.Replace(".exe", ""));
					}
					Vegie_s_RPC vegie_s_RPC = new Vegie_s_RPC();
					vegie_s_RPC.Initialize("704520720218325106");
					vegie_s_RPC.UpdatePresence("Running AntiTamper...", "Exploiting With Kraken");
					Program.LoadConfig();
					try
					{
						File.Delete("start.bat");
					}
					catch
					{
					}
				}
			}
			else
			{
				MessageBox.Show("Please start Kraken via Kraken Bootstrapper.", "Vegie is senpai :3");
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000068A4 File Offset: 0x000068A4
		private static void LoadConfig()
		{
			try
			{
				string text = File.ReadLines("kraken.config").Skip(1).Take(1).First<string>().Replace("r: ", "");
				string text2 = File.ReadLines("kraken.config").Skip(2).Take(1).First<string>().Replace("g: ", "");
				string text3 = File.ReadLines("kraken.config").Skip(3).Take(1).First<string>().Replace("b: ", "");
				string text4 = File.ReadLines("kraken.config").Skip(5).Take(1).First<string>().Replace("r: ", "");
				string text5 = File.ReadLines("kraken.config").Skip(5).Take(1).First<string>().Replace("g: ", "");
				string text6 = File.ReadLines("kraken.config").Skip(5).Take(1).First<string>().Replace("b: ", "");
				string text7 = File.ReadLines("kraken.config").Skip(9).Take(1).First<string>().Replace("r: ", "");
				string text8 = File.ReadLines("kraken.config").Skip(10).Take(1).First<string>().Replace("g: ", "");
				string text9 = File.ReadLines("kraken.config").Skip(11).Take(1).First<string>().Replace("b: ", "");
				string text10 = File.ReadLines("kraken.config").Skip(12).Take(1).First<string>().Replace("title_text: ", "");
				bool flag = Program.ReturnBool(File.ReadLines("kraken.config").Skip(13).Take(1).First<string>().Replace("discordrpc: ", ""));
				bool flag2 = Program.ReturnBool(File.ReadLines("kraken.config").Skip(14).Take(1).First<string>().Replace("autoattach: ", ""));
				bool flag3 = Program.ReturnBool(File.ReadLines("kraken.config").Skip(15).Take(1).First<string>().Replace("topmost: ", ""));
				Application.EnableVisualStyles();
				Application.Run(new KrakenX());
			}
			catch (Exception ex)
			{
				string str = "Corrupted Config! Error: ";
				Exception ex2 = ex;
				MessageBox.Show(str + ((ex2 != null) ? ex2.ToString() : null), "Vegie is senpai :3");
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00006B5C File Offset: 0x00006B5C
		private static bool ReturnBool(string str_bool)
		{
			bool flag = str_bool.ToLower() == "true";
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = str_bool.ToLower() == "false";
				result = (flag2 && false);
			}
			return result;
		}

		// Token: 0x04000019 RID: 25
		public static string Pipe = "krnlpipe";

		// Token: 0x0400001A RID: 26
		public static string DLLPath = Directory.GetCurrentDirectory() + "\\krnl.dll";
	}
}
