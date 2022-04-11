using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;

namespace Server.Forms
{
	// Token: 0x0200005D RID: 93
	public partial class FormFileSearcher : DarkForm
	{
		// Token: 0x06000397 RID: 919 RVA: 0x00023C70 File Offset: 0x00023C70
		public FormFileSearcher()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00023C80 File Offset: 0x00023C80
		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(this.txtExtnsions.Text) && this.numericUpDown1.Value > 0m)
			{
				base.DialogResult = DialogResult.OK;
			}
		}
	}
}
