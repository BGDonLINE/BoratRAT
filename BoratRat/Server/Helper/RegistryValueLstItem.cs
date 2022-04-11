using System;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x0200002A RID: 42
	public class RegistryValueLstItem : ListViewItem
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0000F1FC File Offset: 0x0000F1FC
		// (set) Token: 0x060001AC RID: 428 RVA: 0x0000F204 File Offset: 0x0000F204
		private string _type { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000F210 File Offset: 0x0000F210
		// (set) Token: 0x060001AE RID: 430 RVA: 0x0000F218 File Offset: 0x0000F218
		private string _data { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000F224 File Offset: 0x0000F224
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x0000F22C File Offset: 0x0000F22C
		public string RegName
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
				base.Text = RegValueHelper.GetName(value);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000F244 File Offset: 0x0000F244
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x0000F24C File Offset: 0x0000F24C
		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
				if (base.SubItems.Count < 2)
				{
					base.SubItems.Add(this._type);
				}
				else
				{
					base.SubItems[1].Text = this._type;
				}
				base.ImageIndex = this.GetRegistryValueImgIndex(this._type);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x0000F2B8 File Offset: 0x0000F2B8
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x0000F2C0 File Offset: 0x0000F2C0
		public string Data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
				if (base.SubItems.Count < 3)
				{
					base.SubItems.Add(this._data);
					return;
				}
				base.SubItems[2].Text = this._data;
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000F314 File Offset: 0x0000F314
		public RegistryValueLstItem(RegistrySeeker.RegValueData value)
		{
			this.RegName = value.Name;
			this.Type = value.Kind.RegistryTypeToString();
			this.Data = RegValueHelper.RegistryValueToString(value);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000F354 File Offset: 0x0000F354
		private int GetRegistryValueImgIndex(string type)
		{
			if (!(type == "REG_MULTI_SZ") && !(type == "REG_SZ") && !(type == "REG_EXPAND_SZ"))
			{
				if (!(type == "REG_BINARY") && !(type == "REG_DWORD") && !(type == "REG_QWORD"))
				{
				}
				return 1;
			}
			return 0;
		}
	}
}
