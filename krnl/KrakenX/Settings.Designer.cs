namespace KrakenX
{
	// Token: 0x02000004 RID: 4
	public partial class Settings : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00008F48 File Offset: 0x00008F48
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00008F80 File Offset: 0x00008F80
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KrakenX.Settings));
			this.drag = new global::System.Windows.Forms.Panel();
			this.watermark = new global::Guna.UI.WinForms.GunaLabel();
			this.exit = new global::Guna.UI.WinForms.GunaButton();
			this.rpc_switch = new global::Guna.UI.WinForms.GunaGoogleSwitch();
			this.topmost_label = new global::Guna.UI.WinForms.GunaLabel();
			this.gunaLabel1 = new global::Guna.UI.WinForms.GunaLabel();
			this.topmost_switch = new global::Guna.UI.WinForms.GunaGoogleSwitch();
			this.AA_switch = new global::Guna.UI.WinForms.GunaGoogleSwitch();
			this.gunaLabel2 = new global::Guna.UI.WinForms.GunaLabel();
			this.fade_out = new global::System.Windows.Forms.Timer(this.components);
			this.fade_in = new global::System.Windows.Forms.Timer(this.components);
			this.r_trackbar = new global::Guna.UI.WinForms.GunaMetroTrackBar();
			this.gunaLabel3 = new global::Guna.UI.WinForms.GunaLabel();
			this.gunaLabel4 = new global::Guna.UI.WinForms.GunaLabel();
			this.gunaLabel5 = new global::Guna.UI.WinForms.GunaLabel();
			this.g_trackbar = new global::Guna.UI.WinForms.GunaMetroTrackBar();
			this.b_trackbar = new global::Guna.UI.WinForms.GunaMetroTrackBar();
			this.color_picker = new global::Guna.UI.WinForms.GunaElipsePanel();
			this.realtime_updater = new global::System.Windows.Forms.Timer(this.components);
			this.RGB_Panel = new global::System.Windows.Forms.Timer(this.components);
			this.killrblx = new global::Guna.UI.WinForms.GunaButton();
			this.discord = new global::Guna.UI.WinForms.GunaButton();
			this.realtime = new global::Guna.UI.WinForms.GunaButton();
			this.title = new global::Guna.UI.WinForms.GunaButton();
			this.text = new global::Guna.UI.WinForms.GunaButton();
			this.paint = new global::Guna.UI.WinForms.GunaButton();
			this.reset_rgb = new global::Guna.UI.WinForms.GunaButton();
			this.drag.SuspendLayout();
			base.SuspendLayout();
			this.drag.BackColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.drag.Controls.Add(this.watermark);
			this.drag.Controls.Add(this.exit);
			this.drag.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.drag.Location = new global::System.Drawing.Point(0, 0);
			this.drag.Name = "drag";
			this.drag.Size = new global::System.Drawing.Size(296, 18);
			this.drag.TabIndex = 1;
			this.drag.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.drag_down);
			this.drag.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.drag_move);
			this.watermark.AutoSize = true;
			this.watermark.Font = new global::System.Drawing.Font("Consolas", 10f);
			this.watermark.ForeColor = global::System.Drawing.Color.White;
			this.watermark.Location = new global::System.Drawing.Point(3, 0);
			this.watermark.Name = "watermark";
			this.watermark.Size = new global::System.Drawing.Size(72, 17);
			this.watermark.TabIndex = 16;
			this.watermark.Text = "Kraken X";
			this.exit.AnimationHoverSpeed = 1f;
			this.exit.AnimationSpeed = 0.03f;
			this.exit.BackColor = global::System.Drawing.Color.Transparent;
			this.exit.BaseColor = global::System.Drawing.Color.Transparent;
			this.exit.BorderColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.exit.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.exit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.exit.FocusedColor = global::System.Drawing.Color.Empty;
			this.exit.Font = new global::System.Drawing.Font("Consolas", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.exit.ForeColor = global::System.Drawing.Color.White;
			this.exit.Image = null;
			this.exit.ImageSize = new global::System.Drawing.Size(20, 20);
			this.exit.Location = new global::System.Drawing.Point(267, 0);
			this.exit.Name = "exit";
			this.exit.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.exit.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.exit.OnHoverForeColor = global::System.Drawing.Color.White;
			this.exit.OnHoverImage = null;
			this.exit.OnPressedColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.exit.Radius = 5;
			this.exit.Size = new global::System.Drawing.Size(29, 18);
			this.exit.TabIndex = 15;
			this.exit.Text = "-";
			this.exit.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.exit.Click += new global::System.EventHandler(this.exit_Click);
			this.rpc_switch.BaseColor = global::System.Drawing.SystemColors.Control;
			this.rpc_switch.CheckedOffColor = global::System.Drawing.Color.DarkGray;
			this.rpc_switch.CheckedOnColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.rpc_switch.FillColor = global::System.Drawing.SystemColors.Control;
			this.rpc_switch.Location = new global::System.Drawing.Point(15, 41);
			this.rpc_switch.Name = "rpc_switch";
			this.rpc_switch.Size = new global::System.Drawing.Size(38, 21);
			this.rpc_switch.TabIndex = 4;
			this.rpc_switch.CheckedChanged += new global::System.EventHandler(this.rpc_switch_CheckedChanged);
			this.topmost_label.AutoSize = true;
			this.topmost_label.Font = new global::System.Drawing.Font("Consolas", 10f);
			this.topmost_label.ForeColor = global::System.Drawing.Color.White;
			this.topmost_label.Location = new global::System.Drawing.Point(12, 65);
			this.topmost_label.Name = "topmost_label";
			this.topmost_label.Size = new global::System.Drawing.Size(64, 17);
			this.topmost_label.TabIndex = 5;
			this.topmost_label.Text = "TopMost";
			this.gunaLabel1.AutoSize = true;
			this.gunaLabel1.Font = new global::System.Drawing.Font("Consolas", 10f);
			this.gunaLabel1.ForeColor = global::System.Drawing.Color.White;
			this.gunaLabel1.Location = new global::System.Drawing.Point(12, 21);
			this.gunaLabel1.Name = "gunaLabel1";
			this.gunaLabel1.Size = new global::System.Drawing.Size(96, 17);
			this.gunaLabel1.TabIndex = 6;
			this.gunaLabel1.Text = "Discord RPC";
			this.topmost_switch.BaseColor = global::System.Drawing.SystemColors.Control;
			this.topmost_switch.CheckedOffColor = global::System.Drawing.Color.DarkGray;
			this.topmost_switch.CheckedOnColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.topmost_switch.FillColor = global::System.Drawing.SystemColors.Control;
			this.topmost_switch.Location = new global::System.Drawing.Point(15, 85);
			this.topmost_switch.Name = "topmost_switch";
			this.topmost_switch.Size = new global::System.Drawing.Size(38, 21);
			this.topmost_switch.TabIndex = 7;
			this.topmost_switch.CheckedChanged += new global::System.EventHandler(this.topmost_switch_CheckedChanged);
			this.AA_switch.BaseColor = global::System.Drawing.SystemColors.Control;
			this.AA_switch.CheckedOffColor = global::System.Drawing.Color.DarkGray;
			this.AA_switch.CheckedOnColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.AA_switch.FillColor = global::System.Drawing.SystemColors.Control;
			this.AA_switch.Location = new global::System.Drawing.Point(999, 999);
			this.AA_switch.Name = "AA_switch";
			this.AA_switch.Size = new global::System.Drawing.Size(38, 21);
			this.AA_switch.TabIndex = 9;
			this.gunaLabel2.AutoSize = true;
			this.gunaLabel2.Font = new global::System.Drawing.Font("Consolas", 10f);
			this.gunaLabel2.ForeColor = global::System.Drawing.Color.White;
			this.gunaLabel2.Location = new global::System.Drawing.Point(999, 999);
			this.gunaLabel2.Name = "gunaLabel2";
			this.gunaLabel2.Size = new global::System.Drawing.Size(96, 17);
			this.gunaLabel2.TabIndex = 8;
			this.gunaLabel2.Text = "Auto Attach";
			this.fade_out.Interval = 20;
			this.fade_out.Tick += new global::System.EventHandler(this.fade_out_Tick);
			this.fade_in.Interval = 10;
			this.fade_in.Tick += new global::System.EventHandler(this.fade_in_Tick);
			this.r_trackbar.Location = new global::System.Drawing.Point(155, 96);
			this.r_trackbar.Maximum = 255;
			this.r_trackbar.Name = "r_trackbar";
			this.r_trackbar.Size = new global::System.Drawing.Size(129, 19);
			this.r_trackbar.TabIndex = 10;
			this.r_trackbar.TrackColor = global::System.Drawing.Color.IndianRed;
			this.r_trackbar.TrackHoverColor = global::System.Drawing.Color.IndianRed;
			this.r_trackbar.TrackIdleColor = global::System.Drawing.Color.Silver;
			this.r_trackbar.TrackPressedColor = global::System.Drawing.Color.IndianRed;
			this.r_trackbar.Value = 0;
			this.gunaLabel3.AutoSize = true;
			this.gunaLabel3.Font = new global::System.Drawing.Font("Consolas", 12f);
			this.gunaLabel3.ForeColor = global::System.Drawing.Color.IndianRed;
			this.gunaLabel3.Location = new global::System.Drawing.Point(131, 96);
			this.gunaLabel3.Name = "gunaLabel3";
			this.gunaLabel3.Size = new global::System.Drawing.Size(18, 19);
			this.gunaLabel3.TabIndex = 13;
			this.gunaLabel3.Text = "R";
			this.gunaLabel4.AutoSize = true;
			this.gunaLabel4.Font = new global::System.Drawing.Font("Consolas", 12f);
			this.gunaLabel4.ForeColor = global::System.Drawing.Color.SeaGreen;
			this.gunaLabel4.Location = new global::System.Drawing.Point(131, 115);
			this.gunaLabel4.Name = "gunaLabel4";
			this.gunaLabel4.Size = new global::System.Drawing.Size(18, 19);
			this.gunaLabel4.TabIndex = 14;
			this.gunaLabel4.Text = "G";
			this.gunaLabel5.AutoSize = true;
			this.gunaLabel5.Font = new global::System.Drawing.Font("Consolas", 12f);
			this.gunaLabel5.ForeColor = global::System.Drawing.Color.DarkTurquoise;
			this.gunaLabel5.Location = new global::System.Drawing.Point(131, 134);
			this.gunaLabel5.Name = "gunaLabel5";
			this.gunaLabel5.Size = new global::System.Drawing.Size(18, 19);
			this.gunaLabel5.TabIndex = 15;
			this.gunaLabel5.Text = "B";
			this.g_trackbar.Location = new global::System.Drawing.Point(155, 115);
			this.g_trackbar.Maximum = 255;
			this.g_trackbar.Name = "g_trackbar";
			this.g_trackbar.Size = new global::System.Drawing.Size(129, 19);
			this.g_trackbar.TabIndex = 16;
			this.g_trackbar.TrackColor = global::System.Drawing.Color.SeaGreen;
			this.g_trackbar.TrackHoverColor = global::System.Drawing.Color.SeaGreen;
			this.g_trackbar.TrackIdleColor = global::System.Drawing.Color.Silver;
			this.g_trackbar.TrackPressedColor = global::System.Drawing.Color.SeaGreen;
			this.g_trackbar.Value = 243;
			this.b_trackbar.Location = new global::System.Drawing.Point(155, 134);
			this.b_trackbar.Maximum = 255;
			this.b_trackbar.Name = "b_trackbar";
			this.b_trackbar.Size = new global::System.Drawing.Size(129, 19);
			this.b_trackbar.TabIndex = 17;
			this.b_trackbar.TrackColor = global::System.Drawing.Color.DarkTurquoise;
			this.b_trackbar.TrackHoverColor = global::System.Drawing.Color.DarkTurquoise;
			this.b_trackbar.TrackIdleColor = global::System.Drawing.Color.Silver;
			this.b_trackbar.TrackPressedColor = global::System.Drawing.Color.DarkTurquoise;
			this.b_trackbar.Value = 153;
			this.color_picker.BackColor = global::System.Drawing.Color.Transparent;
			this.color_picker.BaseColor = global::System.Drawing.Color.FromArgb(0, 243, 153);
			this.color_picker.Location = new global::System.Drawing.Point(135, 24);
			this.color_picker.Name = "color_picker";
			this.color_picker.Size = new global::System.Drawing.Size(149, 66);
			this.color_picker.TabIndex = 18;
			this.realtime_updater.Interval = 10;
			this.realtime_updater.Tick += new global::System.EventHandler(this.RGB_Tick);
			this.RGB_Panel.Interval = 10;
			this.RGB_Panel.Tick += new global::System.EventHandler(this.RGB_Panel_Tick);
			this.killrblx.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.killrblx.Animated = true;
			this.killrblx.AnimationHoverSpeed = 0.07f;
			this.killrblx.AnimationSpeed = 0.03f;
			this.killrblx.BackColor = global::System.Drawing.Color.Transparent;
			this.killrblx.BaseColor = global::System.Drawing.Color.Transparent;
			this.killrblx.BorderColor = global::System.Drawing.Color.Aqua;
			this.killrblx.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.killrblx.FocusedColor = global::System.Drawing.Color.Empty;
			this.killrblx.Font = new global::System.Drawing.Font("Consolas", 10f);
			this.killrblx.ForeColor = global::System.Drawing.Color.White;
			this.killrblx.Image = null;
			this.killrblx.ImageSize = new global::System.Drawing.Size(20, 20);
			this.killrblx.Location = new global::System.Drawing.Point(15, 115);
			this.killrblx.Name = "killrblx";
			this.killrblx.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.killrblx.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.killrblx.OnHoverForeColor = global::System.Drawing.Color.White;
			this.killrblx.OnHoverImage = null;
			this.killrblx.OnPressedColor = global::System.Drawing.Color.Black;
			this.killrblx.Radius = 5;
			this.killrblx.Size = new global::System.Drawing.Size(93, 23);
			this.killrblx.TabIndex = 31;
			this.killrblx.Text = "Kill Roblox";
			this.killrblx.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.killrblx.Click += new global::System.EventHandler(this.killrblx_Click);
			this.discord.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.discord.Animated = true;
			this.discord.AnimationHoverSpeed = 0.07f;
			this.discord.AnimationSpeed = 0.03f;
			this.discord.BackColor = global::System.Drawing.Color.Transparent;
			this.discord.BaseColor = global::System.Drawing.Color.Transparent;
			this.discord.BorderColor = global::System.Drawing.Color.Aqua;
			this.discord.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.discord.FocusedColor = global::System.Drawing.Color.Empty;
			this.discord.Font = new global::System.Drawing.Font("Consolas", 10f);
			this.discord.ForeColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.discord.Image = global::KrakenX.Properties.Resources.icons8_discord_24px;
			this.discord.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.discord.ImageSize = new global::System.Drawing.Size(20, 20);
			this.discord.Location = new global::System.Drawing.Point(15, 154);
			this.discord.Name = "discord";
			this.discord.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.discord.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.discord.OnHoverForeColor = global::System.Drawing.Color.White;
			this.discord.OnHoverImage = null;
			this.discord.OnPressedColor = global::System.Drawing.Color.Black;
			this.discord.Radius = 5;
			this.discord.Size = new global::System.Drawing.Size(28, 28);
			this.discord.TabIndex = 32;
			this.discord.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Right;
			this.discord.Click += new global::System.EventHandler(this.discord_Click);
			this.realtime.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.realtime.Animated = true;
			this.realtime.AnimationHoverSpeed = 0.07f;
			this.realtime.AnimationSpeed = 0.03f;
			this.realtime.BackColor = global::System.Drawing.Color.Transparent;
			this.realtime.BaseColor = global::System.Drawing.Color.Transparent;
			this.realtime.BorderColor = global::System.Drawing.Color.Aqua;
			this.realtime.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.realtime.FocusedColor = global::System.Drawing.Color.Empty;
			this.realtime.Font = new global::System.Drawing.Font("Ebrima", 9f);
			this.realtime.ForeColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.realtime.Image = global::KrakenX.Properties.Resources.icons8_realtime_64px;
			this.realtime.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.realtime.ImageSize = new global::System.Drawing.Size(20, 20);
			this.realtime.Location = new global::System.Drawing.Point(197, 159);
			this.realtime.Name = "realtime";
			this.realtime.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.realtime.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.realtime.OnHoverForeColor = global::System.Drawing.Color.White;
			this.realtime.OnHoverImage = null;
			this.realtime.OnPressedColor = global::System.Drawing.Color.Black;
			this.realtime.Radius = 5;
			this.realtime.Size = new global::System.Drawing.Size(25, 23);
			this.realtime.TabIndex = 30;
			this.realtime.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.realtime.Click += new global::System.EventHandler(this.realtime_Click_1);
			this.title.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.title.Animated = true;
			this.title.AnimationHoverSpeed = 0.07f;
			this.title.AnimationSpeed = 0.03f;
			this.title.BackColor = global::System.Drawing.Color.Transparent;
			this.title.BaseColor = global::System.Drawing.Color.Transparent;
			this.title.BorderColor = global::System.Drawing.Color.Aqua;
			this.title.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.title.FocusedColor = global::System.Drawing.Color.Empty;
			this.title.Font = new global::System.Drawing.Font("Ebrima", 9f);
			this.title.ForeColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.title.Image = global::KrakenX.Properties.Resources.icons8_tag_window_48px;
			this.title.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.title.ImageSize = new global::System.Drawing.Size(20, 20);
			this.title.Location = new global::System.Drawing.Point(228, 159);
			this.title.Name = "title";
			this.title.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.title.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.title.OnHoverForeColor = global::System.Drawing.Color.White;
			this.title.OnHoverImage = null;
			this.title.OnPressedColor = global::System.Drawing.Color.Black;
			this.title.Radius = 5;
			this.title.Size = new global::System.Drawing.Size(25, 23);
			this.title.TabIndex = 29;
			this.title.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.title.Click += new global::System.EventHandler(this.title_Click);
			this.text.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.text.Animated = true;
			this.text.AnimationHoverSpeed = 0.07f;
			this.text.AnimationSpeed = 0.03f;
			this.text.BackColor = global::System.Drawing.Color.Transparent;
			this.text.BaseColor = global::System.Drawing.Color.Transparent;
			this.text.BorderColor = global::System.Drawing.Color.Aqua;
			this.text.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.text.FocusedColor = global::System.Drawing.Color.Empty;
			this.text.Font = new global::System.Drawing.Font("Ebrima", 9f);
			this.text.ForeColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.text.Image = global::KrakenX.Properties.Resources.icons8_underline_52px;
			this.text.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.text.ImageSize = new global::System.Drawing.Size(20, 20);
			this.text.Location = new global::System.Drawing.Point(166, 159);
			this.text.Name = "text";
			this.text.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.text.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.text.OnHoverForeColor = global::System.Drawing.Color.White;
			this.text.OnHoverImage = null;
			this.text.OnPressedColor = global::System.Drawing.Color.Black;
			this.text.Radius = 5;
			this.text.Size = new global::System.Drawing.Size(25, 23);
			this.text.TabIndex = 28;
			this.text.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.text.Click += new global::System.EventHandler(this.text_Click);
			this.paint.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.paint.Animated = true;
			this.paint.AnimationHoverSpeed = 0.07f;
			this.paint.AnimationSpeed = 0.03f;
			this.paint.BackColor = global::System.Drawing.Color.Transparent;
			this.paint.BaseColor = global::System.Drawing.Color.Transparent;
			this.paint.BorderColor = global::System.Drawing.Color.Aqua;
			this.paint.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.paint.FocusedColor = global::System.Drawing.Color.Empty;
			this.paint.Font = new global::System.Drawing.Font("Ebrima", 9f);
			this.paint.ForeColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.paint.Image = global::KrakenX.Properties.Resources.icons8_paint_100px;
			this.paint.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.paint.ImageSize = new global::System.Drawing.Size(20, 20);
			this.paint.Location = new global::System.Drawing.Point(135, 159);
			this.paint.Name = "paint";
			this.paint.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.paint.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.paint.OnHoverForeColor = global::System.Drawing.Color.White;
			this.paint.OnHoverImage = null;
			this.paint.OnPressedColor = global::System.Drawing.Color.Black;
			this.paint.Radius = 5;
			this.paint.Size = new global::System.Drawing.Size(25, 23);
			this.paint.TabIndex = 27;
			this.paint.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.paint.Click += new global::System.EventHandler(this.paint_Click);
			this.reset_rgb.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.reset_rgb.Animated = true;
			this.reset_rgb.AnimationHoverSpeed = 0.07f;
			this.reset_rgb.AnimationSpeed = 0.03f;
			this.reset_rgb.BackColor = global::System.Drawing.Color.Transparent;
			this.reset_rgb.BaseColor = global::System.Drawing.Color.Transparent;
			this.reset_rgb.BorderColor = global::System.Drawing.Color.Aqua;
			this.reset_rgb.DialogResult = global::System.Windows.Forms.DialogResult.None;
			this.reset_rgb.FocusedColor = global::System.Drawing.Color.Empty;
			this.reset_rgb.Font = new global::System.Drawing.Font("Ebrima", 9f);
			this.reset_rgb.ForeColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.reset_rgb.Image = global::KrakenX.Properties.Resources.icons8_refresh_24px;
			this.reset_rgb.ImageAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.reset_rgb.ImageSize = new global::System.Drawing.Size(20, 20);
			this.reset_rgb.Location = new global::System.Drawing.Point(259, 159);
			this.reset_rgb.Name = "reset_rgb";
			this.reset_rgb.OnHoverBaseColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.reset_rgb.OnHoverBorderColor = global::System.Drawing.Color.FromArgb(0, 238, 148);
			this.reset_rgb.OnHoverForeColor = global::System.Drawing.Color.White;
			this.reset_rgb.OnHoverImage = null;
			this.reset_rgb.OnPressedColor = global::System.Drawing.Color.Black;
			this.reset_rgb.Radius = 5;
			this.reset_rgb.Size = new global::System.Drawing.Size(25, 23);
			this.reset_rgb.TabIndex = 26;
			this.reset_rgb.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.reset_rgb.Click += new global::System.EventHandler(this.reset_rgb_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(34, 34, 34);
			base.ClientSize = new global::System.Drawing.Size(296, 193);
			base.Controls.Add(this.discord);
			base.Controls.Add(this.killrblx);
			base.Controls.Add(this.realtime);
			base.Controls.Add(this.title);
			base.Controls.Add(this.text);
			base.Controls.Add(this.paint);
			base.Controls.Add(this.reset_rgb);
			base.Controls.Add(this.color_picker);
			base.Controls.Add(this.b_trackbar);
			base.Controls.Add(this.g_trackbar);
			base.Controls.Add(this.gunaLabel5);
			base.Controls.Add(this.gunaLabel4);
			base.Controls.Add(this.gunaLabel3);
			base.Controls.Add(this.r_trackbar);
			base.Controls.Add(this.AA_switch);
			base.Controls.Add(this.gunaLabel2);
			base.Controls.Add(this.topmost_switch);
			base.Controls.Add(this.gunaLabel1);
			base.Controls.Add(this.topmost_label);
			base.Controls.Add(this.rpc_switch);
			base.Controls.Add(this.drag);
			this.ForeColor = global::System.Drawing.SystemColors.ControlText;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Settings";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			base.Load += new global::System.EventHandler(this.Settings_Load);
			this.drag.ResumeLayout(false);
			this.drag.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000021 RID: 33
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Panel drag;

		// Token: 0x04000023 RID: 35
		private global::Guna.UI.WinForms.GunaLabel watermark;

		// Token: 0x04000024 RID: 36
		private global::Guna.UI.WinForms.GunaButton exit;

		// Token: 0x04000025 RID: 37
		private global::Guna.UI.WinForms.GunaGoogleSwitch rpc_switch;

		// Token: 0x04000026 RID: 38
		private global::Guna.UI.WinForms.GunaLabel topmost_label;

		// Token: 0x04000027 RID: 39
		private global::Guna.UI.WinForms.GunaLabel gunaLabel1;

		// Token: 0x04000028 RID: 40
		private global::Guna.UI.WinForms.GunaGoogleSwitch topmost_switch;

		// Token: 0x04000029 RID: 41
		private global::Guna.UI.WinForms.GunaGoogleSwitch AA_switch;

		// Token: 0x0400002A RID: 42
		private global::Guna.UI.WinForms.GunaLabel gunaLabel2;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Timer fade_out;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Timer fade_in;

		// Token: 0x0400002D RID: 45
		private global::Guna.UI.WinForms.GunaLabel gunaLabel3;

		// Token: 0x0400002E RID: 46
		private global::Guna.UI.WinForms.GunaLabel gunaLabel4;

		// Token: 0x0400002F RID: 47
		private global::Guna.UI.WinForms.GunaLabel gunaLabel5;

		// Token: 0x04000030 RID: 48
		private global::Guna.UI.WinForms.GunaElipsePanel color_picker;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Timer realtime_updater;

		// Token: 0x04000032 RID: 50
		private global::Guna.UI.WinForms.GunaButton title;

		// Token: 0x04000033 RID: 51
		private global::Guna.UI.WinForms.GunaButton paint;

		// Token: 0x04000034 RID: 52
		private global::Guna.UI.WinForms.GunaButton text;

		// Token: 0x04000035 RID: 53
		private global::Guna.UI.WinForms.GunaButton reset_rgb;

		// Token: 0x04000036 RID: 54
		private global::Guna.UI.WinForms.GunaButton realtime;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Timer RGB_Panel;

		// Token: 0x04000038 RID: 56
		public global::Guna.UI.WinForms.GunaMetroTrackBar r_trackbar;

		// Token: 0x04000039 RID: 57
		public global::Guna.UI.WinForms.GunaMetroTrackBar g_trackbar;

		// Token: 0x0400003A RID: 58
		public global::Guna.UI.WinForms.GunaMetroTrackBar b_trackbar;

		// Token: 0x0400003B RID: 59
		public global::Guna.UI.WinForms.GunaButton killrblx;

		// Token: 0x0400003C RID: 60
		public global::Guna.UI.WinForms.GunaButton discord;
	}
}
