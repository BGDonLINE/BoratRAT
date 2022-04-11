using System;
using Microsoft.Win32;

namespace Server.Helper
{
	// Token: 0x02000028 RID: 40
	public class RegValueHelper
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x0000F0C8 File Offset: 0x0000F0C8
		public static bool IsDefaultValue(string valueName)
		{
			return string.IsNullOrEmpty(valueName);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000F0D0 File Offset: 0x0000F0D0
		public static string GetName(string valueName)
		{
			if (!RegValueHelper.IsDefaultValue(valueName))
			{
				return valueName;
			}
			return RegValueHelper.DEFAULT_REG_VALUE;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000F0E4 File Offset: 0x0000F0E4
		public static string RegistryValueToString(RegistrySeeker.RegValueData value)
		{
			switch (value.Kind)
			{
			case RegistryValueKind.String:
			case RegistryValueKind.ExpandString:
				return ByteConverter.ToString(value.Data);
			case RegistryValueKind.Binary:
				if (value.Data.Length == 0)
				{
					return "(zero-length binary value)";
				}
				return BitConverter.ToString(value.Data).Replace("-", " ").ToLower();
			case RegistryValueKind.DWord:
			{
				uint num = ByteConverter.ToUInt32(value.Data);
				return string.Format("0x{0:x8} ({1})", num, num);
			}
			case RegistryValueKind.MultiString:
				return string.Join(" ", ByteConverter.ToStringArray(value.Data));
			case RegistryValueKind.QWord:
			{
				ulong num2 = ByteConverter.ToUInt64(value.Data);
				return string.Format("0x{0:x8} ({1})", num2, num2);
			}
			}
			return string.Empty;
		}

		// Token: 0x040000F4 RID: 244
		private static string DEFAULT_REG_VALUE = "(Default)";
	}
}
