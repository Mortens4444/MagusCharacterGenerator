using System.IO;
using System.Reflection;

namespace SourceCodeGenerator
{
	static class EmbeddedResourceReader
	{
		public static string GetContent(string resourceName)
		{
			var assembly = Assembly.GetCallingAssembly();
			using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
			{
				using (var reader = new StreamReader(resourceStream))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}
}
