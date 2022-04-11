using System;
using System.Windows.Forms;

namespace Server
{
	// Token: 0x0200000F RID: 15
	internal static class Program
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x0000B180 File Offset: 0x0000B180
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Program.form1 = new Form1();
			Application.Run(Program.form1);
		}

		// Token: 0x0400009A RID: 154
		public static Form1 form1;
	}
}
