using System;
using System.Collections.Generic;
using Microsoft.Win32;
using ProtoBuf;

namespace Server.Helper
{
	// Token: 0x0200002E RID: 46
	public class RegistrySeeker
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000FBC4 File Offset: 0x0000FBC4
		public RegistrySeeker.RegSeekerMatch[] Matches
		{
			get
			{
				List<RegistrySeeker.RegSeekerMatch> matches = this._matches;
				if (matches == null)
				{
					return null;
				}
				return matches.ToArray();
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000FBDC File Offset: 0x0000FBDC
		public RegistrySeeker()
		{
			this._matches = new List<RegistrySeeker.RegSeekerMatch>();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000FBF0 File Offset: 0x0000FBF0
		public void BeginSeeking(string rootKeyName)
		{
			if (!string.IsNullOrEmpty(rootKeyName))
			{
				using (RegistryKey rootKey = RegistrySeeker.GetRootKey(rootKeyName))
				{
					if (rootKey != null && rootKey.Name != rootKeyName)
					{
						string name = rootKeyName.Substring(rootKey.Name.Length + 1);
						using (RegistryKey registryKey = rootKey.OpenReadonlySubKeySafe(name))
						{
							if (registryKey != null)
							{
								this.Seek(registryKey);
							}
							return;
						}
					}
					this.Seek(rootKey);
					return;
				}
			}
			this.Seek(null);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000FCA0 File Offset: 0x0000FCA0
		private void Seek(RegistryKey rootKey)
		{
			if (rootKey == null)
			{
				using (List<RegistryKey>.Enumerator enumerator = RegistrySeeker.GetRootKeys().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						RegistryKey registryKey = enumerator.Current;
						this.ProcessKey(registryKey, registryKey.Name);
					}
					return;
				}
			}
			this.Search(rootKey);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000FD0C File Offset: 0x0000FD0C
		private void Search(RegistryKey rootKey)
		{
			foreach (string text in rootKey.GetSubKeyNames())
			{
				RegistryKey key = rootKey.OpenReadonlySubKeySafe(text);
				this.ProcessKey(key, text);
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000FD50 File Offset: 0x0000FD50
		private void ProcessKey(RegistryKey key, string keyName)
		{
			if (key != null)
			{
				List<RegistrySeeker.RegValueData> list = new List<RegistrySeeker.RegValueData>();
				foreach (string name in key.GetValueNames())
				{
					RegistryValueKind valueKind = key.GetValueKind(name);
					object value = key.GetValue(name);
					list.Add(RegistryKeyHelper.CreateRegValueData(name, valueKind, value));
				}
				this.AddMatch(keyName, RegistryKeyHelper.AddDefaultValue(list), key.SubKeyCount);
				return;
			}
			this.AddMatch(keyName, RegistryKeyHelper.GetDefaultValues(), 0);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000FDD0 File Offset: 0x0000FDD0
		private void AddMatch(string key, RegistrySeeker.RegValueData[] values, int subkeycount)
		{
			RegistrySeeker.RegSeekerMatch item = new RegistrySeeker.RegSeekerMatch
			{
				Key = key,
				Data = values,
				HasSubKeys = (subkeycount > 0)
			};
			this._matches.Add(item);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000FE0C File Offset: 0x0000FE0C
		public static RegistryKey GetRootKey(string subkeyFullPath)
		{
			string[] array = subkeyFullPath.Split(new char[] { '\\' });
			RegistryKey result;
			try
			{
				string a = array[0];
				if (!(a == "HKEY_CLASSES_ROOT"))
				{
					if (!(a == "HKEY_CURRENT_USER"))
					{
						if (!(a == "HKEY_LOCAL_MACHINE"))
						{
							if (!(a == "HKEY_USERS"))
							{
								if (!(a == "HKEY_CURRENT_CONFIG"))
								{
									throw new Exception("Invalid rootkey, could not be found.");
								}
								result = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64);
							}
							else
							{
								result = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64);
							}
						}
						else
						{
							result = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
						}
					}
					else
					{
						result = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
					}
				}
				else
				{
					result = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
				}
			}
			catch (SystemException)
			{
				throw new Exception("Unable to open root registry key, you do not have the needed permissions.");
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000FF28 File Offset: 0x0000FF28
		public static List<RegistryKey> GetRootKeys()
		{
			List<RegistryKey> list = new List<RegistryKey>();
			try
			{
				list.Add(RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64));
				list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64));
				list.Add(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64));
				list.Add(RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64));
				list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64));
			}
			catch (SystemException)
			{
				throw new Exception("Could not open root registry keys, you may not have the needed permission");
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return list;
		}

		// Token: 0x040000FB RID: 251
		private readonly List<RegistrySeeker.RegSeekerMatch> _matches;

		// Token: 0x02000D5B RID: 3419
		[ProtoContract]
		public class RegSeekerMatch
		{
			// Token: 0x17001D60 RID: 7520
			// (get) Token: 0x06008A07 RID: 35335 RVA: 0x00297DC8 File Offset: 0x00297DC8
			// (set) Token: 0x06008A08 RID: 35336 RVA: 0x00297DD0 File Offset: 0x00297DD0
			[ProtoMember(1)]
			public string Key { get; set; }

			// Token: 0x17001D61 RID: 7521
			// (get) Token: 0x06008A09 RID: 35337 RVA: 0x00297DDC File Offset: 0x00297DDC
			// (set) Token: 0x06008A0A RID: 35338 RVA: 0x00297DE4 File Offset: 0x00297DE4
			[ProtoMember(2)]
			public RegistrySeeker.RegValueData[] Data { get; set; }

			// Token: 0x17001D62 RID: 7522
			// (get) Token: 0x06008A0B RID: 35339 RVA: 0x00297DF0 File Offset: 0x00297DF0
			// (set) Token: 0x06008A0C RID: 35340 RVA: 0x00297DF8 File Offset: 0x00297DF8
			[ProtoMember(3)]
			public bool HasSubKeys { get; set; }

			// Token: 0x06008A0D RID: 35341 RVA: 0x00297E04 File Offset: 0x00297E04
			public override string ToString()
			{
				return string.Format("({0}:{1})", this.Key, this.Data);
			}
		}

		// Token: 0x02000D5C RID: 3420
		[ProtoContract]
		public class RegValueData
		{
			// Token: 0x17001D63 RID: 7523
			// (get) Token: 0x06008A0F RID: 35343 RVA: 0x00297E24 File Offset: 0x00297E24
			// (set) Token: 0x06008A10 RID: 35344 RVA: 0x00297E2C File Offset: 0x00297E2C
			[ProtoMember(1)]
			public string Name { get; set; }

			// Token: 0x17001D64 RID: 7524
			// (get) Token: 0x06008A11 RID: 35345 RVA: 0x00297E38 File Offset: 0x00297E38
			// (set) Token: 0x06008A12 RID: 35346 RVA: 0x00297E40 File Offset: 0x00297E40
			[ProtoMember(2)]
			public RegistryValueKind Kind { get; set; }

			// Token: 0x17001D65 RID: 7525
			// (get) Token: 0x06008A13 RID: 35347 RVA: 0x00297E4C File Offset: 0x00297E4C
			// (set) Token: 0x06008A14 RID: 35348 RVA: 0x00297E54 File Offset: 0x00297E54
			[ProtoMember(3)]
			public byte[] Data { get; set; }
		}
	}
}
