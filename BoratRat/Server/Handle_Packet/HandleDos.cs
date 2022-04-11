using System;
using System.Windows.Forms;
using Server.Connection;
using Server.Forms;
using Server.MessagePack;

namespace Server.Handle_Packet
{
	// Token: 0x02000041 RID: 65
	internal class HandleDos
	{
		// Token: 0x060002D6 RID: 726 RVA: 0x00015904 File Offset: 0x00015904
		public void Add(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				FormDOS formDOS = (FormDOS)Application.OpenForms["DOS"];
				if (formDOS != null)
				{
					object sync = formDOS.sync;
					lock (sync)
					{
						formDOS.PlguinClients.Add(client);
					}
				}
			}
			catch
			{
			}
		}
	}
}
