using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Helper
{
	// Token: 0x0200001E RID: 30
	public class ByteConverter
	{
		// Token: 0x06000171 RID: 369 RVA: 0x0000E5C0 File Offset: 0x0000E5C0
		public static byte[] GetBytes(int value)
		{
			return BitConverter.GetBytes(value);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000E5C8 File Offset: 0x0000E5C8
		public static byte[] GetBytes(long value)
		{
			return BitConverter.GetBytes(value);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000E5D0 File Offset: 0x0000E5D0
		public static byte[] GetBytes(uint value)
		{
			return BitConverter.GetBytes(value);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000E5D8 File Offset: 0x0000E5D8
		public static byte[] GetBytes(ulong value)
		{
			return BitConverter.GetBytes(value);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000E5E0 File Offset: 0x0000E5E0
		public static byte[] GetBytes(string value)
		{
			return ByteConverter.StringToBytes(value);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000E5E8 File Offset: 0x0000E5E8
		public static byte[] GetBytes(string[] value)
		{
			return ByteConverter.StringArrayToBytes(value);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000E5F0 File Offset: 0x0000E5F0
		public static int ToInt32(byte[] bytes)
		{
			return BitConverter.ToInt32(bytes, 0);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000E5FC File Offset: 0x0000E5FC
		public static long ToInt64(byte[] bytes)
		{
			return BitConverter.ToInt64(bytes, 0);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000E608 File Offset: 0x0000E608
		public static uint ToUInt32(byte[] bytes)
		{
			return BitConverter.ToUInt32(bytes, 0);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000E614 File Offset: 0x0000E614
		public static ulong ToUInt64(byte[] bytes)
		{
			return BitConverter.ToUInt64(bytes, 0);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000E620 File Offset: 0x0000E620
		public static string ToString(byte[] bytes)
		{
			return ByteConverter.BytesToString(bytes);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000E628 File Offset: 0x0000E628
		public static string[] ToStringArray(byte[] bytes)
		{
			return ByteConverter.BytesToStringArray(bytes);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000E630 File Offset: 0x0000E630
		private static byte[] GetNullBytes()
		{
			return new byte[]
			{
				ByteConverter.NULL_BYTE,
				ByteConverter.NULL_BYTE
			};
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000E648 File Offset: 0x0000E648
		private static byte[] StringToBytes(string value)
		{
			byte[] array = new byte[value.Length * 2];
			Buffer.BlockCopy(value.ToCharArray(), 0, array, 0, array.Length);
			return array;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000E67C File Offset: 0x0000E67C
		private static byte[] StringArrayToBytes(string[] strings)
		{
			List<byte> list = new List<byte>();
			foreach (string value in strings)
			{
				list.AddRange(ByteConverter.StringToBytes(value));
				list.AddRange(ByteConverter.GetNullBytes());
			}
			return list.ToArray();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000E6CC File Offset: 0x0000E6CC
		private static string BytesToString(byte[] bytes)
		{
			char[] array = new char[(int)Math.Ceiling((double)((float)bytes.Length / 2f))];
			Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
			return new string(array);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000E708 File Offset: 0x0000E708
		private static string[] BytesToStringArray(byte[] bytes)
		{
			List<string> list = new List<string>();
			int i = 0;
			StringBuilder stringBuilder = new StringBuilder(bytes.Length);
			while (i < bytes.Length)
			{
				int num = 0;
				while (i < bytes.Length && num < 3)
				{
					if (bytes[i] == ByteConverter.NULL_BYTE)
					{
						num++;
					}
					else
					{
						stringBuilder.Append(Convert.ToChar(bytes[i]));
						num = 0;
					}
					i++;
				}
				list.Add(stringBuilder.ToString());
				stringBuilder.Clear();
			}
			return list.ToArray();
		}

		// Token: 0x040000E5 RID: 229
		private static byte NULL_BYTE;
	}
}
