using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000033 RID: 51
	public class EditView : IKeyMouseEventHandler
	{
		// Token: 0x06000231 RID: 561 RVA: 0x000111F0 File Offset: 0x000111F0
		public EditView(HexEditor editor)
		{
			this._editor = editor;
			this._hexView = new HexViewHandler(editor);
			this._stringView = new StringViewHandler(editor);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00011218 File Offset: 0x00011218
		public void OnKeyPress(KeyPressEventArgs e)
		{
			if (this.InHexView(this._editor.CaretPosX))
			{
				this._hexView.OnKeyPress(e);
				return;
			}
			this._stringView.OnKeyPress(e);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0001124C File Offset: 0x0001124C
		public void OnKeyDown(KeyEventArgs e)
		{
			if (this.InHexView(this._editor.CaretPosX))
			{
				this._hexView.OnKeyDown(e);
				return;
			}
			this._stringView.OnKeyDown(e);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00011280 File Offset: 0x00011280
		public void OnKeyUp(KeyEventArgs e)
		{
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00011284 File Offset: 0x00011284
		public void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.InHexView(e.X))
				{
					this._hexView.OnMouseDown(e.X, e.Y);
					return;
				}
				this._stringView.OnMouseDown(e.X, e.Y);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000112E8 File Offset: 0x000112E8
		public void OnMouseDragged(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.InHexView(e.X))
				{
					this._hexView.OnMouseDragged(e.X, e.Y);
					return;
				}
				this._stringView.OnMouseDragged(e.X, e.Y);
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0001134C File Offset: 0x0001134C
		public void OnMouseUp(MouseEventArgs e)
		{
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00011350 File Offset: 0x00011350
		public void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.InHexView(e.X))
				{
					this._hexView.OnMouseDoubleClick();
					return;
				}
				this._stringView.OnMouseDoubleClick();
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0001138C File Offset: 0x0001138C
		public void OnGotFocus(EventArgs e)
		{
			if (this.InHexView(this._editor.CaretPosX))
			{
				this._hexView.Focus();
				return;
			}
			this._stringView.Focus();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000113BC File Offset: 0x000113BC
		public void SetLowerCase()
		{
			this._hexView.SetLowerCase();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000113CC File Offset: 0x000113CC
		public void SetUpperCase()
		{
			this._hexView.SetUpperCase();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000113DC File Offset: 0x000113DC
		public void Update(int startPositionX, Rectangle area)
		{
			this._hexView.Update(startPositionX, area);
			this._stringView.Update(this._hexView.MaxWidth, area);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00011404 File Offset: 0x00011404
		public void Paint(Graphics g, int startIndex, int endIndex)
		{
			int num = 0;
			while (num + startIndex < endIndex)
			{
				this._hexView.Paint(g, num, startIndex);
				this._stringView.Paint(g, num, startIndex);
				num++;
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00011444 File Offset: 0x00011444
		private bool InHexView(int x)
		{
			return x < this._hexView.MaxWidth + this._editor.EntityMargin - 2;
		}

		// Token: 0x0400013B RID: 315
		private HexViewHandler _hexView;

		// Token: 0x0400013C RID: 316
		private StringViewHandler _stringView;

		// Token: 0x0400013D RID: 317
		private HexEditor _editor;
	}
}
