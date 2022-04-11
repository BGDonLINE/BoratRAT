using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Server.Connection;

namespace Server
{
	// Token: 0x02000011 RID: 17
	public static class Settings
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000BC6C File Offset: 0x0000BC6C
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000BC74 File Offset: 0x0000BC74
		public static long SentValue { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000BC7C File Offset: 0x0000BC7C
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000BC84 File Offset: 0x0000BC84
		public static long ReceivedValue { get; set; }

		// Token: 0x040000A8 RID: 168
		public static List<string> Blocked = new List<string>();

		// Token: 0x040000A9 RID: 169
		public static object LockBlocked = new object();

		// Token: 0x040000AC RID: 172
		public static object LockReceivedSendValue = new object();

		// Token: 0x040000AD RID: 173
		public static string CertificatePath = Application.StartupPath + "\\ServerCertificate.p12";

		// Token: 0x040000AE RID: 174
		public static X509Certificate2 ServerCertificate;

		// Token: 0x040000AF RID: 175
		public static readonly string Version = "BoratRat 0x0x1";

		// Token: 0x040000B0 RID: 176
		public static object LockListviewClients = new object();

		// Token: 0x040000B1 RID: 177
		public static object LockListviewLogs = new object();

		// Token: 0x040000B2 RID: 178
		public static object LockListviewThumb = new object();

		// Token: 0x040000B3 RID: 179
		public static bool ReportWindow = false;

		// Token: 0x040000B4 RID: 180
		public static List<Clients> ReportWindowClients = new List<Clients>();

		// Token: 0x040000B5 RID: 181
		public static object LockReportWindowClients = new object();
	}
}
