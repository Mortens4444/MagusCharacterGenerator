using MagusCharacterGenerator.Castes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Storyteller
{
	static class TypeUtils
	{
		public static IEnumerable<Type> GetTypesInNamespace(string nameSpace)
		{
			var assembly = typeof(Caste).Assembly;
			return assembly.GetTypes().Where(type => String.Equals(type.Namespace, nameSpace, StringComparison.Ordinal));
		}
	}
}
