using System;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x02000024 RID: 36
	internal class AeroListView : ListView
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0000EC18 File Offset: 0x0000EC18
		public static int MakeWin32Long(short wLow, short wHigh)
		{
			return ((int)wLow << 16) | (int)wHigh;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000EC20 File Offset: 0x0000EC20
		// (set) Token: 0x06000191 RID: 401 RVA: 0x0000EC28 File Offset: 0x0000EC28
		private ListViewColumnSorter LvwColumnSorter { get; set; }

		// Token: 0x06000192 RID: 402 RVA: 0x0000EC34 File Offset: 0x0000EC34
		public AeroListView()
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.LvwColumnSorter = new ListViewColumnSorter();
			base.ListViewItemSorter = this.LvwColumnSorter;
			base.View = View.Details;
			base.FullRowSelect = true;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000EC90 File Offset: 0x0000EC90
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
			{
				NativeMethods.SetWindowTheme(base.Handle, "explorer", null);
			}
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5)
			{
				NativeMethods.SendMessage(base.Handle, 295U, this._removeDots, IntPtr.Zero);
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000ED20 File Offset: 0x0000ED20
		protected override void OnColumnClick(ColumnClickEventArgs e)
		{
			base.OnColumnClick(e);
			if (e.Column == this.LvwColumnSorter.SortColumn)
			{
				this.LvwColumnSorter.Order = ((this.LvwColumnSorter.Order == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending);
			}
			else
			{
				this.LvwColumnSorter.SortColumn = e.Column;
				this.LvwColumnSorter.Order = SortOrder.Ascending;
			}
			if (!base.VirtualMode)
			{
				base.Sort();
			}
		}

		// Token: 0x040000E9 RID: 233
		private const uint WM_CHANGEUISTATE = 295U;

		// Token: 0x040000EA RID: 234
		private const short UIS_SET = 1;

		// Token: 0x040000EB RID: 235
		private const short UISF_HIDEFOCUS = 1;

		// Token: 0x040000EC RID: 236
		private readonly IntPtr _removeDots = new IntPtr(AeroListView.MakeWin32Long(1, 1));
	}
}
