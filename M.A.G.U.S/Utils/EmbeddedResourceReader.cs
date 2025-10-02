using System.Reflection;

namespace M.A.G.U.S;

public static class EmbeddedResourceReader
{
    public static string Get(string resourceName)
	{
        var assembly = Assembly.GetExecutingAssembly();
		return Get(resourceName, assembly);
    }

    public static string Get(string resourceName, Assembly assembly)
    {
        
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
