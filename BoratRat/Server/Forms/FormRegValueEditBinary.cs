using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Helper;
using Server.Helper.HexEditor;

namespace Server.Forms
{
	// Token: 0x02000050 RID: 80
	public partial class FormRegValueEditBinary : DarkForm
	{
		// Token: 0x06000315 RID: 789 RVA: 0x00019484 File Offset: 0x00019484
		public FormRegValueEditBinary(RegistrySeeker.RegValueData value)
		{
			this._value = value;
			this.InitializeComponent();
			this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
			this.hexEditor.HexTable = value.Data;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000194D0 File Offset: 0x000194D0
		private void okButton_Click(object sender, EventArgs e)
		{
			byte[] hexTable = this.hexEditor.HexTable;
			if (hexTable != null)
			{
				try
				{
					this._value.Data = hexTable;
					base.DialogResult = DialogResult.OK;
					base.Tag = this._value;
				}
				catch
				{
					this.ShowWarning("The binary value was invalid and could not be converted correctly.", "Warning");
					base.DialogResult = DialogResult.None;
				}
			}
			base.Close();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00019548 File Offset: 0x00019548
		private void ShowWarning(string msg, string caption)
		{
			MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x0400019C RID: 412
		private readonly RegistrySeeker.RegValueData _value;

		// Token: 0x0400019D RID: 413
		private const string INVALID_BINARY_ERROR = "The binary value was invalid and could not be converted correctly.";
	}
}
