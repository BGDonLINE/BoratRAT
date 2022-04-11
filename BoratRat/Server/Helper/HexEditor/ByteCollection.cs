using System;
using System.Collections.Generic;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000031 RID: 49
	public class ByteCollection
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00010D48 File Offset: 0x00010D48
		public int Length
		{
			get
			{
				return this._bytes.Count;
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00010D58 File Offset: 0x00010D58
		public ByteCollection()
		{
			this._bytes = new List<byte>();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00010D6C File Offset: 0x00010D6C
		public ByteCollection(byte[] bytes)
		{
			this._bytes = new List<byte>(bytes);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00010D80 File Offset: 0x00010D80
		public void Add(byte item)
		{
			this._bytes.Add(item);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00010D90 File Offset: 0x00010D90
		public void Insert(int index, byte item)
		{
			this._bytes.Insert(index, item);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00010DA0 File Offset: 0x00010DA0
		public void Remove(byte item)
		{
			this._bytes.Remove(item);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00010DB0 File Offset: 0x00010DB0
		public void RemoveAt(int index)
		{
			this._bytes.RemoveAt(index);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00010DC0 File Offset: 0x00010DC0
		public void RemoveRange(int startIndex, int count)
		{
			this._bytes.RemoveRange(startIndex, count);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00010DD0 File Offset: 0x00010DD0
		public byte GetAt(int index)
		{
			return this._bytes[index];
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00010DE0 File Offset: 0x00010DE0
		public void SetAt(int index, byte item)
		{
			this._bytes[index] = item;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00010DF0 File Offset: 0x00010DF0
		public char GetCharAt(int index)
		{
			return Convert.ToChar(this._bytes[index]);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00010E04 File Offset: 0x00010E04
		public byte[] ToArray()
		{
			return this._bytes.ToArray();
		}

		// Token: 0x04000132 RID: 306
		private List<byte> _bytes;
	}
}
