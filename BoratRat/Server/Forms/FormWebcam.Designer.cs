namespace Server.Forms
{
	// Token: 0x02000064 RID: 100
	public partial class FormWebcam : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000403 RID: 1027 RVA: 0x00028288 File Offset: 0x00028288
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000282B0 File Offset: 0x000282B0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.numericUpDown1 = new global::DarkUI.Controls.DarkNumericUpDown();
			this.comboBox1 = new global::DarkUI.Controls.DarkComboBox();
			this.btnSave = new global::DarkUI.Controls.DarkButton();
			this.button1 = new global::DarkUI.Controls.DarkButton();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.timerSave = new global::System.Windows.Forms.Timer(this.components);
			this.labelWait = new global::DarkUI.Controls.DarkLabel();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Margin = new global::System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(533, 27);
			this.panel1.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(54, 6);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(30, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "FPS:";
			this.numericUpDown1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.numericUpDown1.Enabled = false;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 10;
			numericUpDown.Increment = new decimal(array);
			this.numericUpDown1.Location = new global::System.Drawing.Point(97, 4);
			this.numericUpDown1.Margin = new global::System.Windows.Forms.Padding(2);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown1;
			int[] array2 = new int[4];
			array2[0] = 20;
			numericUpDown2.Minimum = new decimal(array2);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(55, 20);
			this.numericUpDown1.TabIndex = 7;
			this.numericUpDown1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown1.UpDownAlign = global::System.Windows.Forms.LeftRightAlignment.Left;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown1;
			int[] array3 = new int[4];
			array3[0] = 50;
			numericUpDown3.Value = new decimal(array3);
			this.comboBox1.DrawMode = global::System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.comboBox1.Enabled = false;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new global::System.Drawing.Point(156, 4);
			this.comboBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(183, 21);
			this.comboBox1.TabIndex = 6;
			this.btnSave.BackgroundImage = global::Server.Properties.Resources.save_image;
			this.btnSave.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.btnSave.Enabled = false;
			this.btnSave.Location = new global::System.Drawing.Point(343, 0);
			this.btnSave.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new global::System.Windows.Forms.Padding(5);
			this.btnSave.Size = new global::System.Drawing.Size(26, 27);
			this.btnSave.TabIndex = 5;
			this.btnSave.Click += new global::System.EventHandler(this.BtnSave_Click);
			this.button1.BackgroundImage = global::Server.Properties.Resources.play_button;
			this.button1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.button1.Enabled = false;
			this.button1.Location = new global::System.Drawing.Point(2, 0);
			this.button1.Margin = new global::System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Padding = new global::System.Windows.Forms.Padding(5);
			this.button1.Size = new global::System.Drawing.Size(28, 27);
			this.button1.TabIndex = 0;
			this.button1.Tag = "play";
			this.button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 27);
			this.pictureBox1.Margin = new global::System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(533, 346);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.Timer1_Tick);
			this.timerSave.Interval = 1000;
			this.timerSave.Tick += new global::System.EventHandler(this.TimerSave_Tick);
			this.labelWait.AutoSize = true;
			this.labelWait.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelWait.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.labelWait.Location = new global::System.Drawing.Point(213, 178);
			this.labelWait.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelWait.Name = "labelWait";
			this.labelWait.Size = new global::System.Drawing.Size(101, 20);
			this.labelWait.TabIndex = 6;
			this.labelWait.Text = "Please wait...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(533, 373);
			base.Controls.Add(this.labelWait);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.panel1);
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "FormWebcam";
			base.ShowIcon = false;
			this.Text = "Remote Camera";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormWebcam_FormClosed);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002C7 RID: 711
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002C8 RID: 712
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002C9 RID: 713
		public global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040002CA RID: 714
		public global::System.Windows.Forms.Timer timer1;

		// Token: 0x040002CB RID: 715
		private global::System.Windows.Forms.Timer timerSave;

		// Token: 0x040002CC RID: 716
		public global::DarkUI.Controls.DarkComboBox comboBox1;

		// Token: 0x040002CD RID: 717
		public global::DarkUI.Controls.DarkButton btnSave;

		// Token: 0x040002CE RID: 718
		public global::DarkUI.Controls.DarkButton button1;

		// Token: 0x040002CF RID: 719
		public global::DarkUI.Controls.DarkLabel labelWait;

		// Token: 0x040002D0 RID: 720
		private global::DarkUI.Controls.DarkLabel label1;

		// Token: 0x040002D1 RID: 721
		public global::DarkUI.Controls.DarkNumericUpDown numericUpDown1;
	}
}
