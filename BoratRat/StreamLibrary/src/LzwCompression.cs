using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace StreamLibrary.src
{
	// Token: 0x02000009 RID: 9
	public class LzwCompression
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00003018 File Offset: 0x00003018
		public LzwCompression(int Quality)
		{
			this.parameter = new EncoderParameter(Encoder.Quality, (long)Quality);
			this.encoderInfo = this.GetEncoderInfo("image/jpeg");
			this.encoderParams = new EncoderParameters(2);
			this.encoderParams.Param[0] = this.parameter;
			this.encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003094 File Offset: 0x00003094
		public byte[] Compress(Bitmap bmp, byte[] AdditionInfo = null)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (AdditionInfo != null)
				{
					memoryStream.Write(AdditionInfo, 0, AdditionInfo.Length);
				}
				bmp.Save(memoryStream, this.encoderInfo, this.encoderParams);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000030F8 File Offset: 0x000030F8
		public void Compress(Bitmap bmp, Stream stream, byte[] AdditionInfo = null)
		{
			if (AdditionInfo != null)
			{
				stream.Write(AdditionInfo, 0, AdditionInfo.Length);
			}
			bmp.Save(stream, this.encoderInfo, this.encoderParams);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003120 File Offset: 0x00003120
		private ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			for (int i = 0; i < imageEncoders.Length; i++)
			{
				if (imageEncoders[i].MimeType == mimeType)
				{
					return imageEncoders[i];
				}
			}
			return null;
		}

		// Token: 0x0400001C RID: 28
		private EncoderParameter parameter;

		// Token: 0x0400001D RID: 29
		private ImageCodecInfo encoderInfo;

		// Token: 0x0400001E RID: 30
		private EncoderParameters encoderParams;
	}
}
