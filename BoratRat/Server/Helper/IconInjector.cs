using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace Server.Helper
{
	// Token: 0x02000021 RID: 33
	public static class IconInjector
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0000EA94 File Offset: 0x0000EA94
		public static void InjectIcon(string exeFileName, string iconFileName)
		{
			IconInjector.InjectIcon(exeFileName, iconFileName, 1U, 1U);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000EAA0 File Offset: 0x0000EAA0
		public static void InjectIcon(string exeFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
		{
			IconInjector.IconFile iconFile = IconInjector.IconFile.FromFile(iconFileName);
			IntPtr hUpdate = IconInjector.NativeMethods.BeginUpdateResource(exeFileName, false);
			byte[] array = iconFile.CreateIconGroupData(iconBaseID);
			IconInjector.NativeMethods.UpdateResource(hUpdate, new IntPtr(14L), new IntPtr((long)((ulong)iconGroupID)), 0, array, array.Length);
			for (int i = 0; i <= iconFile.ImageCount - 1; i++)
			{
				byte[] array2 = iconFile.ImageData(i);
				IconInjector.NativeMethods.UpdateResource(hUpdate, new IntPtr(3L), new IntPtr((long)((ulong)iconBaseID + (ulong)((long)i))), 0, array2, array2.Length);
			}
			IconInjector.NativeMethods.EndUpdateResource(hUpdate, false);
		}

		// Token: 0x02000D50 RID: 3408
		[SuppressUnmanagedCodeSecurity]
		private class NativeMethods
		{
			// Token: 0x060089F6 RID: 35318
			[DllImport("kernel32")]
			public static extern IntPtr BeginUpdateResource(string fileName, [MarshalAs(UnmanagedType.Bool)] bool deleteExistingResources);

			// Token: 0x060089F7 RID: 35319
			[DllImport("kernel32")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);

			// Token: 0x060089F8 RID: 35320
			[DllImport("kernel32")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool EndUpdateResource(IntPtr hUpdate, [MarshalAs(UnmanagedType.Bool)] bool discard);
		}

		// Token: 0x02000D51 RID: 3409
		private struct ICONDIR
		{
			// Token: 0x04003F18 RID: 16152
			public ushort Reserved;

			// Token: 0x04003F19 RID: 16153
			public ushort Type;

			// Token: 0x04003F1A RID: 16154
			public ushort Count;
		}

		// Token: 0x02000D52 RID: 3410
		private struct ICONDIRENTRY
		{
			// Token: 0x04003F1B RID: 16155
			public byte Width;

			// Token: 0x04003F1C RID: 16156
			public byte Height;

			// Token: 0x04003F1D RID: 16157
			public byte ColorCount;

			// Token: 0x04003F1E RID: 16158
			public byte Reserved;

			// Token: 0x04003F1F RID: 16159
			public ushort Planes;

			// Token: 0x04003F20 RID: 16160
			public ushort BitCount;

			// Token: 0x04003F21 RID: 16161
			public int BytesInRes;

			// Token: 0x04003F22 RID: 16162
			public int ImageOffset;
		}

		// Token: 0x02000D53 RID: 3411
		private struct BITMAPINFOHEADER
		{
			// Token: 0x04003F23 RID: 16163
			public uint Size;

			// Token: 0x04003F24 RID: 16164
			public int Width;

			// Token: 0x04003F25 RID: 16165
			public int Height;

			// Token: 0x04003F26 RID: 16166
			public ushort Planes;

			// Token: 0x04003F27 RID: 16167
			public ushort BitCount;

			// Token: 0x04003F28 RID: 16168
			public uint Compression;

			// Token: 0x04003F29 RID: 16169
			public uint SizeImage;

			// Token: 0x04003F2A RID: 16170
			public int XPelsPerMeter;

			// Token: 0x04003F2B RID: 16171
			public int YPelsPerMeter;

			// Token: 0x04003F2C RID: 16172
			public uint ClrUsed;

			// Token: 0x04003F2D RID: 16173
			public uint ClrImportant;
		}

		// Token: 0x02000D54 RID: 3412
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		private struct GRPICONDIRENTRY
		{
			// Token: 0x04003F2E RID: 16174
			public byte Width;

			// Token: 0x04003F2F RID: 16175
			public byte Height;

			// Token: 0x04003F30 RID: 16176
			public byte ColorCount;

			// Token: 0x04003F31 RID: 16177
			public byte Reserved;

			// Token: 0x04003F32 RID: 16178
			public ushort Planes;

			// Token: 0x04003F33 RID: 16179
			public ushort BitCount;

			// Token: 0x04003F34 RID: 16180
			public int BytesInRes;

			// Token: 0x04003F35 RID: 16181
			public ushort ID;
		}

		// Token: 0x02000D55 RID: 3413
		private class IconFile
		{
			// Token: 0x17001D5F RID: 7519
			// (get) Token: 0x060089FA RID: 35322 RVA: 0x0029797C File Offset: 0x0029797C
			public int ImageCount
			{
				get
				{
					return (int)this.iconDir.Count;
				}
			}

			// Token: 0x060089FB RID: 35323 RVA: 0x0029798C File Offset: 0x0029798C
			public byte[] ImageData(int index)
			{
				return this.iconImage[index];
			}

			// Token: 0x060089FC RID: 35324 RVA: 0x0029799C File Offset: 0x0029799C
			public static IconInjector.IconFile FromFile(string filename)
			{
				IconInjector.IconFile iconFile = new IconInjector.IconFile();
				byte[] array = File.ReadAllBytes(filename);
				GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
				iconFile.iconDir = (IconInjector.ICONDIR)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(IconInjector.ICONDIR));
				iconFile.iconEntry = new IconInjector.ICONDIRENTRY[(int)iconFile.iconDir.Count];
				iconFile.iconImage = new byte[(int)iconFile.iconDir.Count][];
				int num = Marshal.SizeOf<IconInjector.ICONDIR>(iconFile.iconDir);
				Type typeFromHandle = typeof(IconInjector.ICONDIRENTRY);
				int num2 = Marshal.SizeOf(typeFromHandle);
				for (int i = 0; i <= (int)(iconFile.iconDir.Count - 1); i++)
				{
					IconInjector.ICONDIRENTRY icondirentry = (IconInjector.ICONDIRENTRY)Marshal.PtrToStructure(new IntPtr(gchandle.AddrOfPinnedObject().ToInt64() + (long)num), typeFromHandle);
					iconFile.iconEntry[i] = icondirentry;
					iconFile.iconImage[i] = new byte[icondirentry.BytesInRes];
					Buffer.BlockCopy(array, icondirentry.ImageOffset, iconFile.iconImage[i], 0, icondirentry.BytesInRes);
					num += num2;
				}
				gchandle.Free();
				return iconFile;
			}

			// Token: 0x060089FD RID: 35325 RVA: 0x00297AD0 File Offset: 0x00297AD0
			public byte[] CreateIconGroupData(uint iconBaseID)
			{
				byte[] array = new byte[Marshal.SizeOf(typeof(IconInjector.ICONDIR)) + Marshal.SizeOf(typeof(IconInjector.GRPICONDIRENTRY)) * this.ImageCount];
				GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
				Marshal.StructureToPtr<IconInjector.ICONDIR>(this.iconDir, gchandle.AddrOfPinnedObject(), false);
				int num = Marshal.SizeOf<IconInjector.ICONDIR>(this.iconDir);
				for (int i = 0; i <= this.ImageCount - 1; i++)
				{
					IconInjector.GRPICONDIRENTRY structure = default(IconInjector.GRPICONDIRENTRY);
					IconInjector.BITMAPINFOHEADER bitmapinfoheader = default(IconInjector.BITMAPINFOHEADER);
					GCHandle gchandle2 = GCHandle.Alloc(bitmapinfoheader, GCHandleType.Pinned);
					Marshal.Copy(this.ImageData(i), 0, gchandle2.AddrOfPinnedObject(), Marshal.SizeOf(typeof(IconInjector.BITMAPINFOHEADER)));
					gchandle2.Free();
					structure.Width = this.iconEntry[i].Width;
					structure.Height = this.iconEntry[i].Height;
					structure.ColorCount = this.iconEntry[i].ColorCount;
					structure.Reserved = this.iconEntry[i].Reserved;
					structure.Planes = bitmapinfoheader.Planes;
					structure.BitCount = bitmapinfoheader.BitCount;
					structure.BytesInRes = this.iconEntry[i].BytesInRes;
					structure.ID = Convert.ToUInt16((long)((ulong)iconBaseID + (ulong)((long)i)));
					Marshal.StructureToPtr<IconInjector.GRPICONDIRENTRY>(structure, new IntPtr(gchandle.AddrOfPinnedObject().ToInt64() + (long)num), false);
					num += Marshal.SizeOf(typeof(IconInjector.GRPICONDIRENTRY));
				}
				gchandle.Free();
				return array;
			}

			// Token: 0x04003F36 RID: 16182
			private IconInjector.ICONDIR iconDir;

			// Token: 0x04003F37 RID: 16183
			private IconInjector.ICONDIRENTRY[] iconEntry;

			// Token: 0x04003F38 RID: 16184
			private byte[][] iconImage;
		}
	}
}
