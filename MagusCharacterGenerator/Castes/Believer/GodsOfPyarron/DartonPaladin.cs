using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfPyarron
{
    class DartonPaladin : Paladin
    {
        public DartonPaladin(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new Wrestling(),
						new WeaponBreaking(),
						new PoisoningAndNeutralization(),
						new TrapSetup(),
						new PubFighting(),
						new CardSharper()
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
						new PubFighting(QualificationLevel.Master, 3),
						new DressageTraining(level: 3),
						new CardSharper(QualificationLevel.Master, 4),
						new WeaponUsage(QualificationLevel.Master, 4),
						new Backstab(level: 7)
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Darton paladin");
    }
}
