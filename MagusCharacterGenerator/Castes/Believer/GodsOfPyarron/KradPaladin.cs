using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfPyarron
{
	class KradPaladin : Paladin
    {
        public KradPaladin(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new LanguageKnowledge(3),
						new LanguageKnowledge(3),
						new LanguageKnowledge(3),
						new LanguageKnowledge(3),
						new Herbalism(),
						new LegendKnowledge(),
						new HistoryKnowledge(),
						new Forestry(),
						new Cartography(),
						new Swimming()
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
						new LegendKnowledge(QualificationLevel.Master, 5),
						new HistoryKnowledge(QualificationLevel.Master, 5),
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Krad paladin");
    }
}
