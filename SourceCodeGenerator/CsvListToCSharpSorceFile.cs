#define USE_TRANSLATION_CSV

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mtf.Helper;
using Mtf.Languages.LanguageElemtLoader.Csv;

namespace SourceCodeGenerator
{
	public static class CsvListToCSharpSorceFile
    {
        public static void CreateSourceFile(string sourceTemplateFile, string entityListFile, string basePath)
        {
			var sourceTemplateContent = EmbeddedResourceReader.GetContent(sourceTemplateFile);
			var entityListContent = EmbeddedResourceReader.GetContent(entityListFile);
			var entities = entityListContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			var namespacePart = Path.GetFileNameWithoutExtension(entityListFile);
			namespacePart = namespacePart.Substring(namespacePart.LastIndexOf('.') + 1);

#if USE_TRANSLATION_CSV
			var languageFileContent = CsvFile.GetContent();
			var rows = CsvFile.SplitContent(languageFileContent).ToList();
			var potentialTranslations = entities.Skip(1).Select(entity => entity.Substring(0, entity.GetSecondIndexOf(';')));
			bool written = false;
			foreach (var potentialTranslation in potentialTranslations)
			{
				if (!rows.Any(row => row.Equals(potentialTranslation, StringComparison.Ordinal)))
				{
					rows.Add(potentialTranslation);
					languageFileContent += $"{Environment.NewLine}{potentialTranslation}";
					written = true;
				}
			}
			if (written)
			{
				var path = Path.Combine(Application.StartupPath, @"..\..\..\Mtf.Languages\Languages\Csv\AllLanguages.csv");
				File.WriteAllText(path, languageFileContent);
				Environment.Exit(-1);
			}
#endif
			var propertyNames = entities[0].Split(';');
			for (int i = 1; i < entities.Length; i++)
			{
				var entity = entities[i];
				var propertyValues = entity.Split(';');
				var currentFileContent = sourceTemplateContent;
				currentFileContent = currentFileContent.Replace("{Namespace}", namespacePart);
				var className = GetClassName(propertyValues[0]);
				currentFileContent = currentFileContent.Replace("{ClassName}", className);

				for (int j = 0; j < propertyNames.Length; j++)
				{
					var propertyName = propertyNames[j];
					var value = propertyName == "Price" ? PriceConverter.Get(propertyValues[j]) : propertyValues[j];
					currentFileContent = currentFileContent.Replace($"{{{propertyName}}}", value);
				}

				var directory = Path.Combine(basePath, namespacePart);
				DirectoryExtension.CreateIfNotExists(directory);				
				File.WriteAllText(Path.Combine(directory, String.Concat(className, ".cs")), currentFileContent);
			}
		}

		private static string GetClassName(string englishName)
		{
			var invalidPatterns = new[] { ",", "\\", "/", "-", "(", ")" };
			foreach (var invalidPattern in invalidPatterns)
			{
				englishName = englishName.Replace(invalidPattern, String.Empty);
			}
			if (!englishName.Contains(" "))
			{
				return englishName;
			}

			var nameParts = englishName.Split(' ');
			var result = new StringBuilder();

			var startIndex = englishName.Contains(",") ? 1 : 0;
			for (int i = startIndex; i < nameParts.Length; i++)
			{
				result.Append(nameParts[i].FirstCharToUpper());
			}
			if (startIndex == 1)
			{
				result.Append(nameParts[0].FirstCharToUpper());
			}

			return result.ToString();
		}
	}
}
