using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfPyarron
{
    class KyelPriest : Priest
    {
        public KyelPriest(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new WeaponUsage(),
						new WeaponUsage(),
						new WeaponUsage(),
						new ShieldUsing(),
						new HeavyArmorWearing(),
						new WeaponKnowledge(),
						new Leadership(),
						new LanguageKnowledge(3),
						new LanguageKnowledge(3),
						new LanguageKnowledge(2),
						new Etiquette(QualificationLevel.Master),
						new WoundHealing(),
						new Herbalism(),
						new Disarmament()
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
						new Cartography(level: 3),
						new WoundHealing(QualificationLevel.Master, 4),
						new Herbalism(QualificationLevel.Master, 5),
						new Physiology(level: 6),
						new Disarmament(QualificationLevel.Master, 7),
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Kiel priest");
    }
}
