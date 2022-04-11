using System;
using System.Windows.Forms;
using Server.Connection;
using Server.Forms;
using Server.MessagePack;

namespace Server.Handle_Packet
{
	// Token: 0x0200003A RID: 58
	public class HandleFun
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x00014B84 File Offset: 0x00014B84
		public void Fun(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				FormFun formFun = (FormFun)Application.OpenForms["fun:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
				if (formFun != null && formFun.Client == null)
				{
					formFun.Client = client;
					formFun.timer1.Enabled = true;
				}
			}
			catch
			{
			}
		}
	}
}
