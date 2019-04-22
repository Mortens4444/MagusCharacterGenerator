using System.IO;

namespace SourceCodeGenerator
{
	class Program
    {
        static void Main(string[] args)
        {
			var repoFolder = @"C:\Users\morte\source\repos\MagusCharacterGenerator";
			var thingsFolder = Path.Combine(repoFolder, @"MagusCharacterGenerator\Things");
			//var characterSheetFolder = Path.Combine(repoFolder, @"Storyteller\CharacterSheet");
			OdtTranslator.Translate("M.A.G.U.S. Karakterlap.odt", "M.A.G.U.S. Charactersheet.odt");

			//var namespaceBaseName = "SourceCodeGenerator.Resources.ClassGeneration.";
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Accomodation.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Animals.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralArmorTemplate.cst", $"{namespaceBaseName}Armors.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Clothes.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Debauchery.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Food.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Other.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Trappings.csv", thingsFolder);
			//CsvListToCSharpSorceFile.CreateSourceFile($"{namespaceBaseName}GeneralObjectTemplate.cst", $"{namespaceBaseName}Travelling.csv", thingsFolder);
		}
	}
}
