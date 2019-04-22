using System.IO;
using System.Reflection;

namespace Mtf.Languages.Utils
{
    class EmbeddedResourceReader
    {
        public string GetContent(Assembly assembly, string resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
