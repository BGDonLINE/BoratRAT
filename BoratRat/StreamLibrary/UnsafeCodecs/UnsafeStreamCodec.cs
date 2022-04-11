// StreamLibrary.UnsafeCodecs.UnsafeStreamCodec
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using StreamLibrary;
using StreamLibrary.src;

public class UnsafeStreamCodec : IUnsafeCodec
{
	private byte[] EncodeBuffer;

	private Bitmap decodedBitmap;

	private PixelFormat EncodedFormat;

	private int EncodedWidth;

	private int EncodedHeight;

	private bool UseJPEG;

	public override ulong CachedSize { get; internal set; }

	public override int BufferCount => 1;

	public override CodecOption CodecOptions => CodecOption.RequireSameSize;

	public Size CheckBlock { get; private set; }

	public override event IVideoCodec.VideoDebugScanningDelegate onCodeDebugScan;

	public override event IVideoCodec.VideoDebugScanningDelegate onDecodeDebugScan;

	public UnsafeStreamCodec(int ImageQuality = 100, bool UseJPEG = true)
		: base(ImageQuality)
	{
		CheckBlock = new Size(50, 1);
		this.UseJPEG = UseJPEG;
	}

	public unsafe override void CodeImage(IntPtr Scan0, Rectangle ScanArea, Size ImageSize, PixelFormat Format, Stream outStream)
	{
		lock (base.ImageProcessLock)
		{
			byte* ptr = (byte*)Scan0.ToInt32();
			if (!outStream.CanWrite)
			{
				throw new Exception("Must have access to Write in the Stream");
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			switch (Format)
			{
				case PixelFormat.Format24bppRgb:
				case PixelFormat.Format32bppRgb:
					num3 = 3;
					break;
				case PixelFormat.Format32bppPArgb:
				case PixelFormat.Format32bppArgb:
					num3 = 4;
					break;
				default:
					throw new NotSupportedException(Format.ToString());
			}
			num = ImageSize.Width * num3;
			num2 = num * ImageSize.Height;
			if (EncodeBuffer == null)
			{
				EncodedFormat = Format;
				EncodedWidth = ImageSize.Width;
				EncodedHeight = ImageSize.Height;
				EncodeBuffer = new byte[num2];
				fixed (byte* value = EncodeBuffer)
				{
					byte[] array = null;
					using (Bitmap bmp = new Bitmap(ImageSize.Width, ImageSize.Height, num, Format, Scan0))
					{
						array = jpgCompression.Compress(bmp);
					}
					outStream.Write(BitConverter.GetBytes(array.Length), 0, 4);
					outStream.Write(array, 0, array.Length);
					NativeMethods.memcpy(new IntPtr(value), Scan0, (uint)num2);
				}
				return;
			}
			long position = outStream.Position;
			outStream.Write(new byte[4], 0, 4);
			int num4 = 0;
			if (EncodedFormat != Format)
			{
				throw new Exception("PixelFormat is not equal to previous Bitmap");
			}
			if (EncodedWidth != ImageSize.Width || EncodedHeight != ImageSize.Height)
			{
				throw new Exception("Bitmap width/height are not equal to previous bitmap");
			}
			List<Rectangle> list = new List<Rectangle>();
			int num5 = 0;
			Size size = new Size(ScanArea.Width, CheckBlock.Height);
			Size size2 = new Size(ScanArea.Width % CheckBlock.Width, ScanArea.Height % CheckBlock.Height);
			int num6 = ScanArea.Height - size2.Height;
			int num7 = ScanArea.Width - size2.Width;
			Rectangle rectangle = default(Rectangle);
			List<Rectangle> list2 = new List<Rectangle>();
			size = new Size(ScanArea.Width, size.Height);
			fixed (byte* ptr2 = EncodeBuffer)
			{
				for (int i = ScanArea.Y; i != ScanArea.Height; i += size.Height)
				{
					if (i == num6)
					{
						size = new Size(ScanArea.Width, size2.Height);
					}
					rectangle = new Rectangle(ScanArea.X, i, ScanArea.Width, size.Height);
					if (onCodeDebugScan != null)
					{
						onCodeDebugScan(rectangle);
					}
					int num8 = i * num + ScanArea.X * num3;
					if (NativeMethods.memcmp(ptr2 + num8, ptr + num8, (uint)num) != 0)
					{
						num5 = list.Count - 1;
						if (list.Count != 0 && list[num5].Y + list[num5].Height == rectangle.Y)
						{
							rectangle = (list[num5] = new Rectangle(list[num5].X, list[num5].Y, list[num5].Width, list[num5].Height + rectangle.Height));
						}
						else
						{
							list.Add(rectangle);
						}
					}
				}
				int j = 0;
				int x = ScanArea.X;
				for (; j < list.Count; j++)
				{
					size = new Size(CheckBlock.Width, list[j].Height);
					for (x = ScanArea.X; x != ScanArea.Width; x += size.Width)
					{
						if (x == num7)
						{
							size = new Size(size2.Width, list[j].Height);
						}
						rectangle = new Rectangle(x, list[j].Y, size.Width, list[j].Height);
						bool flag = false;
						int count = num3 * rectangle.Width;
						for (int k = 0; k < rectangle.Height; k++)
						{
							int num9 = num * (rectangle.Y + k) + num3 * rectangle.X;
							if (NativeMethods.memcmp(ptr2 + num9, ptr + num9, (uint)count) != 0)
							{
								flag = true;
							}
							NativeMethods.memcpy(ptr2 + num9, ptr + num9, (uint)count);
						}
						if (onCodeDebugScan != null)
						{
							onCodeDebugScan(rectangle);
						}
						if (flag)
						{
							num5 = list2.Count - 1;
							if (list2.Count > 0 && list2[num5].X + list2[num5].Width == rectangle.X)
							{
								Rectangle rectangle3 = list2[num5];
								int width = rectangle.Width + rectangle3.Width;
								rectangle = (list2[num5] = new Rectangle(rectangle3.X, rectangle3.Y, width, rectangle3.Height));
							}
							else
							{
								list2.Add(rectangle);
							}
						}
					}
				}
			}
			for (int l = 0; l < list2.Count; l++)
			{
				Rectangle rectangle5 = list2[l];
				int num10 = num3 * rectangle5.Width;
				Bitmap bitmap = new Bitmap(rectangle5.Width, rectangle5.Height, Format);
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
				int m = 0;
				int num11 = 0;
				for (; m < rectangle5.Height; m++)
				{
					int num12 = num * (rectangle5.Y + m) + num3 * rectangle5.X;
					NativeMethods.memcpy((byte*)bitmapData.Scan0.ToPointer() + num11, ptr + num12, (uint)num10);
					num11 += num10;
				}
				bitmap.UnlockBits(bitmapData);
				outStream.Write(BitConverter.GetBytes(rectangle5.X), 0, 4);
				outStream.Write(BitConverter.GetBytes(rectangle5.Y), 0, 4);
				outStream.Write(BitConverter.GetBytes(rectangle5.Width), 0, 4);
				outStream.Write(BitConverter.GetBytes(rectangle5.Height), 0, 4);
				outStream.Write(new byte[4], 0, 4);
				long length = outStream.Length;
				long position2 = outStream.Position;
				if (UseJPEG)
				{
					jpgCompression.Compress(bitmap, ref outStream);
				}
				else
				{
					lzwCompression.Compress(bitmap, outStream);
				}
				length = outStream.Position - length;
				outStream.Position = position2 - 4;
				outStream.Write(BitConverter.GetBytes((int)length), 0, 4);
				outStream.Position += length;
				bitmap.Dispose();
				num4 += (int)length + 20;
			}
			outStream.Position = position;
			outStream.Write(BitConverter.GetBytes(num4), 0, 4);
			list.Clear();
			list2.Clear();
		}
	}

	public unsafe override Bitmap DecodeData(IntPtr CodecBuffer, uint Length)
	{
		if (Length < 4)
		{
			return decodedBitmap;
		}
		int num = *(int*)(void*)CodecBuffer;
		if (decodedBitmap == null)
		{
			byte[] array = new byte[num];
			fixed (byte* value = array)
			{
				NativeMethods.memcpy(new IntPtr(value), new IntPtr(CodecBuffer.ToInt32() + 4), (uint)num);
			}
			decodedBitmap = (Bitmap)Image.FromStream(new MemoryStream(array));
			return decodedBitmap;
		}
		return decodedBitmap;
	}

	public override Bitmap DecodeData(Stream inStream)
	{
		try
		{
			byte[] array = new byte[4];
			inStream.Read(array, 0, 4);
			int num = BitConverter.ToInt32(array, 0);
			if (decodedBitmap == null)
			{
				array = new byte[num];
				inStream.Read(array, 0, array.Length);
				decodedBitmap = (Bitmap)Image.FromStream(new MemoryStream(array));
				return decodedBitmap;
			}
			using (Graphics graphics = Graphics.FromImage(decodedBitmap))
			{
				while (num > 0)
				{
					byte[] array2 = new byte[20];
					inStream.Read(array2, 0, array2.Length);
					Rectangle scanArea = new Rectangle(BitConverter.ToInt32(array2, 0), BitConverter.ToInt32(array2, 4), BitConverter.ToInt32(array2, 8), BitConverter.ToInt32(array2, 12));
					int num2 = BitConverter.ToInt32(array2, 16);
					array2 = null;
					byte[] array3 = new byte[num2];
					inStream.Read(array3, 0, array3.Length);
					if (onDecodeDebugScan != null)
					{
						onDecodeDebugScan(scanArea);
					}
					using (MemoryStream stream = new MemoryStream(array3))
					{
						using Bitmap image = (Bitmap)Image.FromStream(stream);
						graphics.DrawImage(image, scanArea.Location);
					}
					array3 = null;
					num -= num2 + 20;
				}
			}
			return decodedBitmap;
		}
		catch
		{
			return null;
		}
	}
}
