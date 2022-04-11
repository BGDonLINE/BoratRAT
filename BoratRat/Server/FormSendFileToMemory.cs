using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Helper;

namespace Server
{
	// Token: 0x02000010 RID: 16
	public partial class FormSendFileToMemory : DarkForm
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x0000B1A4 File Offset: 0x0000B1A4
		public FormSendFileToMemory()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000B1B4 File Offset: 0x0000B1B4
		private void SendFileToMemory_Load(object sender, EventArgs e)
		{
			this.comboBox1.SelectedIndex = 0;
			this.comboBox2.SelectedIndex = 0;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000B1D0 File Offset: 0x0000B1D0
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.comboBox1.SelectedIndex;
			if (selectedIndex == 0)
			{
				this.label3.Visible = false;
				this.comboBox2.Visible = false;
				return;
			}
			if (selectedIndex != 1)
			{
				return;
			}
			this.label3.Visible = true;
			this.comboBox2.Visible = true;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000B22C File Offset: 0x0000B22C
		private void button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "(*.exe)|*.exe";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.toolStripStatusLabel1.Text = Path.GetFileName(openFileDialog.FileName);
					this.toolStripStatusLabel1.Tag = openFileDialog.FileName;
					this.toolStripStatusLabel1.ForeColor = Color.Green;
					this.IsOK = true;
					if (this.comboBox1.SelectedIndex != 0)
					{
						goto IL_E6;
					}
					try
					{
						new ReferenceLoader().AppDomainSetup(openFileDialog.FileName);
						this.IsOK = true;
						return;
					}
					catch
					{
						this.toolStripStatusLabel1.ForeColor = Color.Red;
						ToolStripStatusLabel toolStripStatusLabel = this.toolStripStatusLabel1;
						toolStripStatusLabel.Text += " Invalid!";
						this.IsOK = false;
						return;
					}
				}
				this.toolStripStatusLabel1.Text = "";
				this.toolStripStatusLabel1.ForeColor = Color.Black;
				this.IsOK = true;
				IL_E6:;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000B350 File Offset: 0x0000B350
		private void button2_Click(object sender, EventArgs e)
		{
			if (this.IsOK)
			{
				base.Hide();
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000B364 File Offset: 0x0000B364
		private void Button3_Click(object sender, EventArgs e)
		{
			this.IsOK = false;
			base.Hide();
		}

		// Token: 0x0400009B RID: 155
		public bool IsOK;
	}
}
