using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

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
					Save(streamWriter, obj, 0);
				}
			}
		}

		private static void Save(StreamWriter streamWriter, object obj, int indent)
		{
			var objectType = obj.GetType();

			if (objectType.FullName.EndsWith("[]"))
			{
				HandleArrayProperties(streamWriter, obj, indent + 1);
			}
			else if (objectType.FullName.Contains("List"))
			{
				HandleListProperties(streamWriter, obj, indent + 1);
			}
			else
			{
				var properties = objectType.GetProperties();
				foreach (var property in properties)
				{
					SaveProperty(streamWriter, obj, property, indent);
				}
			}
		}

		private static void HandleArrayProperties(StreamWriter streamWriter, object obj, int indent)
		{
			var objectType = obj.GetType();
			var objectsTypeInArray = objectType.FullName.Substring(0, objectType.FullName.Length - 2);
			var elementType = TypeExtensions.GetTypeByName(objectsTypeInArray);
			var properties = elementType.GetProperties();
			foreach (var o in obj as Array)
			{
				foreach (var property in properties)
				{
					SaveProperty(streamWriter, o, property, indent);
				}
			}
		}

		private static void HandleListProperties(StreamWriter streamWriter, object obj, int indent)
		{
			var objectType = obj.GetType();
			
			while (!objectType.IsGenericList())
			{
				objectType = objectType.BaseType;
			}

			var elementType = objectType.GenericTypeArguments.First();
			var properties = elementType.GetProperties();
			foreach (var element in obj as IList)
			{
				WriteWithIndent(streamWriter, indent, "{");
				foreach (var property in properties)
				{
					SaveProperty(streamWriter, element, property, indent + 1);
				}
				WriteWithIndent(streamWriter, indent, "}");
			}
		}

		private static void WriteWithIndent(StreamWriter streamWriter, int indent, string text)
		{
			AddIndent(streamWriter, indent);
			streamWriter.WriteLine(text);
		}

		private static void SaveProperty(StreamWriter streamWriter, object obj, PropertyInfo property, int indent)
		{
			if (property.PropertyType.BaseType.IsArray())
			{
				streamWriter.WriteLine($"{property.Name}: Array {{");
				Save(streamWriter, property.GetValue(obj), indent);
				streamWriter.WriteLine("}");
			}
			else if (property.PropertyType.BaseType.IsGenericList())
			{
				streamWriter.WriteLine($"{property.Name}: List {{");
				Save(streamWriter, property.GetValue(obj), indent);
				streamWriter.WriteLine("}");
			}
			else
			{
				var propertyValue = property.GetValue(obj) ?? "null";
				AddIndent(streamWriter, indent);
				streamWriter.WriteLine($"{property.Name}: {propertyValue}");
			}
		}

		private static void AddIndent(StreamWriter streamWriter, int indent)
		{
			for (int i = 0; i < indent; i++)
			{
				streamWriter.Write('\t');
			}
		}
	}
}
