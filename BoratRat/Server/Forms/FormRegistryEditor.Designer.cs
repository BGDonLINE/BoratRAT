namespace Server.Forms
{
	// Token: 0x02000065 RID: 101
	public partial class FormRegistryEditor : global::DarkUI.Forms.DarkForm
	{
		// Token: 0x06000440 RID: 1088 RVA: 0x0002A240 File Offset: 0x0002A240
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0002A268 File Offset: 0x0002A268
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Server.Forms.FormRegistryEditor));
			this.tableLayoutPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.splitContainer = new global::System.Windows.Forms.SplitContainer();
			this.tvRegistryDirectory = new global::Server.Helper.RegistryTreeView();
			this.imageRegistryDirectoryList = new global::System.Windows.Forms.ImageList(this.components);
			this.lstRegistryValues = new global::Server.Helper.AeroListView();
			this.hName = new global::System.Windows.Forms.ColumnHeader();
			this.hType = new global::System.Windows.Forms.ColumnHeader();
			this.hValue = new global::System.Windows.Forms.ColumnHeader();
			this.imageRegistryKeyTypeList = new global::System.Windows.Forms.ImageList(this.components);
			this.statusStrip = new global::DarkUI.Controls.DarkStatusStrip();
			this.selectedStripStatusLabel = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyBinaryDataToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyNewtoolStripSeparator = new global::System.Windows.Forms.ToolStripSeparator();
			this.newToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.keyToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new global::System.Windows.Forms.ToolStripSeparator();
			this.stringValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.binaryValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dWORD32bitValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.qWORD64bitValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.multiStringValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.expandableStringValueToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new global::System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tv_ContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.keyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.stringValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.binaryValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dWORD32bitValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.qWORD64bitValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.multiStringValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.expandableStringValueToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedItem_ContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.modifyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyBinaryDataToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.lst_ContextMenuStrip = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.keyToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.stringValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.binaryValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dWORD32bitValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.qWORD64bitValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.multiStringValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.expandableStringValueToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.tv_ContextMenuStrip.SuspendLayout();
			this.selectedItem_ContextMenuStrip.SuspendLayout();
			this.lst_ContextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel.Controls.Add(this.splitContainer, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.statusStrip, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.menuStrip, 0, 0);
			this.tableLayoutPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.GrowStyle = global::System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel.Location = new global::System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 25f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 22f));
			this.tableLayoutPanel.Size = new global::System.Drawing.Size(784, 561);
			this.tableLayoutPanel.TabIndex = 0;
			this.splitContainer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new global::System.Drawing.Point(3, 28);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Panel1.Controls.Add(this.tvRegistryDirectory);
			this.splitContainer.Panel2.Controls.Add(this.lstRegistryValues);
			this.splitContainer.Size = new global::System.Drawing.Size(778, 508);
			this.splitContainer.SplitterDistance = 259;
			this.splitContainer.TabIndex = 0;
			this.tvRegistryDirectory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tvRegistryDirectory.HideSelection = false;
			this.tvRegistryDirectory.ImageIndex = 0;
			this.tvRegistryDirectory.ImageList = this.imageRegistryDirectoryList;
			this.tvRegistryDirectory.Location = new global::System.Drawing.Point(0, 0);
			this.tvRegistryDirectory.Name = "tvRegistryDirectory";
			this.tvRegistryDirectory.SelectedImageIndex = 0;
			this.tvRegistryDirectory.Size = new global::System.Drawing.Size(259, 508);
			this.tvRegistryDirectory.TabIndex = 0;
			this.tvRegistryDirectory.AfterLabelEdit += new global::System.Windows.Forms.NodeLabelEditEventHandler(this.tvRegistryDirectory_AfterLabelEdit);
			this.tvRegistryDirectory.BeforeExpand += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.tvRegistryDirectory_BeforeExpand);
			this.tvRegistryDirectory.BeforeSelect += new global::System.Windows.Forms.TreeViewCancelEventHandler(this.tvRegistryDirectory_BeforeSelect);
			this.tvRegistryDirectory.NodeMouseClick += new global::System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRegistryDirectory_NodeMouseClick);
			this.tvRegistryDirectory.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tvRegistryDirectory_KeyUp);
			this.imageRegistryDirectoryList.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageRegistryDirectoryList.ImageStream");
			this.imageRegistryDirectoryList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageRegistryDirectoryList.Images.SetKeyName(0, "folder.png");
			this.lstRegistryValues.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] { this.hName, this.hType, this.hValue });
			this.lstRegistryValues.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.lstRegistryValues.FullRowSelect = true;
			this.lstRegistryValues.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstRegistryValues.HideSelection = false;
			this.lstRegistryValues.Location = new global::System.Drawing.Point(0, 0);
			this.lstRegistryValues.Name = "lstRegistryValues";
			this.lstRegistryValues.Size = new global::System.Drawing.Size(515, 508);
			this.lstRegistryValues.SmallImageList = this.imageRegistryKeyTypeList;
			this.lstRegistryValues.TabIndex = 0;
			this.lstRegistryValues.UseCompatibleStateImageBehavior = false;
			this.lstRegistryValues.View = global::System.Windows.Forms.View.Details;
			this.lstRegistryValues.AfterLabelEdit += new global::System.Windows.Forms.LabelEditEventHandler(this.lstRegistryKeys_AfterLabelEdit);
			this.lstRegistryValues.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.lstRegistryKeys_KeyUp);
			this.lstRegistryValues.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.lstRegistryKeys_MouseClick);
			this.hName.Text = "Name";
			this.hName.Width = 173;
			this.hType.Text = "Type";
			this.hType.Width = 104;
			this.hValue.Text = "Value";
			this.hValue.Width = 214;
			this.imageRegistryKeyTypeList.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imageRegistryKeyTypeList.ImageStream");
			this.imageRegistryKeyTypeList.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imageRegistryKeyTypeList.Images.SetKeyName(0, "reg_string.png");
			this.imageRegistryKeyTypeList.Images.SetKeyName(1, "reg_binary.png");
			this.statusStrip.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.statusStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.selectedStripStatusLabel });
			this.statusStrip.Location = new global::System.Drawing.Point(0, 539);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new global::System.Drawing.Size(784, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip";
			this.selectedStripStatusLabel.Name = "selectedStripStatusLabel";
			this.selectedStripStatusLabel.Size = new global::System.Drawing.Size(0, 17);
			this.menuStrip.Dock = global::System.Windows.Forms.DockStyle.None;
			this.menuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem, this.editToolStripMenuItem });
			this.menuStrip.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new global::System.Drawing.Size(89, 25);
			this.menuStrip.TabIndex = 2;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.exitToolStripMenuItem });
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(39, 21);
			this.fileToolStripMenuItem.Text = "File";
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new global::System.Drawing.Size(96, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new global::System.EventHandler(this.menuStripExit_Click);
			this.editToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.modifyToolStripMenuItem1, this.modifyBinaryDataToolStripMenuItem1, this.modifyNewtoolStripSeparator, this.newToolStripMenuItem2, this.toolStripSeparator6, this.deleteToolStripMenuItem2, this.renameToolStripMenuItem2 });
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new global::System.Drawing.Size(42, 21);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.DropDownOpening += new global::System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
			this.modifyToolStripMenuItem1.Enabled = false;
			this.modifyToolStripMenuItem1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
			this.modifyToolStripMenuItem1.Size = new global::System.Drawing.Size(197, 22);
			this.modifyToolStripMenuItem1.Text = "Modify...";
			this.modifyToolStripMenuItem1.Visible = false;
			this.modifyToolStripMenuItem1.Click += new global::System.EventHandler(this.modifyRegistryValue_Click);
			this.modifyBinaryDataToolStripMenuItem1.Enabled = false;
			this.modifyBinaryDataToolStripMenuItem1.Name = "modifyBinaryDataToolStripMenuItem1";
			this.modifyBinaryDataToolStripMenuItem1.Size = new global::System.Drawing.Size(197, 22);
			this.modifyBinaryDataToolStripMenuItem1.Text = "Modify Binary Data...";
			this.modifyBinaryDataToolStripMenuItem1.Visible = false;
			this.modifyBinaryDataToolStripMenuItem1.Click += new global::System.EventHandler(this.modifyBinaryDataRegistryValue_Click);
			this.modifyNewtoolStripSeparator.Name = "modifyNewtoolStripSeparator";
			this.modifyNewtoolStripSeparator.Size = new global::System.Drawing.Size(194, 6);
			this.modifyNewtoolStripSeparator.Visible = false;
			this.newToolStripMenuItem2.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.keyToolStripMenuItem2, this.toolStripSeparator7, this.stringValueToolStripMenuItem2, this.binaryValueToolStripMenuItem2, this.dWORD32bitValueToolStripMenuItem2, this.qWORD64bitValueToolStripMenuItem2, this.multiStringValueToolStripMenuItem2, this.expandableStringValueToolStripMenuItem2 });
			this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
			this.newToolStripMenuItem2.Size = new global::System.Drawing.Size(197, 22);
			this.newToolStripMenuItem2.Text = "New";
			this.keyToolStripMenuItem2.Name = "keyToolStripMenuItem2";
			this.keyToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.keyToolStripMenuItem2.Text = "Key";
			this.keyToolStripMenuItem2.Click += new global::System.EventHandler(this.createNewRegistryKey_Click);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new global::System.Drawing.Size(215, 6);
			this.stringValueToolStripMenuItem2.Name = "stringValueToolStripMenuItem2";
			this.stringValueToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.stringValueToolStripMenuItem2.Text = "String Value";
			this.stringValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createStringRegistryValue_Click);
			this.binaryValueToolStripMenuItem2.Name = "binaryValueToolStripMenuItem2";
			this.binaryValueToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.binaryValueToolStripMenuItem2.Text = "Binary Value";
			this.binaryValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createBinaryRegistryValue_Click);
			this.dWORD32bitValueToolStripMenuItem2.Name = "dWORD32bitValueToolStripMenuItem2";
			this.dWORD32bitValueToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.dWORD32bitValueToolStripMenuItem2.Text = "DWORD (32-bit) Value";
			this.dWORD32bitValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createDwordRegistryValue_Click);
			this.qWORD64bitValueToolStripMenuItem2.Name = "qWORD64bitValueToolStripMenuItem2";
			this.qWORD64bitValueToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.qWORD64bitValueToolStripMenuItem2.Text = "QWORD (64-bit) Value";
			this.qWORD64bitValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createQwordRegistryValue_Click);
			this.multiStringValueToolStripMenuItem2.Name = "multiStringValueToolStripMenuItem2";
			this.multiStringValueToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.multiStringValueToolStripMenuItem2.Text = "Multi-String Value";
			this.multiStringValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createMultiStringRegistryValue_Click);
			this.expandableStringValueToolStripMenuItem2.Name = "expandableStringValueToolStripMenuItem2";
			this.expandableStringValueToolStripMenuItem2.Size = new global::System.Drawing.Size(218, 22);
			this.expandableStringValueToolStripMenuItem2.Text = "Expandable String Value";
			this.expandableStringValueToolStripMenuItem2.Click += new global::System.EventHandler(this.createExpandStringRegistryValue_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new global::System.Drawing.Size(194, 6);
			this.deleteToolStripMenuItem2.Enabled = false;
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.ShortcutKeyDisplayString = "Del";
			this.deleteToolStripMenuItem2.Size = new global::System.Drawing.Size(197, 22);
			this.deleteToolStripMenuItem2.Text = "Delete";
			this.deleteToolStripMenuItem2.Click += new global::System.EventHandler(this.menuStripDelete_Click);
			this.renameToolStripMenuItem2.Enabled = false;
			this.renameToolStripMenuItem2.Name = "renameToolStripMenuItem2";
			this.renameToolStripMenuItem2.Size = new global::System.Drawing.Size(197, 22);
			this.renameToolStripMenuItem2.Text = "Rename";
			this.renameToolStripMenuItem2.Click += new global::System.EventHandler(this.menuStripRename_Click);
			this.tv_ContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.newToolStripMenuItem, this.toolStripSeparator1, this.deleteToolStripMenuItem, this.renameToolStripMenuItem });
			this.tv_ContextMenuStrip.Name = "contextMenuStrip";
			this.tv_ContextMenuStrip.Size = new global::System.Drawing.Size(124, 76);
			this.newToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.keyToolStripMenuItem, this.toolStripSeparator2, this.stringValueToolStripMenuItem, this.binaryValueToolStripMenuItem, this.dWORD32bitValueToolStripMenuItem, this.qWORD64bitValueToolStripMenuItem, this.multiStringValueToolStripMenuItem, this.expandableStringValueToolStripMenuItem });
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new global::System.Drawing.Size(123, 22);
			this.newToolStripMenuItem.Text = "New";
			this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
			this.keyToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.keyToolStripMenuItem.Text = "Key";
			this.keyToolStripMenuItem.Click += new global::System.EventHandler(this.createNewRegistryKey_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(215, 6);
			this.stringValueToolStripMenuItem.Name = "stringValueToolStripMenuItem";
			this.stringValueToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.stringValueToolStripMenuItem.Text = "String Value";
			this.stringValueToolStripMenuItem.Click += new global::System.EventHandler(this.createStringRegistryValue_Click);
			this.binaryValueToolStripMenuItem.Name = "binaryValueToolStripMenuItem";
			this.binaryValueToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.binaryValueToolStripMenuItem.Text = "Binary Value";
			this.binaryValueToolStripMenuItem.Click += new global::System.EventHandler(this.createBinaryRegistryValue_Click);
			this.dWORD32bitValueToolStripMenuItem.Name = "dWORD32bitValueToolStripMenuItem";
			this.dWORD32bitValueToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.dWORD32bitValueToolStripMenuItem.Text = "DWORD (32-bit) Value";
			this.dWORD32bitValueToolStripMenuItem.Click += new global::System.EventHandler(this.createDwordRegistryValue_Click);
			this.qWORD64bitValueToolStripMenuItem.Name = "qWORD64bitValueToolStripMenuItem";
			this.qWORD64bitValueToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.qWORD64bitValueToolStripMenuItem.Text = "QWORD (64-bit) Value";
			this.qWORD64bitValueToolStripMenuItem.Click += new global::System.EventHandler(this.createQwordRegistryValue_Click);
			this.multiStringValueToolStripMenuItem.Name = "multiStringValueToolStripMenuItem";
			this.multiStringValueToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.multiStringValueToolStripMenuItem.Text = "Multi-String Value";
			this.multiStringValueToolStripMenuItem.Click += new global::System.EventHandler(this.createMultiStringRegistryValue_Click);
			this.expandableStringValueToolStripMenuItem.Name = "expandableStringValueToolStripMenuItem";
			this.expandableStringValueToolStripMenuItem.Size = new global::System.Drawing.Size(218, 22);
			this.expandableStringValueToolStripMenuItem.Text = "Expandable String Value";
			this.expandableStringValueToolStripMenuItem.Click += new global::System.EventHandler(this.createExpandStringRegistryValue_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(120, 6);
			this.deleteToolStripMenuItem.Enabled = false;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(123, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new global::System.EventHandler(this.deleteRegistryKey_Click);
			this.renameToolStripMenuItem.Enabled = false;
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new global::System.Drawing.Size(123, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			this.renameToolStripMenuItem.Click += new global::System.EventHandler(this.renameRegistryKey_Click);
			this.selectedItem_ContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.modifyToolStripMenuItem, this.modifyBinaryDataToolStripMenuItem, this.modifyToolStripSeparator1, this.deleteToolStripMenuItem1, this.renameToolStripMenuItem1 });
			this.selectedItem_ContextMenuStrip.Name = "selectedItem_ContextMenuStrip";
			this.selectedItem_ContextMenuStrip.Size = new global::System.Drawing.Size(198, 98);
			this.modifyToolStripMenuItem.Enabled = false;
			this.modifyToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
			this.modifyToolStripMenuItem.Size = new global::System.Drawing.Size(197, 22);
			this.modifyToolStripMenuItem.Text = "Modify...";
			this.modifyToolStripMenuItem.Click += new global::System.EventHandler(this.modifyRegistryValue_Click);
			this.modifyBinaryDataToolStripMenuItem.Enabled = false;
			this.modifyBinaryDataToolStripMenuItem.Name = "modifyBinaryDataToolStripMenuItem";
			this.modifyBinaryDataToolStripMenuItem.Size = new global::System.Drawing.Size(197, 22);
			this.modifyBinaryDataToolStripMenuItem.Text = "Modify Binary Data...";
			this.modifyBinaryDataToolStripMenuItem.Click += new global::System.EventHandler(this.modifyBinaryDataRegistryValue_Click);
			this.modifyToolStripSeparator1.Name = "modifyToolStripSeparator1";
			this.modifyToolStripSeparator1.Size = new global::System.Drawing.Size(194, 6);
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new global::System.Drawing.Size(197, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			this.deleteToolStripMenuItem1.Click += new global::System.EventHandler(this.deleteRegistryValue_Click);
			this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
			this.renameToolStripMenuItem1.Size = new global::System.Drawing.Size(197, 22);
			this.renameToolStripMenuItem1.Text = "Rename";
			this.renameToolStripMenuItem1.Click += new global::System.EventHandler(this.renameRegistryValue_Click);
			this.lst_ContextMenuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.newToolStripMenuItem1 });
			this.lst_ContextMenuStrip.Name = "lst_ContextMenuStrip";
			this.lst_ContextMenuStrip.Size = new global::System.Drawing.Size(103, 26);
			this.newToolStripMenuItem1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.keyToolStripMenuItem1, this.toolStripSeparator4, this.stringValueToolStripMenuItem1, this.binaryValueToolStripMenuItem1, this.dWORD32bitValueToolStripMenuItem1, this.qWORD64bitValueToolStripMenuItem1, this.multiStringValueToolStripMenuItem1, this.expandableStringValueToolStripMenuItem1 });
			this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			this.newToolStripMenuItem1.Size = new global::System.Drawing.Size(102, 22);
			this.newToolStripMenuItem1.Text = "New";
			this.keyToolStripMenuItem1.Name = "keyToolStripMenuItem1";
			this.keyToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.keyToolStripMenuItem1.Text = "Key";
			this.keyToolStripMenuItem1.Click += new global::System.EventHandler(this.createNewRegistryKey_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(215, 6);
			this.stringValueToolStripMenuItem1.Name = "stringValueToolStripMenuItem1";
			this.stringValueToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.stringValueToolStripMenuItem1.Text = "String Value";
			this.stringValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createStringRegistryValue_Click);
			this.binaryValueToolStripMenuItem1.Name = "binaryValueToolStripMenuItem1";
			this.binaryValueToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.binaryValueToolStripMenuItem1.Text = "Binary Value";
			this.binaryValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createBinaryRegistryValue_Click);
			this.dWORD32bitValueToolStripMenuItem1.Name = "dWORD32bitValueToolStripMenuItem1";
			this.dWORD32bitValueToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.dWORD32bitValueToolStripMenuItem1.Text = "DWORD (32-bit) Value";
			this.dWORD32bitValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createDwordRegistryValue_Click);
			this.qWORD64bitValueToolStripMenuItem1.Name = "qWORD64bitValueToolStripMenuItem1";
			this.qWORD64bitValueToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.qWORD64bitValueToolStripMenuItem1.Text = "QWORD (64-bit) Value";
			this.qWORD64bitValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createQwordRegistryValue_Click);
			this.multiStringValueToolStripMenuItem1.Name = "multiStringValueToolStripMenuItem1";
			this.multiStringValueToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.multiStringValueToolStripMenuItem1.Text = "Multi-String Value";
			this.multiStringValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createMultiStringRegistryValue_Click);
			this.expandableStringValueToolStripMenuItem1.Name = "expandableStringValueToolStripMenuItem1";
			this.expandableStringValueToolStripMenuItem1.Size = new global::System.Drawing.Size(218, 22);
			this.expandableStringValueToolStripMenuItem1.Text = "Expandable String Value";
			this.expandableStringValueToolStripMenuItem1.Click += new global::System.EventHandler(this.createExpandStringRegistryValue_Click);
			this.timer1.Interval = 2000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(784, 561);
			base.Controls.Add(this.tableLayoutPanel);
			this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.MainMenuStrip = this.menuStrip;
			base.Name = "FormRegistryEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registry Editor []";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.FormRegistryEditor_FormClosed);
			base.Load += new global::System.EventHandler(this.FrmRegistryEditor_Load);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.tv_ContextMenuStrip.ResumeLayout(false);
			this.selectedItem_ContextMenuStrip.ResumeLayout(false);
			this.lst_ContextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040002D5 RID: 725
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040002D6 RID: 726
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

		// Token: 0x040002D7 RID: 727
		private global::System.Windows.Forms.SplitContainer splitContainer;

		// Token: 0x040002D8 RID: 728
		public global::Server.Helper.RegistryTreeView tvRegistryDirectory;

		// Token: 0x040002D9 RID: 729
		private global::Server.Helper.AeroListView lstRegistryValues;

		// Token: 0x040002DA RID: 730
		private global::System.Windows.Forms.StatusStrip statusStrip;

		// Token: 0x040002DB RID: 731
		private global::System.Windows.Forms.ToolStripStatusLabel selectedStripStatusLabel;

		// Token: 0x040002DC RID: 732
		private global::System.Windows.Forms.ImageList imageRegistryDirectoryList;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.ColumnHeader hName;

		// Token: 0x040002DE RID: 734
		private global::System.Windows.Forms.ColumnHeader hType;

		// Token: 0x040002DF RID: 735
		private global::System.Windows.Forms.ColumnHeader hValue;

		// Token: 0x040002E0 RID: 736
		private global::System.Windows.Forms.ImageList imageRegistryKeyTypeList;

		// Token: 0x040002E1 RID: 737
		private global::System.Windows.Forms.ContextMenuStrip tv_ContextMenuStrip;

		// Token: 0x040002E2 RID: 738
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

		// Token: 0x040002E3 RID: 739
		private global::System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem;

		// Token: 0x040002E4 RID: 740
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		// Token: 0x040002E5 RID: 741
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem;

		// Token: 0x040002EA RID: 746
		private global::System.Windows.Forms.ToolStripMenuItem dWORD32bitValueToolStripMenuItem;

		// Token: 0x040002EB RID: 747
		private global::System.Windows.Forms.ToolStripMenuItem qWORD64bitValueToolStripMenuItem;

		// Token: 0x040002EC RID: 748
		private global::System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem;

		// Token: 0x040002ED RID: 749
		private global::System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem;

		// Token: 0x040002EE RID: 750
		private global::System.Windows.Forms.ContextMenuStrip selectedItem_ContextMenuStrip;

		// Token: 0x040002EF RID: 751
		private global::System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;

		// Token: 0x040002F0 RID: 752
		private global::System.Windows.Forms.ToolStripMenuItem modifyBinaryDataToolStripMenuItem;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem1;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.ContextMenuStrip lst_ContextMenuStrip;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem1;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem1;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem1;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.ToolStripMenuItem dWORD32bitValueToolStripMenuItem1;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.ToolStripMenuItem qWORD64bitValueToolStripMenuItem1;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem1;

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem1;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		// Token: 0x040002FD RID: 765
		private global::System.Windows.Forms.MenuStrip menuStrip;

		// Token: 0x040002FE RID: 766
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x040002FF RID: 767
		private global::System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

		// Token: 0x04000300 RID: 768
		private global::System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;

		// Token: 0x04000301 RID: 769
		private global::System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;

		// Token: 0x04000302 RID: 770
		private global::System.Windows.Forms.ToolStripMenuItem modifyBinaryDataToolStripMenuItem1;

		// Token: 0x04000303 RID: 771
		private global::System.Windows.Forms.ToolStripSeparator modifyNewtoolStripSeparator;

		// Token: 0x04000304 RID: 772
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;

		// Token: 0x04000305 RID: 773
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

		// Token: 0x04000306 RID: 774
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;

		// Token: 0x04000307 RID: 775
		private global::System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem2;

		// Token: 0x04000308 RID: 776
		private global::System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem2;

		// Token: 0x04000309 RID: 777
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator7;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.ToolStripMenuItem stringValueToolStripMenuItem2;

		// Token: 0x0400030B RID: 779
		private global::System.Windows.Forms.ToolStripMenuItem binaryValueToolStripMenuItem2;

		// Token: 0x0400030C RID: 780
		private global::System.Windows.Forms.ToolStripMenuItem dWORD32bitValueToolStripMenuItem2;

		// Token: 0x0400030D RID: 781
		private global::System.Windows.Forms.ToolStripMenuItem qWORD64bitValueToolStripMenuItem2;

		// Token: 0x0400030E RID: 782
		private global::System.Windows.Forms.ToolStripMenuItem multiStringValueToolStripMenuItem2;

		// Token: 0x0400030F RID: 783
		private global::System.Windows.Forms.ToolStripMenuItem expandableStringValueToolStripMenuItem2;

		// Token: 0x04000310 RID: 784
		private global::System.Windows.Forms.ToolStripSeparator modifyToolStripSeparator1;

		// Token: 0x04000311 RID: 785
		public global::System.Windows.Forms.Timer timer1;
	}
}
