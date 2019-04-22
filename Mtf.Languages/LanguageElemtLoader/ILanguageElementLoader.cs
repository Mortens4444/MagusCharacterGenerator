using Mtf.Languages.Utils;
using System.Collections.Generic;

namespace Mtf.Languages.LanguageElemtLoader
{
	interface ILanguageElementLoader
	{
		Dictionary<(Language Language, string ElementIdentifier), List<string>> LoadElements();
	}
}
