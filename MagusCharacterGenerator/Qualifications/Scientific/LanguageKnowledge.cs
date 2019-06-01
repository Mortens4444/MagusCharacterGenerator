using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Helper;
using Mtf.Languages;
using Newtonsoft.Json;

namespace MagusCharacterGenerator.Qualifications.Scientific
{
	class LanguageKnowledge : Qualification, ICanHaveMany
	{
        public Language Language { get; set; }

		[JsonConstructor]
		public LanguageKnowledge() { }

		public LanguageKnowledge(byte languageLevel, byte level = 1)
            : base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
        {
        }

		public LanguageKnowledge(Language language, byte languageLevel, byte level = 1)
			: base(languageLevel > 5 ? QualificationLevel.Master : QualificationLevel.Base, level)
		{
			Language = language;
		}

		public override string ToString() => $"{Lng.Elem("Language knowledge")} ({Lng.Elem(EnumUtils.GetDescription(Language))})";
    }
}
