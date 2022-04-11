using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace StreamLibrary.src
{
	// Token: 0x02000008 RID: 8
	public class JpgCompression
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00002EE8 File Offset: 0x00002EE8
		public JpgCompression(int Quality)
		{
			this.parameter = new EncoderParameter(Encoder.Quality, (long)Quality);
			this.encoderInfo = this.GetEncoderInfo("image/jpeg");
			this.encoderParams = new EncoderParameters(2);
			this.encoderParams.Param[0] = this.parameter;
			this.encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002F64 File Offset: 0x00002F64
		public byte[] Compress(Bitmap bmp)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bmp.Save(memoryStream, this.encoderInfo, this.encoderParams);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002FB4 File Offset: 0x00002FB4
		public void Compress(Bitmap bmp, ref Stream TargetStream)
		{
			bmp.Save(TargetStream, this.encoderInfo, this.encoderParams);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002FCC File Offset: 0x00002FCC
		private ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			int num = imageEncoders.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (imageEncoders[i].MimeType == mimeType)
				{
					return imageEncoders[i];
				}
			}
			return null;
		}

		// Token: 0x04000019 RID: 25
		private EncoderParameter parameter;

		// Token: 0x0400001A RID: 26
		private ImageCodecInfo encoderInfo;

		// Token: 0x0400001B RID: 27
		private EncoderParameters encoderParams;
	}
}
