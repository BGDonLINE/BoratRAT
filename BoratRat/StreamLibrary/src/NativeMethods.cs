using System;
using System.Runtime.InteropServices;

namespace StreamLibrary.src
{
	// Token: 0x0200000A RID: 10
	public class NativeMethods
	{
		// Token: 0x06000043 RID: 67
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int memcmp(byte* ptr1, byte* ptr2, uint count);

		// Token: 0x06000044 RID: 68
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int memcmp(IntPtr ptr1, IntPtr ptr2, uint count);

		// Token: 0x06000045 RID: 69
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int memcpy(IntPtr dst, IntPtr src, uint count);

		// Token: 0x06000046 RID: 70
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public unsafe static extern int memcpy(void* dst, void* src, uint count);
	}
}
