namespace Server.Forms
{
	// Token: 0x02000057 RID: 87
	public partial class FormAudio : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x0600034B RID: 843 RVA: 0x0001BCB8 File Offset: 0x0001BCB8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001BCE0 File Offset: 0x0001BCE0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.btnStartStopRecord = new global::DarkUI.Controls.DarkButton();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.textBox1 = new global::DarkUI.Controls.DarkTextBox();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			base.SuspendLayout();
			this.btnStartStopRecord.Location = new global::System.Drawing.Point(12, 82);
			this.btnStartStopRecord.Name = "btnStartStopRecord";
			this.btnStartStopRecord.Size = new global::System.Drawing.Size(297, 21);
			this.btnStartStopRecord.TabIndex = 0;
			this.btnStartStopRecord.Text = "Start Recording";
			this.btnStartStopRecord.UseVisualStyleBackColor = true;
			this.btnStartStopRecord.Click += new global::System.EventHandler(this.btnStartStopRecord_Click);
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.textBox1.Location = new global::System.Drawing.Point(12, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(244, 21);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "10";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(262, 36);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(47, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "seconds";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(321, 115);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.btnStartStopRecord);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "FormAudio";
			base.ShowIcon = false;
			this.Text = "Audio Recorder";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001DF RID: 479
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001E0 RID: 480
		public global::System.Windows.Forms.Button btnStartStopRecord;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.Label label1;
	}
}
