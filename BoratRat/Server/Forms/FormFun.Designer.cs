namespace Server.Forms
{
	// Token: 0x0200004F RID: 79
	public partial class FormFun : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000312 RID: 786 RVA: 0x00017E20 File Offset: 0x00017E20
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00017E48 File Offset: 0x00017E48
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.button1 = new global::DarkUI.Controls.DarkButton();
			this.button2 = new global::DarkUI.Controls.DarkButton();
			this.groupBox1 = new global::DarkUI.Controls.DarkGroupBox();
			this.groupBox2 = new global::DarkUI.Controls.DarkGroupBox();
			this.button4 = new global::DarkUI.Controls.DarkButton();
			this.button3 = new global::DarkUI.Controls.DarkButton();
			this.groupBox3 = new global::DarkUI.Controls.DarkGroupBox();
			this.button5 = new global::DarkUI.Controls.DarkButton();
			this.button6 = new global::DarkUI.Controls.DarkButton();
			this.groupBox4 = new global::DarkUI.Controls.DarkGroupBox();
			this.button7 = new global::DarkUI.Controls.DarkButton();
			this.button8 = new global::DarkUI.Controls.DarkButton();
			this.groupBox5 = new global::DarkUI.Controls.DarkGroupBox();
			this.button9 = new global::DarkUI.Controls.DarkButton();
			this.button10 = new global::DarkUI.Controls.DarkButton();
			this.groupBox6 = new global::DarkUI.Controls.DarkGroupBox();
			this.button11 = new global::DarkUI.Controls.DarkButton();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.numericUpDown1 = new global::DarkUI.Controls.DarkNumericUpDown();
			this.button12 = new global::DarkUI.Controls.DarkButton();
			this.button14 = new global::DarkUI.Controls.DarkButton();
			this.groupBox7 = new global::DarkUI.Controls.DarkGroupBox();
			this.button15 = new global::DarkUI.Controls.DarkButton();
			this.label3 = new global::DarkUI.Controls.DarkLabel();
			this.label4 = new global::DarkUI.Controls.DarkLabel();
			this.numericUpDown2 = new global::DarkUI.Controls.DarkNumericUpDown();
			this.groupBox9 = new global::DarkUI.Controls.DarkGroupBox();
			this.button17 = new global::DarkUI.Controls.DarkButton();
			this.button18 = new global::DarkUI.Controls.DarkButton();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.groupBox8 = new global::DarkUI.Controls.DarkGroupBox();
			this.button16 = new global::DarkUI.Controls.DarkButton();
			this.button19 = new global::DarkUI.Controls.DarkButton();
			this.button13 = new global::DarkUI.Controls.DarkButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			base.SuspendLayout();
			this.button1.Location = new global::System.Drawing.Point(6, 22);
			this.button1.Name = "button1";
			this.button1.Padding = new global::System.Windows.Forms.Padding(5);
			this.button1.Size = new global::System.Drawing.Size(75, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Show";
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Location = new global::System.Drawing.Point(87, 22);
			this.button2.Name = "button2";
			this.button2.Padding = new global::System.Windows.Forms.Padding(5);
			this.button2.Size = new global::System.Drawing.Size(75, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Hide";
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.groupBox1.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(170, 61);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Taskbar";
			this.groupBox2.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 80);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(170, 61);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Desktop";
			this.button4.Location = new global::System.Drawing.Point(88, 23);
			this.button4.Name = "button4";
			this.button4.Padding = new global::System.Windows.Forms.Padding(5);
			this.button4.Size = new global::System.Drawing.Size(75, 32);
			this.button4.TabIndex = 1;
			this.button4.Text = "Hide";
			this.button4.Click += new global::System.EventHandler(this.button4_Click);
			this.button3.Location = new global::System.Drawing.Point(7, 23);
			this.button3.Name = "button3";
			this.button3.Padding = new global::System.Windows.Forms.Padding(5);
			this.button3.Size = new global::System.Drawing.Size(75, 31);
			this.button3.TabIndex = 0;
			this.button3.Text = "Show";
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.groupBox3.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox3.Controls.Add(this.button5);
			this.groupBox3.Controls.Add(this.button6);
			this.groupBox3.Location = new global::System.Drawing.Point(12, 150);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(170, 61);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Clock";
			this.button5.Location = new global::System.Drawing.Point(6, 22);
			this.button5.Name = "button5";
			this.button5.Padding = new global::System.Windows.Forms.Padding(5);
			this.button5.Size = new global::System.Drawing.Size(75, 32);
			this.button5.TabIndex = 0;
			this.button5.Text = "Show";
			this.button5.Click += new global::System.EventHandler(this.button5_Click);
			this.button6.Location = new global::System.Drawing.Point(87, 22);
			this.button6.Name = "button6";
			this.button6.Padding = new global::System.Windows.Forms.Padding(5);
			this.button6.Size = new global::System.Drawing.Size(75, 32);
			this.button6.TabIndex = 1;
			this.button6.Text = "Hide";
			this.button6.Click += new global::System.EventHandler(this.button6_Click);
			this.groupBox4.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox4.Controls.Add(this.button7);
			this.groupBox4.Controls.Add(this.button8);
			this.groupBox4.Location = new global::System.Drawing.Point(199, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(170, 61);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Mouse";
			this.button7.Location = new global::System.Drawing.Point(88, 23);
			this.button7.Name = "button7";
			this.button7.Padding = new global::System.Windows.Forms.Padding(5);
			this.button7.Size = new global::System.Drawing.Size(75, 32);
			this.button7.TabIndex = 1;
			this.button7.Text = "Restore";
			this.button7.Click += new global::System.EventHandler(this.button7_Click);
			this.button8.Location = new global::System.Drawing.Point(7, 23);
			this.button8.Name = "button8";
			this.button8.Padding = new global::System.Windows.Forms.Padding(5);
			this.button8.Size = new global::System.Drawing.Size(75, 31);
			this.button8.TabIndex = 0;
			this.button8.Text = "Swap";
			this.button8.Click += new global::System.EventHandler(this.button8_Click);
			this.groupBox5.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox5.Controls.Add(this.button9);
			this.groupBox5.Controls.Add(this.button10);
			this.groupBox5.Location = new global::System.Drawing.Point(199, 80);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(170, 61);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "CD Drive";
			this.button9.Location = new global::System.Drawing.Point(88, 23);
			this.button9.Name = "button9";
			this.button9.Padding = new global::System.Windows.Forms.Padding(5);
			this.button9.Size = new global::System.Drawing.Size(75, 32);
			this.button9.TabIndex = 1;
			this.button9.Text = "Close";
			this.button9.Click += new global::System.EventHandler(this.button9_Click);
			this.button10.Location = new global::System.Drawing.Point(7, 23);
			this.button10.Name = "button10";
			this.button10.Padding = new global::System.Windows.Forms.Padding(5);
			this.button10.Size = new global::System.Drawing.Size(75, 31);
			this.button10.TabIndex = 0;
			this.button10.Text = "Open";
			this.button10.Click += new global::System.EventHandler(this.button10_Click);
			this.groupBox6.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox6.Controls.Add(this.button11);
			this.groupBox6.Controls.Add(this.label2);
			this.groupBox6.Controls.Add(this.label1);
			this.groupBox6.Controls.Add(this.numericUpDown1);
			this.groupBox6.Location = new global::System.Drawing.Point(12, 230);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(357, 74);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Block Input";
			this.button11.Location = new global::System.Drawing.Point(217, 29);
			this.button11.Name = "button11";
			this.button11.Padding = new global::System.Windows.Forms.Padding(5);
			this.button11.Size = new global::System.Drawing.Size(71, 28);
			this.button11.TabIndex = 3;
			this.button11.Text = "Start";
			this.button11.Click += new global::System.EventHandler(this.button11_Click);
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label2.Location = new global::System.Drawing.Point(164, 34);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(47, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "seconds";
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(52, 34);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(19, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "for";
			this.numericUpDown1.Location = new global::System.Drawing.Point(81, 32);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(77, 20);
			this.numericUpDown1.TabIndex = 0;
			this.button12.Location = new global::System.Drawing.Point(137, 486);
			this.button12.Name = "button12";
			this.button12.Padding = new global::System.Windows.Forms.Padding(5);
			this.button12.Size = new global::System.Drawing.Size(101, 35);
			this.button12.TabIndex = 6;
			this.button12.Text = "Turn Monitor off";
			this.button12.Click += new global::System.EventHandler(this.button12_Click);
			this.button14.Location = new global::System.Drawing.Point(261, 486);
			this.button14.Name = "button14";
			this.button14.Padding = new global::System.Windows.Forms.Padding(5);
			this.button14.Size = new global::System.Drawing.Size(101, 35);
			this.button14.TabIndex = 8;
			this.button14.Text = "Hang system";
			this.button14.Click += new global::System.EventHandler(this.button14_Click);
			this.groupBox7.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox7.Controls.Add(this.button15);
			this.groupBox7.Controls.Add(this.label3);
			this.groupBox7.Controls.Add(this.label4);
			this.groupBox7.Controls.Add(this.numericUpDown2);
			this.groupBox7.Location = new global::System.Drawing.Point(12, 310);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(357, 74);
			this.groupBox7.TabIndex = 5;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Hold Mouse";
			this.button15.Location = new global::System.Drawing.Point(217, 29);
			this.button15.Name = "button15";
			this.button15.Padding = new global::System.Windows.Forms.Padding(5);
			this.button15.Size = new global::System.Drawing.Size(71, 28);
			this.button15.TabIndex = 3;
			this.button15.Text = "Start";
			this.button15.Click += new global::System.EventHandler(this.button15_Click);
			this.label3.AutoSize = true;
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label3.Location = new global::System.Drawing.Point(164, 34);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(47, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "seconds";
			this.label4.AutoSize = true;
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label4.Location = new global::System.Drawing.Point(52, 34);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(19, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "for";
			this.numericUpDown2.Location = new global::System.Drawing.Point(81, 32);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new global::System.Drawing.Size(77, 20);
			this.numericUpDown2.TabIndex = 0;
			this.groupBox9.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox9.Controls.Add(this.button17);
			this.groupBox9.Controls.Add(this.button18);
			this.groupBox9.Location = new global::System.Drawing.Point(199, 147);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(170, 61);
			this.groupBox9.TabIndex = 4;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Lock Screen";
			this.button17.Location = new global::System.Drawing.Point(88, 23);
			this.button17.Name = "button17";
			this.button17.Padding = new global::System.Windows.Forms.Padding(5);
			this.button17.Size = new global::System.Drawing.Size(75, 32);
			this.button17.TabIndex = 1;
			this.button17.Text = "Stop";
			this.button17.Click += new global::System.EventHandler(this.button17_Click);
			this.button18.Location = new global::System.Drawing.Point(7, 23);
			this.button18.Name = "button18";
			this.button18.Padding = new global::System.Windows.Forms.Padding(5);
			this.button18.Size = new global::System.Drawing.Size(75, 31);
			this.button18.TabIndex = 0;
			this.button18.Text = "Start";
			this.button18.Click += new global::System.EventHandler(this.button18_Click);
			this.timer1.Interval = 2000;
			this.timer1.Tick += new global::System.EventHandler(this.Timer1_Tick);
			this.groupBox8.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.groupBox8.Controls.Add(this.button16);
			this.groupBox8.Controls.Add(this.button19);
			this.groupBox8.Location = new global::System.Drawing.Point(12, 390);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(357, 86);
			this.groupBox8.TabIndex = 4;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Turn off webcam light";
			this.button16.Location = new global::System.Drawing.Point(176, 35);
			this.button16.Name = "button16";
			this.button16.Padding = new global::System.Windows.Forms.Padding(5);
			this.button16.Size = new global::System.Drawing.Size(112, 32);
			this.button16.TabIndex = 1;
			this.button16.Text = "Turn Off";
			this.button16.Click += new global::System.EventHandler(this.button16_Click);
			this.button19.Location = new global::System.Drawing.Point(58, 35);
			this.button19.Name = "button19";
			this.button19.Padding = new global::System.Windows.Forms.Padding(5);
			this.button19.Size = new global::System.Drawing.Size(112, 31);
			this.button19.TabIndex = 0;
			this.button19.Text = "Turn On";
			this.button19.Click += new global::System.EventHandler(this.button19_Click);
			this.button13.Location = new global::System.Drawing.Point(14, 486);
			this.button13.Name = "button13";
			this.button13.Padding = new global::System.Windows.Forms.Padding(5);
			this.button13.Size = new global::System.Drawing.Size(101, 35);
			this.button13.TabIndex = 9;
			this.button13.Text = "Play Audio";
			this.button13.Click += new global::System.EventHandler(this.button13_Click_1);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(382, 533);
			base.Controls.Add(this.button13);
			base.Controls.Add(this.button14);
			base.Controls.Add(this.button12);
			base.Controls.Add(this.groupBox7);
			base.Controls.Add(this.groupBox6);
			base.Controls.Add(this.groupBox8);
			base.Controls.Add(this.groupBox9);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Name = "FormFun";
			base.ShowIcon = false;
			this.Text = "Utils";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormFun_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
			this.groupBox9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000178 RID: 376
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000179 RID: 377
		public global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400017A RID: 378
		private global::DarkUI.Controls.DarkButton button1;

		// Token: 0x0400017B RID: 379
		private global::DarkUI.Controls.DarkButton button2;

		// Token: 0x0400017C RID: 380
		private global::DarkUI.Controls.DarkGroupBox groupBox1;

		// Token: 0x0400017D RID: 381
		private global::DarkUI.Controls.DarkGroupBox groupBox2;

		// Token: 0x0400017E RID: 382
		private global::DarkUI.Controls.DarkButton button4;

		// Token: 0x0400017F RID: 383
		private global::DarkUI.Controls.DarkButton button3;

		// Token: 0x04000180 RID: 384
		private global::DarkUI.Controls.DarkGroupBox groupBox3;

		// Token: 0x04000181 RID: 385
		private global::DarkUI.Controls.DarkButton button5;

		// Token: 0x04000182 RID: 386
		private global::DarkUI.Controls.DarkButton button6;

		// Token: 0x04000183 RID: 387
		private global::DarkUI.Controls.DarkGroupBox groupBox4;

		// Token: 0x04000184 RID: 388
		private global::DarkUI.Controls.DarkButton button7;

		// Token: 0x04000185 RID: 389
		private global::DarkUI.Controls.DarkButton button8;

		// Token: 0x04000186 RID: 390
		private global::DarkUI.Controls.DarkGroupBox groupBox5;

		// Token: 0x04000187 RID: 391
		private global::DarkUI.Controls.DarkButton button9;

		// Token: 0x04000188 RID: 392
		private global::DarkUI.Controls.DarkButton button10;

		// Token: 0x04000189 RID: 393
		private global::DarkUI.Controls.DarkGroupBox groupBox6;

		// Token: 0x0400018A RID: 394
		private global::DarkUI.Controls.DarkButton button11;

		// Token: 0x0400018B RID: 395
		private global::DarkUI.Controls.DarkLabel label2;

		// Token: 0x0400018C RID: 396
		private global::DarkUI.Controls.DarkLabel label1;

		// Token: 0x0400018D RID: 397
		private global::DarkUI.Controls.DarkNumericUpDown numericUpDown1;

		// Token: 0x0400018E RID: 398
		private global::DarkUI.Controls.DarkButton button12;

		// Token: 0x0400018F RID: 399
		private global::DarkUI.Controls.DarkButton button14;

		// Token: 0x04000190 RID: 400
		private global::DarkUI.Controls.DarkGroupBox groupBox7;

		// Token: 0x04000191 RID: 401
		private global::DarkUI.Controls.DarkButton button15;

		// Token: 0x04000192 RID: 402
		private global::DarkUI.Controls.DarkLabel label3;

		// Token: 0x04000193 RID: 403
		private global::DarkUI.Controls.DarkLabel label4;

		// Token: 0x04000194 RID: 404
		private global::DarkUI.Controls.DarkNumericUpDown numericUpDown2;

		// Token: 0x04000195 RID: 405
		private global::DarkUI.Controls.DarkGroupBox groupBox9;

		// Token: 0x04000196 RID: 406
		private global::DarkUI.Controls.DarkButton button17;

		// Token: 0x04000197 RID: 407
		private global::DarkUI.Controls.DarkButton button18;

		// Token: 0x04000198 RID: 408
		private global::DarkUI.Controls.DarkGroupBox groupBox8;

		// Token: 0x04000199 RID: 409
		private global::DarkUI.Controls.DarkButton button16;

		// Token: 0x0400019A RID: 410
		private global::DarkUI.Controls.DarkButton button19;

		// Token: 0x0400019B RID: 411
		private global::DarkUI.Controls.DarkButton button13;
	}
}
