using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace KrakenX.Properties
{
	// Token: 0x02000013 RID: 19
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000C450 File Offset: 0x0000C450
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400006E RID: 110
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
