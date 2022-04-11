using System;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x02000029 RID: 41
	public class RegistryTreeView : TreeView
	{
		// Token: 0x060001AA RID: 426 RVA: 0x0000F1E8 File Offset: 0x0000F1E8
		public RegistryTreeView()
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
