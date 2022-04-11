using System;
using System.Reflection;

// Token: 0x02000727 RID: 1831
internal class AssemblyInfo
{
	// Token: 0x17000ADE RID: 2782
	// (get) Token: 0x0600405B RID: 16475 RVA: 0x0015FDF0 File Offset: 0x0015FDF0
	public static string Version
	{
		get
		{
			if (AssemblyInfo.version == null)
			{
				AssemblyInfo.version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
				if (AssemblyInfo.version == null)
				{
					AssemblyInfo.version = string.Empty;
				}
			}
			return AssemblyInfo.version;
		}
	}

	// Token: 0x040020E3 RID: 8419
	private static string version = null;
}
