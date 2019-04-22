using System;
using System.IO;

namespace Mtf.Helper
{
	public class ObjectSerializer
	{
		public static T Load<T>(string fullPath)
		{
			using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (var streamReader = new StreamReader(stream))
				{
					var fileContent = streamReader.ReadToEnd();
					var lines = fileContent.Split(new[] { '\r', '\n' });

					var obj = Activator.CreateInstance<T>();
					var objectType = typeof(T);
					foreach (var line in lines)
					{
						var propertyNameAndValue = line.Split(':');
						var propertyName = propertyNameAndValue[0];
						var value = propertyNameAndValue[1];
						var property = objectType.GetProperty(propertyName);
						property.SetValue(obj, value);
					}
					return obj;
				}
			}
		}

		public static void Save(string fullPath, object obj)
		{
			using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
			{
				using (var streamWriter = new StreamWriter(fileStream))
				{
					var objectType = obj.GetType();
					var properties = objectType.GetProperties();
					foreach (var property in properties)
					{
						streamWriter.WriteLine($"{property.Name}:{property.GetValue(obj)}");
					}
				}
			}
		}
	}
}
