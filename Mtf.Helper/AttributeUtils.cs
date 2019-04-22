using System;
using System.Linq;

namespace Mtf.Helper
{
	public static class AttributeUtils
	{
		public static object[] GetAttributes(object instance, string propertyName)
		{
			var property = instance.GetType().GetProperty(propertyName);
			return property.GetCustomAttributes(false);
		}

		public static T GetAttribute<T>(object[] attributes)
			where T : Attribute
		{
			return attributes.FirstOrDefault(attribute => attribute is T) as T;
		}
	}
}
