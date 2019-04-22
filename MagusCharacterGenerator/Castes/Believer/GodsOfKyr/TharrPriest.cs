using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfKyr
{
    class TharrPriest : Priest
    {
        public TharrPriest(byte level = 1) : base(level) { }

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
						new WeaponThrowing(),
						new AntientLanguageKnowledge(QualificationLevel.Master),
						new PoisoningAndNeutralization(),
						new Backstab(),
						new Alchemy(),
						new Demonology()
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
						new Alchemy(QualificationLevel.Master, 3),
						new Demonology(QualificationLevel.Master, 4),
						new RuneMagic(level: 6)
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Tharr priest");
    }
}
