using System;
using System.Collections.Generic;

namespace Server.MessagePack
{
	// Token: 0x02000018 RID: 24
	public class MsgPackArray
	{
		// Token: 0x06000131 RID: 305 RVA: 0x0000CFD0 File Offset: 0x0000CFD0
		public MsgPackArray(MsgPack msgpackObj, List<MsgPack> listObj)
		{
			this.owner = msgpackObj;
			this.children = listObj;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000CFE8 File Offset: 0x0000CFE8
		public MsgPack Add()
		{
			return this.owner.AddArrayChild();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000CFF8 File Offset: 0x0000CFF8
		public MsgPack Add(string value)
		{
			MsgPack msgPack = this.owner.AddArrayChild();
			msgPack.AsString = value;
			return msgPack;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000D00C File Offset: 0x0000D00C
		public MsgPack Add(long value)
		{
			MsgPack msgPack = this.owner.AddArrayChild();
			msgPack.SetAsInteger(value);
			return msgPack;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000D020 File Offset: 0x0000D020
		public MsgPack Add(double value)
		{
			MsgPack msgPack = this.owner.AddArrayChild();
			msgPack.SetAsFloat(value);
			return msgPack;
		}

		// Token: 0x17000051 RID: 81
		public MsgPack this[int index]
		{
			get
			{
				return this.children[index];
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000137 RID: 311 RVA: 0x0000D044 File Offset: 0x0000D044
		public int Length
		{
			get
			{
				return this.children.Count;
			}
		}

		// Token: 0x040000CB RID: 203
		private List<MsgPack> children;

		// Token: 0x040000CC RID: 204
		private MsgPack owner;
	}
}
