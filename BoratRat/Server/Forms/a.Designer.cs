namespace Server.Forms
{
	// Token: 0x0200004E RID: 78
	public partial class a : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x0001747C File Offset: 0x0001747C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000174A4 File Offset: 0x000174A4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Server.Forms.a));
			this.darkTextBox1 = new global::DarkUI.Controls.DarkTextBox();
			this.darkButton1 = new global::DarkUI.Controls.DarkButton();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.darkTextBox1.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.darkTextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.darkTextBox1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.darkTextBox1.Location = new global::System.Drawing.Point(12, 92);
			this.darkTextBox1.Name = "darkTextBox1";
			this.darkTextBox1.Size = new global::System.Drawing.Size(262, 20);
			this.darkTextBox1.TabIndex = 0;
			this.darkButton1.Location = new global::System.Drawing.Point(103, 133);
			this.darkButton1.Name = "darkButton1";
			this.darkButton1.Padding = new global::System.Windows.Forms.Padding(5);
			this.darkButton1.Size = new global::System.Drawing.Size(75, 23);
			this.darkButton1.TabIndex = 1;
			this.darkButton1.Text = "Login";
			this.darkButton1.Click += new global::System.EventHandler(this.darkButton1_Click);
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(-9, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(295, 61);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(289, 178);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.darkButton1);
			base.Controls.Add(this.darkTextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "a";
			base.ShowIcon = false;
			this.Text = "Cracked.io Auth";
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000171 RID: 369
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000172 RID: 370
		private global::DarkUI.Controls.DarkTextBox darkTextBox1;

		// Token: 0x04000173 RID: 371
		private global::DarkUI.Controls.DarkButton darkButton1;

		// Token: 0x04000174 RID: 372
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
