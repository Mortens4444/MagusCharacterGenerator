using System;
using System.Linq;

namespace Mtf.Helper
{
	public static class AttributeUtils
	{
		public static short GetPropertyShortValue(this object instance, string propertyName)
		{
			var value = instance.GetPropertyValue(propertyName);
			return value == null ? (short)0 : (short)value;
		}

		public static object GetPropertyValue(this object instance, string propertyName)
		{
			var property = instance.GetType().GetProperty(propertyName);
			return property == null ? null : property.GetValue(instance);
		}

		public static object[] GetCustomAttributes(this object instance, string propertyName)
		{
			var property = instance.GetType().GetProperty(propertyName);
			return property.GetCustomAttributes(false);
		}

		public static T GetAttribute<T>(this object[] attributes)
			where T : Attribute
		{
			return attributes.FirstOrDefault(attribute => attribute is T) as T;
		}
	}
}
