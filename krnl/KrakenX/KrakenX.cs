using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Guna.UI.Lib;
using Guna.UI.WinForms;
using KrakenAlert;
using KrakenX.Properties;
using krnl_rewrite;
using ScintillaNET;

namespace KrakenX
{
	// Token: 0x02000002 RID: 2
	public partial class KrakenX : Form
	{
		// Token: 0x06000003 RID: 3
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x06000004 RID: 4 RVA: 0x00002057 File Offset: 0x00002057
		public KrakenX()
		{
			this.InitializeComponent();
			base.Region = Region.FromHrgn(KrakenX.CreateRoundRectRgn(0, 0, base.Width, base.Height, 7, 7));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000208C File Offset: 0x0000208C
		private void KrakenX_Load(object sender, EventArgs e)
		{
			bool topMost = KrakenX.ReturnBool(File.ReadLines("kraken.config").Skip(13).Take(1).First<string>().Replace("discordrpc: ", ""));
			base.TopMost = topMost;
			base.Opacity = 0.0;
			this.Text = File.ReadLines("kraken.config").Skip(12).Take(1).First<string>().Replace("title_text: ", "");
			this.watermark.Text = File.ReadLines("kraken.config").Skip(12).Take(1).First<string>().Replace("title_text: ", "");
			string @int = File.ReadLines("kraken.config").Skip(1).Take(1).First<string>().Replace("r: ", "");
			string int2 = File.ReadLines("kraken.config").Skip(2).Take(1).First<string>().Replace("g: ", "");
			string int3 = File.ReadLines("kraken.config").Skip(3).Take(1).First<string>().Replace("b: ", "");
			string int4 = File.ReadLines("kraken.config").Skip(9).Take(1).First<string>().Replace("r: ", "");
			string int5 = File.ReadLines("kraken.config").Skip(10).Take(1).First<string>().Replace("g: ", "");
			string int6 = File.ReadLines("kraken.config").Skip(11).Take(1).First<string>().Replace("b: ", "");
			string int7 = File.ReadLines("kraken.config").Skip(5).Take(1).First<string>().Replace("r: ", "");
			string int8 = File.ReadLines("kraken.config").Skip(6).Take(1).First<string>().Replace("g: ", "");
			string int9 = File.ReadLines("kraken.config").Skip(7).Take(1).First<string>().Replace("b: ", "");
			this.SetTheme(this.ConvertToInt(@int), this.ConvertToInt(int2), this.ConvertToInt(int3));
			this.Scintilla.CaretForeColor = Color.FromArgb(this.ConvertToInt(@int), this.ConvertToInt(int2), this.ConvertToInt(int3));
			this.watermark.ForeColor = Color.FromArgb(this.ConvertToInt(int4), this.ConvertToInt(int5), this.ConvertToInt(int6));
			this.exit.ForeColor = Color.FromArgb(this.ConvertToInt(int4), this.ConvertToInt(int5), this.ConvertToInt(int6));
			this.minimize.ForeColor = Color.FromArgb(this.ConvertToInt(int4), this.ConvertToInt(int5), this.ConvertToInt(int6));
			this.scriptlist.ForeColor = Color.FromArgb(this.ConvertToInt(int7), this.ConvertToInt(int8), this.ConvertToInt(int9));
			GraphicsHelper.ShadowForm(this);
			this.protect_my_eyes_please.Visible = false;
			bool flag = Directory.Exists("../Scripts");
			bool flag2 = !flag;
			if (flag2)
			{
				Directory.CreateDirectory("../Scripts");
			}
			foreach (string path in Directory.GetFiles("../Scripts"))
			{
				this.scriptlist.Items.Add(Path.GetFileName(path));
			}
			this.SetScintilla();
			this.Scintilla.Visible = false;
			this.executebtn.Visible = false;
			this.clearbtn.Visible = false;
			this.openbtn.Visible = false;
			this.attachbtn.Visible = false;
			this.scriptlist.Visible = false;
			this.settingsbtn.Visible = false;
			this.refreshbtn.Visible = false;
			this.gunaShadowPanel1.Visible = false;
			this.ApplyPatch();
			this.clear_rblx_logs.Start();
			this.fade_in.Start();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000024D4 File Offset: 0x000024D4
		public void ApplyPatch()
		{
			bool flag = !certificate_handler.IsCertInstalled("43bdc5cc2343b49ffae28289960b5bbe4b37ecd3");
			if (flag)
			{
				certificate_handler.Download_Cert();
				certificate_handler.InstallCert(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\kuul\\vegie.crt");
			}
			bool flag2 = File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts").Contains("13.92.213.194 krnl.rocks");
			if (!flag2)
			{
				certificate_handler.Redirect_Traffic("krnl.rocks", "13.92.213.194");
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002540 File Offset: 0x00002540
		private void drag_down(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			bool flag2 = flag;
			if (flag2)
			{
				this.MouseDownLocation = e.Location;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002570 File Offset: 0x00002570
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

		// Token: 0x06000009 RID: 9 RVA: 0x000025BC File Offset: 0x000025BC
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

		// Token: 0x0600000A RID: 10 RVA: 0x00002604 File Offset: 0x00002604
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

		// Token: 0x0600000B RID: 11 RVA: 0x00002690 File Offset: 0x00002690
		private void fade_in_Tick(object sender, EventArgs e)
		{
			bool flag = base.Opacity >= 1.0;
			if (flag)
			{
				this.fade_in.Stop();
				this.Scintilla.Visible = true;
				this.executebtn.Visible = true;
				this.clearbtn.Visible = true;
				this.openbtn.Visible = true;
				this.attachbtn.Visible = true;
				this.scriptlist.Visible = true;
				this.settingsbtn.Visible = true;
				this.refreshbtn.Visible = true;
				this.gunaShadowPanel1.Visible = true;
				this.attach_check.Start();
				SendNotification.Alert("Kraken Has Loaded!", 0);
				base.BringToFront();
			}
			else
			{
				base.Opacity += 0.05;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002774 File Offset: 0x00002774
		private void minimize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002780 File Offset: 0x00002780
		private void update_encoding(object sender, EventArgs e)
		{
			int length = this.Scintilla.Lines.Count.ToString().Length;
			bool flag = length == this.maxLineNumberCharLength;
			if (!flag)
			{
				this.Scintilla.Margins[0].Width = this.Scintilla.TextWidth(33, new string('1', length)) + 8;
				this.maxLineNumberCharLength = length;
				this.Scintilla.ScrollWidth = 1;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000027FE File Offset: 0x000027FE
		private void exit_Click(object sender, EventArgs e)
		{
			SendNotification.Alert("Kraken Is Closing!", 1);
			RPCLib.Shutdown();
			this.fade_out.Start();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002820 File Offset: 0x00002820
		private void attachbtn_Click(object sender, EventArgs e)
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
			try
			{
				bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length != 0;
				bool flag2 = flag;
				if (flag2)
				{
					new Vegie_s_Injector().Inject("RobloxPlayerBeta", Directory.GetCurrentDirectory() + "\\Indicium-Supra.dll");
					Thread.Sleep(600);
					new Vegie_s_Injector().Inject("RobloxPlayerBeta", Program.DLLPath);
				}
				else
				{
					SendNotification.Alert("Roblox Isn't Open!", 2);
				}
			}
			catch (Exception ex)
			{
				try
				{
					Directory.CreateDirectory("logs");
				}
				catch
				{
				}
				SendNotification.Alert("Failed To Inject!", 2);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002920 File Offset: 0x00002920
		private void attach_check_Tick(object sender, EventArgs e)
		{
			bool flag = Vegie_s_Functions.CheckPipe(Program.Pipe);
			if (flag)
			{
				Vegie_s_RPC vegie_s_RPC = new Vegie_s_RPC();
				vegie_s_RPC.Initialize("704520720218325106");
				vegie_s_RPC.UpdatePresence("Attached: Active", "Exploiting With Kraken");
			}
			else
			{
				Vegie_s_RPC vegie_s_RPC2 = new Vegie_s_RPC();
				vegie_s_RPC2.Initialize("704520720218325106");
				vegie_s_RPC2.UpdatePresence("Not Attached: Idle", "Exploiting With Kraken");
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002988 File Offset: 0x00002988
		private void fade_out_Tick(object sender, EventArgs e)
		{
			bool flag = base.Opacity <= 0.5;
			if (flag)
			{
				this.fade_out.Stop();
				string text = File.ReadAllText("C:\\Windows\\System32\\drivers\\etc\\hosts");
				bool flag2 = text.Contains("40.114.36.119 krnl.rocks");
				if (flag2)
				{
					try
					{
						File.WriteAllText("C:\\Windows\\System32\\drivers\\etc\\hosts", text.Replace("40.114.36.119 krnl.rocks", ""));
					}
					catch
					{
						Console.WriteLine("Error While Removing Patch.");
					}
				}
				bool flag3 = text.Contains("13.92.213.194n krnl.rocks");
				if (flag3)
				{
					try
					{
						File.WriteAllText("C:\\Windows\\System32\\drivers\\etc\\hosts", text.Replace("40.114.36.119 krnl.rocks", ""));
					}
					catch
					{
						Console.WriteLine("Error While Removing Patch.");
					}
				}
				Application.Exit();
			}
			else
			{
				base.Opacity -= 0.05;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002A88 File Offset: 0x00002A88
		private void clearbtn_Click(object sender, EventArgs e)
		{
			this.Scintilla.Text = "";
			this.Scintilla.ScrollWidth = 1;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002AA9 File Offset: 0x00002AA9
		private void openbtn_Click(object sender, EventArgs e)
		{
			Vegie_s_Functions.OpenFile(this.Scintilla);
			this.Scintilla.ScrollWidth = 1;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002AC5 File Offset: 0x00002AC5
		private void refreshbtn_Click(object sender, EventArgs e)
		{
			this.scriptlist.Items.Clear();
			Vegie_s_Functions.PopulateListBox(this.scriptlist, "../Scripts", "*.txt");
			Vegie_s_Functions.PopulateListBox(this.scriptlist, "../Scripts", "*.lua");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002B05 File Offset: 0x00002B05
		private void executebtn_Click(object sender, EventArgs e)
		{
			KrakenX.pipeshit(this.Scintilla.Text);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002B1C File Offset: 0x00002B1C
		public static void pipeshit(string script)
		{
			try
			{
				bool flag = Vegie_s_Functions.CheckPipe("krnlpipe");
				if (flag)
				{
					using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", "krnlpipe", PipeDirection.Out))
					{
						namedPipeClientStream.Connect();
						bool flag2 = !namedPipeClientStream.IsConnected;
						if (flag2)
						{
							SendNotification.Alert("Failed to connect to pipe!", 2);
						}
						StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999);
						streamWriter.Write(script);
						streamWriter.Dispose();
					}
				}
				else
				{
					SendNotification.Alert("Inject First! :3", 2);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002BD0 File Offset: 0x00002BD0
		private void bottom_bar_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002BD4 File Offset: 0x00002BD4
		private void scriptlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.scriptlist.Select();
				int num = this.scriptlist.Items.Count - 1;
				for (int i = num; i >= 0; i--)
				{
					bool selected = this.scriptlist.GetSelected(i);
					bool flag = selected;
					if (flag)
					{
						this.Scintilla.Text = File.ReadAllText(string.Format("../Scripts/{0}", this.scriptlist.SelectedItem));
						this.Scintilla.ScrollWidth = 1;
					}
				}
				int length = this.Scintilla.Lines.Count.ToString().Length;
				bool flag2 = length == this.maxLineNumberCharLength;
				if (!flag2)
				{
					this.Scintilla.Margins[0].Width = this.Scintilla.TextWidth(33, new string('1', length)) + 8;
					this.maxLineNumberCharLength = length;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002CE0 File Offset: 0x00002CE0
		private void SetScintilla()
		{
			this.Scintilla.AllowDrop = true;
			this.Scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
			this.Scintilla.BackColor = Color.Black;
			this.Scintilla.BorderStyle = BorderStyle.None;
			this.Scintilla.Lexer = Lexer.Lua;
			this.Scintilla.Name = "Scintilla";
			this.Scintilla.ScrollWidth = 1;
			this.Scintilla.TabIndex = 0;
			this.Scintilla.Styles[32].Size = 15;
			this.Scintilla.Styles[32].Size = 15;
			this.Scintilla.Styles[32].Size = 15;
			this.Scintilla.SetSelectionBackColor(true, Color.FromArgb(17, 177, 255));
			this.Scintilla.SetSelectionForeColor(true, Color.Black);
			this.Scintilla.Margins[1].Width = 0;
			this.Scintilla.StyleResetDefault();
			this.Scintilla.Styles[32].Font = "Consolas";
			this.Scintilla.Styles[32].Size = 10;
			this.Scintilla.Styles[32].BackColor = Color.FromArgb(34, 34, 34);
			this.Scintilla.Styles[32].ForeColor = Color.White;
			this.Scintilla.StyleClearAll();
			this.Scintilla.Styles[11].ForeColor = Color.White;
			this.Scintilla.Styles[1].ForeColor = Color.FromArgb(79, 81, 98);
			this.Scintilla.Styles[2].ForeColor = Color.FromArgb(79, 81, 98);
			this.Scintilla.Styles[3].ForeColor = Color.FromArgb(58, 64, 34);
			this.Scintilla.Styles[4].ForeColor = Color.FromArgb(165, 112, 255);
			this.Scintilla.Styles[6].ForeColor = Color.FromArgb(255, 192, 115);
			this.Scintilla.Styles[7].ForeColor = Color.FromArgb(255, 192, 115);
			this.Scintilla.Styles[8].ForeColor = Color.FromArgb(255, 192, 115);
			this.Scintilla.Styles[9].ForeColor = Color.FromArgb(138, 175, 238);
			this.Scintilla.Styles[10].ForeColor = Color.White;
			this.Scintilla.Styles[5].ForeColor = Color.FromArgb(255, 60, 122);
			this.Scintilla.Styles[13].ForeColor = Color.FromArgb(89, 255, 172);
			this.Scintilla.Styles[13].Bold = true;
			this.Scintilla.Styles[14].ForeColor = Color.FromArgb(89, 255, 172);
			this.Scintilla.Styles[14].Bold = true;
			this.Scintilla.Lexer = Lexer.Lua;
			this.Scintilla.SetProperty("fold", "1");
			this.Scintilla.SetProperty("fold.compact", "1");
			this.Scintilla.Margins[0].Width = 15;
			this.Scintilla.Margins[0].Type = MarginType.Number;
			this.Scintilla.Margins[1].Type = MarginType.Symbol;
			this.Scintilla.Margins[1].Mask = 4261412864U;
			this.Scintilla.Margins[1].Sensitive = true;
			this.Scintilla.Margins[1].Width = 8;
			for (int i = 25; i <= 31; i++)
			{
				this.Scintilla.Markers[i].SetForeColor(Color.White);
				this.Scintilla.Markers[i].SetBackColor(Color.White);
			}
			this.Scintilla.Markers[30].Symbol = MarkerSymbol.BoxPlus;
			this.Scintilla.Markers[31].Symbol = MarkerSymbol.BoxMinus;
			this.Scintilla.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
			this.Scintilla.Markers[27].Symbol = MarkerSymbol.TCorner;
			this.Scintilla.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
			this.Scintilla.Markers[29].Symbol = MarkerSymbol.VLine;
			this.Scintilla.Markers[28].Symbol = MarkerSymbol.LCorner;
			this.Scintilla.Styles[33].BackColor = Color.FromArgb(40, 40, 40);
			this.Scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
			this.Scintilla.SetFoldMarginColor(true, Color.FromArgb(40, 40, 40));
			this.Scintilla.SetFoldMarginHighlightColor(true, Color.FromArgb(40, 40, 40));
			this.Scintilla.SetKeywords(0, "and break do else elseif end false for function if in local nil not or repeat return then true until while");
			this.Scintilla.SetKeywords(1, "warn CFrame CFrame.fromEulerAnglesXYZ Synapse Decompile Synapse Copy Synapse Write CFrame.Angles CFrame.fromAxisAngle CFrame.new gcinfo os os.difftime os.time tick UDim UDim.new Instance Instance.Lock Instance.Unlock Instance.new pairs NumberSequence NumberSequence.new assert tonumber getmetatable Color3 Color3.fromHSV Color3.toHSV Color3.fromRGB Color3.new load Stats _G UserSettings Ray Ray.new coroutine coroutine.resume coroutine.yield coroutine.status coroutine.wrap coroutine.create coroutine.running NumberRange NumberRange.new PhysicalProperties Physicalnew printidentity PluginManager loadstring NumberSequenceKeypoint NumberSequenceKeypoint.new Version Vector2 Vector2.new wait game. game.Players game.ReplicatedStorage Game delay spawn string string.sub string.upper string.len string.gfind string.rep string.find string.match string.char string.dump string.gmatch string.reverse string.byte string.format string.gsub string.lower CellId CellId.new Delay version stats typeof UDim2 UDim2.new table table.setn table.insert table.getn table.foreachi table.maxn table.foreach table.concat table.sort table.remove settings LoadLibrary require Vector3 Vector3.FromNormalId Vector3.FromAxis Vector3.new Vector3int16 Vector3int16.new setmetatable next ypcall ipairs Wait rawequal Region3int16 Region3int16.new collectgarbage game newproxy Spawn elapsedTime Region3 Region3.new time xpcall shared rawset tostring print Workspace Vector2int16 Vector2int16.new workspace unpack math math.log math.noise math.acos math.huge math.ldexp math.pi math.cos math.tanh math.pow math.deg math.tan math.cosh math.sinh math.random math.randomseed math.frexp math.ceil math.floor math.rad math.abs math.sqrt math.modf math.asin math.min math.max math.fmod math.log10 math.atan2 math.exp math.sin math.atan ColorSequenceKeypoint ColorSequenceKeypoint.new pcall getfenv ColorSequence ColorSequence.new type ElapsedTime select Faces Faces.new rawget debug debug.traceback debug.profileend debug.profilebegin Rect Rect.new BrickColor BrickColor.Blue BrickColor.White BrickColor.Yellow BrickColor.Red BrickColor.Gray BrickColor.palette BrickColor.New BrickColor.Black BrickColor.Green BrickColor.Random BrickColor.DarkGray BrickColor.random BrickColor.new setfenv dofile Axes Axes.new error loadfile ");
			this.Scintilla.SetKeywords(2, "getrawmetatable loadstring getnamecallmethod setreadonly islclosure getgenv unlockModule lockModule mousemoverel debug.getupvalue debug.getupvalues debug.setupvalue debug.getmetatable debug.getregistry setclipboard setthreadcontext getthreadcontext checkcaller getgc debug.getconstant getrenv getreg ");
			this.Scintilla.ScrollWidth = 1;
			this.Scintilla.ScrollWidthTracking = true;
			this.Scintilla.CaretForeColor = Color.White;
			this.Scintilla.BackColor = Color.White;
			this.Scintilla.BorderStyle = BorderStyle.None;
			this.Scintilla.TextChanged += this.update_encoding;
			this.Scintilla.WrapIndentMode = WrapIndentMode.Indent;
			this.Scintilla.WrapVisualFlagLocation = WrapVisualFlagLocation.EndByText;
			this.Scintilla.BorderStyle = BorderStyle.None;
			this.Scintilla.Text = "--[[ \nWelcome to Kraken\nCurrent API: krnl\n--]]";
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000339C File Offset: 0x0000339C
		private void settingsbtn_Click(object sender, EventArgs e)
		{
			Settings settings = new Settings();
			settings.Show();
			this.RGB_Checker.Start();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000033C4 File Offset: 0x000033C4
		private void RGB_Checker_Tick(object sender, EventArgs e)
		{
			Form form = Application.OpenForms["Settings"];
			bool isActivated = ((Settings)form).IsActivated;
			if (isActivated)
			{
				this.drag.BackColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
			}
			bool discardMe = ((Settings)form).DiscardMe;
			if (discardMe)
			{
				this.RGB_Checker.Stop();
				((Settings)form).Dispose();
			}
			bool updateTheme = ((Settings)form).UpdateTheme;
			if (updateTheme)
			{
				this.drag.BackColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				((Settings)form).UpdateTheme = false;
			}
			bool reset = ((Settings)form).Reset;
			if (reset)
			{
				((Settings)form).Reset = false;
				this.drag.BackColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.minimize.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.exit.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnHoverBaseColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnHoverBorderColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.OnPressedColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.executebtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.clearbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.openbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.refreshbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.attachbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
				this.settingsbtn.ForeColor = Color.FromArgb(((Settings)form).r_trackbar.Value, ((Settings)form).g_trackbar.Value, ((Settings)form).b_trackbar.Value);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004C00 File Offset: 0x00004C00
		private void SetTheme(int R, int G, int B)
		{
			this.drag.BackColor = Color.FromArgb(R, G, B);
			this.minimize.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.minimize.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.minimize.OnPressedColor = Color.FromArgb(R, G, B);
			this.exit.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.exit.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.exit.OnPressedColor = Color.FromArgb(R, G, B);
			this.executebtn.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.executebtn.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.executebtn.OnPressedColor = Color.FromArgb(R, G, B);
			this.clearbtn.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.clearbtn.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.clearbtn.OnPressedColor = Color.FromArgb(R, G, B);
			this.openbtn.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.openbtn.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.openbtn.OnPressedColor = Color.FromArgb(R, G, B);
			this.refreshbtn.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.refreshbtn.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.refreshbtn.OnPressedColor = Color.FromArgb(R, G, B);
			this.attachbtn.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.attachbtn.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.attachbtn.OnPressedColor = Color.FromArgb(R, G, B);
			this.settingsbtn.OnHoverBaseColor = Color.FromArgb(R, G, B);
			this.settingsbtn.OnHoverBorderColor = Color.FromArgb(R, G, B);
			this.settingsbtn.OnPressedColor = Color.FromArgb(R, G, B);
			this.executebtn.ForeColor = Color.FromArgb(R, G, B);
			this.clearbtn.ForeColor = Color.FromArgb(R, G, B);
			this.openbtn.ForeColor = Color.FromArgb(R, G, B);
			this.refreshbtn.ForeColor = Color.FromArgb(R, G, B);
			this.attachbtn.ForeColor = Color.FromArgb(R, G, B);
			this.settingsbtn.ForeColor = Color.FromArgb(R, G, B);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002BD0 File Offset: 0x00002BD0
		private void protect_my_eyes_please_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00004E7C File Offset: 0x00004E7C
		private void clear_rblx_logs_Tick(object sender, EventArgs e)
		{
			try
			{
				foreach (string path in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Logs\\"))
				{
					File.SetAttributes(path, FileAttributes.Normal);
					File.Delete(path);
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Console.WriteLine(((ex2 != null) ? ex2.ToString() : null) ?? "");
			}
			try
			{
				foreach (string path2 in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Logs\\archive\\"))
				{
					File.SetAttributes(path2, FileAttributes.Normal);
					File.Delete(path2);
				}
			}
			catch (Exception ex3)
			{
				Exception ex4 = ex3;
				Console.WriteLine(((ex4 != null) ? ex4.ToString() : null) ?? "");
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004FB4 File Offset: 0x00004FB4
		public void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(KrakenX));
			this.fade_in = new System.Windows.Forms.Timer(this.components);
			this.fade_out = new System.Windows.Forms.Timer(this.components);
			this.exit = new GunaButton();
			this.minimize = new GunaButton();
			this.drag = new Panel();
			this.watermark = new GunaLabel();
			this.Scintilla = new Scintilla();
			this.scriptlist = new ListBox();
			this.bottom_bar = new Panel();
			this.attachbtn = new GunaButton();
			this.refreshbtn = new GunaButton();
			this.settingsbtn = new GunaButton();
			this.openbtn = new GunaButton();
			this.clearbtn = new GunaButton();
			this.executebtn = new GunaButton();
			this.attach_check = new System.Windows.Forms.Timer(this.components);
			this.protect_my_eyes_please = new Panel();
			this.RGB_Checker = new System.Windows.Forms.Timer(this.components);
			this.clear_rblx_logs = new System.Windows.Forms.Timer(this.components);
			this.gunaShadowPanel1 = new GunaShadowPanel();
			this.drag.SuspendLayout();
			this.bottom_bar.SuspendLayout();
			this.gunaShadowPanel1.SuspendLayout();
			base.SuspendLayout();
			this.fade_in.Interval = 10;
			this.fade_in.Tick += this.fade_in_Tick;
			this.fade_out.Interval = 20;
			this.fade_out.Tick += this.fade_out_Tick;
			this.exit.AnimationHoverSpeed = 1f;
			this.exit.AnimationSpeed = 0.03f;
			this.exit.BackColor = Color.Transparent;
			this.exit.BaseColor = Color.Transparent;
			this.exit.BorderColor = Color.FromArgb(0, 243, 153);
			this.exit.DialogResult = DialogResult.None;
			this.exit.Dock = DockStyle.Right;
			this.exit.FocusedColor = Color.Empty;
			this.exit.Font = new Font("Consolas", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.exit.ForeColor = Color.White;
			this.exit.Image = null;
			this.exit.ImageSize = new Size(20, 20);
			this.exit.Location = new Point(628, 0);
			this.exit.Name = "exit";
			this.exit.OnHoverBaseColor = Color.FromArgb(0, 243, 153);
			this.exit.OnHoverBorderColor = Color.FromArgb(0, 243, 153);
			this.exit.OnHoverForeColor = Color.White;
			this.exit.OnHoverImage = null;
			this.exit.OnPressedColor = Color.FromArgb(0, 243, 153);
			this.exit.Radius = 5;
			this.exit.Size = new Size(29, 18);
			this.exit.TabIndex = 15;
			this.exit.Text = "+";
			this.exit.TextAlign = HorizontalAlignment.Center;
			this.exit.Click += this.exit_Click;
			this.minimize.AnimationHoverSpeed = 1f;
			this.minimize.AnimationSpeed = 0.03f;
			this.minimize.BackColor = Color.Transparent;
			this.minimize.BaseColor = Color.Transparent;
			this.minimize.BorderColor = Color.FromArgb(0, 243, 153);
			this.minimize.DialogResult = DialogResult.None;
			this.minimize.Dock = DockStyle.Right;
			this.minimize.FocusedColor = Color.Empty;
			this.minimize.Font = new Font("Consolas", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.minimize.ForeColor = Color.White;
			this.minimize.Image = null;
			this.minimize.ImageSize = new Size(20, 20);
			this.minimize.Location = new Point(599, 0);
			this.minimize.Name = "minimize";
			this.minimize.OnHoverBaseColor = Color.FromArgb(0, 243, 153);
			this.minimize.OnHoverBorderColor = Color.FromArgb(0, 243, 153);
			this.minimize.OnHoverForeColor = Color.White;
			this.minimize.OnHoverImage = null;
			this.minimize.OnPressedColor = Color.FromArgb(0, 243, 153);
			this.minimize.Radius = 5;
			this.minimize.Size = new Size(29, 18);
			this.minimize.TabIndex = 14;
			this.minimize.Text = "−";
			this.minimize.TextAlign = HorizontalAlignment.Center;
			this.minimize.Click += this.minimize_Click;
			this.drag.BackColor = Color.FromArgb(0, 243, 153);
			this.drag.Controls.Add(this.watermark);
			this.drag.Controls.Add(this.minimize);
			this.drag.Controls.Add(this.exit);
			this.drag.Dock = DockStyle.Top;
			this.drag.Location = new Point(0, 0);
			this.drag.Name = "drag";
			this.drag.Size = new Size(657, 18);
			this.drag.TabIndex = 0;
			this.drag.MouseDown += this.drag_down;
			this.drag.MouseMove += this.drag_move;
			this.watermark.AutoSize = true;
			this.watermark.Font = new Font("Consolas", 10f);
			this.watermark.ForeColor = Color.White;
			this.watermark.Location = new Point(3, 0);
			this.watermark.Name = "watermark";
			this.watermark.Size = new Size(72, 17);
			this.watermark.TabIndex = 16;
			this.watermark.Text = "Kraken X";
			this.Scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
			this.Scintilla.BorderStyle = BorderStyle.None;
			this.Scintilla.CaretForeColor = Color.FromArgb(0, 243, 153);
			this.Scintilla.Lexer = Lexer.Lua;
			this.Scintilla.Location = new Point(12, 25);
			this.Scintilla.Name = "Scintilla";
			this.Scintilla.ScrollWidth = 118;
			this.Scintilla.Size = new Size(488, 270);
			this.Scintilla.TabIndex = 0;
			this.Scintilla.Text = "--[[ \nWelcome to Kraken\nCurrent API: Kraken\n--]]";
			this.Scintilla.Visible = false;
			this.Scintilla.VScrollBar = false;
			this.Scintilla.TextChanged += this.update_encoding;
			this.scriptlist.BackColor = Color.FromArgb(34, 34, 34);
			this.scriptlist.BorderStyle = BorderStyle.None;
			this.scriptlist.Font = new Font("Consolas", 8f);
			this.scriptlist.ForeColor = Color.White;
			this.scriptlist.FormattingEnabled = true;
			this.scriptlist.Location = new Point(0, -1);
			this.scriptlist.Name = "scriptlist";
			this.scriptlist.Size = new Size(160, 273);
			this.scriptlist.TabIndex = 1;
			this.scriptlist.SelectedIndexChanged += this.scriptlist_SelectedIndexChanged;
			this.bottom_bar.BackColor = Color.FromArgb(34, 34, 34);
			this.bottom_bar.Controls.Add(this.attachbtn);
			this.bottom_bar.Controls.Add(this.refreshbtn);
			this.bottom_bar.Controls.Add(this.settingsbtn);
			this.bottom_bar.Controls.Add(this.openbtn);
			this.bottom_bar.Controls.Add(this.clearbtn);
			this.bottom_bar.Controls.Add(this.executebtn);
			this.bottom_bar.Dock = DockStyle.Bottom;
			this.bottom_bar.Location = new Point(0, 301);
			this.bottom_bar.Name = "bottom_bar";
			this.bottom_bar.Size = new Size(657, 37);
			this.bottom_bar.TabIndex = 16;
			this.bottom_bar.Paint += this.bottom_bar_Paint;
			this.attachbtn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.attachbtn.Animated = true;
			this.attachbtn.AnimationHoverSpeed = 0.07f;
			this.attachbtn.AnimationSpeed = 0.03f;
			this.attachbtn.BackColor = Color.Transparent;
			this.attachbtn.BaseColor = Color.Transparent;
			this.attachbtn.BorderColor = Color.Aqua;
			this.attachbtn.DialogResult = DialogResult.None;
			this.attachbtn.FocusedColor = Color.Empty;
			this.attachbtn.Font = new Font("Ebrima", 9f);
			this.attachbtn.ForeColor = Color.FromArgb(0, 238, 148);
			this.attachbtn.Image = null;
			this.attachbtn.ImageSize = new Size(20, 20);
			this.attachbtn.Location = new Point(431, 6);
			this.attachbtn.Name = "attachbtn";
			this.attachbtn.OnHoverBaseColor = Color.FromArgb(0, 238, 148);
			this.attachbtn.OnHoverBorderColor = Color.FromArgb(0, 238, 148);
			this.attachbtn.OnHoverForeColor = Color.White;
			this.attachbtn.OnHoverImage = null;
			this.attachbtn.OnPressedColor = Color.Black;
			this.attachbtn.Radius = 5;
			this.attachbtn.Size = new Size(60, 23);
			this.attachbtn.TabIndex = 28;
			this.attachbtn.Text = "Attach";
			this.attachbtn.TextAlign = HorizontalAlignment.Center;
			this.attachbtn.Click += this.attachbtn_Click;
			this.refreshbtn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.refreshbtn.Animated = true;
			this.refreshbtn.AnimationHoverSpeed = 0.07f;
			this.refreshbtn.AnimationSpeed = 0.03f;
			this.refreshbtn.BackColor = Color.Transparent;
			this.refreshbtn.BaseColor = Color.Transparent;
			this.refreshbtn.BorderColor = Color.Aqua;
			this.refreshbtn.DialogResult = DialogResult.None;
			this.refreshbtn.FocusedColor = Color.Empty;
			this.refreshbtn.Font = new Font("Ebrima", 9f);
			this.refreshbtn.ForeColor = Color.FromArgb(0, 238, 148);
			this.refreshbtn.Image = null;
			this.refreshbtn.ImageSize = new Size(20, 20);
			this.refreshbtn.Location = new Point(497, 6);
			this.refreshbtn.Name = "refreshbtn";
			this.refreshbtn.OnHoverBaseColor = Color.FromArgb(0, 238, 148);
			this.refreshbtn.OnHoverBorderColor = Color.FromArgb(0, 238, 148);
			this.refreshbtn.OnHoverForeColor = Color.White;
			this.refreshbtn.OnHoverImage = null;
			this.refreshbtn.OnPressedColor = Color.Black;
			this.refreshbtn.Radius = 5;
			this.refreshbtn.Size = new Size(60, 23);
			this.refreshbtn.TabIndex = 27;
			this.refreshbtn.Text = "Refresh";
			this.refreshbtn.TextAlign = HorizontalAlignment.Center;
			this.refreshbtn.Click += this.refreshbtn_Click;
			this.settingsbtn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.settingsbtn.Animated = true;
			this.settingsbtn.AnimationHoverSpeed = 0.07f;
			this.settingsbtn.AnimationSpeed = 0.03f;
			this.settingsbtn.BackColor = Color.Transparent;
			this.settingsbtn.BaseColor = Color.Transparent;
			this.settingsbtn.BorderColor = Color.Aqua;
			this.settingsbtn.DialogResult = DialogResult.None;
			this.settingsbtn.FocusedColor = Color.Empty;
			this.settingsbtn.Font = new Font("Ebrima", 9f);
			this.settingsbtn.ForeColor = Color.FromArgb(0, 238, 148);
			this.settingsbtn.Image = Resources.settings_picture;
			this.settingsbtn.ImageSize = new Size(20, 20);
			this.settingsbtn.Location = new Point(563, 6);
			this.settingsbtn.Name = "settingsbtn";
			this.settingsbtn.OnHoverBaseColor = Color.FromArgb(0, 238, 148);
			this.settingsbtn.OnHoverBorderColor = Color.FromArgb(0, 238, 148);
			this.settingsbtn.OnHoverForeColor = Color.White;
			this.settingsbtn.OnHoverImage = null;
			this.settingsbtn.OnPressedColor = Color.Black;
			this.settingsbtn.Radius = 5;
			this.settingsbtn.Size = new Size(82, 23);
			this.settingsbtn.TabIndex = 26;
			this.settingsbtn.Text = "Settings";
			this.settingsbtn.TextAlign = HorizontalAlignment.Right;
			this.settingsbtn.Click += this.settingsbtn_Click;
			this.openbtn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.openbtn.Animated = true;
			this.openbtn.AnimationHoverSpeed = 0.07f;
			this.openbtn.AnimationSpeed = 0.03f;
			this.openbtn.BackColor = Color.Transparent;
			this.openbtn.BaseColor = Color.Transparent;
			this.openbtn.BorderColor = Color.Aqua;
			this.openbtn.DialogResult = DialogResult.None;
			this.openbtn.FocusedColor = Color.Empty;
			this.openbtn.Font = new Font("Ebrima", 9f);
			this.openbtn.ForeColor = Color.FromArgb(0, 238, 148);
			this.openbtn.Image = null;
			this.openbtn.ImageSize = new Size(20, 20);
			this.openbtn.Location = new Point(164, 6);
			this.openbtn.Name = "openbtn";
			this.openbtn.OnHoverBaseColor = Color.FromArgb(0, 238, 148);
			this.openbtn.OnHoverBorderColor = Color.FromArgb(0, 238, 148);
			this.openbtn.OnHoverForeColor = Color.White;
			this.openbtn.OnHoverImage = null;
			this.openbtn.OnPressedColor = Color.Black;
			this.openbtn.Radius = 5;
			this.openbtn.Size = new Size(70, 23);
			this.openbtn.TabIndex = 24;
			this.openbtn.Text = "Open";
			this.openbtn.TextAlign = HorizontalAlignment.Center;
			this.openbtn.Click += this.openbtn_Click;
			this.clearbtn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.clearbtn.Animated = true;
			this.clearbtn.AnimationHoverSpeed = 0.07f;
			this.clearbtn.AnimationSpeed = 0.03f;
			this.clearbtn.BackColor = Color.Transparent;
			this.clearbtn.BaseColor = Color.Transparent;
			this.clearbtn.BorderColor = Color.Aqua;
			this.clearbtn.DialogResult = DialogResult.None;
			this.clearbtn.FocusedColor = Color.Empty;
			this.clearbtn.Font = new Font("Ebrima", 9f);
			this.clearbtn.ForeColor = Color.FromArgb(0, 238, 148);
			this.clearbtn.Image = null;
			this.clearbtn.ImageSize = new Size(20, 20);
			this.clearbtn.Location = new Point(88, 6);
			this.clearbtn.Name = "clearbtn";
			this.clearbtn.OnHoverBaseColor = Color.FromArgb(0, 238, 148);
			this.clearbtn.OnHoverBorderColor = Color.FromArgb(0, 238, 148);
			this.clearbtn.OnHoverForeColor = Color.White;
			this.clearbtn.OnHoverImage = null;
			this.clearbtn.OnPressedColor = Color.Black;
			this.clearbtn.Radius = 5;
			this.clearbtn.Size = new Size(70, 23);
			this.clearbtn.TabIndex = 23;
			this.clearbtn.Text = "Clear";
			this.clearbtn.TextAlign = HorizontalAlignment.Center;
			this.clearbtn.Click += this.clearbtn_Click;
			this.executebtn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.executebtn.Animated = true;
			this.executebtn.AnimationHoverSpeed = 0.07f;
			this.executebtn.AnimationSpeed = 0.03f;
			this.executebtn.BackColor = Color.Transparent;
			this.executebtn.BaseColor = Color.Transparent;
			this.executebtn.BorderColor = Color.Aqua;
			this.executebtn.DialogResult = DialogResult.None;
			this.executebtn.FocusedColor = Color.Empty;
			this.executebtn.Font = new Font("Ebrima", 9f);
			this.executebtn.ForeColor = Color.FromArgb(0, 238, 148);
			this.executebtn.Image = null;
			this.executebtn.ImageSize = new Size(20, 20);
			this.executebtn.Location = new Point(12, 6);
			this.executebtn.Name = "executebtn";
			this.executebtn.OnHoverBaseColor = Color.FromArgb(0, 238, 148);
			this.executebtn.OnHoverBorderColor = Color.FromArgb(0, 238, 148);
			this.executebtn.OnHoverForeColor = Color.White;
			this.executebtn.OnHoverImage = null;
			this.executebtn.OnPressedColor = Color.Black;
			this.executebtn.Radius = 5;
			this.executebtn.Size = new Size(70, 23);
			this.executebtn.TabIndex = 22;
			this.executebtn.Text = "Execute";
			this.executebtn.TextAlign = HorizontalAlignment.Center;
			this.executebtn.Click += this.executebtn_Click;
			this.attach_check.Interval = 1000;
			this.attach_check.Tick += this.attach_check_Tick;
			this.protect_my_eyes_please.Location = new Point(12, 25);
			this.protect_my_eyes_please.Name = "protect_my_eyes_please";
			this.protect_my_eyes_please.Size = new Size(488, 270);
			this.protect_my_eyes_please.TabIndex = 17;
			this.protect_my_eyes_please.Paint += this.protect_my_eyes_please_Paint;
			this.RGB_Checker.Interval = 10;
			this.RGB_Checker.Tick += this.RGB_Checker_Tick;
			this.clear_rblx_logs.Interval = 1000;
			this.clear_rblx_logs.Tick += this.clear_rblx_logs_Tick;
			this.gunaShadowPanel1.BackColor = Color.Transparent;
			this.gunaShadowPanel1.BaseColor = Color.FromArgb(34, 34, 34);
			this.gunaShadowPanel1.Controls.Add(this.scriptlist);
			this.gunaShadowPanel1.Location = new Point(506, 25);
			this.gunaShadowPanel1.Name = "gunaShadowPanel1";
			this.gunaShadowPanel1.ShadowColor = Color.Black;
			this.gunaShadowPanel1.Size = new Size(139, 270);
			this.gunaShadowPanel1.TabIndex = 18;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(32, 32, 32);
			base.ClientSize = new Size(657, 338);
			base.Controls.Add(this.gunaShadowPanel1);
			base.Controls.Add(this.protect_my_eyes_please);
			base.Controls.Add(this.bottom_bar);
			base.Controls.Add(this.Scintilla);
			base.Controls.Add(this.drag);
			this.ForeColor = SystemColors.ControlText;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "KrakenX";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Kraken X";
			base.Load += this.KrakenX_Load;
			this.drag.ResumeLayout(false);
			this.drag.PerformLayout();
			this.bottom_bar.ResumeLayout(false);
			this.gunaShadowPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000001 RID: 1
		private Point MouseDownLocation;

		// Token: 0x04000002 RID: 2
		private int maxLineNumberCharLength;

		// Token: 0x04000003 RID: 3
		public GunaAnimateWindow animate;

		// Token: 0x04000004 RID: 4
		public System.Windows.Forms.Timer fade_in;

		// Token: 0x04000005 RID: 5
		public System.Windows.Forms.Timer fade_out;

		// Token: 0x04000006 RID: 6
		public GunaButton exit;

		// Token: 0x04000007 RID: 7
		public GunaButton minimize;

		// Token: 0x04000008 RID: 8
		public Panel drag;

		// Token: 0x04000009 RID: 9
		public Scintilla Scintilla;

		// Token: 0x0400000A RID: 10
		public ListBox scriptlist;

		// Token: 0x0400000B RID: 11
		public Panel bottom_bar;

		// Token: 0x0400000C RID: 12
		public GunaButton settingsbtn;

		// Token: 0x0400000D RID: 13
		public GunaButton openbtn;

		// Token: 0x0400000E RID: 14
		public GunaButton clearbtn;

		// Token: 0x0400000F RID: 15
		public GunaButton executebtn;

		// Token: 0x04000010 RID: 16
		public GunaButton attachbtn;

		// Token: 0x04000011 RID: 17
		public GunaButton refreshbtn;

		// Token: 0x04000012 RID: 18
		public System.Windows.Forms.Timer attach_check;

		// Token: 0x04000013 RID: 19
		public Panel protect_my_eyes_please;

		// Token: 0x04000014 RID: 20
		public GunaLabel watermark;

		// Token: 0x04000015 RID: 21
		public System.Windows.Forms.Timer RGB_Checker;

		// Token: 0x04000017 RID: 23
		public System.Windows.Forms.Timer clear_rblx_logs;

		// Token: 0x04000018 RID: 24
		private GunaShadowPanel gunaShadowPanel1;
	}
}
