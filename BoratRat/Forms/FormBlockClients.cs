// Server.Forms.FormBlockClients
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server;
using Server.Properties;

public class FormBlockClients : DarkForm
{
	private IContainer components;

	private ListBox listBlocked;

	private DarkGroupBox groupBox1;

	private DarkButton btnDelete;

	private DarkButton btnAdd;

	private DarkLabel label1;

	public DarkTextBox txtBlock;

	public FormBlockClients()
	{
		InitializeComponent();
	}

	private void BtnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			listBlocked.Items.Add(txtBlock.Text);
			txtBlock.Clear();
		}
		catch
		{
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		try
		{
			for (int num = listBlocked.SelectedIndices.Count - 1; num >= 0; num--)
			{
				listBlocked.Items.RemoveAt(listBlocked.SelectedIndices[num]);
			}
		}
		catch
		{
		}
	}

	private void FormBlockClients_Load(object sender, EventArgs e)
	{
		try
		{
			listBlocked.Items.Clear();
			if (string.IsNullOrWhiteSpace(Server.Properties.Settings.Default.txtBlocked))
			{
				return;
			}
			string[] array = Server.Properties.Settings.Default.txtBlocked.Split(',');
			foreach (string text in array)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					listBlocked.Items.Add(text);
				}
			}
		}
		catch
		{
		}
	}

	private void FormBlockClients_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			lock (Server.Settings.Blocked)
			{
				Server.Settings.Blocked.Clear();
				List<string> list = new List<string>();
				foreach (string item in listBlocked.Items)
				{
					list.Add(item);
					Server.Settings.Blocked.Add(item);
				}
				Server.Properties.Settings.Default.txtBlocked = string.Join(",", list);
				Server.Properties.Settings.Default.Save();
			}
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
		this.groupBox1 = new DarkUI.Controls.DarkGroupBox();
		this.listBlocked = new System.Windows.Forms.ListBox();
		this.btnDelete = new DarkUI.Controls.DarkButton();
		this.btnAdd = new DarkUI.Controls.DarkButton();
		this.label1 = new DarkUI.Controls.DarkLabel();
		this.txtBlock = new DarkUI.Controls.DarkTextBox();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(51, 51, 51);
		this.groupBox1.Controls.Add(this.listBlocked);
		this.groupBox1.Controls.Add(this.btnDelete);
		this.groupBox1.Controls.Add(this.btnAdd);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.txtBlock);
		this.groupBox1.Location = new System.Drawing.Point(8, 8);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox1.Size = new System.Drawing.Size(543, 231);
		this.groupBox1.TabIndex = 4;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Blocklist";
		this.listBlocked.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listBlocked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listBlocked.DataBindings.Add(new System.Windows.Forms.Binding("Name", Server.Properties.Settings.Default, "txtBlocked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.listBlocked.ForeColor = System.Drawing.Color.Gainsboro;
		this.listBlocked.FormattingEnabled = true;
		this.listBlocked.Location = new System.Drawing.Point(225, 30);
		this.listBlocked.Margin = new System.Windows.Forms.Padding(2);
		this.listBlocked.Name = Server.Properties.Settings.Default.txtBlocked;
		this.listBlocked.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
		this.listBlocked.Size = new System.Drawing.Size(297, 171);
		this.listBlocked.TabIndex = 4;
		this.btnDelete.Location = new System.Drawing.Point(117, 107);
		this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
		this.btnDelete.Size = new System.Drawing.Size(38, 23);
		this.btnDelete.TabIndex = 3;
		this.btnDelete.Text = "-";
		this.btnDelete.Click += new System.EventHandler(BtnDelete_Click);
		this.btnAdd.Location = new System.Drawing.Point(24, 107);
		this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Padding = new System.Windows.Forms.Padding(5);
		this.btnAdd.Size = new System.Drawing.Size(38, 23);
		this.btnAdd.TabIndex = 2;
		this.btnAdd.Text = "+";
		this.btnAdd.Click += new System.EventHandler(BtnAdd_Click);
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label1.Location = new System.Drawing.Point(4, 34);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(89, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Input HWID or IP";
		this.txtBlock.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtBlock.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtBlock.Location = new System.Drawing.Point(7, 56);
		this.txtBlock.Margin = new System.Windows.Forms.Padding(2);
		this.txtBlock.Name = "txtBlock";
		this.txtBlock.Size = new System.Drawing.Size(192, 20);
		this.txtBlock.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(562, 246);
		base.Controls.Add(this.groupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormBlockClients";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Block";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormBlockClients_FormClosed);
		base.Load += new System.EventHandler(FormBlockClients_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}
}
