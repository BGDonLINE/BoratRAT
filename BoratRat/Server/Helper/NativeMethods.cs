using System;
using System.Runtime.InteropServices;

namespace Server.Helper
{
	// Token: 0x02000026 RID: 38
	public static class NativeMethods
	{
		// Token: 0x0600019D RID: 413
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600019E RID: 414
		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessageListViewItem(IntPtr hWnd, uint msg, IntPtr wParam, ref NativeMethods.LVITEM lParam);

		// Token: 0x0600019F RID: 415
		[DllImport("user32.dll")]
		internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);

		// Token: 0x060001A0 RID: 416
		[DllImport("user32.dll")]
		internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		// Token: 0x060001A1 RID: 417
		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		internal static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

		// Token: 0x02000D57 RID: 3415
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct LVITEM
		{
			// Token: 0x04003F3E RID: 16190
			public uint mask;

			// Token: 0x04003F3F RID: 16191
			public int iItem;

			// Token: 0x04003F40 RID: 16192
			public int iSubItem;

			// Token: 0x04003F41 RID: 16193
			public int state;

			// Token: 0x04003F42 RID: 16194
			public int stateMask;

			// Token: 0x04003F43 RID: 16195
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszText;

			// Token: 0x04003F44 RID: 16196
			public int cchTextMax;

			// Token: 0x04003F45 RID: 16197
			public int iImage;

			// Token: 0x04003F46 RID: 16198
			public IntPtr lParam;

			// Token: 0x04003F47 RID: 16199
			public int iIndent;

			// Token: 0x04003F48 RID: 16200
			public int iGroupId;

			// Token: 0x04003F49 RID: 16201
			public uint cColumns;

			// Token: 0x04003F4A RID: 16202
			public IntPtr puColumns;

			// Token: 0x04003F4B RID: 16203
			public IntPtr piColFmt;

			// Token: 0x04003F4C RID: 16204
			public int iGroup;
		}
	}
}
