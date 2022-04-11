namespace Server.Forms
{
	// Token: 0x0200005D RID: 93
	public partial class FormFileSearcher : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000399 RID: 921 RVA: 0x00023CB8 File Offset: 0x00023CB8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00023CE0 File Offset: 0x00023CE0
		private void InitializeComponent()
		{
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.txtExtnsions = new global::DarkUI.Controls.DarkTextBox();
			this.btnOk = new global::DarkUI.Controls.DarkButton();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.numericUpDown1 = new global::DarkUI.Controls.DarkNumericUpDown();
			this.label3 = new global::DarkUI.Controls.DarkLabel();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(8, 25);
			this.label1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type:";
			this.txtExtnsions.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.txtExtnsions.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtExtnsions.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.txtExtnsions.Location = new global::System.Drawing.Point(11, 47);
			this.txtExtnsions.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtExtnsions.Name = "txtExtnsions";
			this.txtExtnsions.Size = new global::System.Drawing.Size(366, 20);
			this.txtExtnsions.TabIndex = 1;
			this.txtExtnsions.Text = ".txt .pdf .doc";
			this.btnOk.Location = new global::System.Drawing.Point(286, 90);
			this.btnOk.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnOk.Name = "btnOk";
			this.btnOk.Padding = new global::System.Windows.Forms.Padding(5);
			this.btnOk.Size = new global::System.Drawing.Size(91, 31);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label2.Location = new global::System.Drawing.Point(8, 78);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(51, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Max size:";
			this.numericUpDown1.Location = new global::System.Drawing.Point(11, 99);
			this.numericUpDown1.Margin = new global::System.Windows.Forms.Padding(2);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown1;
			int[] array = new int[4];
			array[0] = 200;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown1;
			int[] array2 = new int[4];
			array2[0] = 1;
			numericUpDown2.Minimum = new decimal(array2);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new global::System.Drawing.Size(66, 20);
			this.numericUpDown1.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown1;
			int[] array3 = new int[4];
			array3[0] = 5;
			numericUpDown3.Value = new decimal(array3);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7f);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label3.Location = new global::System.Drawing.Point(86, 102);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(23, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "MB";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(383, 139);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.numericUpDown1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.txtExtnsions);
			base.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormFileSearcher";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Searcher";
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000263 RID: 611
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000264 RID: 612
		private global::DarkUI.Controls.DarkLabel label1;

		// Token: 0x04000265 RID: 613
		private global::DarkUI.Controls.DarkButton btnOk;

		// Token: 0x04000266 RID: 614
		private global::DarkUI.Controls.DarkLabel label2;

		// Token: 0x04000267 RID: 615
		private global::DarkUI.Controls.DarkLabel label3;

		// Token: 0x04000268 RID: 616
		public global::DarkUI.Controls.DarkTextBox txtExtnsions;

		// Token: 0x04000269 RID: 617
		public global::DarkUI.Controls.DarkNumericUpDown numericUpDown1;
	}
}
