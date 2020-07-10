using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace KrakenX
{
	// Token: 0x02000011 RID: 17
	internal class Vegie_s_Scanner
	{
		// Token: 0x06000071 RID: 113 RVA: 0x0000BC5C File Offset: 0x0000BC5C
		public static void ScanAndKill()
		{
			bool flag = Vegie_s_Scanner.Scan(true) != 0;
			if (flag)
			{
				Environment.FailFast("MY Cock HURTS! - Vegie");
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000BC84 File Offset: 0x0000BC84
		private static int Scan(bool KillProcess)
		{
			int result = 0;
			bool flag = Vegie_s_Scanner.BadProcessnameList.Count == 0 && Vegie_s_Scanner.BadWindowTextList.Count == 0;
			if (flag)
			{
				Vegie_s_Scanner.Init();
			}
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				bool flag2 = Vegie_s_Scanner.BadProcessnameList.Contains(process.ProcessName) || Vegie_s_Scanner.BadWindowTextList.Contains(process.MainWindowTitle);
				if (flag2)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("BAD PROCESS FOUND: " + process.ProcessName);
					result = 1;
					if (KillProcess)
					{
						try
						{
							process.Kill();
						}
						catch (Win32Exception ex)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("Win32Exception: " + ex.Message);
						}
						catch (NotSupportedException ex2)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("NotSupportedException: " + ex2.Message);
						}
						catch (InvalidOperationException ex3)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("InvalidOperationException: " + ex3.Message);
						}
					}
					break;
				}
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000BDEC File Offset: 0x0000BDEC
		private static int Init()
		{
			bool flag = Vegie_s_Scanner.BadProcessnameList.Count > 0 && Vegie_s_Scanner.BadWindowTextList.Count > 0;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				Vegie_s_Scanner.BadProcessnameList.Add("ollydbg");
				Vegie_s_Scanner.BadProcessnameList.Add("ida");
				Vegie_s_Scanner.BadProcessnameList.Add("ida64");
				Vegie_s_Scanner.BadProcessnameList.Add("idag");
				Vegie_s_Scanner.BadProcessnameList.Add("idag64");
				Vegie_s_Scanner.BadProcessnameList.Add("idaw");
				Vegie_s_Scanner.BadProcessnameList.Add("idaw64");
				Vegie_s_Scanner.BadProcessnameList.Add("idaq");
				Vegie_s_Scanner.BadProcessnameList.Add("idaq64");
				Vegie_s_Scanner.BadProcessnameList.Add("idau");
				Vegie_s_Scanner.BadProcessnameList.Add("idau64");
				Vegie_s_Scanner.BadProcessnameList.Add("scylla");
				Vegie_s_Scanner.BadProcessnameList.Add("scylla_x64");
				Vegie_s_Scanner.BadProcessnameList.Add("scylla_x86");
				Vegie_s_Scanner.BadProcessnameList.Add("protection_id");
				Vegie_s_Scanner.BadProcessnameList.Add("x64dbg");
				Vegie_s_Scanner.BadProcessnameList.Add("x32dbg");
				Vegie_s_Scanner.BadProcessnameList.Add("windbg");
				Vegie_s_Scanner.BadProcessnameList.Add("reshacker");
				Vegie_s_Scanner.BadProcessnameList.Add("ImportREC");
				Vegie_s_Scanner.BadProcessnameList.Add("IMMUNITYDEBUGGER");
				Vegie_s_Scanner.BadProcessnameList.Add("HTTPDebuggerSvc");
				Vegie_s_Scanner.BadProcessnameList.Add("wireshark");
				Vegie_s_Scanner.BadProcessnameList.Add("dnSpy");
				Vegie_s_Scanner.BadProcessnameList.Add("dnSpy-x86");
				Vegie_s_Scanner.BadProcessnameList.Add("fiddler");
				Vegie_s_Scanner.BadWindowTextList.Add("OLLYDBG");
				Vegie_s_Scanner.BadWindowTextList.Add("ida");
				Vegie_s_Scanner.BadWindowTextList.Add("disassembly");
				Vegie_s_Scanner.BadWindowTextList.Add("scylla");
				Vegie_s_Scanner.BadWindowTextList.Add("Debug");
				Vegie_s_Scanner.BadWindowTextList.Add("[CPU");
				Vegie_s_Scanner.BadWindowTextList.Add("Immunity");
				Vegie_s_Scanner.BadWindowTextList.Add("WinDbg");
				Vegie_s_Scanner.BadWindowTextList.Add("x32dbg");
				Vegie_s_Scanner.BadWindowTextList.Add("x64dbg");
				Vegie_s_Scanner.BadWindowTextList.Add("Import reconstructor");
				Vegie_s_Scanner.BadWindowTextList.Add("MegaDumper");
				Vegie_s_Scanner.BadWindowTextList.Add("HTTPDebuggerSvc");
				Vegie_s_Scanner.BadWindowTextList.Add("wireshark");
				Vegie_s_Scanner.BadWindowTextList.Add("dnSpy");
				Vegie_s_Scanner.BadWindowTextList.Add("dnSpy-x86");
				Vegie_s_Scanner.BadWindowTextList.Add("fiddler");
				result = 0;
			}
			return result;
		}

		// Token: 0x0400006A RID: 106
		private static HashSet<string> BadProcessnameList = new HashSet<string>();

		// Token: 0x0400006B RID: 107
		private static HashSet<string> BadWindowTextList = new HashSet<string>();
	}
}
