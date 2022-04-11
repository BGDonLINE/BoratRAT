namespace Server.Forms
{
	// Token: 0x02000053 RID: 83
	public partial class FormRegValueEditString : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x0600032F RID: 815 RVA: 0x0001A55C File Offset: 0x0001A55C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0001A584 File Offset: 0x0001A584
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Server.Forms.FormRegValueEditString));
			this.cancelButton = new global::DarkUI.Controls.DarkButton();
			this.okButton = new global::DarkUI.Controls.DarkButton();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.valueNameTxtBox = new global::DarkUI.Controls.DarkTextBox();
			this.valueDataTxtBox = new global::DarkUI.Controls.DarkTextBox();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			base.SuspendLayout();
			this.cancelButton.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.cancelButton.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new global::System.Drawing.Point(280, 116);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new global::System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.okButton.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new global::System.Drawing.Point(199, 116);
			this.okButton.Name = "okButton";
			this.okButton.Size = new global::System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(9, 64);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(71, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "Value data:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.valueNameTxtBox.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.valueNameTxtBox.Location = new global::System.Drawing.Point(12, 32);
			this.valueNameTxtBox.Name = "valueNameTxtBox";
			this.valueNameTxtBox.ReadOnly = true;
			this.valueNameTxtBox.Size = new global::System.Drawing.Size(345, 21);
			this.valueNameTxtBox.TabIndex = 9;
			this.valueDataTxtBox.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.valueDataTxtBox.Location = new global::System.Drawing.Point(12, 80);
			this.valueDataTxtBox.Name = "valueDataTxtBox";
			this.valueDataTxtBox.Size = new global::System.Drawing.Size(345, 21);
			this.valueDataTxtBox.TabIndex = 5;
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(9, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(71, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "Value name:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(369, 151);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.valueNameTxtBox);
			base.Controls.Add(this.valueDataTxtBox);
			base.Controls.Add(this.label1);
			base.Name = "FormRegValueEditString";
			this.Text = "FormRegValueEditString";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001BB RID: 443
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001BC RID: 444
		private global::System.Windows.Forms.Button cancelButton;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.Button okButton;

		// Token: 0x040001BE RID: 446
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.TextBox valueNameTxtBox;

		// Token: 0x040001C0 RID: 448
		private global::System.Windows.Forms.TextBox valueDataTxtBox;

		// Token: 0x040001C1 RID: 449
		private global::System.Windows.Forms.Label label1;
	}
}
