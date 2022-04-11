using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000032 RID: 50
	public class Caret
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00010E14 File Offset: 0x00010E14
		public int SelectionStart
		{
			get
			{
				if (this._endIndex < this._startIndex)
				{
					return this._endIndex;
				}
				return this._startIndex;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00010E34 File Offset: 0x00010E34
		public int SelectionLength
		{
			get
			{
				if (this._endIndex < this._startIndex)
				{
					return this._startIndex - this._endIndex;
				}
				return this._endIndex - this._startIndex;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00010E64 File Offset: 0x00010E64
		public bool Focused
		{
			get
			{
				return this._isCaretActive;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00010E6C File Offset: 0x00010E6C
		public int CurrentIndex
		{
			get
			{
				return this._endIndex;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00010E74 File Offset: 0x00010E74
		public Point Location
		{
			get
			{
				return this._location;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600021E RID: 542 RVA: 0x00010E7C File Offset: 0x00010E7C
		// (remove) Token: 0x0600021F RID: 543 RVA: 0x00010EB8 File Offset: 0x00010EB8
		public event EventHandler SelectionStartChanged;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000220 RID: 544 RVA: 0x00010EF4 File Offset: 0x00010EF4
		// (remove) Token: 0x06000221 RID: 545 RVA: 0x00010F30 File Offset: 0x00010F30
		public event EventHandler SelectionLengthChanged;

		// Token: 0x06000222 RID: 546 RVA: 0x00010F6C File Offset: 0x00010F6C
		public Caret(HexEditor editor)
		{
			this._editor = editor;
			this._isCaretActive = false;
			this._startIndex = 0;
			this._endIndex = 0;
			this._isCaretHidden = true;
			this._location = new Point(0, 0);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00010FA4 File Offset: 0x00010FA4
		private bool Create(IntPtr hWHandler)
		{
			if (!this._isCaretActive)
			{
				this._isCaretActive = true;
				return Caret.CreateCaret(hWHandler, IntPtr.Zero, 0, (int)this._editor.CharSize.Height - 2);
			}
			return false;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00010FEC File Offset: 0x00010FEC
		private bool Show(IntPtr hWnd)
		{
			if (this._isCaretActive)
			{
				this._isCaretHidden = false;
				return Caret.ShowCaret(hWnd);
			}
			return false;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00011008 File Offset: 0x00011008
		public bool Hide(IntPtr hWnd)
		{
			if (this._isCaretActive && !this._isCaretHidden)
			{
				this._isCaretHidden = true;
				return Caret.HideCaret(hWnd);
			}
			return false;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00011030 File Offset: 0x00011030
		public bool Destroy()
		{
			if (this._isCaretActive)
			{
				this._isCaretActive = false;
				this.DeSelect();
				Caret.DestroyCaret();
			}
			return false;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00011054 File Offset: 0x00011054
		public void SetStartIndex(int index)
		{
			this._startIndex = index;
			this._endIndex = this._startIndex;
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, EventArgs.Empty);
			}
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000110B0 File Offset: 0x000110B0
		public void SetEndIndex(int index)
		{
			this._endIndex = index;
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, EventArgs.Empty);
			}
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00011100 File Offset: 0x00011100
		public void SetCaretLocation(Point start)
		{
			this.Create(this._editor.Handle);
			this._location = start;
			Caret.SetCaretPos(this._location.X, this._location.Y);
			this.Show(this._editor.Handle);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00011158 File Offset: 0x00011158
		public bool IsSelected(int byteIndex)
		{
			return this.SelectionStart <= byteIndex && byteIndex < this.SelectionStart + this.SelectionLength;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00011178 File Offset: 0x00011178
		private void DeSelect()
		{
			if (this._endIndex < this._startIndex)
			{
				this._startIndex = this._endIndex;
			}
			else
			{
				this._endIndex = this._startIndex;
			}
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, EventArgs.Empty);
			}
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600022C RID: 556
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

		// Token: 0x0600022D RID: 557
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool DestroyCaret();

		// Token: 0x0600022E RID: 558
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetCaretPos(int x, int y);

		// Token: 0x0600022F RID: 559
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool ShowCaret(IntPtr hWnd);

		// Token: 0x06000230 RID: 560
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool HideCaret(IntPtr hWnd);

		// Token: 0x04000133 RID: 307
		private int _startIndex;

		// Token: 0x04000134 RID: 308
		private int _endIndex;

		// Token: 0x04000135 RID: 309
		private bool _isCaretActive;

		// Token: 0x04000136 RID: 310
		private bool _isCaretHidden;

		// Token: 0x04000137 RID: 311
		private Point _location;

		// Token: 0x04000138 RID: 312
		private HexEditor _editor;
	}
}
