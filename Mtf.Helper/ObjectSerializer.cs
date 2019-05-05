using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

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
					WriteWithIndent(streamWriter, 0, "{");
					Save(streamWriter, obj, 1);
					WriteWithIndent(streamWriter, 0, "}");
				}
			}
		}

		private static void Save(StreamWriter streamWriter, object obj, int indent)
		{
			var objectType = obj.GetType();
			if (objectType.FullName.EndsWith("[]"))
			{
				HandleArrayProperties(streamWriter, obj, indent);
			}
			else if (objectType.IsGenericList(out var _))
			{
				HandleListProperties(streamWriter, obj, indent);
			}
			else if (objectType.IsPrimitiveOrString())
			{
				WriteWithIndent(streamWriter, indent, obj.ToString());
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
			var elements = obj as Array;
			SaveElements(streamWriter, indent, elementType, elements);
		}

		private static void SaveElements(StreamWriter streamWriter, int indent, Type elementType, IEnumerable elements)
		{
			var elementsStr = new StringBuilder();
			foreach (var element in elements)
			{
				if (elementType.IsPrimitiveOrString())
				{
					if (elementsStr.Length > 0)
					{
						elementsStr.Append(", ");
					}
					var value = GetValue(elementType, element);
					elementsStr.Append(value);
				}
				else
				{
					Save(streamWriter, element, indent);
				}
			}
			if (elementsStr.Length > 0)
			{
				Save(streamWriter, elementsStr.ToString(), indent);
			}
		}

		private static object GetValue(Type elementType, object element)
		{
			if (element == null)
			{
				return "null";
			}
			if (elementType == typeof(string))
			{
				return $"\"{element}\"";
			}
			if (elementType == typeof(char))
			{
				return $"'{element}'";
			}
			return element;
		}

		private static void HandleListProperties(StreamWriter streamWriter, object obj, int indent)
		{
			var objectType = obj.GetType();
			objectType.IsGenericList(out var elementType);
			var elements = obj as IList;
			SaveElements(streamWriter, indent, elementType, elements);
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
				WriteWithIndent(streamWriter, indent, $"{property.Name}: Array");
				WriteWithIndent(streamWriter, indent, "{");
				Save(streamWriter, property.GetValue(obj), indent + 1);
				WriteWithIndent(streamWriter, indent, "}");
			}
			else if (property.PropertyType.IsGenericList(out var _))
			{
				WriteWithIndent(streamWriter, indent, $"{property.Name}: List");
				WriteWithIndent(streamWriter, indent, "{");
				Save(streamWriter, property.GetValue(obj), indent + 1);
				WriteWithIndent(streamWriter, indent, "}");
			}
			else
			{
				var propertyValue = property.GetValue(obj);
				propertyValue = GetValue(property.PropertyType, propertyValue);
				WriteWithIndent(streamWriter, indent, $"{property.Name}: {propertyValue}");
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
