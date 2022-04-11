namespace Server
{
	// Token: 0x02000010 RID: 16
	public partial class FormSendFileToMemory : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x060000AC RID: 172 RVA: 0x0000B374 File Offset: 0x0000B374
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000B39C File Offset: 0x0000B39C
		private void InitializeComponent()
		{
			this.groupBox1 = new global::DarkUI.Controls.DarkGroupBox();
			this.button1 = new global::DarkUI.Controls.DarkButton();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.label3 = new global::DarkUI.Controls.DarkLabel();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.comboBox2 = new global::DarkUI.Controls.DarkComboBox();
			this.comboBox1 = new global::DarkUI.Controls.DarkComboBox();
			this.button2 = new global::DarkUI.Controls.DarkButton();
			this.statusStrip1 = new global::DarkUI.Controls.DarkStatusStrip();
			this.toolStripStatusLabel1 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.button3 = new global::DarkUI.Controls.DarkButton();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new global::System.Drawing.Point(8, 8);
			this.groupBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new global::System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new global::System.Drawing.Size(213, 119);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Injection";
			this.button1.Location = new global::System.Drawing.Point(75, 54);
			this.button1.Margin = new global::System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Padding = new global::System.Windows.Forms.Padding(5);
			this.button1.Size = new global::System.Drawing.Size(135, 22);
			this.button1.TabIndex = 1;
			this.button1.Text = "Select";
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label2.Location = new global::System.Drawing.Point(4, 59);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(26, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "File:";
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label3.Location = new global::System.Drawing.Point(4, 92);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(41, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Target:";
			this.label3.Visible = false;
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(4, 24);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(34, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type:";
			this.comboBox2.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] { "aspnet_compiler.exe", "RegAsm.exe", "MSBuild.exe", "RegSvcs.exe", "vbc.exe" });
			this.comboBox2.Location = new global::System.Drawing.Point(75, 90);
			this.comboBox2.Margin = new global::System.Windows.Forms.Padding(2);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new global::System.Drawing.Size(135, 21);
			this.comboBox2.TabIndex = 1;
			this.comboBox2.Visible = false;
			this.comboBox1.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] { "Reflection", "RunPE" });
			this.comboBox1.Location = new global::System.Drawing.Point(75, 22);
			this.comboBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(135, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new global::System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.button2.Location = new global::System.Drawing.Point(15, 143);
			this.button2.Margin = new global::System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Padding = new global::System.Windows.Forms.Padding(5);
			this.button2.Size = new global::System.Drawing.Size(59, 20);
			this.button2.TabIndex = 1;
			this.button2.Text = "OK";
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.statusStrip1.AutoSize = false;
			this.statusStrip1.BackColor = global::System.Drawing.Color.FromArgb(60, 63, 65);
			this.statusStrip1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.statusStrip1.ImageScalingSize = new global::System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel1 });
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 175);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new global::System.Windows.Forms.Padding(1, 0, 9, 0);
			this.statusStrip1.Size = new global::System.Drawing.Size(234, 24);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new global::System.Drawing.Size(16, 19);
			this.toolStripStatusLabel1.Text = "...";
			this.button3.Location = new global::System.Drawing.Point(146, 143);
			this.button3.Margin = new global::System.Windows.Forms.Padding(2);
			this.button3.Name = "button3";
			this.button3.Padding = new global::System.Windows.Forms.Padding(5);
			this.button3.Size = new global::System.Drawing.Size(75, 20);
			this.button3.TabIndex = 3;
			this.button3.Text = "CANCEL";
			this.button3.Click += new global::System.EventHandler(this.Button3_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(234, 199);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormSendFileToMemory";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Injection";
			base.Load += new global::System.EventHandler(this.SendFileToMemory_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400009C RID: 156
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400009D RID: 157
		public global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

		// Token: 0x0400009E RID: 158
		private global::DarkUI.Controls.DarkGroupBox groupBox1;

		// Token: 0x0400009F RID: 159
		private global::DarkUI.Controls.DarkButton button1;

		// Token: 0x040000A0 RID: 160
		private global::DarkUI.Controls.DarkLabel label2;

		// Token: 0x040000A1 RID: 161
		private global::DarkUI.Controls.DarkLabel label1;

		// Token: 0x040000A2 RID: 162
		public global::DarkUI.Controls.DarkComboBox comboBox1;

		// Token: 0x040000A3 RID: 163
		private global::DarkUI.Controls.DarkButton button2;

		// Token: 0x040000A4 RID: 164
		private global::DarkUI.Controls.DarkStatusStrip statusStrip1;

		// Token: 0x040000A5 RID: 165
		private global::DarkUI.Controls.DarkLabel label3;

		// Token: 0x040000A6 RID: 166
		public global::DarkUI.Controls.DarkComboBox comboBox2;

		// Token: 0x040000A7 RID: 167
		private global::DarkUI.Controls.DarkButton button3;
	}
}
