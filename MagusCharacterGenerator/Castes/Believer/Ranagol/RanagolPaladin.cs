using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Underworld;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.Ranagol
{
    class RanagolPaladin : Paladin
	{
		public RanagolPaladin(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
						new WeaponThrowing(),
						new WeaponBreaking(),
						new Backstab()
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
						new PoisoningAndNeutralization(level: 3),
						new Backstab(QualificationLevel.Master, 6)
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Ranagol paladin");
    }
}
