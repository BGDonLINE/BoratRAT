using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Handle_Packet
{
	// Token: 0x02000045 RID: 69
	public class HandleLogs
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x00016530 File Offset: 0x00016530
		public void Addmsg(string Msg, Color color)
		{
			try
			{
				if (color == Color.Black)
				{
					color = Color.White;
				}
				ListViewItem LV = new ListViewItem();
				LV.Text = DateTime.Now.ToLongTimeString();
				LV.SubItems.Add(Msg);
				LV.ForeColor = color;
				if (Program.form1.InvokeRequired)
				{
					Program.form1.Invoke(new MethodInvoker(delegate()
					{
						object lockListviewLogs2 = Settings.LockListviewLogs;
						lock (lockListviewLogs2)
						{
							Program.form1.listView2.Items.Insert(0, LV);
						}
					}));
				}
				else
				{
					object lockListviewLogs = Settings.LockListviewLogs;
					lock (lockListviewLogs)
					{
						Program.form1.listView2.Items.Insert(0, LV);
					}
				}
			}
			catch
			{
			}
		}
	}
}
