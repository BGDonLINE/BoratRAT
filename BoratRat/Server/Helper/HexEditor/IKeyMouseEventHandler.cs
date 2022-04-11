using System;
using System.Windows.Forms;

namespace Server.Helper.HexEditor
{
	// Token: 0x02000036 RID: 54
	public interface IKeyMouseEventHandler
	{
		// Token: 0x060002A9 RID: 681
		void OnKeyPress(KeyPressEventArgs e);

		// Token: 0x060002AA RID: 682
		void OnKeyDown(KeyEventArgs e);

		// Token: 0x060002AB RID: 683
		void OnKeyUp(KeyEventArgs e);

		// Token: 0x060002AC RID: 684
		void OnMouseDown(MouseEventArgs e);

		// Token: 0x060002AD RID: 685
		void OnMouseDragged(MouseEventArgs e);

		// Token: 0x060002AE RID: 686
		void OnMouseUp(MouseEventArgs e);

		// Token: 0x060002AF RID: 687
		void OnMouseDoubleClick(MouseEventArgs e);

		// Token: 0x060002B0 RID: 688
		void OnGotFocus(EventArgs e);
	}
}
