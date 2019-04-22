using Mtf.Languages.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mtf.Languages.LanguageElemtLoader.Json
{
	class JsonLanguageElementLoader : ILanguageElementLoader
	{
		/// <summary>
		/// Memory usage can be reduced if only the current languge elements are loaded, not all languages.
		/// </summary>
		public Dictionary<(Language Language, string ElementIdentifier), List<string>> LoadElements()
		{
			var allLanguageElements = new Dictionary<(Language Language, string ElementIdentifier), List<string>>();
			var embeddedResourceReader = new EmbeddedResourceReader();
			var languages = Enum.GetValues(typeof(Language));
			foreach (var language in languages)
			{
				var languageFileContent = embeddedResourceReader.GetContent(Assembly.GetCallingAssembly(), $"Mtf.Languages.Languages.Json.{language}.json");
				var languageElements = JsonConvert.CreateLanguageElements(languageFileContent);

				foreach (var languageElement in languageElements)
				{
					var key = ((Language)language, languageElement.Key);
					if (allLanguageElements.ContainsKey(key))
					{
						allLanguageElements[key].Add(languageElement.Value);
					}
					else
					{
						allLanguageElements.Add(key, new List<string> { languageElement.Value });
					}
				}
			}
			return allLanguageElements;
		}
	}
}
