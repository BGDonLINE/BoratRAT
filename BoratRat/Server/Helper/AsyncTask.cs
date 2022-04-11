using System;
using System.Collections.Generic;

namespace Server.Helper
{
	// Token: 0x0200001D RID: 29
	public class AsyncTask
	{
		// Token: 0x06000170 RID: 368 RVA: 0x0000E598 File Offset: 0x0000E598
		public AsyncTask(byte[] _msgPack, string _id, bool _admin)
		{
			this.msgPack = _msgPack;
			this.id = _id;
			this.admin = _admin;
			this.doneClient = new List<string>();
		}

		// Token: 0x040000E1 RID: 225
		public byte[] msgPack;

		// Token: 0x040000E2 RID: 226
		public string id;

		// Token: 0x040000E3 RID: 227
		public bool admin;

		// Token: 0x040000E4 RID: 228
		public List<string> doneClient;
	}
}
