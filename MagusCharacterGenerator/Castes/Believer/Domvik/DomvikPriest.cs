using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.Domvik
{
    class DomvikPriest : Priest
    {
        public DomvikPriest(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new WeaponUsage(),
						new ShieldUsing(),
						new AntientLanguageKnowledge(AntientLanguage.LinguaDomini),
						new WoundHealing(),
						new PoisoningAndNeutralization(),
						new Heraldry(),
						new Riding()
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
						new ReadingAndWriting(QualificationLevel.Master),
						new AntientLanguageKnowledge(AntientLanguage.LinguaDomini, QualificationLevel.Master, 3),
						new PoisoningAndNeutralization(QualificationLevel.Master, 3),
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Domvik priest");
    }
}
