// Server.Forms.FormSetting
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Server.Properties;

public class FormSetting : DarkForm
{
	private IContainer components;

	private DarkButton button1;

	private DarkCheckBox checkBox1;

	private DarkTextBox textBox1;

	private DarkTextBox textBox2;

	private DarkLabel label1;

	private DarkLabel label2;

	public FormSetting()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (checkBox1.Checked && (textBox1.Text == null || textBox2.Text == null))
		{
			MessageBox.Show("Input the WebHook and secret");
		}
		Settings.Default.DingDing = checkBox1.Checked;
		Settings.Default.WebHook = textBox1.Text;
		Settings.Default.Secret = textBox2.Text;
		Settings.Default.Save();
		Close();
	}

	private void FormSetting_Load(object sender, EventArgs e)
	{
		checkBox1.Checked = Settings.Default.DingDing;
		textBox1.Text = Settings.Default.WebHook;
		textBox2.Text = Settings.Default.Secret;
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
		this.checkBox1 = new DarkUI.Controls.DarkCheckBox();
		this.textBox1 = new DarkUI.Controls.DarkTextBox();
		this.textBox2 = new DarkUI.Controls.DarkTextBox();
		this.label1 = new DarkUI.Controls.DarkLabel();
		this.label2 = new DarkUI.Controls.DarkLabel();
		base.SuspendLayout();
		this.button1.Location = new System.Drawing.Point(12, 165);
		this.button1.Name = "button1";
		this.button1.Padding = new System.Windows.Forms.Padding(5);
		this.button1.Size = new System.Drawing.Size(321, 44);
		this.button1.TabIndex = 0;
		this.button1.Text = "OK";
		this.button1.Click += new System.EventHandler(button1_Click);
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(12, 13);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(70, 17);
		this.checkBox1.TabIndex = 1;
		this.checkBox1.Text = "DingDing";
		this.textBox1.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.textBox1.Location = new System.Drawing.Point(71, 51);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(262, 20);
		this.textBox1.TabIndex = 2;
		this.textBox2.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.textBox2.Location = new System.Drawing.Point(71, 113);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(262, 20);
		this.textBox2.TabIndex = 3;
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label1.Location = new System.Drawing.Point(12, 60);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(57, 13);
		this.label1.TabIndex = 4;
		this.label1.Text = "Webhook:";
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label2.Location = new System.Drawing.Point(12, 113);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(41, 13);
		this.label2.TabIndex = 5;
		this.label2.Text = "Secret:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(345, 222);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormSetting";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Setting";
		base.Load += new System.EventHandler(FormSetting_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
