using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000034 RID: 52
	public class HexEditor : Control
	{
		// Token: 0x1700007C RID: 124
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00011464 File Offset: 0x00011464
		public override Font Font
		{
			set
			{
				base.Font = value;
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0001147C File Offset: 0x0001147C
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00011484 File Offset: 0x00011484
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00011490 File Offset: 0x00011490
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000114E0 File Offset: 0x000114E0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public byte[] HexTable
		{
			get
			{
				object hexTableLock = this._hexTableLock;
				byte[] result;
				lock (hexTableLock)
				{
					result = this._hexTable.ToArray();
				}
				return result;
			}
			set
			{
				object hexTableLock = this._hexTableLock;
				lock (hexTableLock)
				{
					if (value == this._hexTable.ToArray())
					{
						return;
					}
					this._hexTable = new ByteCollection(value);
				}
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00011550 File Offset: 0x00011550
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00011558 File Offset: 0x00011558
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SizeF CharSize
		{
			get
			{
				return this._charSize;
			}
			private set
			{
				if (this._charSize == value)
				{
					return;
				}
				this._charSize = value;
				if (this.CharSizeChanged != null)
				{
					this.CharSizeChanged(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00011590 File Offset: 0x00011590
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int MaxBytesV
		{
			get
			{
				return this._maxBytesV;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00011598 File Offset: 0x00011598
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int FirstVisibleByte
		{
			get
			{
				return this._firstByte;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000248 RID: 584 RVA: 0x000115A0 File Offset: 0x000115A0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int LastVisibleByte
		{
			get
			{
				return this._lastByte;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000249 RID: 585 RVA: 0x000115A8 File Offset: 0x000115A8
		// (set) Token: 0x0600024A RID: 586 RVA: 0x000115B0 File Offset: 0x000115B0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool VScrollBarHidden
		{
			get
			{
				return this._isVScrollHidden;
			}
			set
			{
				if (this._isVScrollHidden == value)
				{
					return;
				}
				this._isVScrollHidden = value;
				if (!this._isVScrollHidden)
				{
					base.Controls.Add(this._vScrollBar);
				}
				else
				{
					base.Controls.Remove(this._vScrollBar);
				}
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00011614 File Offset: 0x00011614
		// (set) Token: 0x0600024C RID: 588 RVA: 0x0001161C File Offset: 0x0001161C
		[DefaultValue(8)]
		[Category("Hex")]
		[Description("Property that specifies the number of bytes to display per line.")]
		public int BytesPerLine
		{
			get
			{
				return this._bytesPerLine;
			}
			set
			{
				if (this._bytesPerLine == value)
				{
					return;
				}
				this._bytesPerLine = value;
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00011640 File Offset: 0x00011640
		// (set) Token: 0x0600024E RID: 590 RVA: 0x00011648 File Offset: 0x00011648
		[DefaultValue(10)]
		[Category("Hex")]
		[Description("Property that specifies the margin between each of the entitys in the control.")]
		public int EntityMargin
		{
			get
			{
				return this._entityMargin;
			}
			set
			{
				if (this._entityMargin == value)
				{
					return;
				}
				this._entityMargin = value;
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0001166C File Offset: 0x0001166C
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00011674 File Offset: 0x00011674
		[DefaultValue(BorderStyle.Fixed3D)]
		[Category("Appearance")]
		[Description("Indicates where the control should have a border.")]
		public BorderStyle BorderStyle
		{
			get
			{
				return this._borderStyle;
			}
			set
			{
				if (this._borderStyle == value)
				{
					return;
				}
				if (value != BorderStyle.FixedSingle)
				{
					this._borderColor = Color.Empty;
				}
				this._borderStyle = value;
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000251 RID: 593 RVA: 0x000116A8 File Offset: 0x000116A8
		// (set) Token: 0x06000252 RID: 594 RVA: 0x000116B0 File Offset: 0x000116B0
		[DefaultValue(typeof(Color), "Empty")]
		[Category("Appearance")]
		[Description("Indicates the color to be used when displaying a FixedSingle border.")]
		public Color BorderColor
		{
			get
			{
				return this._borderColor;
			}
			set
			{
				if (this.BorderStyle != BorderStyle.FixedSingle || this._borderColor == value)
				{
					return;
				}
				this._borderColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000116E0 File Offset: 0x000116E0
		// (set) Token: 0x06000254 RID: 596 RVA: 0x000116E8 File Offset: 0x000116E8
		[DefaultValue(typeof(Color), "Blue")]
		[Category("Hex")]
		[Description("Property for the background color of the selected text areas.")]
		public Color SelectionBackColor
		{
			get
			{
				return this._selectionBackColor;
			}
			set
			{
				if (this._selectionBackColor == value)
				{
					return;
				}
				this._selectionBackColor = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00011704 File Offset: 0x00011704
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0001170C File Offset: 0x0001170C
		[DefaultValue(typeof(Color), "White")]
		[Category("Hex")]
		[Description("Property for the foreground color of the selected text areas.")]
		public Color SelectionForeColor
		{
			get
			{
				return this._selectionForeColor;
			}
			set
			{
				if (this._selectionForeColor == value)
				{
					return;
				}
				this._selectionForeColor = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00011728 File Offset: 0x00011728
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00011730 File Offset: 0x00011730
		[DefaultValue(HexEditor.CaseStyle.UpperCase)]
		[Category("Hex")]
		[Description("Property for the case type to use on the line counter.")]
		public HexEditor.CaseStyle LineCountCaseStyle
		{
			get
			{
				return this._lineCountCaseStyle;
			}
			set
			{
				if (this._lineCountCaseStyle == value)
				{
					return;
				}
				this._lineCountCaseStyle = value;
				if (this._lineCountCaseStyle == HexEditor.CaseStyle.LowerCase)
				{
					this._lineCountCaps = "x";
				}
				else
				{
					this._lineCountCaps = "X";
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00011784 File Offset: 0x00011784
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0001178C File Offset: 0x0001178C
		[DefaultValue(HexEditor.CaseStyle.UpperCase)]
		[Category("Hex")]
		[Description("Property for the case type to use for the hexadecimal values view.")]
		public HexEditor.CaseStyle HexViewCaseStyle
		{
			get
			{
				return this._hexViewCaseStyle;
			}
			set
			{
				if (this._hexViewCaseStyle == value)
				{
					return;
				}
				this._hexViewCaseStyle = value;
				if (this._hexViewCaseStyle == HexEditor.CaseStyle.LowerCase)
				{
					this._editView.SetLowerCase();
				}
				else
				{
					this._editView.SetUpperCase();
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600025B RID: 603 RVA: 0x000117E0 File Offset: 0x000117E0
		// (set) Token: 0x0600025C RID: 604 RVA: 0x000117E8 File Offset: 0x000117E8
		[DefaultValue(false)]
		[Category("Hex")]
		[Description("Property for the visibility of the vertical scrollbar.")]
		public bool VScrollBarVisisble
		{
			get
			{
				return this._isVScrollVisible;
			}
			set
			{
				if (this._isVScrollVisible == value)
				{
					return;
				}
				this._isVScrollVisible = value;
				this.UpdateRectanglePositioning();
				base.Invalidate();
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600025D RID: 605 RVA: 0x0001180C File Offset: 0x0001180C
		// (remove) Token: 0x0600025E RID: 606 RVA: 0x00011848 File Offset: 0x00011848
		[Description("Event that is triggered whenever the hextable has been changed.")]
		public event EventHandler HexTableChanged;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600025F RID: 607 RVA: 0x00011884 File Offset: 0x00011884
		// (remove) Token: 0x06000260 RID: 608 RVA: 0x000118C0 File Offset: 0x000118C0
		[Description("Event that is triggered whenever the SelectionStart value is changed.")]
		public event EventHandler SelectionStartChanged;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000261 RID: 609 RVA: 0x000118FC File Offset: 0x000118FC
		// (remove) Token: 0x06000262 RID: 610 RVA: 0x00011938 File Offset: 0x00011938
		[Description("Event that is triggered whenever the SelectionLength value is changed.")]
		public event EventHandler SelectionLengthChanged;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000263 RID: 611 RVA: 0x00011974 File Offset: 0x00011974
		// (remove) Token: 0x06000264 RID: 612 RVA: 0x000119B0 File Offset: 0x000119B0
		[Description("Event that is triggered whenever the size of the char is changed.")]
		public event EventHandler CharSizeChanged;

		// Token: 0x06000265 RID: 613 RVA: 0x000119EC File Offset: 0x000119EC
		protected void OnVScrollBarScroll(object sender, ScrollEventArgs e)
		{
			switch (e.Type)
			{
			case ScrollEventType.SmallDecrement:
				this.ScrollLineUp(1);
				break;
			case ScrollEventType.SmallIncrement:
				this.ScrollLineDown(1);
				break;
			case ScrollEventType.LargeDecrement:
				this.ScrollLineUp(this._vScrollLarge);
				break;
			case ScrollEventType.LargeIncrement:
				this.ScrollLineDown(this._vScrollLarge);
				break;
			case ScrollEventType.ThumbTrack:
				this.ScrollThumbTrack(e.NewValue - e.OldValue);
				break;
			}
			base.Invalidate();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00011A7C File Offset: 0x00011A7C
		protected void CaretSelectionStartChanged(object sender, EventArgs e)
		{
			if (this.SelectionStartChanged != null)
			{
				this.SelectionStartChanged(this, e);
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00011A98 File Offset: 0x00011A98
		protected void CaretSelectionLengthChanged(object sender, EventArgs e)
		{
			if (this.SelectionLengthChanged != null)
			{
				this.SelectionLengthChanged(this, e);
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00011AB4 File Offset: 0x00011AB4
		protected override void OnMarginChanged(EventArgs e)
		{
			base.OnMarginChanged(e);
			this.UpdateRectanglePositioning();
			base.Invalidate();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00011ACC File Offset: 0x00011ACC
		protected override void OnGotFocus(EventArgs e)
		{
			if (this._handler != null)
			{
				this._handler.OnGotFocus(e);
			}
			this.UpdateRectanglePositioning();
			base.Invalidate();
			base.OnGotFocus(e);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00011AF8 File Offset: 0x00011AF8
		protected override void OnLostFocus(EventArgs e)
		{
			this._dragging = false;
			this.DestroyCaret();
			base.OnLostFocus(e);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00011B10 File Offset: 0x00011B10
		protected override bool IsInputKey(Keys keyData)
		{
			return keyData - Keys.Left <= 3 || keyData - (Keys.LButton | Keys.MButton | Keys.Space | Keys.Shift) <= 3 || base.IsInputKey(keyData);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00011B34 File Offset: 0x00011B34
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (this._handler != null)
			{
				this._handler.OnKeyPress(e);
			}
			base.OnKeyPress(e);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00011B54 File Offset: 0x00011B54
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Next)
			{
				if (!this._isVScrollHidden)
				{
					this.ScrollLineDown(this._vScrollLarge);
					base.Invalidate();
				}
			}
			else if (e.KeyCode == Keys.Prior)
			{
				if (!this._isVScrollHidden)
				{
					this.ScrollLineUp(this._vScrollLarge);
					base.Invalidate();
				}
			}
			else if (this._handler != null)
			{
				this._handler.OnKeyDown(e);
			}
			base.OnKeyDown(e);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00011BE4 File Offset: 0x00011BE4
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (this._handler != null)
			{
				this._handler.OnKeyUp(e);
			}
			base.OnKeyUp(e);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00011C04 File Offset: 0x00011C04
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.Focused)
			{
				if (this._handler != null)
				{
					this._handler.OnMouseDown(e);
				}
				if (e.Button == MouseButtons.Left)
				{
					this._dragging = true;
					base.Invalidate();
				}
			}
			else
			{
				base.Focus();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00011C68 File Offset: 0x00011C68
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (this.Focused && this._dragging)
			{
				if (this._handler != null)
				{
					this._handler.OnMouseDragged(e);
				}
				base.Invalidate();
			}
			base.OnMouseMove(e);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00011CA4 File Offset: 0x00011CA4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this._dragging = false;
			if (this.Focused && this._handler != null)
			{
				this._handler.OnMouseUp(e);
			}
			base.OnMouseUp(e);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00011CD8 File Offset: 0x00011CD8
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (this.Focused && this._handler != null)
			{
				this._handler.OnMouseDoubleClick(e);
			}
			base.OnMouseDoubleClick(e);
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00011D04 File Offset: 0x00011D04
		public int CaretPosX
		{
			get
			{
				object caretLock = this._caretLock;
				int x;
				lock (caretLock)
				{
					x = this._caret.Location.X;
				}
				return x;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00011D5C File Offset: 0x00011D5C
		public int CaretPosY
		{
			get
			{
				object caretLock = this._caretLock;
				int y;
				lock (caretLock)
				{
					y = this._caret.Location.Y;
				}
				return y;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00011DB4 File Offset: 0x00011DB4
		public int SelectionStart
		{
			get
			{
				object caretLock = this._caretLock;
				int selectionStart;
				lock (caretLock)
				{
					selectionStart = this._caret.SelectionStart;
				}
				return selectionStart;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000276 RID: 630 RVA: 0x00011E04 File Offset: 0x00011E04
		public int SelectionLength
		{
			get
			{
				object caretLock = this._caretLock;
				int selectionLength;
				lock (caretLock)
				{
					selectionLength = this._caret.SelectionLength;
				}
				return selectionLength;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00011E54 File Offset: 0x00011E54
		public int CaretIndex
		{
			get
			{
				object caretLock = this._caretLock;
				int currentIndex;
				lock (caretLock)
				{
					currentIndex = this._caret.CurrentIndex;
				}
				return currentIndex;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00011EA4 File Offset: 0x00011EA4
		public bool CaretFocused
		{
			get
			{
				object caretLock = this._caretLock;
				bool focused;
				lock (caretLock)
				{
					focused = this._caret.Focused;
				}
				return focused;
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00011EF4 File Offset: 0x00011EF4
		public void SetCaretStart(int index, Point location)
		{
			location = this.ScrollToCaret(index, location);
			object caretLock = this._caretLock;
			lock (caretLock)
			{
				this._caret.SetStartIndex(index);
				this._caret.SetCaretLocation(location);
			}
			base.Invalidate();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00011F5C File Offset: 0x00011F5C
		public void SetCaretEnd(int index, Point location)
		{
			location = this.ScrollToCaret(index, location);
			object caretLock = this._caretLock;
			lock (caretLock)
			{
				this._caret.SetEndIndex(index);
				this._caret.SetCaretLocation(location);
			}
			base.Invalidate();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00011FC4 File Offset: 0x00011FC4
		public bool IsSelected(int byteIndex)
		{
			object caretLock = this._caretLock;
			bool result;
			lock (caretLock)
			{
				result = this._caret.IsSelected(byteIndex);
			}
			return result;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00012014 File Offset: 0x00012014
		public void DestroyCaret()
		{
			object caretLock = this._caretLock;
			lock (caretLock)
			{
				this._caret.Destroy();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00012060 File Offset: 0x00012060
		public int HexTableLength
		{
			get
			{
				object hexTableLock = this._hexTableLock;
				int length;
				lock (hexTableLock)
				{
					length = this._hexTable.Length;
				}
				return length;
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000120B0 File Offset: 0x000120B0
		public void RemoveSelectedBytes()
		{
			int selectionStart = this.SelectionStart;
			int selectionLength = this.SelectionLength;
			if (selectionLength > 0)
			{
				object hexTableLock = this._hexTableLock;
				lock (hexTableLock)
				{
					this._hexTable.RemoveRange(selectionStart, selectionLength);
				}
				this.UpdateRectanglePositioning();
				base.Invalidate();
				if (this.HexTableChanged != null)
				{
					this.HexTableChanged(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0001213C File Offset: 0x0001213C
		public void RemoveByteAt(int index)
		{
			object hexTableLock = this._hexTableLock;
			lock (hexTableLock)
			{
				this._hexTable.RemoveAt(index);
			}
			this.UpdateRectanglePositioning();
			base.Invalidate();
			if (this.HexTableChanged != null)
			{
				this.HexTableChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000121B0 File Offset: 0x000121B0
		public void AppendByte(byte item)
		{
			object hexTableLock = this._hexTableLock;
			lock (hexTableLock)
			{
				this._hexTable.Add(item);
			}
			this.UpdateRectanglePositioning();
			base.Invalidate();
			if (this.HexTableChanged != null)
			{
				this.HexTableChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00012224 File Offset: 0x00012224
		public void InsertByte(int index, byte item)
		{
			object hexTableLock = this._hexTableLock;
			lock (hexTableLock)
			{
				this._hexTable.Insert(index, item);
			}
			this.UpdateRectanglePositioning();
			base.Invalidate();
			if (this.HexTableChanged != null)
			{
				this.HexTableChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0001229C File Offset: 0x0001229C
		public char GetByteAsChar(int index)
		{
			object hexTableLock = this._hexTableLock;
			char charAt;
			lock (hexTableLock)
			{
				charAt = this._hexTable.GetCharAt(index);
			}
			return charAt;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000122EC File Offset: 0x000122EC
		public byte GetByte(int index)
		{
			object hexTableLock = this._hexTableLock;
			byte at;
			lock (hexTableLock)
			{
				at = this._hexTable.GetAt(index);
			}
			return at;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0001233C File Offset: 0x0001233C
		public void SetByte(int index, byte item)
		{
			object hexTableLock = this._hexTableLock;
			lock (hexTableLock)
			{
				this._hexTable.SetAt(index, item);
			}
			base.Invalidate();
			if (this.HexTableChanged != null)
			{
				this.HexTableChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000123AC File Offset: 0x000123AC
		public void ScrollLineUp(int lines)
		{
			if (this._firstByte > 0)
			{
				lines = ((lines > this._vScrollPos) ? this._vScrollPos : lines);
				this._vScrollPos -= this._vScrollSmall * lines;
				this.UpdateVisibleByteIndex();
				this.UpdateScrollValues();
				if (this.CaretFocused)
				{
					Point caretLocation = new Point(this.CaretPosX, this.CaretPosY);
					caretLocation.Y += this._recLineCount.Height * lines;
					object caretLock = this._caretLock;
					lock (caretLock)
					{
						this._caret.SetCaretLocation(caretLocation);
					}
				}
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00012478 File Offset: 0x00012478
		public void ScrollLineDown(int lines)
		{
			if (this._vScrollPos <= this._vScrollMax - this._vScrollLarge)
			{
				lines = ((lines + this._vScrollPos > this._vScrollMax - this._vScrollLarge) ? (this._vScrollMax - this._vScrollLarge - this._vScrollPos + 1) : lines);
				this._vScrollPos += this._vScrollSmall * lines;
				this.UpdateVisibleByteIndex();
				this.UpdateScrollValues();
				if (this.CaretFocused)
				{
					Point caretLocation = new Point(this.CaretPosX, this.CaretPosY);
					caretLocation.Y -= this._recLineCount.Height * lines;
					object caretLock = this._caretLock;
					lock (caretLock)
					{
						this._caret.SetCaretLocation(caretLocation);
						if (caretLocation.Y < this._recContent.Y)
						{
							this._caret.Hide(base.Handle);
						}
					}
				}
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00012598 File Offset: 0x00012598
		public void ScrollThumbTrack(int lines)
		{
			if (lines == 0)
			{
				return;
			}
			if (lines < 0)
			{
				this.ScrollLineUp(-1 * lines);
				return;
			}
			this.ScrollLineDown(lines);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000125BC File Offset: 0x000125BC
		public Point ScrollToCaret(int caretIndex, Point position)
		{
			if (position.Y < 0)
			{
				this._vScrollPos -= Math.Abs((position.Y - this._recContent.Y) / this._recLineCount.Height) * this._vScrollSmall;
				this.UpdateVisibleByteIndex();
				this.UpdateScrollValues();
				if (this.CaretFocused)
				{
					position.Y = this._recContent.Y;
				}
			}
			else if (position.Y > this._maxVisibleBytesV * this._recLineCount.Height)
			{
				this._vScrollPos += (position.Y / this._recLineCount.Height - (this._maxVisibleBytesV - 1)) * this._vScrollSmall;
				if (this._vScrollPos > this._vScrollMax - (this._vScrollLarge - 1))
				{
					this._vScrollPos = this._vScrollMax - (this._vScrollLarge - 1);
				}
				this.UpdateVisibleByteIndex();
				this.UpdateScrollValues();
				if (this.CaretFocused)
				{
					position.Y = (this._maxVisibleBytesV - 1) * this._recLineCount.Height + this._recContent.Y;
				}
			}
			return position;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000126FC File Offset: 0x000126FC
		private void UpdateRectanglePositioning()
		{
			if (base.ClientRectangle.Width == 0)
			{
				return;
			}
			SizeF sizeF;
			using (Graphics graphics = base.CreateGraphics())
			{
				sizeF = graphics.MeasureString("D", this.Font, 100, this._stringFormat);
			}
			this.CharSize = new SizeF((float)Math.Ceiling((double)sizeF.Width), (float)Math.Ceiling((double)sizeF.Height));
			this._recContent = base.ClientRectangle;
			this._recContent.X = this._recContent.X + base.Margin.Left;
			this._recContent.Y = this._recContent.Y + base.Margin.Top;
			this._recContent.Width = this._recContent.Width - base.Margin.Right;
			this._recContent.Height = this._recContent.Height - base.Margin.Bottom;
			if (this.BorderStyle == BorderStyle.Fixed3D)
			{
				this._recContent.X = this._recContent.X + 2;
				this._recContent.Y = this._recContent.Y + 2;
				this._recContent.Width = this._recContent.Width - 1;
				this._recContent.Height = this._recContent.Height - 1;
			}
			else if (this.BorderStyle == BorderStyle.FixedSingle)
			{
				this._recContent.X = this._recContent.X + 1;
				this._recContent.Y = this._recContent.Y + 1;
				this._recContent.Width = this._recContent.Width - 1;
				this._recContent.Height = this._recContent.Height - 1;
			}
			if (!this.VScrollBarHidden)
			{
				this._recContent.Width = this._recContent.Width - this._vScrollBarWidth;
				this._vScrollBar.Left = this._recContent.X + this._recContent.Width - base.Margin.Left;
				this._vScrollBar.Top = this._recContent.Y - base.Margin.Top;
				this._vScrollBar.Width = this._vScrollBarWidth;
				this._vScrollBar.Height = this._recContent.Height;
			}
			this._recLineCount = new Rectangle(this._recContent.X, this._recContent.Y, (int)(this._charSize.Width * 4f), (int)this._charSize.Height - 2);
			this._editView.Update(this._recLineCount.X + this._recLineCount.Width + this._entityMargin / 2, this._recContent);
			this._maxBytesH = this._bytesPerLine;
			this._maxBytesV = (int)Math.Ceiling((double)((float)this._recContent.Height / (float)this._recLineCount.Height));
			this._maxBytes = this._maxBytesH * this._maxBytesV;
			this._maxVisibleBytesV = (int)Math.Floor((double)((float)this._recContent.Height / (float)this._recLineCount.Height));
			this.UpdateScrollBarSize();
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00012A4C File Offset: 0x00012A4C
		private void UpdateVisibleByteIndex()
		{
			if (this._hexTable.Length == 0)
			{
				this._firstByte = 0;
				this._lastByte = 0;
				return;
			}
			this._firstByte = this._vScrollPos * this._maxBytesH;
			this._lastByte = Math.Min(this.HexTableLength, this._firstByte + this._maxBytes);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00012AB0 File Offset: 0x00012AB0
		private void UpdateScrollValues()
		{
			if (!this._isVScrollHidden)
			{
				this._vScrollBar.Minimum = this._vScrollMin;
				this._vScrollBar.Maximum = this._vScrollMax;
				this._vScrollBar.Value = this._vScrollPos;
				this._vScrollBar.SmallChange = this._vScrollSmall;
				this._vScrollBar.LargeChange = this._vScrollLarge;
				this._vScrollBar.Visible = true;
				return;
			}
			this._vScrollBar.Visible = false;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00012B3C File Offset: 0x00012B3C
		private void UpdateScrollBarSize()
		{
			if (!this.VScrollBarVisisble || this._maxVisibleBytesV <= 0 || this._maxBytesH <= 0)
			{
				this.VScrollBarHidden = true;
				return;
			}
			int maxVisibleBytesV = this._maxVisibleBytesV;
			int num = 1;
			int vScrollMin = 0;
			int num2 = this.HexTableLength / this._maxBytesH;
			int num3 = this._firstByte / this._maxBytesH;
			if (maxVisibleBytesV != this._vScrollLarge || num != this._vScrollSmall)
			{
				this._vScrollLarge = maxVisibleBytesV;
				this._vScrollSmall = num;
			}
			if (num2 >= maxVisibleBytesV)
			{
				if (num2 != this._vScrollMax || num3 != this._vScrollPos)
				{
					this._vScrollMin = vScrollMin;
					this._vScrollMax = num2;
					this._vScrollPos = num3;
				}
				this.VScrollBarHidden = false;
				this.UpdateScrollValues();
				return;
			}
			this.VScrollBarHidden = true;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00012C14 File Offset: 0x00012C14
		public HexEditor()
			: this(new ByteCollection())
		{
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00012C24 File Offset: 0x00012C24
		public HexEditor(ByteCollection collection)
		{
			this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
			this._stringFormat.Alignment = StringAlignment.Center;
			this._stringFormat.LineAlignment = StringAlignment.Center;
			this._hexTable = collection;
			this._vScrollBar = new VScrollBar();
			this._vScrollBar.Scroll += this.OnVScrollBarScroll;
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, true);
			this._caret = new Caret(this);
			this._caret.SelectionStartChanged += this.CaretSelectionStartChanged;
			this._caret.SelectionLengthChanged += this.CaretSelectionLengthChanged;
			this._editView = new EditView(this);
			this._handler = this._editView;
			this.Cursor = Cursors.IBeam;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00012D88 File Offset: 0x00012D88
		private RectangleF GetLineCountBound(int index)
		{
			return new RectangleF((float)this._recLineCount.X, (float)(this._recLineCount.Y + this._recLineCount.Height * index), (float)this._recLineCount.Width, (float)this._recLineCount.Height);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00012DDC File Offset: 0x00012DDC
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (this.BorderStyle == BorderStyle.Fixed3D)
			{
				SolidBrush brush = new SolidBrush(this.BackColor);
				Rectangle clientRectangle = base.ClientRectangle;
				pevent.Graphics.FillRectangle(brush, clientRectangle);
				ControlPaint.DrawBorder3D(pevent.Graphics, base.ClientRectangle, Border3DStyle.Sunken);
				return;
			}
			if (this.BorderStyle == BorderStyle.FixedSingle)
			{
				SolidBrush brush2 = new SolidBrush(this.BackColor);
				Rectangle clientRectangle2 = base.ClientRectangle;
				pevent.Graphics.FillRectangle(brush2, clientRectangle2);
				ControlPaint.DrawBorder(pevent.Graphics, base.ClientRectangle, this.BorderColor, ButtonBorderStyle.Solid);
				return;
			}
			base.OnPaintBackground(pevent);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00012E7C File Offset: 0x00012E7C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Region region = new Region(base.ClientRectangle);
			region.Exclude(this._recContent);
			e.Graphics.ExcludeClip(region);
			this.UpdateVisibleByteIndex();
			this.PaintLineCount(e.Graphics, this._firstByte, this._lastByte);
			this._editView.Paint(e.Graphics, this._firstByte, this._lastByte);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00012EF4 File Offset: 0x00012EF4
		private void PaintLineCount(Graphics g, int startIndex, int lastIndex)
		{
			SolidBrush brush = new SolidBrush(this.ForeColor);
			int num = 0;
			while (num * this._maxBytesH + startIndex <= lastIndex)
			{
				RectangleF lineCountBound = this.GetLineCountBound(num);
				string text = (startIndex + num * this._maxBytesH).ToString(this._lineCountCaps);
				int num2 = this._nrCharsLineCount - text.Length;
				string s;
				if (num2 > -1)
				{
					s = new string('0', num2) + text;
				}
				else
				{
					s = new string('~', this._nrCharsLineCount);
				}
				g.DrawString(s, this.Font, brush, lineCountBound, this._stringFormat);
				num++;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00012FA4 File Offset: 0x00012FA4
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.UpdateRectanglePositioning();
			base.Invalidate();
		}

		// Token: 0x0400013E RID: 318
		private object _caretLock = new object();

		// Token: 0x0400013F RID: 319
		private object _hexTableLock = new object();

		// Token: 0x04000140 RID: 320
		private IKeyMouseEventHandler _handler;

		// Token: 0x04000141 RID: 321
		private EditView _editView;

		// Token: 0x04000142 RID: 322
		private ByteCollection _hexTable;

		// Token: 0x04000143 RID: 323
		private string _lineCountCaps = "X";

		// Token: 0x04000144 RID: 324
		private int _nrCharsLineCount = 4;

		// Token: 0x04000145 RID: 325
		private Caret _caret;

		// Token: 0x04000146 RID: 326
		private Rectangle _recContent;

		// Token: 0x04000147 RID: 327
		private Rectangle _recLineCount;

		// Token: 0x04000148 RID: 328
		private StringFormat _stringFormat;

		// Token: 0x04000149 RID: 329
		private int _firstByte;

		// Token: 0x0400014A RID: 330
		private int _lastByte;

		// Token: 0x0400014B RID: 331
		private int _maxBytesH;

		// Token: 0x0400014C RID: 332
		private int _maxBytesV;

		// Token: 0x0400014D RID: 333
		private int _maxBytes;

		// Token: 0x0400014E RID: 334
		private int _maxVisibleBytesV;

		// Token: 0x0400014F RID: 335
		private VScrollBar _vScrollBar;

		// Token: 0x04000150 RID: 336
		private int _vScrollBarWidth = 20;

		// Token: 0x04000151 RID: 337
		private int _vScrollPos;

		// Token: 0x04000152 RID: 338
		private int _vScrollMax;

		// Token: 0x04000153 RID: 339
		private int _vScrollMin;

		// Token: 0x04000154 RID: 340
		private int _vScrollSmall;

		// Token: 0x04000155 RID: 341
		private int _vScrollLarge;

		// Token: 0x04000156 RID: 342
		private SizeF _charSize;

		// Token: 0x04000157 RID: 343
		private bool _isVScrollHidden = true;

		// Token: 0x04000158 RID: 344
		private int _bytesPerLine = 8;

		// Token: 0x04000159 RID: 345
		private int _entityMargin = 10;

		// Token: 0x0400015A RID: 346
		private BorderStyle _borderStyle = BorderStyle.Fixed3D;

		// Token: 0x0400015B RID: 347
		private Color _borderColor = Color.Empty;

		// Token: 0x0400015C RID: 348
		private Color _selectionBackColor = Color.Blue;

		// Token: 0x0400015D RID: 349
		private Color _selectionForeColor = Color.White;

		// Token: 0x0400015E RID: 350
		private HexEditor.CaseStyle _lineCountCaseStyle = HexEditor.CaseStyle.UpperCase;

		// Token: 0x0400015F RID: 351
		private HexEditor.CaseStyle _hexViewCaseStyle = HexEditor.CaseStyle.UpperCase;

		// Token: 0x04000160 RID: 352
		private bool _isVScrollVisible;

		// Token: 0x04000165 RID: 357
		private bool _dragging;

		// Token: 0x02000D61 RID: 3425
		public enum CaseStyle
		{
			// Token: 0x04003F60 RID: 16224
			LowerCase,
			// Token: 0x04003F61 RID: 16225
			UpperCase
		}
	}
}
