using System;
using System.Drawing;
using System.Threading;
using Server.Connection;
using Server.MessagePack;

namespace Server.Handle_Packet
{
	// Token: 0x02000046 RID: 70
	public class HandlePing
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x00016634 File Offset: 0x00016634
		public void Ping(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").SetAsString("Po_ng");
				ThreadPool.QueueUserWorkItem(new WaitCallback(client.Send), msgPack.Encode2Bytes());
				object lockListviewClients = Settings.LockListviewClients;
				lock (lockListviewClients)
				{
					if (client.LV != null)
					{
						client.LV.SubItems[Program.form1.lv_act.Index].Text = unpack_msgpack.ForcePathObject("Message").AsString;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000166FC File Offset: 0x000166FC
		public void Po_ng(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				object lockListviewClients = Settings.LockListviewClients;
				lock (lockListviewClients)
				{
					if (client.LV != null)
					{
						client.LV.SubItems[Program.form1.lv_ping.Index].Text = unpack_msgpack.ForcePathObject("Message").AsInteger.ToString() + " MS";
						if (unpack_msgpack.ForcePathObject("Message").AsInteger > 600L)
						{
							client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Red;
						}
						else if (unpack_msgpack.ForcePathObject("Message").AsInteger > 300L)
						{
							client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Orange;
						}
						else
						{
							client.LV.SubItems[Program.form1.lv_ping.Index].ForeColor = Color.Green;
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
