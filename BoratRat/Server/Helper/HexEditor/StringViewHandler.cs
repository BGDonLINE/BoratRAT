using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000037 RID: 55
	public class StringViewHandler
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00013D98 File Offset: 0x00013D98
		public int MaxWidth
		{
			get
			{
				return this._recStringView.X + this._recStringView.Width;
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00013DB4 File Offset: 0x00013DB4
		public StringViewHandler(HexEditor editor)
		{
			this._editor = editor;
			this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
			this._stringFormat.Alignment = StringAlignment.Center;
			this._stringFormat.LineAlignment = StringAlignment.Center;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00013DEC File Offset: 0x00013DEC
		public void OnKeyPress(KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar))
			{
				this.HandleUserInput(e.KeyChar);
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00013E0C File Offset: 0x00013E0C
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
					return;
				}
				if (this._editor.CaretIndex < this._editor.LastVisibleByte && e.KeyCode == Keys.Delete)
				{
					this._editor.RemoveByteAt(this._editor.CaretIndex);
					Point caretLocation2 = this.GetCaretLocation(this._editor.CaretIndex);
					this._editor.SetCaretStart(this._editor.CaretIndex, caretLocation2);
					return;
				}
				if (this._editor.CaretIndex > 0 && e.KeyCode == Keys.Back)
				{
					int index = this._editor.CaretIndex - 1;
					this._editor.RemoveByteAt(index);
					Point caretLocation3 = this.GetCaretLocation(index);
					this._editor.SetCaretStart(index, caretLocation3);
					return;
				}
			}
			else if (e.KeyCode == Keys.Up && this._editor.CaretIndex - this._editor.BytesPerLine >= 0)
			{
				int num = this._editor.CaretIndex - this._editor.BytesPerLine;
				if (num % this._editor.BytesPerLine != 0 || this._editor.CaretPosX < this._recStringView.X + this._recStringView.Width)
				{
					this.HandleArrowKeys(num, e.Shift);
					return;
				}
				Point location = new Point(this._editor.CaretPosX, this._editor.CaretPosY - this._recStringView.Height);
				if (num == 0)
				{
					location = new Point(this._editor.CaretPosX, this._editor.CaretPosY);
					num = this._editor.BytesPerLine;
				}
				if (e.Shift)
				{
					this._editor.SetCaretEnd(num, location);
					return;
				}
				this._editor.SetCaretStart(num, location);
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
				Point location2 = new Point(this._editor.CaretPosX, this._editor.CaretPosY + this._recStringView.Height);
				if (e.Shift)
				{
					this._editor.SetCaretEnd(num2, location2);
					return;
				}
				this._editor.SetCaretStart(num2, location2);
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
				if (e.KeyCode == Keys.Right && this._editor.CaretIndex + 1 <= this._editor.LastVisibleByte)
				{
					int index3 = this._editor.CaretIndex + 1;
					this.HandleArrowKeys(index3, e.Shift);
				}
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0001419C File Offset: 0x0001419C
		public void HandleArrowKeys(int index, bool isShiftDown)
		{
			Point caretLocation = this.GetCaretLocation(index);
			if (isShiftDown)
			{
				this._editor.SetCaretEnd(index, caretLocation);
				return;
			}
			this._editor.SetCaretStart(index, caretLocation);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000141D8 File Offset: 0x000141D8
		public void OnMouseDown(int x, int y)
		{
			int num = (x - this._recStringView.X) / (int)this._editor.CharSize.Width;
			int num2 = (y - this._recStringView.Y) / this._recStringView.Height;
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
			int x2 = num * (int)this._editor.CharSize.Width + this._recStringView.X;
			int y2 = num2 * this._recStringView.Height + this._recStringView.Y;
			this._editor.SetCaretStart(index, new Point(x2, y2));
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000143A4 File Offset: 0x000143A4
		public void OnMouseDragged(int x, int y)
		{
			int num = (x - this._recStringView.X) / (int)this._editor.CharSize.Width;
			int num2 = (y - this._recStringView.Y) / this._recStringView.Height;
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
			int x2 = num * (int)this._editor.CharSize.Width + this._recStringView.X;
			int y2 = num2 * this._recStringView.Height + this._recStringView.Y;
			this._editor.SetCaretEnd(index, new Point(x2, y2));
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00014598 File Offset: 0x00014598
		public void OnMouseDoubleClick()
		{
			if (this._editor.CaretIndex < this._editor.LastVisibleByte)
			{
				int index = this._editor.CaretIndex + 1;
				Point caretLocation = this.GetCaretLocation(index);
				this._editor.SetCaretEnd(index, caretLocation);
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000145E8 File Offset: 0x000145E8
		public void Focus()
		{
			int caretIndex = this._editor.CaretIndex;
			Point caretLocation = this.GetCaretLocation(caretIndex);
			this._editor.SetCaretStart(caretIndex, caretLocation);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0001461C File Offset: 0x0001461C
		public void Update(int startPositionX, Rectangle area)
		{
			this._recStringView = new Rectangle(startPositionX, area.Y, (int)(this._editor.CharSize.Width * (float)this._editor.BytesPerLine), (int)this._editor.CharSize.Height - 2);
			this._recStringView.X = this._recStringView.X + this._editor.EntityMargin;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00014694 File Offset: 0x00014694
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

		// Token: 0x060002BC RID: 700 RVA: 0x000146D8 File Offset: 0x000146D8
		private void PaintByteAsSelected(Graphics g, Point point, int index)
		{
			SolidBrush brush = new SolidBrush(this._editor.SelectionBackColor);
			SolidBrush brush2 = new SolidBrush(this._editor.SelectionForeColor);
			RectangleF bound = this.GetBound(point);
			char byteAsChar = this._editor.GetByteAsChar(index);
			string s = (char.IsControl(byteAsChar) ? "." : byteAsChar.ToString());
			g.FillRectangle(brush, bound);
			g.DrawString(s, this._editor.Font, brush2, bound, this._stringFormat);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00014764 File Offset: 0x00014764
		private void PaintByte(Graphics g, Point point, int index)
		{
			SolidBrush brush = new SolidBrush(this._editor.ForeColor);
			RectangleF bound = this.GetBound(point);
			char byteAsChar = this._editor.GetByteAsChar(index);
			string s = (char.IsControl(byteAsChar) ? "." : byteAsChar.ToString());
			g.DrawString(s, this._editor.Font, brush, bound, this._stringFormat);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000147D4 File Offset: 0x000147D4
		private Point GetCaretLocation(int index)
		{
			int x = this._recStringView.X + (int)this._editor.CharSize.Width * (index % this._editor.BytesPerLine);
			int y = this._recStringView.Y + this._recStringView.Height * ((index - (this._editor.FirstVisibleByte + index % this._editor.BytesPerLine)) / this._editor.BytesPerLine);
			return new Point(x, y);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0001485C File Offset: 0x0001485C
		private void HandleUserRemove()
		{
			int selectionStart = this._editor.SelectionStart;
			Point caretLocation = this.GetCaretLocation(selectionStart);
			this._editor.RemoveSelectedBytes();
			this._editor.SetCaretStart(selectionStart, caretLocation);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0001489C File Offset: 0x0001489C
		private void HandleUserInput(char key)
		{
			if (!this._editor.CaretFocused)
			{
				return;
			}
			this.HandleUserRemove();
			byte item = Convert.ToByte(key);
			if (this._editor.HexTableLength <= 0)
			{
				this._editor.AppendByte(item);
			}
			else
			{
				this._editor.InsertByte(this._editor.CaretIndex, item);
			}
			int index = this._editor.CaretIndex + 1;
			Point caretLocation = this.GetCaretLocation(index);
			this._editor.SetCaretStart(index, caretLocation);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00014928 File Offset: 0x00014928
		private Point GetByteColumnAndRow(int index)
		{
			int x = index % this._editor.BytesPerLine;
			int y = index / this._editor.BytesPerLine;
			return new Point(x, y);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0001495C File Offset: 0x0001495C
		private RectangleF GetBound(Point point)
		{
			return new RectangleF((float)(this._recStringView.X + point.X * (int)this._editor.CharSize.Width), (float)(this._recStringView.Y + point.Y * this._recStringView.Height), this._editor.CharSize.Width, (float)this._recStringView.Height);
		}

		// Token: 0x0400016B RID: 363
		private Rectangle _recStringView;

		// Token: 0x0400016C RID: 364
		private StringFormat _stringFormat;

		// Token: 0x0400016D RID: 365
		private HexEditor _editor;
	}
}
