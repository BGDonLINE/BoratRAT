namespace Server.Forms
{
	// Token: 0x02000054 RID: 84
	public partial class FormRegValueEditWord : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000336 RID: 822 RVA: 0x0001AB5C File Offset: 0x0001AB5C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0001AB84 File Offset: 0x0001AB84
		private void InitializeComponent()
		{
			this.cancelButton = new global::DarkUI.Controls.DarkButton();
			this.baseBox = new global::DarkUI.Controls.DarkGroupBox();
			this.radioDecimal = new global::DarkUI.Controls.DarkRadioButton();
			this.radioHexa = new global::DarkUI.Controls.DarkRadioButton();
			this.okButton = new global::DarkUI.Controls.DarkButton();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.valueNameTxtBox = new global::DarkUI.Controls.DarkTextBox();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.valueDataTxtBox = new global::Server.Helper.WordTextBox();
			this.baseBox.SuspendLayout();
			base.SuspendLayout();
			this.cancelButton.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.cancelButton.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new global::System.Drawing.Point(271, 146);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Padding = new global::System.Windows.Forms.Padding(5);
			this.cancelButton.Size = new global::System.Drawing.Size(75, 25);
			this.cancelButton.TabIndex = 12;
			this.cancelButton.Text = "Cancel";
			this.baseBox.BorderColor = global::System.Drawing.Color.FromArgb(51, 51, 51);
			this.baseBox.Controls.Add(this.radioDecimal);
			this.baseBox.Controls.Add(this.radioHexa);
			this.baseBox.Location = new global::System.Drawing.Point(190, 65);
			this.baseBox.Name = "baseBox";
			this.baseBox.Size = new global::System.Drawing.Size(156, 68);
			this.baseBox.TabIndex = 14;
			this.baseBox.TabStop = false;
			this.baseBox.Text = "Base";
			this.radioDecimal.AutoSize = true;
			this.radioDecimal.Location = new global::System.Drawing.Point(14, 43);
			this.radioDecimal.Name = "radioDecimal";
			this.radioDecimal.Size = new global::System.Drawing.Size(63, 17);
			this.radioDecimal.TabIndex = 4;
			this.radioDecimal.Text = "Decimal";
			this.radioHexa.AutoSize = true;
			this.radioHexa.Checked = true;
			this.radioHexa.Location = new global::System.Drawing.Point(14, 18);
			this.radioHexa.Name = "radioHexa";
			this.radioHexa.Size = new global::System.Drawing.Size(86, 17);
			this.radioHexa.TabIndex = 3;
			this.radioHexa.TabStop = true;
			this.radioHexa.Text = "Hexadecimal";
			this.okButton.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new global::System.Drawing.Point(190, 146);
			this.okButton.Name = "okButton";
			this.okButton.Padding = new global::System.Windows.Forms.Padding(5);
			this.okButton.Size = new global::System.Drawing.Size(75, 25);
			this.okButton.TabIndex = 11;
			this.okButton.Text = "OK";
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label2.Location = new global::System.Drawing.Point(9, 65);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Value data:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.valueNameTxtBox.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.valueNameTxtBox.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.valueNameTxtBox.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.valueNameTxtBox.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.valueNameTxtBox.Location = new global::System.Drawing.Point(12, 37);
			this.valueNameTxtBox.Name = "valueNameTxtBox";
			this.valueNameTxtBox.ReadOnly = true;
			this.valueNameTxtBox.Size = new global::System.Drawing.Size(334, 20);
			this.valueNameTxtBox.TabIndex = 13;
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(9, 20);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(66, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Value name:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.valueDataTxtBox.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.valueDataTxtBox.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.valueDataTxtBox.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.valueDataTxtBox.IsHexNumber = false;
			this.valueDataTxtBox.Location = new global::System.Drawing.Point(13, 83);
			this.valueDataTxtBox.MaxLength = 8;
			this.valueDataTxtBox.Name = "valueDataTxtBox";
			this.valueDataTxtBox.Size = new global::System.Drawing.Size(171, 20);
			this.valueDataTxtBox.TabIndex = 17;
			this.valueDataTxtBox.Type = global::Server.Helper.WordTextBox.WordType.DWORD;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(362, 185);
			base.Controls.Add(this.valueDataTxtBox);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.baseBox);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.valueNameTxtBox);
			base.Controls.Add(this.label1);
			base.Name = "FormRegValueEditWord";
			this.Text = "FormRegValueEditWord";
			this.baseBox.ResumeLayout(false);
			this.baseBox.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001C5 RID: 453
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040001C6 RID: 454
		private global::Server.Helper.WordTextBox valueDataTxtBox;

		// Token: 0x040001C7 RID: 455
		private global::DarkUI.Controls.DarkButton cancelButton;

		// Token: 0x040001C8 RID: 456
		private global::DarkUI.Controls.DarkGroupBox baseBox;

		// Token: 0x040001C9 RID: 457
		private global::DarkUI.Controls.DarkRadioButton radioDecimal;

		// Token: 0x040001CA RID: 458
		private global::DarkUI.Controls.DarkRadioButton radioHexa;

		// Token: 0x040001CB RID: 459
		private global::DarkUI.Controls.DarkButton okButton;

		// Token: 0x040001CC RID: 460
		private global::DarkUI.Controls.DarkLabel label2;

		// Token: 0x040001CD RID: 461
		private global::DarkUI.Controls.DarkTextBox valueNameTxtBox;

		// Token: 0x040001CE RID: 462
		private global::DarkUI.Controls.DarkLabel label1;
	}
}
