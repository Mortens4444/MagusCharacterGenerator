using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Helper;
using Mtf.Languages;
using System;

namespace MagusCharacterGenerator.Qualifications.Scientific
{
	class AntientLanguageKnowledge : Qualification, ICanHaveMany
	{
        public AntientLanguage Language { get; set; }

        public AntientLanguageKnowledge(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
            : base(qualificationLevel, level)
        {
        }

		public AntientLanguageKnowledge(AntientLanguage language, QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
			: base(qualificationLevel, level)
		{
			Language = language;
		}

		public override string ToString() => $"{Lng.Elem("Antient language knowledge")} ({Lng.Elem(EnumUtils.GetDescription(Language))})";
    }
}
