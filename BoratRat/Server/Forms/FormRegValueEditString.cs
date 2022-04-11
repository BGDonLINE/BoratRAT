using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Helper;

namespace Server.Forms
{
	// Token: 0x02000053 RID: 83
	public partial class FormRegValueEditString : DarkForm
	{
		// Token: 0x0600032D RID: 813 RVA: 0x0001A4C4 File Offset: 0x0001A4C4
		public FormRegValueEditString(RegistrySeeker.RegValueData value)
		{
			this._value = value;
			this.InitializeComponent();
			this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
			this.valueDataTxtBox.Text = Server.Helper.ByteConverter.ToString(value.Data);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0001A514 File Offset: 0x0001A514
		private void okButton_Click(object sender, EventArgs e)
		{
			this._value.Data = Server.Helper.ByteConverter.GetBytes(this.valueDataTxtBox.Text);
			base.Tag = this._value;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x040001BA RID: 442
		private readonly RegistrySeeker.RegValueData _value;
	}
}
