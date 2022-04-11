namespace Server.Forms
{
	// Token: 0x02000062 RID: 98
	public partial class FormDownloadFile : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00027518 File Offset: 0x00027518
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00027540 File Offset: 0x00027540
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.labelsize = new global::DarkUI.Controls.DarkLabel();
			this.label3 = new global::DarkUI.Controls.DarkLabel();
			this.labelfile = new global::DarkUI.Controls.DarkLabel();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(8, 59);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(64, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Downloaad:";
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.labelsize.AutoSize = true;
			this.labelsize.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.labelsize.Location = new global::System.Drawing.Point(69, 59);
			this.labelsize.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelsize.Name = "labelsize";
			this.labelsize.Size = new global::System.Drawing.Size(13, 13);
			this.labelsize.TabIndex = 0;
			this.labelsize.Text = "..";
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label3.Location = new global::System.Drawing.Point(8, 25);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(26, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "File:";
			this.labelfile.AutoSize = true;
			this.labelfile.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.labelfile.Location = new global::System.Drawing.Point(69, 25);
			this.labelfile.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelfile.Name = "labelfile";
			this.labelfile.Size = new global::System.Drawing.Size(13, 13);
			this.labelfile.TabIndex = 0;
			this.labelfile.Text = "..";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(410, 99);
			base.Controls.Add(this.labelfile);
			base.Controls.Add(this.labelsize);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormDownloadFile";
			base.ShowIcon = false;
			this.Text = "Download";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.SocketDownload_FormClosed);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002B2 RID: 690
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002B3 RID: 691
		public global::System.Windows.Forms.Timer timer1;

		// Token: 0x040002B4 RID: 692
		public global::DarkUI.Controls.DarkLabel labelsize;

		// Token: 0x040002B5 RID: 693
		private global::DarkUI.Controls.DarkLabel label3;

		// Token: 0x040002B6 RID: 694
		public global::DarkUI.Controls.DarkLabel labelfile;

		// Token: 0x040002B7 RID: 695
		public global::DarkUI.Controls.DarkLabel label1;
	}
}
