namespace Server.Forms
{
	// Token: 0x02000063 RID: 99
	public partial class FormShell : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x00027B00 File Offset: 0x00027B00
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00027B28 File Offset: 0x00027B28
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.textBox1 = new global::DarkUI.Controls.DarkTextBox();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.panel1 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.richTextBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.richTextBox1.BackColor = global::System.Drawing.Color.FromArgb(0, 37, 86);
			this.richTextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Font = new global::System.Drawing.Font("Consolas", 8f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.richTextBox1.ForeColor = global::System.Drawing.Color.FromArgb(248, 248, 242);
			this.richTextBox1.Location = new global::System.Drawing.Point(0, 0);
			this.richTextBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new global::System.Drawing.Size(533, 268);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.textBox1.BackColor = global::System.Drawing.Color.FromArgb(248, 248, 242);
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.textBox1.Font = new global::System.Drawing.Font("Consolas", 8f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = global::System.Drawing.Color.FromArgb(40, 42, 54);
			this.textBox1.Location = new global::System.Drawing.Point(31, 271);
			this.textBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(502, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.Timer1_Tick);
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(0, 37, 86);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(31, 291);
			this.panel1.TabIndex = 2;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(40, 42, 54);
			base.ClientSize = new global::System.Drawing.Size(533, 291);
			base.Controls.Add(this.richTextBox1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.panel1);
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "FormShell";
			base.ShowIcon = false;
			this.Text = "Remote Shell";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormShell_FormClosed);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002BA RID: 698
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002BB RID: 699
		public global::System.Windows.Forms.RichTextBox richTextBox1;

		// Token: 0x040002BC RID: 700
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002BD RID: 701
		public global::System.Windows.Forms.Timer timer1;

		// Token: 0x040002BE RID: 702
		private global::DarkUI.Controls.DarkTextBox textBox1;
	}
}
