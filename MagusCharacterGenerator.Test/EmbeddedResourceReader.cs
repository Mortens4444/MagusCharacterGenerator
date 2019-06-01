using System;
using System.IO;
using System.Reflection;

namespace MagusCharacterGenerator.Test
{
	public static class EmbeddedResourceReader
	{
		public static string Get(string resourceName)
		{
			var assembly = Assembly.GetExecutingAssembly();
			using (var stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (stream == null)
				{
					throw new ArgumentException($"Embedded resource cannot be found: {resourceName}", nameof(resourceName));
				}
				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}
}
