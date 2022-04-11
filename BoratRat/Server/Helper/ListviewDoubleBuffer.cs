using System;
using System.Reflection;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x02000023 RID: 35
	public static class ListviewDoubleBuffer
	{
		// Token: 0x0600018E RID: 398 RVA: 0x0000EBF0 File Offset: 0x0000EBF0
		public static void Enable(ListView listView)
		{
			typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(listView, true, null);
		}
	}
}
