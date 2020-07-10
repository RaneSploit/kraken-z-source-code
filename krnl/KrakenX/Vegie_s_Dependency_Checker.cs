using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace KrakenX
{
	// Token: 0x02000006 RID: 6
	internal class Vegie_s_Dependency_Checker
	{
		// Token: 0x0600003E RID: 62 RVA: 0x0000AC34 File Offset: 0x0000AC34
		public static bool IsInstalled(RedistributablePackageVersion redistributableVersion)
		{
			bool result;
			try
			{
				switch (redistributableVersion)
				{
				case RedistributablePackageVersion.VC2005x86:
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Products\\c1c4f01781cc94c4c8fb1542c0981a2a", false);
					bool flag = registryKey == null;
					if (flag)
					{
						return false;
					}
					object value = registryKey.GetValue("Version");
					bool flag2 = (int)value > 1;
					if (flag2)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2005x64:
				{
					RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Products\\1af2a8da7e60d0b429d7e6453b3d0182", false);
					bool flag3 = registryKey2 == null;
					if (flag3)
					{
						return false;
					}
					object value2 = registryKey2.GetValue("Version");
					bool flag4 = (int)value2 > 1;
					if (flag4)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2008x86:
				{
					RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Products\\6E815EB96CCE9A53884E7857C57002F0", false);
					bool flag5 = registryKey3 == null;
					if (flag5)
					{
						return false;
					}
					object value3 = registryKey3.GetValue("Version");
					bool flag6 = (int)value3 > 1;
					if (flag6)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2008x64:
				{
					RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Products\\67D6ECF5CD5FBA732B8B22BAC8DE1B4D", false);
					bool flag7 = registryKey4 == null;
					if (flag7)
					{
						return false;
					}
					object value4 = registryKey4.GetValue("Version");
					bool flag8 = (int)value4 > 1;
					if (flag8)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2010x86:
				{
					RegistryKey registryKey5 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Products\\1D5E3C0FEDA1E123187686FED06E995A", false);
					bool flag9 = registryKey5 == null;
					if (flag9)
					{
						return false;
					}
					object value5 = registryKey5.GetValue("Version");
					bool flag10 = (int)value5 > 1;
					if (flag10)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2010x64:
				{
					RegistryKey registryKey6 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Products\\1926E8D15D0BCE53481466615F760A7F", false);
					bool flag11 = registryKey6 == null;
					if (flag11)
					{
						return false;
					}
					object value6 = registryKey6.GetValue("Version");
					bool flag12 = (int)value6 > 1;
					if (flag12)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2012x86:
				{
					RegistryKey registryKey7 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies\\{33d1fd90-4274-48a1-9bc1-97e33d9c2d6f}", false);
					bool flag13 = registryKey7 == null;
					if (flag13)
					{
						return false;
					}
					object value7 = registryKey7.GetValue("Version");
					bool flag14 = ((string)value7).StartsWith("11");
					if (flag14)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2012x64:
				{
					RegistryKey registryKey8 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies\\{ca67548a-5ebe-413a-b50c-4b9ceb6d66c6}", false);
					bool flag15 = registryKey8 == null;
					if (flag15)
					{
						return false;
					}
					object value8 = registryKey8.GetValue("Version");
					bool flag16 = ((string)value8).StartsWith("11");
					if (flag16)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2013x86:
				{
					RegistryKey registryKey9 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies\\{f65db027-aff3-4070-886a-0d87064aabb1}", false);
					bool flag17 = registryKey9 == null;
					if (flag17)
					{
						return false;
					}
					object value9 = registryKey9.GetValue("Version");
					bool flag18 = ((string)value9).StartsWith("12");
					if (flag18)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2013x64:
				{
					RegistryKey registryKey10 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies\\{050d4fc8-5d48-4b8f-8972-47c82c46020f}", false);
					bool flag19 = registryKey10 == null;
					if (flag19)
					{
						return false;
					}
					object value10 = registryKey10.GetValue("Version");
					bool flag20 = ((string)value10).StartsWith("12");
					if (flag20)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2015x86:
				{
					RegistryKey registryKey11 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies\\{e2803110-78b3-4664-a479-3611a381656a}", false);
					bool flag21 = registryKey11 == null;
					if (flag21)
					{
						return false;
					}
					object value11 = registryKey11.GetValue("Version");
					bool flag22 = ((string)value11).StartsWith("14");
					if (flag22)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2015x64:
				{
					RegistryKey registryKey12 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Installer\\Dependencies\\{d992c12e-cab2-426f-bde3-fb8c53950b0d}", false);
					bool flag23 = registryKey12 == null;
					if (flag23)
					{
						return false;
					}
					object value12 = registryKey12.GetValue("Version");
					bool flag24 = ((string)value12).StartsWith("14");
					if (flag24)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2017x86:
				{
					List<string> list = new List<string>
					{
						"Installer\\Dependencies\\,,x86,14.0,bundle",
						"Installer\\Dependencies\\VC,redist.x86,x86,14.16,bundle"
					};
					foreach (string name in list)
					{
						RegistryKey registryKey13 = Registry.ClassesRoot.OpenSubKey(name, false);
						bool flag25 = registryKey13 == null;
						if (!flag25)
						{
							object value13 = registryKey13.GetValue("Version");
							bool flag26 = value13 == null;
							if (flag26)
							{
								return false;
							}
							bool flag27 = ((string)value13).StartsWith("14");
							if (flag27)
							{
								return true;
							}
						}
					}
					break;
				}
				case RedistributablePackageVersion.VC2017x64:
				{
					List<string> list2 = new List<string>
					{
						"Installer\\Dependencies\\,,amd64,14.0,bundle",
						"Installer\\Dependencies\\VC,redist.x64,amd64,14.16,bundle"
					};
					foreach (string name2 in list2)
					{
						RegistryKey registryKey14 = Registry.ClassesRoot.OpenSubKey(name2, false);
						bool flag28 = registryKey14 == null;
						if (!flag28)
						{
							object value14 = registryKey14.GetValue("Version");
							bool flag29 = value14 == null;
							if (flag29)
							{
								return false;
							}
							bool flag30 = ((string)value14).StartsWith("14");
							if (flag30)
							{
								return true;
							}
						}
					}
					break;
				}
				case RedistributablePackageVersion.VC2015to2019x86:
				{
					RegistryKey registryKey15 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\DevDiv\\VC\\Servicing\\14.0\\RuntimeMinimum", false);
					bool flag31 = registryKey15 == null;
					if (flag31)
					{
						return false;
					}
					object value15 = registryKey15.GetValue("Version");
					bool flag32 = ((string)value15).StartsWith("14");
					if (flag32)
					{
						return true;
					}
					break;
				}
				case RedistributablePackageVersion.VC2015to2019x64:
				{
					RegistryKey registryKey16 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\DevDiv\\VC\\Servicing\\14.0\\RuntimeMinimum", false);
					bool flag33 = registryKey16 == null;
					if (flag33)
					{
						return false;
					}
					object value16 = registryKey16.GetValue("Version");
					bool flag34 = ((string)value16).StartsWith("14");
					if (flag34)
					{
						return true;
					}
					break;
				}
				}
				result = false;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
