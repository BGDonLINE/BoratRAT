// Server.Forms.FormNetstat
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;
using Server;
using Server.Connection;
using Server.MessagePack;

public class FormNetstat : DarkForm
{
	private IContainer components;

	private ColumnHeader lv_id;

	public ListView listView1;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem killToolStripMenuItem;

	private ToolStripMenuItem refreshToolStripMenuItem;

	public System.Windows.Forms.Timer timer1;

	private ColumnHeader lv_localAddr;

	private ColumnHeader lv_remoteAddr;

	private ColumnHeader lv_state;

	public Form1 F { get; set; }

	internal Clients Client { get; set; }

	internal Clients ParentClient { get; set; }

	public FormNetstat()
	{
		InitializeComponent();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		try
		{
			if (!Client.TcpClient.Connected || !ParentClient.TcpClient.Connected)
			{
				Close();
			}
		}
		catch
		{
			Close();
		}
	}

	private async void killToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count <= 0)
		{
			return;
		}
		foreach (ListViewItem P in listView1.SelectedItems)
		{
			await Task.Run(delegate
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
				msgPack.ForcePathObject("Option").AsString = "Kill";
				msgPack.ForcePathObject("ID").AsString = P.SubItems[lv_id.Index].Text;
				ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
			});
		}
	}

	private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ThreadPool.QueueUserWorkItem(delegate
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "Netstat";
			msgPack.ForcePathObject("Option").AsString = "List";
			ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
		});
	}

	private void FormNetstat_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			ThreadPool.QueueUserWorkItem(delegate
			{
				Client?.Disconnected();
			});
		}
		catch
		{
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
		this.listView1 = new System.Windows.Forms.ListView();
		this.lv_id = new System.Windows.Forms.ColumnHeader();
		this.lv_localAddr = new System.Windows.Forms.ColumnHeader();
		this.lv_remoteAddr = new System.Windows.Forms.ColumnHeader();
		this.lv_state = new System.Windows.Forms.ColumnHeader();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.contextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.listView1.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { this.lv_id, this.lv_localAddr, this.lv_remoteAddr, this.lv_state });
		this.listView1.ContextMenuStrip = this.contextMenuStrip1;
		this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.listView1.Enabled = false;
		this.listView1.ForeColor = System.Drawing.Color.Gainsboro;
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(0, 0);
		this.listView1.Margin = new System.Windows.Forms.Padding(2);
		this.listView1.Name = "listView1";
		this.listView1.ShowGroups = false;
		this.listView1.ShowItemToolTips = true;
		this.listView1.Size = new System.Drawing.Size(545, 375);
		this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
		this.listView1.TabIndex = 0;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.lv_id.Text = "ID";
		this.lv_id.Width = 92;
		this.lv_localAddr.Text = "LocalAddress";
		this.lv_localAddr.Width = 161;
		this.lv_remoteAddr.Text = "RemoteAddress";
		this.lv_remoteAddr.Width = 177;
		this.lv_state.Text = "State";
		this.lv_state.Width = 110;
		this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.killToolStripMenuItem, this.refreshToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
		this.killToolStripMenuItem.Name = "killToolStripMenuItem";
		this.killToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
		this.killToolStripMenuItem.Text = "Kill";
		this.killToolStripMenuItem.Click += new System.EventHandler(killToolStripMenuItem_Click);
		this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
		this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
		this.refreshToolStripMenuItem.Text = "Refresh";
		this.refreshToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(545, 375);
		base.Controls.Add(this.listView1);
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormNetstat";
		base.ShowIcon = false;
		this.Text = "Netstat";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormNetstat_FormClosed);
		this.contextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
