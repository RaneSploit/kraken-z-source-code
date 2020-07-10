using System;
using System.Runtime.InteropServices;

namespace KrakenX
{
	// Token: 0x02000008 RID: 8
	internal class RPCLib
	{
		// Token: 0x0600004B RID: 75
		[DllImport("discord-rpc-w32", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Initialize")]
		public static extern void Initialize(string applicationId, ref RPCLib.EventHandlers handlers, bool autoRegister, string optionalSteamId);

		// Token: 0x0600004C RID: 76
		[DllImport("discord-rpc-w32", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_UpdatePresence")]
		public static extern void UpdatePresence(ref RPCLib.RichPresence presence);

		// Token: 0x0600004D RID: 77
		[DllImport("discord-rpc-w32", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_RunCallbacks")]
		public static extern void RunCallbacks();

		// Token: 0x0600004E RID: 78
		[DllImport("discord-rpc-w32", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Discord_Shutdown")]
		public static extern void Shutdown();

		// Token: 0x02000009 RID: 9
		// (Invoke) Token: 0x06000051 RID: 81
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ReadyCallback();

		// Token: 0x0200000A RID: 10
		// (Invoke) Token: 0x06000055 RID: 85
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DisconnectedCallback(int errorCode, string message);

		// Token: 0x0200000B RID: 11
		// (Invoke) Token: 0x06000059 RID: 89
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ErrorCallback(int errorCode, string message);

		// Token: 0x0200000C RID: 12
		public struct EventHandlers
		{
			// Token: 0x0400004F RID: 79
			public RPCLib.ReadyCallback readyCallback;

			// Token: 0x04000050 RID: 80
			public RPCLib.DisconnectedCallback disconnectedCallback;

			// Token: 0x04000051 RID: 81
			public RPCLib.ErrorCallback errorCallback;
		}

		// Token: 0x0200000D RID: 13
		[Serializable]
		public struct RichPresence
		{
			// Token: 0x04000052 RID: 82
			public string state;

			// Token: 0x04000053 RID: 83
			public string details;

			// Token: 0x04000054 RID: 84
			public long startTimestamp;

			// Token: 0x04000055 RID: 85
			public long endTimestamp;

			// Token: 0x04000056 RID: 86
			public string largeImageKey;

			// Token: 0x04000057 RID: 87
			public string largeImageText;

			// Token: 0x04000058 RID: 88
			public string smallImageKey;

			// Token: 0x04000059 RID: 89
			public string smallImageText;

			// Token: 0x0400005A RID: 90
			public string partyId;

			// Token: 0x0400005B RID: 91
			public int partySize;

			// Token: 0x0400005C RID: 92
			public int partyMax;

			// Token: 0x0400005D RID: 93
			public string matchSecret;

			// Token: 0x0400005E RID: 94
			public string joinSecret;

			// Token: 0x0400005F RID: 95
			public string spectateSecret;

			// Token: 0x04000060 RID: 96
			public bool instance;
		}
	}
}
