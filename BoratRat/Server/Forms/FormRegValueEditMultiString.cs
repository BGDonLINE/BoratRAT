using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Helper;

namespace Server.Forms
{
	// Token: 0x02000052 RID: 82
	public partial class FormRegValueEditMultiString : DarkForm
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00019FEC File Offset: 0x00019FEC
		public FormRegValueEditMultiString(RegistrySeeker.RegValueData value)
		{
			this._value = value;
			this.InitializeComponent();
			this.valueNameTxtBox.Text = value.Name;
			this.valueDataTxtBox.Text = string.Join("\r\n", Server.Helper.ByteConverter.ToStringArray(value.Data));
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0001A044 File Offset: 0x0001A044
		private void okButton_Click(object sender, EventArgs e)
		{
			this._value.Data = Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
			base.Tag = this._value;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x040001B2 RID: 434
		private readonly RegistrySeeker.RegValueData _value;
	}
}
