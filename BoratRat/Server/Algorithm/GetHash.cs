using System;
using System.IO;
using System.Security.Cryptography;

namespace Server.Algorithm
{
	// Token: 0x02000067 RID: 103
	public static class GetHash
	{
		// Token: 0x0600044A RID: 1098 RVA: 0x0002C0A4 File Offset: 0x0002C0A4
		public static string GetChecksum(string file)
		{
			string result;
			using (FileStream fileStream = File.OpenRead(file))
			{
				result = BitConverter.ToString(new SHA256Managed().ComputeHash(fileStream)).Replace("-", string.Empty);
			}
			return result;
		}
	}
}
