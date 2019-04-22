using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfPyarron
{
    class UwelPaladin : Paladin
    {
        public UwelPaladin(byte level = 1) : base(level) { }

		public override QualificationList Qualifications
		{
			get
			{
				var result = base.Qualifications;
				result.AddRange(
					new List<Qualification>()
					{
				new HeavyArmorWearing(),
				new ShieldUsing(),
				new WeaponBreaking(),
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
				new TrackReadingAndHiding(QualificationLevel.Master, 3),
				new Herbalism(level: 5),
				new WoundHealing(QualificationLevel.Master, 5),
				new HeavyArmorWearing(QualificationLevel.Master, 6)
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Uwel paladin");
    }
}
