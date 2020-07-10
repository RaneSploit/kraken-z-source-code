using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI.Lib;
using Guna.UI.WinForms;
using KrakenAlert;
using KrakenX.Properties;

namespace KrakenX
{
	// Token: 0x02000004 RID: 4
	public partial class Settings : Form
	{
		// Token: 0x06000025 RID: 37
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000026 RID: 38 RVA: 0x00006BC4 File Offset: 0x00006BC4
		public Settings()
		{
			this.InitializeComponent();
			base.Region = Region.FromHrgn(Settings.CreateRoundRectRgn(0, 0, base.Width, base.Height, 7, 7));
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00006C3C File Offset: 0x00006C3C
		private int ConvertToInt(string INT)
		{
			try
			{
				return int.Parse(INT);
			}
			catch
			{
				MessageBox.Show("Error Parsing Intergers", "Vegie is snepai :3");
				Application.Exit();
			}
			return 0;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00006C88 File Offset: 0x00006C88
		private void Settings_Load(object sender, EventArgs e)
		{
			base.Opacity = 0.0;
			this.Text = ((KrakenX)this.f).watermark.Text;
			this.watermark.Text = ((KrakenX)this.f).watermark.Text;
			string @int = File.ReadLines("kraken.config").Skip(1).Take(1).First<string>().Replace("r: ", "");
			string int2 = File.ReadLines("kraken.config").Skip(2).Take(1).First<string>().Replace("g: ", "");
			string int3 = File.ReadLines("kraken.config").Skip(3).Take(1).First<string>().Replace("b: ", "");
			this.r_trackbar.Value = this.ConvertToInt(@int);
			this.g_trackbar.Value = this.ConvertToInt(int2);
			this.b_trackbar.Value = this.ConvertToInt(int3);
			this.rpc_switch.Checked = true;
			bool topMost = ((KrakenX)this.f).TopMost;
			if (topMost)
			{
				this.topmost_switch.Checked = true;
			}
			else
			{
				this.topmost_switch.Checked = false;
			}
			bool flag = Settings.ReturnBool(File.ReadLines("kraken.config").Skip(13).Take(1).First<string>().Replace("discordrpc: ", ""));
			bool flag2 = flag;
			if (flag2)
			{
				this.rpc_switch.Checked = true;
			}
			else
			{
				this.rpc_switch.Checked = false;
			}
			bool flag3 = Settings.ReturnBool(File.ReadLines("kraken.config").Skip(14).Take(1).First<string>().Replace("autoattach: ", ""));
			bool flag4 = flag3;
			if (flag4)
			{
				this.AA_switch.Checked = true;
			}
			else
			{
				this.AA_switch.Checked = false;
			}
			this.UPX();
			base.TopMost = true;
			GraphicsHelper.ShadowForm(this);
			this.RGB_Panel.Start();
			base.Location = new Point(30, 30);
			this.fade_in.Start();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00006ED0 File Offset: 0x00006ED0
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

		// Token: 0x0600002A RID: 42 RVA: 0x00006F18 File Offset: 0x00006F18
		private void drag_down(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			bool flag2 = flag;
			if (flag2)
			{
				this.MouseDownLocation = e.Location;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00006F48 File Offset: 0x00006F48
		private void drag_move(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			bool flag2 = flag;
			if (flag2)
			{
				this.drag.Parent.Left = e.X + this.drag.Parent.Left - this.MouseDownLocation.X;
				this.drag.Parent.Top = e.Y + this.drag.Parent.Top - this.MouseDownLocation.Y;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00006FD3 File Offset: 0x00006FD3
		private void exit_Click(object sender, EventArgs e)
		{
			SendNotification.Alert("Config Updated!", 0);
			this.SetCfg();
			this.fade_out.Start();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00006FF8 File Offset: 0x00006FF8
		private void fade_in_Tick(object sender, EventArgs e)
		{
			bool flag = base.Opacity >= 1.0;
			if (flag)
			{
				this.fade_in.Stop();
			}
			else
			{
				base.Opacity += 0.05;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00007048 File Offset: 0x00007048
		private void fade_out_Tick(object sender, EventArgs e)
		{
			bool flag = base.Opacity <= 0.5;
			if (flag)
			{
				this.fade_out.Stop();
				this.DiscardMe = true;
				base.Hide();
			}
			else
			{
				base.Opacity -= 0.05;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000070A4 File Offset: 0x000070A4
		private void RGB_Tick(object sender, EventArgs e)
		{
			this.color_picker.BaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.drag.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.AA_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.topmost_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.rpc_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00007690 File Offset: 0x00007690
		private void UPX()
		{
			this.color_picker.BaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.drag.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.AA_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.topmost_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.rpc_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00007C7A File Offset: 0x00007C7A
		private void RGB_Panel_Tick(object sender, EventArgs e)
		{
			this.color_picker.BaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00007CB0 File Offset: 0x00007CB0
		private void realtime_Click_1(object sender, EventArgs e)
		{
			bool flag = !this.IsActivated;
			if (flag)
			{
				SendNotification.Alert("Realtime View Activated!", 0);
				this.realtime_updater.Start();
				this.IsActivated = true;
			}
			else
			{
				SendNotification.Alert("Realtime View Deactivated!", 0);
				this.realtime_updater.Stop();
				this.IsActivated = false;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00007D10 File Offset: 0x00007D10
		private void paint_Click(object sender, EventArgs e)
		{
			SendNotification.Alert("Theme Updated!", 0);
			this.drag.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.AA_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.topmost_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.rpc_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.UpdateTheme = true;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000082DC File Offset: 0x000082DC
		private void text_Click(object sender, EventArgs e)
		{
			SendNotification.Alert("Text Updated!", 0);
			this.gunaLabel1.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.gunaLabel2.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			((KrakenX)this.f).scriptlist.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.topmost_label.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000083FC File Offset: 0x000083FC
		private void reset_rgb_Click(object sender, EventArgs e)
		{
			SendNotification.Alert("Theme Reset!", 0);
			this.r_trackbar.Value = 0;
			this.g_trackbar.Value = 243;
			this.b_trackbar.Value = 153;
			this.gunaLabel1.ForeColor = Color.White;
			this.gunaLabel2.ForeColor = Color.White;
			this.gunaLabel3.ForeColor = Color.White;
			this.gunaLabel4.ForeColor = Color.White;
			this.gunaLabel5.ForeColor = Color.White;
			((KrakenX)this.f).minimize.ForeColor = Color.White;
			((KrakenX)this.f).exit.ForeColor = Color.White;
			((KrakenX)this.f).watermark.ForeColor = Color.White;
			this.killrblx.ForeColor = Color.White;
			((KrakenX)this.f).scriptlist.ForeColor = Color.White;
			this.topmost_label.ForeColor = Color.White;
			this.color_picker.BaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.drag.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.AA_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.topmost_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.rpc_switch.CheckedOnColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.BackColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.realtime.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.paint.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.text.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.reset_rgb.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.title.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.watermark.ForeColor = Color.White;
			this.exit.ForeColor = Color.White;
			this.discord.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.discord.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBaseColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnHoverBorderColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.killrblx.OnPressedColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.Reset = true;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00008B30 File Offset: 0x00008B30
		private void title_Click(object sender, EventArgs e)
		{
			SendNotification.Alert("Title Updated!", 0);
			this.watermark.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			((KrakenX)this.f).watermark.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			((KrakenX)this.f).exit.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			((KrakenX)this.f).minimize.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
			this.exit.ForeColor = Color.FromArgb(this.r_trackbar.Value, this.g_trackbar.Value, this.b_trackbar.Value);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00008C64 File Offset: 0x00008C64
		private void topmost_switch_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.topmost_switch.Checked;
			if (@checked)
			{
				((KrakenX)this.f).TopMost = true;
			}
			else
			{
				((KrakenX)this.f).TopMost = false;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00008CAC File Offset: 0x00008CAC
		private void rpc_switch_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.rpc_switch.Checked;
			if (flag)
			{
				((KrakenX)this.f).attach_check.Stop();
				RPCLib.Shutdown();
			}
			else
			{
				((KrakenX)this.f).attach_check.Start();
				Vegie_s_RPC vegie_s_RPC = new Vegie_s_RPC();
				vegie_s_RPC.Initialize("704520720218325106");
				vegie_s_RPC.UpdatePresence("Activating RPC...", "Exploiting With Kraken");
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00008D28 File Offset: 0x00008D28
		private void SetCfg()
		{
			string contents = string.Concat(new string[]
			{
				"theme:\nr: ",
				this.drag.BackColor.R.ToString(),
				"\ng: ",
				this.drag.BackColor.G.ToString(),
				"\nb: ",
				this.drag.BackColor.B.ToString(),
				"\ntext:\nr: ",
				this.gunaLabel1.ForeColor.R.ToString(),
				"\ng: ",
				this.gunaLabel1.ForeColor.G.ToString(),
				"\nb: ",
				this.gunaLabel1.ForeColor.B.ToString(),
				"\ntitle:\nr: ",
				this.watermark.ForeColor.R.ToString(),
				"\ng: ",
				this.watermark.ForeColor.G.ToString(),
				"\nb: ",
				this.watermark.ForeColor.B.ToString(),
				"\ntitle_text: ",
				this.watermark.Text,
				"\ndiscordrpc: ",
				this.rpc_switch.Checked.ToString(),
				"\nautoattach: ",
				this.AA_switch.Checked.ToString(),
				"\ntopmost: ",
				this.topmost_switch.Checked.ToString(),
				"\npipe: krakpipe\ndllname: kraken.dll"
			});
			File.WriteAllText("kraken.config", contents);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00008F2F File Offset: 0x00008F2F
		private void killrblx_Click(object sender, EventArgs e)
		{
			Vegie_s_Functions.KillRoblox();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00008F38 File Offset: 0x00008F38
		private void discord_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/CfkSGaB");
		}

		// Token: 0x0400001B RID: 27
		private Form f = Application.OpenForms["KrakenX"];

		// Token: 0x0400001C RID: 28
		private Point MouseDownLocation;

		// Token: 0x0400001D RID: 29
		public bool IsActivated = false;

		// Token: 0x0400001E RID: 30
		public bool DiscardMe = false;

		// Token: 0x0400001F RID: 31
		public bool UpdateTheme = false;

		// Token: 0x04000020 RID: 32
		public bool Reset = true;
	}
}
