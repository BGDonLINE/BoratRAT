using System;

namespace Server.MessagePack
{
	// Token: 0x0200001A RID: 26
	public enum MsgPackType
	{
		// Token: 0x040000D5 RID: 213
		Unknown,
		// Token: 0x040000D6 RID: 214
		Null,
		// Token: 0x040000D7 RID: 215
		Map,
		// Token: 0x040000D8 RID: 216
		Array,
		// Token: 0x040000D9 RID: 217
		String,
		// Token: 0x040000DA RID: 218
		Integer,
		// Token: 0x040000DB RID: 219
		UInt64,
		// Token: 0x040000DC RID: 220
		Boolean,
		// Token: 0x040000DD RID: 221
		Float,
		// Token: 0x040000DE RID: 222
		Single,
		// Token: 0x040000DF RID: 223
		DateTime,
		// Token: 0x040000E0 RID: 224
		Binary
	}
}
