using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace krnl_rewrite
{
	// Token: 0x02000014 RID: 20
	internal class certificate_handler
	{
		// Token: 0x0600008D RID: 141 RVA: 0x0000C488 File Offset: 0x0000C488
		public static void InstallCert(string Path)
		{
			X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadWrite);
			x509Store.Add(new X509Certificate2(X509Certificate.CreateFromCertFile(Path)));
			x509Store.Close();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000C4C0 File Offset: 0x0000C4C0
		public static bool IsCertInstalled(string ThumbPrint)
		{
			X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			x509Store.Open(OpenFlags.ReadOnly);
			X509Certificate2Collection x509Certificate2Collection = x509Store.Certificates.Find(X509FindType.FindByThumbprint, ThumbPrint, false);
			return x509Certificate2Collection != null && x509Certificate2Collection.Count > 0;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000C50C File Offset: 0x0000C50C
		public static void Download_Cert()
		{
			try
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\kuul\\");
			}
			catch
			{
			}
			WebClient webClient = new WebClient();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/711694951359971328/712783185280499823/vegie.crt", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\kuul\\vegie.crt");
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000C570 File Offset: 0x0000C570
		public static void Redirect_Traffic(string target, string destination)
		{
			bool flag = !File.Exists("C:\\Windows\\System32\\drivers\\etc\\hosts");
			if (flag)
			{
				try
				{
					File.Create("C:\\Windows\\System32\\drivers\\etc\\hosts");
				}
				catch
				{
					MessageBox.Show("Failed to create Hosts File!", "krnl_rewrite");
				}
			}
			bool flag2 = !File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts").Contains(destination + " " + target);
			if (flag2)
			{
				try
				{
					File.WriteAllText("C:\\Windows\\System32\\drivers\\etc\\hosts", string.Concat(new string[]
					{
						File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts"),
						"\n",
						destination,
						" ",
						target
					}));
				}
				catch
				{
					MessageBox.Show("Error, Couldn't Redirect Network Traffic!", "krnl_rewrite");
				}
			}
		}
	}
}
