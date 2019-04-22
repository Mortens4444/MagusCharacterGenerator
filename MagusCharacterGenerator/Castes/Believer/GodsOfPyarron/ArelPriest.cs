using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Castes.Believer.GodsOfPyarron
{
    class ArelPriest : Priest
    {
        public ArelPriest(byte level = 1) : base(level) { }

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
						new WeaponKnowledge(),
						new LanguageKnowledge(4),
						new LanguageKnowledge(3),
						new LanguageKnowledge(2),
						new WeatherForecast(),
						new Herbalism(),
						new WoundHealing(),
						new DressageTraining(),
						new Forestry(QualificationLevel.Master),
						new FishingAndHunting(QualificationLevel.Master),
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
						new PubFighting(level: 2),
						new LegendKnowledge(level: 3),
						new TrapSetup(level: 4),
						new TrackReadingAndHiding(level: 5),
						new WeaponUsage(QualificationLevel.Master, 9),
					}
				);
				return result;
			}
		}

		public override string ToString() => Lng.Elem("Arel priest");
    }
}
