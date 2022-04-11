using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.Win32;
using Server.Helper;

namespace Server.Forms
{
	// Token: 0x02000054 RID: 84
	public partial class FormRegValueEditWord : DarkForm
	{
		// Token: 0x06000331 RID: 817 RVA: 0x0001A954 File Offset: 0x0001A954
		public FormRegValueEditWord(RegistrySeeker.RegValueData value)
		{
			this._value = value;
			this.InitializeComponent();
			this.valueNameTxtBox.Text = value.Name;
			if (value.Kind == RegistryValueKind.DWord)
			{
				this.Text = "Edit DWORD (32-bit) Value";
				this.valueDataTxtBox.Type = WordTextBox.WordType.DWORD;
				this.valueDataTxtBox.Text = Server.Helper.ByteConverter.ToUInt32(value.Data).ToString("x");
				return;
			}
			this.Text = "Edit QWORD (64-bit) Value";
			this.valueDataTxtBox.Type = WordTextBox.WordType.QWORD;
			this.valueDataTxtBox.Text = Server.Helper.ByteConverter.ToUInt64(value.Data).ToString("x");
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0001AA0C File Offset: 0x0001AA0C
		private void radioHex_CheckboxChanged(object sender, EventArgs e)
		{
			if (this.valueDataTxtBox.IsHexNumber == this.radioHexa.Checked)
			{
				return;
			}
			if (this.valueDataTxtBox.IsConversionValid() || this.IsOverridePossible())
			{
				this.valueDataTxtBox.IsHexNumber = this.radioHexa.Checked;
				return;
			}
			this.radioDecimal.Checked = true;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0001AA78 File Offset: 0x0001AA78
		private void okButton_Click(object sender, EventArgs e)
		{
			if (this.valueDataTxtBox.IsConversionValid() || this.IsOverridePossible())
			{
				this._value.Data = ((this._value.Kind == RegistryValueKind.DWord) ? Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.UIntValue) : Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.ULongValue));
				base.Tag = this._value;
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.None;
			}
			base.Close();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0001AB0C File Offset: 0x0001AB0C
		private DialogResult ShowWarning(string msg, string caption)
		{
			return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0001AB18 File Offset: 0x0001AB18
		private bool IsOverridePossible()
		{
			string msg = ((this._value.Kind == RegistryValueKind.DWord) ? "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?" : "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?");
			return this.ShowWarning(msg, "Overflow") == DialogResult.Yes;
		}

		// Token: 0x040001C2 RID: 450
		private readonly RegistrySeeker.RegValueData _value;

		// Token: 0x040001C3 RID: 451
		private const string DWORD_WARNING = "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?";

		// Token: 0x040001C4 RID: 452
		private const string QWORD_WARNING = "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?";
	}
}
