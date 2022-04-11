using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Server.Helper
{
	// Token: 0x0200002B RID: 43
	public class WordTextBox : TextBox
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000F3D0 File Offset: 0x0000F3D0
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x0000F3D8 File Offset: 0x0000F3D8
		public override int MaxLength
		{
			get
			{
				return base.MaxLength;
			}
			set
			{
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000F3DC File Offset: 0x0000F3DC
		// (set) Token: 0x060001BA RID: 442 RVA: 0x0000F3E4 File Offset: 0x0000F3E4
		public bool IsHexNumber
		{
			get
			{
				return this.isHexNumber;
			}
			set
			{
				if (this.isHexNumber == value)
				{
					return;
				}
				if (value)
				{
					if (this.Type == WordTextBox.WordType.DWORD)
					{
						this.Text = this.UIntValue.ToString("x");
					}
					else
					{
						this.Text = this.ULongValue.ToString("x");
					}
				}
				else if (this.Type == WordTextBox.WordType.DWORD)
				{
					this.Text = this.UIntValue.ToString();
				}
				else
				{
					this.Text = this.ULongValue.ToString();
				}
				this.isHexNumber = value;
				this.UpdateMaxLength();
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001BB RID: 443 RVA: 0x0000F494 File Offset: 0x0000F494
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000F49C File Offset: 0x0000F49C
		public WordTextBox.WordType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				if (this.type == value)
				{
					return;
				}
				this.type = value;
				this.UpdateMaxLength();
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000F4B8 File Offset: 0x0000F4B8
		public uint UIntValue
		{
			get
			{
				uint result;
				try
				{
					if (string.IsNullOrEmpty(this.Text))
					{
						result = 0U;
					}
					else if (this.IsHexNumber)
					{
						result = uint.Parse(this.Text, NumberStyles.HexNumber);
					}
					else
					{
						result = uint.Parse(this.Text);
					}
				}
				catch (Exception)
				{
					result = uint.MaxValue;
				}
				return result;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000F528 File Offset: 0x0000F528
		public ulong ULongValue
		{
			get
			{
				ulong result;
				try
				{
					if (string.IsNullOrEmpty(this.Text))
					{
						result = 0UL;
					}
					else if (this.IsHexNumber)
					{
						result = ulong.Parse(this.Text, NumberStyles.HexNumber);
					}
					else
					{
						result = ulong.Parse(this.Text);
					}
				}
				catch (Exception)
				{
					result = ulong.MaxValue;
				}
				return result;
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000F59C File Offset: 0x0000F59C
		public bool IsConversionValid()
		{
			return string.IsNullOrEmpty(this.Text) || this.IsHexNumber || this.ConvertToHex();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000F5C4 File Offset: 0x0000F5C4
		public WordTextBox()
		{
			this.InitializeComponent();
			base.MaxLength = 8;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000F5DC File Offset: 0x0000F5DC
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			e.Handled = !this.IsValidChar(e.KeyChar);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000F60C File Offset: 0x0000F60C
		private bool IsValidChar(char ch)
		{
			return char.IsControl(ch) || char.IsDigit(ch) || (this.IsHexNumber && char.IsLetter(ch) && char.ToLower(ch) <= 'f');
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000F64C File Offset: 0x0000F64C
		private void UpdateMaxLength()
		{
			if (this.Type == WordTextBox.WordType.DWORD)
			{
				if (this.IsHexNumber)
				{
					base.MaxLength = 8;
					return;
				}
				base.MaxLength = 10;
				return;
			}
			else
			{
				if (this.IsHexNumber)
				{
					base.MaxLength = 16;
					return;
				}
				base.MaxLength = 20;
				return;
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000F6A0 File Offset: 0x0000F6A0
		private bool ConvertToHex()
		{
			bool result;
			try
			{
				if (this.Type == WordTextBox.WordType.DWORD)
				{
					uint.Parse(this.Text);
				}
				else
				{
					ulong.Parse(this.Text);
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000F6F8 File Offset: 0x0000F6F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000F720 File Offset: 0x0000F720
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040000F7 RID: 247
		private bool isHexNumber;

		// Token: 0x040000F8 RID: 248
		private WordTextBox.WordType type;

		// Token: 0x040000F9 RID: 249
		private IContainer components;

		// Token: 0x02000D59 RID: 3417
		public enum WordType
		{
			// Token: 0x04003F50 RID: 16208
			DWORD,
			// Token: 0x04003F51 RID: 16209
			QWORD
		}
	}
}
