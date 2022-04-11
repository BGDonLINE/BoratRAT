using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000035 RID: 53
	public class HexViewHandler
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00012FBC File Offset: 0x00012FBC
		public int MaxWidth
		{
			get
			{
				return this._recHexValue.X + this._recHexValue.Width * this._editor.BytesPerLine;
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00012FF0 File Offset: 0x00012FF0
		public HexViewHandler(HexEditor editor)
		{
			this._editor = editor;
			this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
			this._stringFormat.Alignment = StringAlignment.Center;
			this._stringFormat.LineAlignment = StringAlignment.Center;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00013044 File Offset: 0x00013044
		public void OnKeyPress(KeyPressEventArgs e)
		{
			if (this.IsHex(e.KeyChar))
			{
				this.HandleUserInput(e.KeyChar);
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00013064 File Offset: 0x00013064
		public void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				if (this._editor.SelectionLength > 0)
				{
					this.HandleUserRemove();
					int caretIndex = this._editor.CaretIndex;
					Point caretLocation = this.GetCaretLocation(caretIndex);
					this._editor.SetCaretStart(caretIndex, caretLocation);
				}
				else if (this._editor.CaretIndex < this._editor.LastVisibleByte && e.KeyCode == Keys.Delete)
				{
					this._editor.RemoveByteAt(this._editor.CaretIndex);
					Point caretLocation2 = this.GetCaretLocation(this._editor.CaretIndex);
					this._editor.SetCaretStart(this._editor.CaretIndex, caretLocation2);
				}
				else if (this._editor.CaretIndex > 0 && e.KeyCode == Keys.Back)
				{
					int index = this._editor.CaretIndex - 1;
					if (this._isEditing)
					{
						index = this._editor.CaretIndex;
					}
					this._editor.RemoveByteAt(index);
					Point caretLocation3 = this.GetCaretLocation(index);
					this._editor.SetCaretStart(index, caretLocation3);
				}
				this._isEditing = false;
				return;
			}
			if (e.KeyCode == Keys.Up && this._editor.CaretIndex - this._editor.BytesPerLine >= 0)
			{
				int num = this._editor.CaretIndex - this._editor.BytesPerLine;
				if (num % this._editor.BytesPerLine == 0 && this._editor.CaretPosX >= this._recHexValue.X + this._recHexValue.Width * this._editor.BytesPerLine)
				{
					Point location = new Point(this._editor.CaretPosX, this._editor.CaretPosY - this._recHexValue.Height);
					if (num == 0)
					{
						location = new Point(this._editor.CaretPosX, this._editor.CaretPosY);
						num = this._editor.BytesPerLine;
					}
					if (e.Shift)
					{
						this._editor.SetCaretEnd(num, location);
					}
					else
					{
						this._editor.SetCaretStart(num, location);
					}
					this._isEditing = false;
					return;
				}
				this.HandleArrowKeys(num, e.Shift);
				return;
			}
			else if (e.KeyCode == Keys.Down && (this._editor.CaretIndex - 1) / this._editor.BytesPerLine < this._editor.HexTableLength / this._editor.BytesPerLine)
			{
				int num2 = this._editor.CaretIndex + this._editor.BytesPerLine;
				if (num2 > this._editor.HexTableLength)
				{
					num2 = this._editor.HexTableLength;
					this.HandleArrowKeys(num2, e.Shift);
					return;
				}
				Point location2 = new Point(this._editor.CaretPosX, this._editor.CaretPosY + this._recHexValue.Height);
				if (e.Shift)
				{
					this._editor.SetCaretEnd(num2, location2);
				}
				else
				{
					this._editor.SetCaretStart(num2, location2);
				}
				this._isEditing = false;
				return;
			}
			else
			{
				if (e.KeyCode == Keys.Left && this._editor.CaretIndex - 1 >= 0)
				{
					int index2 = this._editor.CaretIndex - 1;
					this.HandleArrowKeys(index2, e.Shift);
					return;
				}
				if (e.KeyCode == Keys.Right && this._editor.CaretIndex + 1 <= this._editor.HexTableLength)
				{
					int index3 = this._editor.CaretIndex + 1;
					this.HandleArrowKeys(index3, e.Shift);
				}
				return;
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0001343C File Offset: 0x0001343C
		public void HandleArrowKeys(int index, bool isShiftDown)
		{
			Point caretLocation = this.GetCaretLocation(index);
			if (isShiftDown)
			{
				this._editor.SetCaretEnd(index, caretLocation);
			}
			else
			{
				this._editor.SetCaretStart(index, caretLocation);
			}
			this._isEditing = false;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00013484 File Offset: 0x00013484
		public void OnMouseDown(int x, int y)
		{
			int num = (x - this._recHexValue.X) / this._recHexValue.Width;
			int num2 = (y - this._recHexValue.Y) / this._recHexValue.Height;
			num = ((num > this._editor.BytesPerLine) ? this._editor.BytesPerLine : num);
			num = ((num < 0) ? 0 : num);
			num2 = ((num2 > this._editor.MaxBytesV) ? this._editor.MaxBytesV : num2);
			num2 = ((num2 < 0) ? 0 : num2);
			if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine <= num2)
			{
				if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine <= num)
				{
					num = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine;
				}
				num2 = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine;
			}
			int index = Math.Min(this._editor.LastVisibleByte, this._editor.FirstVisibleByte + num + num2 * this._editor.BytesPerLine);
			int x2 = num * this._recHexValue.Width + this._recHexValue.X;
			int y2 = num2 * this._recHexValue.Height + this._recHexValue.Y;
			this._editor.SetCaretStart(index, new Point(x2, y2));
			this._isEditing = false;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00013644 File Offset: 0x00013644
		public void OnMouseDragged(int x, int y)
		{
			int num = (x - this._recHexValue.X) / this._recHexValue.Width;
			int num2 = (y - this._recHexValue.Y) / this._recHexValue.Height;
			num = ((num > this._editor.BytesPerLine) ? this._editor.BytesPerLine : num);
			num = ((num < 0) ? 0 : num);
			num2 = ((num2 > this._editor.MaxBytesV) ? this._editor.MaxBytesV : num2);
			if (this._editor.FirstVisibleByte > 0)
			{
				num2 = ((num2 < 0) ? (-1) : num2);
			}
			else
			{
				num2 = ((num2 < 0) ? 0 : num2);
			}
			if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine <= num2)
			{
				if ((this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine <= num)
				{
					num = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) % this._editor.BytesPerLine;
				}
				num2 = (this._editor.LastVisibleByte - this._editor.FirstVisibleByte) / this._editor.BytesPerLine;
			}
			int index = Math.Min(this._editor.LastVisibleByte, this._editor.FirstVisibleByte + num + num2 * this._editor.BytesPerLine);
			int x2 = num * this._recHexValue.Width + this._recHexValue.X;
			int y2 = num2 * this._recHexValue.Height + this._recHexValue.Y;
			this._editor.SetCaretEnd(index, new Point(x2, y2));
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00013824 File Offset: 0x00013824
		public void OnMouseDoubleClick()
		{
			if (this._editor.CaretIndex < this._editor.LastVisibleByte)
			{
				int index = this._editor.CaretIndex + 1;
				Point caretLocation = this.GetCaretLocation(index);
				this._editor.SetCaretEnd(index, caretLocation);
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00013874 File Offset: 0x00013874
		public void Update(int startPositionX, Rectangle area)
		{
			this._recHexValue = new Rectangle(startPositionX, area.Y, (int)(this._editor.CharSize.Width * 3f), (int)this._editor.CharSize.Height - 2);
			this._recHexValue.X = this._recHexValue.X + this._editor.EntityMargin;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000138E8 File Offset: 0x000138E8
		public void Paint(Graphics g, int index, int startIndex)
		{
			Point byteColumnAndRow = this.GetByteColumnAndRow(index);
			if (this._editor.IsSelected(index + startIndex))
			{
				this.PaintByteAsSelected(g, byteColumnAndRow, index + startIndex);
				return;
			}
			this.PaintByte(g, byteColumnAndRow, index + startIndex);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0001392C File Offset: 0x0001392C
		private void PaintByteAsSelected(Graphics g, Point point, int index)
		{
			SolidBrush brush = new SolidBrush(this._editor.SelectionBackColor);
			SolidBrush brush2 = new SolidBrush(this._editor.SelectionForeColor);
			RectangleF bound = this.GetBound(point);
			string s = this._editor.GetByte(index).ToString(this._hexType);
			g.FillRectangle(brush, bound);
			g.DrawString(s, this._editor.Font, brush2, bound, this._stringFormat);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000139A8 File Offset: 0x000139A8
		private void PaintByte(Graphics g, Point point, int index)
		{
			SolidBrush brush = new SolidBrush(this._editor.ForeColor);
			RectangleF bound = this.GetBound(point);
			string s = this._editor.GetByte(index).ToString(this._hexType);
			g.DrawString(s, this._editor.Font, brush, bound, this._stringFormat);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00013A08 File Offset: 0x00013A08
		public void SetLowerCase()
		{
			this._hexType = "x2";
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00013A18 File Offset: 0x00013A18
		public void SetUpperCase()
		{
			this._hexType = "X2";
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00013A28 File Offset: 0x00013A28
		public void Focus()
		{
			int caretIndex = this._editor.CaretIndex;
			Point caretLocation = this.GetCaretLocation(caretIndex);
			this._editor.SetCaretStart(caretIndex, caretLocation);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00013A5C File Offset: 0x00013A5C
		private Point GetCaretLocation(int index)
		{
			int x = this._recHexValue.X + this._recHexValue.Width * (index % this._editor.BytesPerLine);
			int y = this._recHexValue.Y + this._recHexValue.Height * ((index - (this._editor.FirstVisibleByte + index % this._editor.BytesPerLine)) / this._editor.BytesPerLine);
			return new Point(x, y);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00013ADC File Offset: 0x00013ADC
		private void HandleUserRemove()
		{
			int selectionStart = this._editor.SelectionStart;
			Point caretLocation = this.GetCaretLocation(selectionStart);
			this._editor.RemoveSelectedBytes();
			this._editor.SetCaretStart(selectionStart, caretLocation);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00013B1C File Offset: 0x00013B1C
		private void HandleUserInput(char key)
		{
			if (!this._editor.CaretFocused)
			{
				return;
			}
			this.HandleUserRemove();
			if (this._isEditing)
			{
				this._isEditing = false;
				byte b = this._editor.GetByte(this._editor.CaretIndex);
				b += Convert.ToByte(key.ToString(), 16);
				this._editor.SetByte(this._editor.CaretIndex, b);
				int index = this._editor.CaretIndex + 1;
				Point caretLocation = this.GetCaretLocation(index);
				this._editor.SetCaretStart(index, caretLocation);
				return;
			}
			this._isEditing = true;
			byte item = Convert.ToByte(key.ToString() + "0", 16);
			if (this._editor.HexTable.Length == 0)
			{
				this._editor.AppendByte(item);
			}
			else
			{
				this._editor.InsertByte(this._editor.CaretIndex, item);
			}
			int x = this._recHexValue.X + this._recHexValue.Width * (this._editor.CaretIndex % this._editor.BytesPerLine) + this._recHexValue.Width / 2;
			int y = this._recHexValue.Y + this._recHexValue.Height * ((this._editor.CaretIndex - (this._editor.FirstVisibleByte + this._editor.CaretIndex % this._editor.BytesPerLine)) / this._editor.BytesPerLine);
			this._editor.SetCaretStart(this._editor.CaretIndex, new Point(x, y));
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00013CC8 File Offset: 0x00013CC8
		private Point GetByteColumnAndRow(int index)
		{
			int x = index % this._editor.BytesPerLine;
			int y = index / this._editor.BytesPerLine;
			return new Point(x, y);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00013CFC File Offset: 0x00013CFC
		private RectangleF GetBound(Point point)
		{
			return new RectangleF((float)(this._recHexValue.X + point.X * this._recHexValue.Width), (float)(this._recHexValue.Y + point.Y * this._recHexValue.Height), (float)this._recHexValue.Width, (float)this._recHexValue.Height);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00013D6C File Offset: 0x00013D6C
		private bool IsHex(char c)
		{
			return (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || char.IsDigit(c);
		}

		// Token: 0x04000166 RID: 358
		private bool _isEditing;

		// Token: 0x04000167 RID: 359
		private string _hexType = "X2";

		// Token: 0x04000168 RID: 360
		private Rectangle _recHexValue;

		// Token: 0x04000169 RID: 361
		private StringFormat _stringFormat;

		// Token: 0x0400016A RID: 362
		private HexEditor _editor;
	}
}
