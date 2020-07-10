using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using KrakenAlert;

namespace KrakenX
{
	// Token: 0x0200000E RID: 14
	internal sealed class Vegie_s_Injector
	{
		// Token: 0x0600005C RID: 92
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		// Token: 0x0600005D RID: 93
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		// Token: 0x0600005E RID: 94
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		// Token: 0x0600005F RID: 95
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000060 RID: 96
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x06000061 RID: 97
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

		// Token: 0x06000062 RID: 98
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000063 RID: 99 RVA: 0x0000B768 File Offset: 0x0000B768
		private static Vegie_s_Injector GetInstance
		{
			get
			{
				bool flag = Vegie_s_Injector._instance == null;
				bool flag2 = flag;
				if (flag2)
				{
					Vegie_s_Injector._instance = new Vegie_s_Injector();
				}
				return Vegie_s_Injector._instance;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000B79C File Offset: 0x0000B79C
		public DllInjectionResult Inject(string sProcName, string sDllPath)
		{
			bool flag = !File.Exists(sDllPath);
			bool flag2 = flag;
			DllInjectionResult result;
			if (flag2)
			{
				SendNotification.Alert("DLL is missing, turn off your antivirus!", 2);
				result = DllInjectionResult.DllNotFound;
			}
			else
			{
				uint num = 0U;
				Process[] processes = Process.GetProcesses();
				for (int i = 0; i < processes.Length; i++)
				{
					bool flag3 = processes[i].ProcessName == sProcName;
					bool flag4 = flag3;
					if (flag4)
					{
						num = (uint)processes[i].Id;
						break;
					}
				}
				bool flag5 = num == 0U;
				bool flag6 = flag5;
				if (flag6)
				{
					MessageBox.Show("Roblox Isn't Open!", "Kraken");
					result = DllInjectionResult.GameProcessNotFound;
				}
				else
				{
					bool flag7 = !this.bInject(num, sDllPath);
					bool flag8 = flag7;
					if (flag8)
					{
						MessageBox.Show("Injection Failed!", "Kraken");
						result = DllInjectionResult.InjectionFailed;
					}
					else
					{
						result = DllInjectionResult.Success;
					}
				}
			}
			return result;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000B878 File Offset: 0x0000B878
		private bool bInject(uint pToBeInjected, string sDllPath)
		{
			IntPtr intPtr = Vegie_s_Injector.OpenProcess(1082U, 1, pToBeInjected);
			bool flag = intPtr == Vegie_s_Injector.INTPTR_ZERO;
			bool flag2 = flag;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				IntPtr procAddress = Vegie_s_Injector.GetProcAddress(Vegie_s_Injector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
				bool flag3 = procAddress == Vegie_s_Injector.INTPTR_ZERO;
				bool flag4 = flag3;
				if (flag4)
				{
					result = false;
				}
				else
				{
					IntPtr intPtr2 = Vegie_s_Injector.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)sDllPath.Length, 12288U, 64U);
					bool flag5 = intPtr2 == Vegie_s_Injector.INTPTR_ZERO;
					bool flag6 = flag5;
					if (flag6)
					{
						result = false;
					}
					else
					{
						byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
						bool flag7 = Vegie_s_Injector.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0;
						bool flag8 = flag7;
						if (flag8)
						{
							result = false;
						}
						else
						{
							bool flag9 = Vegie_s_Injector.CreateRemoteThread(intPtr, (IntPtr)null, Vegie_s_Injector.INTPTR_ZERO, procAddress, intPtr2, 0U, (IntPtr)null) == Vegie_s_Injector.INTPTR_ZERO;
							bool flag10 = flag9;
							if (flag10)
							{
								result = false;
							}
							else
							{
								Vegie_s_Injector.CloseHandle(intPtr);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04000061 RID: 97
		private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

		// Token: 0x04000062 RID: 98
		public static Vegie_s_Injector _instance;
	}
}
