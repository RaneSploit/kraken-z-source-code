using System;
using System.IO;
using System.Linq;
using KrakenAlert;

namespace KrakenX
{
	// Token: 0x02000010 RID: 16
	internal class Vegie_s_RPC
	{
		// Token: 0x06000068 RID: 104 RVA: 0x0000B9B0 File Offset: 0x0000B9B0
		public void Initialize(string clientId)
		{
			bool flag = Vegie_s_RPC.ReturnBool(File.ReadLines("kraken.config").Skip(13).Take(1).First<string>().Replace("discordrpc: ", ""));
			bool flag2 = flag;
			if (flag2)
			{
				this.handlers = default(RPCLib.EventHandlers);
				this.handlers.readyCallback = new RPCLib.ReadyCallback(this.ReadyCallback);
				this.handlers.disconnectedCallback = (RPCLib.DisconnectedCallback)Delegate.Combine(this.handlers.disconnectedCallback, new RPCLib.DisconnectedCallback(this.DisconnectedCallback));
				this.handlers.errorCallback = (RPCLib.ErrorCallback)Delegate.Combine(this.handlers.errorCallback, new RPCLib.ErrorCallback(this.ErrorCallback));
				RPCLib.Initialize(clientId, ref this.handlers, true, null);
				Console.WriteLine("Init Complete");
				RPCLib.RunCallbacks();
				Console.WriteLine("RunCallback Done!");
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000BAA4 File Offset: 0x0000BAA4
		public void UpdatePresence(string details, string state)
		{
			bool flag = Vegie_s_RPC.ReturnBool(File.ReadLines("kraken.config").Skip(13).Take(1).First<string>().Replace("discordrpc: ", ""));
			bool flag2 = flag;
			if (flag2)
			{
				this.presence.details = details;
				this.presence.state = state;
				long startTimestamp;
				bool flag3 = long.TryParse("0", out startTimestamp);
				if (flag3)
				{
					this.presence.startTimestamp = startTimestamp;
				}
				long endTimestamp;
				bool flag4 = long.TryParse("0", out endTimestamp);
				if (flag4)
				{
					this.presence.endTimestamp = endTimestamp;
				}
				this.presence.largeImageKey = "kraken_512";
				this.presence.largeImageText = "Kraken X";
				this.presence.smallImageKey = "vegie_logo";
				this.presence.smallImageText = "Made By Vegie";
				RPCLib.UpdatePresence(ref this.presence);
				Console.WriteLine("Presence Updated");
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000BBA0 File Offset: 0x0000BBA0
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

		// Token: 0x0600006B RID: 107 RVA: 0x0000BBE5 File Offset: 0x0000BBE5
		private void Shutdown()
		{
			SendNotification.Alert("RPC Disabled!", 0);
			RPCLib.Shutdown();
			Console.WriteLine("Closing");
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000BC05 File Offset: 0x0000BC05
		private void ReadyCallback()
		{
			Console.WriteLine("Ready");
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000BC13 File Offset: 0x0000BC13
		private void DisconnectedCallback(int errorCode, string message)
		{
			Console.WriteLine("Disconnected");
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000BC21 File Offset: 0x0000BC21
		private void ErrorCallback(int errorCode, string message)
		{
			Console.WriteLine("Error");
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000BC30 File Offset: 0x0000BC30
		private long DateTimeToTimestamp(DateTime dt)
		{
			return (dt.Ticks - 621355968000000000L) / 10000000L;
		}

		// Token: 0x04000068 RID: 104
		private RPCLib.RichPresence presence;

		// Token: 0x04000069 RID: 105
		private RPCLib.EventHandlers handlers;
	}
}
