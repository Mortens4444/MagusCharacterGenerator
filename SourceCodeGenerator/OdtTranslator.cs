using Mtf.Helper;
using Mtf.Languages;
using Mtf.Languages.Utils;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SourceCodeGenerator
{
	public static class OdtTranslator
	{
		public static void Translate(string inputFilename, string outputFilename, string folder = null)
		{
			if (String.IsNullOrWhiteSpace(folder))
			{
				folder = Application.StartupPath;
			}

			var zipFile = Path.Combine(folder, inputFilename);
			var destinationFolder = Zip.Extract(zipFile, folder);

			var contentFile = Path.Combine(destinationFolder, "content.xml");
			var xml = XDocument.Load(contentFile);

			var hungarianElements = Lng.AllLanguageElements.Where(e => e.Key.Language == Language.Magyar).Select(e => e.Value[0]).ToList();
			var elements = xml.Descendants().Where(e => hungarianElements.Contains(e.Value));
			foreach (var element in elements)
			{
				element.Value = Lng.Elem(Language.Magyar, Language.English, element.Value);
			}
			xml.Save(Path.Combine(destinationFolder, "content_english.xml"));
		}
	}
}
