using System;
using System.Linq;

namespace Mtf.Helper
{
	public static class TypeExtensions
	{
		public static Type GetTypeByName(string typeFullname)
		{
			var asseblies = AppDomain.CurrentDomain.GetAssemblies();
			return asseblies.SelectMany(assembly => assembly.GetTypes())
				.First(type => type.FullName == typeFullname);
		}

		public static bool IsArray(this Type type)
		{
			return type != null && type.FullName == "System.Array";
		}

		public static bool IsPrimitiveOrString(this Type type)
		{
			return type != null && (type.IsPrimitive || type == typeof(string));
		}

		public static bool IsGenericList(this Type type, out Type elementsType)
		{
			while (type != null)
			{
				if (type.FullName.StartsWith("System.Collections.Generic.List`"))
				{
					elementsType = type.GenericTypeArguments.First();
					return true;
				}
				type = type.BaseType;
			}
			elementsType = null;
			return false;
		}
	}
}
