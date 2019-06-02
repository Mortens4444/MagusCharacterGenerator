using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
    class Khal : Race
    {
        public override short Strength => 3;

        public override short Speed => 2;

        public override short Dexterity => 1;

        public override short Stamina => 2;

        public override short Health => 3;

        public override short WillPower => -1;

        public override short Astral => -5;

		public override QualificationList Qualifications => new QualificationList
		{
			new Forestry(),
			new FishingAndHunting(),
			new WeatherForecast(),
			new Swimming(),
			new Running(QualificationLevel.Master),
			new Demonology()
		};

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			new BetterSeeing(2),
			new BetterHearing(2),
			new BetterSniffing(5)
		};

        public override string ToString()
        {
            return Lng.Elem("Khal");
        }
    }
}
