using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Magic;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.Ranagol
{
    class KranRanagolPriest : Priest
    {
        public KranRanagolPriest(byte level = 1) : base(level) { }

		public override QualificationList FutureQualifications
		{
			get
			{
				var result = base.FutureQualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new MagicUsage(level: 3),
						new AntientLanguageKnowledge(AntientLanguage.Aquir, level: 5),
						new MagicUsage(QualificationLevel.Master, 6),
						new AntientLanguageKnowledge(AntientLanguage.Aquir, QualificationLevel.Master, 11)
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Ranagol priest (Kran)");
    }
}
