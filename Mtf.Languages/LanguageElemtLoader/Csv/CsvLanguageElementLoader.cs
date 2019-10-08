using Mtf.Languages.Utils;
using System;
using System.Collections.Generic;

namespace Mtf.Languages.LanguageElemtLoader.Csv
{
	class CsvLanguageElementLoader : ILanguageElementLoader
	{
		/// <summary>
		/// Memory usage can be reduced if only the current language elements are loaded, not all languages.
		/// </summary>
		public Dictionary<(Language Language, string ElementIdentifier), List<string>> LoadElements()
		{
			var allLanguageElements = new Dictionary<(Language Language, string ElementIdentifier), List<string>>();
			var languageFileContent = CsvFile.GetContent();
			var rows = CsvFile.SplitContent(languageFileContent);
			var lngStrs = rows[0].Split(';');
			var languages = new List<Language>();
			for (int i = 0; i < lngStrs.Length; i++)
			{
				var language = (Language)Enum.Parse(typeof(Language), lngStrs[i]);
				languages.Add(language);
			}

			for (int i = 1; i < rows.Length; i++)
			{
				var elements = rows[i].Split(';');
				if (elements.Length != lngStrs.Length)
				{
					throw new Exception($"{Environment.NewLine}The line {i + 1} in {CsvFile.FileName} has an error:{Environment.NewLine}{rows[i]}{Environment.NewLine}It should contain only {lngStrs.Length - 1} semicolon.");
				}
				for (int j = 0; j < elements.Length; j++)
				{
					var key = ((Language)languages[j], elements[0]);
					if (allLanguageElements.ContainsKey(key))
					{
						allLanguageElements[key].Add(elements[j]);
					}
					else
					{
						allLanguageElements.Add(key, new List<string> { elements[j] });
					}
				}
			}

			return allLanguageElements;
		}
	}
}
