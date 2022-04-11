using System;
using System.Text;

namespace Server.MessagePack
{
	// Token: 0x02000016 RID: 22
	public class BytesTools
	{
		// Token: 0x06000122 RID: 290 RVA: 0x0000CE14 File Offset: 0x0000CE14
		public static byte[] GetUtf8Bytes(string s)
		{
			return BytesTools.utf8Encode.GetBytes(s);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000CE24 File Offset: 0x0000CE24
		public static string GetString(byte[] utf8Bytes)
		{
			return BytesTools.utf8Encode.GetString(utf8Bytes);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000CE34 File Offset: 0x0000CE34
		public static string BytesAsString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in bytes)
			{
				stringBuilder.Append(string.Format("{0:D3} ", b));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000CE80 File Offset: 0x0000CE80
		public static string BytesAsHexString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in bytes)
			{
				stringBuilder.Append(string.Format("{0:X2} ", b));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000CECC File Offset: 0x0000CECC
		public static byte[] SwapBytes(byte[] v)
		{
			byte[] array = new byte[v.Length];
			int num = v.Length - 1;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = v[num];
				num--;
			}
			return array;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000CF08 File Offset: 0x0000CF08
		public static byte[] SwapInt64(long v)
		{
			return BytesTools.SwapBytes(BitConverter.GetBytes(v));
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000CF18 File Offset: 0x0000CF18
		public static byte[] SwapInt32(int v)
		{
			byte[] array = new byte[]
			{
				0,
				0,
				0,
				(byte)v
			};
			array[2] = (byte)(v >> 8);
			array[1] = (byte)(v >> 16);
			array[0] = (byte)(v >> 24);
			return array;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000CF3C File Offset: 0x0000CF3C
		public static byte[] SwapInt16(short v)
		{
			byte[] array = new byte[]
			{
				0,
				(byte)v
			};
			array[0] = (byte)(v >> 8);
			return array;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000CF50 File Offset: 0x0000CF50
		public static byte[] SwapDouble(double v)
		{
			return BytesTools.SwapBytes(BitConverter.GetBytes(v));
		}

		// Token: 0x040000C8 RID: 200
		private static UTF8Encoding utf8Encode = new UTF8Encoding();
	}
}
