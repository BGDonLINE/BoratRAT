using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.MessagePack
{
	// Token: 0x02000017 RID: 23
	public class MsgPackEnum : IEnumerator
	{
		// Token: 0x0600012D RID: 301 RVA: 0x0000CF74 File Offset: 0x0000CF74
		public MsgPackEnum(List<MsgPack> obj)
		{
			this.children = obj;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000CF8C File Offset: 0x0000CF8C
		object IEnumerator.Current
		{
			get
			{
				return this.children[this.position];
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000CFA0 File Offset: 0x0000CFA0
		bool IEnumerator.MoveNext()
		{
			this.position++;
			return this.position < this.children.Count;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000CFC4 File Offset: 0x0000CFC4
		void IEnumerator.Reset()
		{
			this.position = -1;
		}

		// Token: 0x040000C9 RID: 201
		private List<MsgPack> children;

		// Token: 0x040000CA RID: 202
		private int position = -1;
	}
}
