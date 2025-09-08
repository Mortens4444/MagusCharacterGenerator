using System;
using System.Collections.Generic;
using System.Linq;

namespace Mtf.Helper
{
	public static class TypeExtensions
	{
		public static IEnumerable<Type> GetTypesInNamespace(this Type searchedType, string @namespace)
		{
			var assembly = searchedType.Assembly;
			return assembly.GetTypes().Where(type => String.Equals(type.Namespace, @namespace, StringComparison.Ordinal));
		}

		public static Type GetTypeByName(string typeFullname)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			return assemblies.SelectMany(assembly => assembly.GetTypes())
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
