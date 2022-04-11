using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Server.Helper
{
	// Token: 0x0200002D RID: 45
	public static class RegistryKeyHelper
	{
		// Token: 0x060001CB RID: 459 RVA: 0x0000F914 File Offset: 0x0000F914
		public static bool AddRegistryKeyValue(RegistryHive hive, string path, string name, string value, bool addQuotes = false)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path))
				{
					if (registryKey == null)
					{
						result = false;
					}
					else
					{
						if (addQuotes && !value.StartsWith("\"") && !value.EndsWith("\""))
						{
							value = "\"" + value + "\"";
						}
						registryKey.SetValue(name, value);
						result = true;
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000F9BC File Offset: 0x0000F9BC
		public static RegistryKey OpenReadonlySubKey(RegistryHive hive, string path)
		{
			RegistryKey result;
			try
			{
				result = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenSubKey(path, false);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000F9FC File Offset: 0x0000F9FC
		public static bool DeleteRegistryKeyValue(RegistryHive hive, string path, string name)
		{
			bool result;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path))
				{
					if (registryKey == null)
					{
						result = false;
					}
					else
					{
						registryKey.DeleteValue(name, true);
						result = true;
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000FA6C File Offset: 0x0000FA6C
		public static bool IsDefaultValue(string valueName)
		{
			return string.IsNullOrEmpty(valueName);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000FA74 File Offset: 0x0000FA74
		public static RegistrySeeker.RegValueData[] AddDefaultValue(List<RegistrySeeker.RegValueData> values)
		{
			if (!values.Any((RegistrySeeker.RegValueData value) => RegistryKeyHelper.IsDefaultValue(value.Name)))
			{
				values.Add(RegistryKeyHelper.GetDefaultValue());
			}
			return values.ToArray();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000FAB4 File Offset: 0x0000FAB4
		public static RegistrySeeker.RegValueData[] GetDefaultValues()
		{
			return new RegistrySeeker.RegValueData[] { RegistryKeyHelper.GetDefaultValue() };
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000FAC4 File Offset: 0x0000FAC4
		public static RegistrySeeker.RegValueData CreateRegValueData(string name, RegistryValueKind kind, object value = null)
		{
			RegistrySeeker.RegValueData regValueData = new RegistrySeeker.RegValueData
			{
				Name = name,
				Kind = kind
			};
			if (value == null)
			{
				regValueData.Data = new byte[0];
			}
			else
			{
				switch (regValueData.Kind)
				{
				case RegistryValueKind.String:
				case RegistryValueKind.ExpandString:
					regValueData.Data = ByteConverter.GetBytes((string)value);
					break;
				case RegistryValueKind.Binary:
					regValueData.Data = (byte[])value;
					break;
				case RegistryValueKind.DWord:
					regValueData.Data = ByteConverter.GetBytes((uint)((int)value));
					break;
				case RegistryValueKind.MultiString:
					regValueData.Data = ByteConverter.GetBytes((string[])value);
					break;
				case RegistryValueKind.QWord:
					regValueData.Data = ByteConverter.GetBytes((ulong)((long)value));
					break;
				}
			}
			return regValueData;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000FBA8 File Offset: 0x0000FBA8
		private static RegistrySeeker.RegValueData GetDefaultValue()
		{
			return RegistryKeyHelper.CreateRegValueData(RegistryKeyHelper.DEFAULT_VALUE, RegistryValueKind.String, null);
		}

		// Token: 0x040000FA RID: 250
		private static string DEFAULT_VALUE = string.Empty;
	}
}
