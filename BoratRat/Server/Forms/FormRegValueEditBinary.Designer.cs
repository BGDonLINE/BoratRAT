namespace Server.Forms
{
	// Token: 0x02000050 RID: 80
	public partial class FormRegValueEditBinary : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000318 RID: 792 RVA: 0x00019558 File Offset: 0x00019558
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00019580 File Offset: 0x00019580
		private void InitializeComponent()
		{
			this.cancelButton = new global::DarkUI.Controls.DarkButton();
			this.okButton = new global::DarkUI.Controls.DarkButton();
			this.label2 = new global::DarkUI.Controls.DarkLabel();
			this.valueNameTxtBox = new global::DarkUI.Controls.DarkTextBox();
			this.label1 = new global::DarkUI.Controls.DarkLabel();
			this.hexEditor = new global::Server.Helper.HexEditor.HexEditor();
			base.SuspendLayout();
			this.cancelButton.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.cancelButton.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new global::System.Drawing.Point(280, 284);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Padding = new global::System.Windows.Forms.Padding(5);
			this.cancelButton.Size = new global::System.Drawing.Size(75, 25);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.okButton.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new global::System.Drawing.Point(188, 284);
			this.okButton.Name = "okButton";
			this.okButton.Padding = new global::System.Windows.Forms.Padding(5);
			this.okButton.Size = new global::System.Drawing.Size(75, 25);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "OK";
			this.okButton.Click += new global::System.EventHandler(this.okButton_Click);
			this.label2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label2.Location = new global::System.Drawing.Point(12, 59);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(61, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Value data:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.valueNameTxtBox.Anchor = global::System.Windows.Forms.AnchorStyles.Left;
			this.valueNameTxtBox.BackColor = global::System.Drawing.Color.FromArgb(69, 73, 74);
			this.valueNameTxtBox.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.valueNameTxtBox.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.valueNameTxtBox.Location = new global::System.Drawing.Point(14, 32);
			this.valueNameTxtBox.Name = "valueNameTxtBox";
			this.valueNameTxtBox.ReadOnly = true;
			this.valueNameTxtBox.Size = new global::System.Drawing.Size(341, 20);
			this.valueNameTxtBox.TabIndex = 8;
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(220, 220, 220);
			this.label1.Location = new global::System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(66, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Value name:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.hexEditor.BorderColor = global::System.Drawing.Color.Empty;
			this.hexEditor.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.hexEditor.ForeColor = global::System.Drawing.Color.Gainsboro;
			this.hexEditor.Location = new global::System.Drawing.Point(13, 75);
			this.hexEditor.Name = "hexEditor";
			this.hexEditor.Size = new global::System.Drawing.Size(342, 203);
			this.hexEditor.TabIndex = 10;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(373, 334);
			base.Controls.Add(this.hexEditor);
			base.Controls.Add(this.cancelButton);
			base.Controls.Add(this.okButton);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.valueNameTxtBox);
			base.Controls.Add(this.label1);
			base.Name = "FormRegValueEditBinary";
			this.Text = "FormRegValueEditBinary";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400019E RID: 414
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400019F RID: 415
		private global::Server.Helper.HexEditor.HexEditor hexEditor;

		// Token: 0x040001A0 RID: 416
		private global::DarkUI.Controls.DarkButton cancelButton;

		// Token: 0x040001A1 RID: 417
		private global::DarkUI.Controls.DarkButton okButton;

		// Token: 0x040001A2 RID: 418
		private global::DarkUI.Controls.DarkLabel label2;

		// Token: 0x040001A3 RID: 419
		private global::DarkUI.Controls.DarkTextBox valueNameTxtBox;

		// Token: 0x040001A4 RID: 420
		private global::DarkUI.Controls.DarkLabel label1;
	}
}
