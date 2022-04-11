using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x02000025 RID: 37
	public static class Methods
	{
		// Token: 0x06000195 RID: 405 RVA: 0x0000EDA4 File Offset: 0x0000EDA4
		public static string BytesToString(long byteCount)
		{
			string[] array = new string[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
			if (byteCount == 0L)
			{
				return "0" + array[0];
			}
			long num = Math.Abs(byteCount);
			int num2 = Convert.ToInt32(Math.Floor(Math.Log((double)num, 1024.0)));
			double num3 = Math.Round((double)num / Math.Pow(1024.0, (double)num2), 1);
			return ((double)Math.Sign(byteCount) * num3).ToString() + array[num2];
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000EE64 File Offset: 0x0000EE64
		public static async Task FadeIn(Form o, int interval = 80)
		{
			while (o.Opacity < 1.0)
			{
				await Task.Delay(interval);
				o.Opacity += 0.05;
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000EEB4 File Offset: 0x0000EEB4
		public static double DiffSeconds(DateTime startTime, DateTime endTime)
		{
			TimeSpan timeSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
			return Math.Abs(timeSpan.TotalSeconds);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000EEE8 File Offset: 0x0000EEE8
		public static string GetRandomString(int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Methods.Random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000EF3C File Offset: 0x0000EF3C
		public static int MakeWin32Long(short wLow, short wHigh)
		{
			return ((int)wLow << 16) | (int)wHigh;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000EF44 File Offset: 0x0000EF44
		public static void SetItemState(IntPtr handle, int itemIndex, int mask, int value)
		{
			NativeMethods.LVITEM lvitem = new NativeMethods.LVITEM
			{
				stateMask = mask,
				state = value
			};
			NativeMethods.SendMessageListViewItem(handle, 4139U, new IntPtr(itemIndex), ref lvitem);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000EF84 File Offset: 0x0000EF84
		public static void ScrollToBottom(IntPtr handle)
		{
			NativeMethods.SendMessage(handle, 277U, Methods.SB_PAGEBOTTOM, IntPtr.Zero);
		}

		// Token: 0x040000EE RID: 238
		private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

		// Token: 0x040000EF RID: 239
		public static Random Random = new Random();

		// Token: 0x040000F0 RID: 240
		private const int LVM_FIRST = 4096;

		// Token: 0x040000F1 RID: 241
		private const int LVM_SETITEMSTATE = 4139;

		// Token: 0x040000F2 RID: 242
		private const int WM_VSCROLL = 277;

		// Token: 0x040000F3 RID: 243
		private static readonly IntPtr SB_PAGEBOTTOM = new IntPtr(7);
	}
}
