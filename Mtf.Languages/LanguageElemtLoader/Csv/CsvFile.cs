using Mtf.Languages.Utils;
using System;
using System.Reflection;

namespace Mtf.Languages.LanguageElemtLoader.Csv
{
	public static class CsvFile
	{
		public static string FileName = "AllLanguages.csv";

		public static string GetContent()
		{
			var embeddedResourceReader = new EmbeddedResourceReader();
			return embeddedResourceReader.GetContent(Assembly.GetExecutingAssembly(), $"Mtf.Languages.Languages.Csv.{FileName}");
		}

		public static string[] SplitContent(string languageFileContent)
		{
			return languageFileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
