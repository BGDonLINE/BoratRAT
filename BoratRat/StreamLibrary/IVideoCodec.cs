using System;
using System.Drawing;
using System.IO;
using StreamLibrary.src;

namespace StreamLibrary
{
	// Token: 0x02000006 RID: 6
	public abstract class IVideoCodec
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600001C RID: 28
		// (remove) Token: 0x0600001D RID: 29
		public abstract event IVideoCodec.VideoCodeProgress onVideoStreamCoding;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600001E RID: 30
		// (remove) Token: 0x0600001F RID: 31
		public abstract event IVideoCodec.VideoDecodeProgress onVideoStreamDecoding;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000020 RID: 32
		// (remove) Token: 0x06000021 RID: 33
		public abstract event IVideoCodec.VideoDebugScanningDelegate onCodeDebugScan;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000022 RID: 34
		// (remove) Token: 0x06000023 RID: 35
		public abstract event IVideoCodec.VideoDebugScanningDelegate onDecodeDebugScan;

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000024 RID: 36
		// (set) Token: 0x06000025 RID: 37
		public abstract ulong CachedSize { get; internal set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000022A8 File Offset: 0x000022A8
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000022B0 File Offset: 0x000022B0
		public int ImageQuality { get; set; }

		// Token: 0x06000028 RID: 40 RVA: 0x000022BC File Offset: 0x000022BC
		public IVideoCodec(int ImageQuality = 100)
		{
			this.jpgCompression = new JpgCompression(ImageQuality);
			this.ImageQuality = ImageQuality;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000029 RID: 41
		public abstract int BufferCount { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002A RID: 42
		public abstract CodecOption CodecOptions { get; }

		// Token: 0x0600002B RID: 43
		public abstract void CodeImage(Bitmap bitmap, Stream outStream);

		// Token: 0x0600002C RID: 44
		public abstract Bitmap DecodeData(Stream inStream);

		// Token: 0x0400000D RID: 13
		protected JpgCompression jpgCompression;

		// Token: 0x02000D40 RID: 3392
		// (Invoke) Token: 0x060089C4 RID: 35268
		public delegate void VideoCodeProgress(Stream stream, Rectangle[] MotionChanges);

		// Token: 0x02000D41 RID: 3393
		// (Invoke) Token: 0x060089C8 RID: 35272
		public delegate void VideoDecodeProgress(Bitmap bitmap);

		// Token: 0x02000D42 RID: 3394
		// (Invoke) Token: 0x060089CC RID: 35276
		public delegate void VideoDebugScanningDelegate(Rectangle ScanArea);
	}
}
