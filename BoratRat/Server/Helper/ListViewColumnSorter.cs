using System;
using System.Collections;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x02000022 RID: 34
	public class ListViewColumnSorter : IComparer
	{
		// Token: 0x06000188 RID: 392 RVA: 0x0000EB2C File Offset: 0x0000EB2C
		public ListViewColumnSorter()
		{
			this.ColumnToSort = 0;
			this.OrderOfSort = SortOrder.None;
			this.ObjectCompare = new CaseInsensitiveComparer();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000EB50 File Offset: 0x0000EB50
		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			int num = this.ObjectCompare.Compare(listViewItem.SubItems[this.ColumnToSort].Text, listViewItem2.SubItems[this.ColumnToSort].Text);
			if (this.OrderOfSort == SortOrder.Ascending)
			{
				return num;
			}
			if (this.OrderOfSort == SortOrder.Descending)
			{
				return -num;
			}
			return 0;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600018B RID: 395 RVA: 0x0000EBD4 File Offset: 0x0000EBD4
		// (set) Token: 0x0600018A RID: 394 RVA: 0x0000EBC8 File Offset: 0x0000EBC8
		public int SortColumn
		{
			get
			{
				return this.ColumnToSort;
			}
			set
			{
				this.ColumnToSort = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600018D RID: 397 RVA: 0x0000EBE8 File Offset: 0x0000EBE8
		// (set) Token: 0x0600018C RID: 396 RVA: 0x0000EBDC File Offset: 0x0000EBDC
		public SortOrder Order
		{
			get
			{
				return this.OrderOfSort;
			}
			set
			{
				this.OrderOfSort = value;
			}
		}

		// Token: 0x040000E6 RID: 230
		private int ColumnToSort;

		// Token: 0x040000E7 RID: 231
		private SortOrder OrderOfSort;

		// Token: 0x040000E8 RID: 232
		private CaseInsensitiveComparer ObjectCompare;
	}
}
