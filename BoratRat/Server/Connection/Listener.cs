using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Server.Handle_Packet;

namespace Server.Connection
{
	// Token: 0x02000013 RID: 19
	internal class Listener
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000C718 File Offset: 0x0000C718
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000C720 File Offset: 0x0000C720
		private Socket Server { get; set; }

		// Token: 0x060000D9 RID: 217 RVA: 0x0000C72C File Offset: 0x0000C72C
		public void Connect(object port)
		{
			try
			{
				IPEndPoint localEP = new IPEndPoint(IPAddress.Any, Convert.ToInt32(port));
				this.Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
				{
					SendBufferSize = 51200,
					ReceiveBufferSize = 51200
				};
				this.Server.Bind(localEP);
				this.Server.Listen(500);
				new HandleLogs().Addmsg(string.Format("Listenning to: {0}", port), Color.Green);
				this.Server.BeginAccept(new AsyncCallback(this.EndAccept), null);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Environment.Exit(0);
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000C7E8 File Offset: 0x0000C7E8
		private void EndAccept(IAsyncResult ar)
		{
			try
			{
				new Clients(this.Server.EndAccept(ar));
			}
			catch
			{
			}
			finally
			{
				this.Server.BeginAccept(new AsyncCallback(this.EndAccept), null);
			}
		}
	}
}
