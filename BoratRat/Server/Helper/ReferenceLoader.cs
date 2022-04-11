using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Server.Helper
{
	// Token: 0x02000027 RID: 39
	public class ReferenceLoader : MarshalByRefObject
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x0000EFB4 File Offset: 0x0000EFB4
		public string[] LoadReferences(string assemblyPath)
		{
			string[] result;
			try
			{
				result = (from x in Assembly.ReflectionOnlyLoadFrom(assemblyPath).GetReferencedAssemblies()
					select x.FullName).ToArray<string>();
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000F018 File Offset: 0x0000F018
		public void AppDomainSetup(string assemblyPath)
		{
			try
			{
				AppDomainSetup info = new AppDomainSetup
				{
					ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
				};
				AppDomain domain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, info);
				((ReferenceLoader)Activator.CreateInstance(domain, typeof(ReferenceLoader).Assembly.FullName, typeof(ReferenceLoader).FullName, false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, CultureInfo.CurrentCulture, new object[0]).Unwrap()).LoadReferences(assemblyPath);
				AppDomain.Unload(domain);
			}
			catch
			{
			}
		}
	}
}
