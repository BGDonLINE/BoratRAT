namespace Server.Forms
{
	// Token: 0x0200005B RID: 91
	public partial class FormDOS : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000375 RID: 885 RVA: 0x00020E78 File Offset: 0x00020E78
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00020EA0 File Offset: 0x00020EA0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.groupBox1 = new global::DarkUI.Controls.DarkGroupBox();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.txtPort = new global::DarkUI.Controls.DarkTextBox();
			this.txtHost = new global::DarkUI.Controls.DarkTextBox();
			this.label4 = new global::DarkUI.Controls.DarkLabel();
			this.label3 = new global::DarkUI.Controls.DarkLabel();
			this.txtTimeout = new global::DarkUI.Controls.DarkTextBox();
			this.groupBox3 = new global::DarkUI.Controls.DarkGroupBox();
			this.btnStop = new global::DarkUI.Controls.DarkButton();
			this.btnAttack = new global::DarkUI.Controls.DarkButton();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTimeout);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtPort);
			this.groupBox1.Controls.Add(this.txtHost);
			this.groupBox1.Location = new global::System.Drawing.Point(8, 8);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new global::System.Drawing.Size(387, 131);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Target";
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label2.Location = new global::System.Drawing.Point(11, 87);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(37, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "PORT";
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(11, 42);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(37, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "HOST";
			this.txtPort.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.txtPort.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPort.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.txtPort.Location = new global::System.Drawing.Point(55, 83);
			this.txtPort.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new global::System.Drawing.Size(48, 20);
			this.txtPort.TabIndex = 1;
			this.txtPort.Text = "80";
			this.txtHost.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.txtHost.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHost.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.txtHost.Location = new global::System.Drawing.Point(55, 39);
			this.txtHost.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new global::System.Drawing.Size(287, 20);
			this.txtHost.TabIndex = 1;
			this.txtHost.Text = "www.website.com";
			this.label4.AutoSize = true;
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label4.Location = new global::System.Drawing.Point(316, 87);
			this.label4.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(26, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "min.";
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label3.Location = new global::System.Drawing.Point(206, 87);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(45, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Timeout";
			this.txtTimeout.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.txtTimeout.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTimeout.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.txtTimeout.Location = new global::System.Drawing.Point(269, 84);
			this.txtTimeout.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtTimeout.Name = "txtTimeout";
			this.txtTimeout.Size = new global::System.Drawing.Size(43, 20);
			this.txtTimeout.TabIndex = 3;
			this.txtTimeout.Text = "5";
			this.groupBox3.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox3.Controls.Add(this.btnStop);
			this.groupBox3.Controls.Add(this.btnAttack);
			this.groupBox3.Location = new global::System.Drawing.Point(399, 8);
			this.groupBox3.Margin = new global::System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new global::System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new global::System.Drawing.Size(103, 131);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Order";
			this.btnStop.Enabled = false;
			this.btnStop.Location = new global::System.Drawing.Point(15, 75);
			this.btnStop.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnStop.Name = "btnStop";
			this.btnStop.Padding = new global::System.Windows.Forms.Padding(5);
			this.btnStop.Size = new global::System.Drawing.Size(71, 37);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.Click += new global::System.EventHandler(this.BtnStop_Click);
			this.btnAttack.Location = new global::System.Drawing.Point(15, 22);
			this.btnAttack.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnAttack.Name = "btnAttack";
			this.btnAttack.Padding = new global::System.Windows.Forms.Padding(5);
			this.btnAttack.Size = new global::System.Drawing.Size(71, 37);
			this.btnAttack.TabIndex = 0;
			this.btnAttack.Text = "Start";
			this.btnAttack.Click += new global::System.EventHandler(this.BtnAttack_Click);
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.Timer1_Tick);
			this.timer2.Interval = 5000;
			this.timer2.Tick += new global::System.EventHandler(this.Timer2_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(513, 147);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "FormDOS";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DDOS";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FormDOS_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400022C RID: 556
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.Timer timer2;

		// Token: 0x0400022F RID: 559
		private global::DarkUI.Controls.DarkGroupBox groupBox1;

		// Token: 0x04000230 RID: 560
		private global::DarkUI.Controls.DarkLabel label2;

		// Token: 0x04000231 RID: 561
		private global::DarkUI.Controls.DarkLabel label1;

		// Token: 0x04000232 RID: 562
		private global::DarkUI.Controls.DarkTextBox txtPort;

		// Token: 0x04000233 RID: 563
		private global::DarkUI.Controls.DarkTextBox txtHost;

		// Token: 0x04000234 RID: 564
		private global::DarkUI.Controls.DarkLabel label4;

		// Token: 0x04000235 RID: 565
		private global::DarkUI.Controls.DarkLabel label3;

		// Token: 0x04000236 RID: 566
		private global::DarkUI.Controls.DarkTextBox txtTimeout;

		// Token: 0x04000237 RID: 567
		private global::DarkUI.Controls.DarkGroupBox groupBox3;

		// Token: 0x04000238 RID: 568
		private global::DarkUI.Controls.DarkButton btnStop;

		// Token: 0x04000239 RID: 569
		private global::DarkUI.Controls.DarkButton btnAttack;
	}
}
