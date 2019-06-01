using Newtonsoft.Json;
using System.IO;

namespace Mtf.Helper
{
	public class ObjectSerializer
	{
		public static T LoadFile<T>(string fullPath)
		{
			using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (var streamReader = new StreamReader(stream))
				{
					var fileContent = streamReader.ReadToEnd();
					return LoadContent<T>(fileContent);
				}
			}
		}

		public static T LoadContent<T>(string fileContent)
		{
			return JsonConvert.DeserializeObject<T>(fileContent, new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.All,
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			});
		}

		public static void SaveFile(string fullPath, object obj)
		{
			using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
			{
				using (var streamWriter = new StreamWriter(fileStream))
				{
					string result = GetSerializedString(obj);
					streamWriter.Write(result);
				}
			}
		}

		public static string GetSerializedString(object obj)
		{
			return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.All,
				PreserveReferencesHandling = PreserveReferencesHandling.Objects
			});
		}
	}
}
