using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.Domvik
{
	class DomvikPaladin : Paladin
    {
        public DomvikPaladin(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new AntientLanguageKnowledge(AntientLanguage.LinguaDomini),
						new WoundHealing(),
					}
				);
				return result;
			}
		}

		public override QualificationList FutureQualifications
		{
			get
			{
				var result = base.FutureQualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new AntientLanguageKnowledge(AntientLanguage.LinguaDomini, QualificationLevel.Master, 4),
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Domvik paladin");
    }
}
