using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/feh%C3%A9r-ork-r65/
	/// </summary>
	class WhiteOrc : Race
    {
        public override short Strength => 3;

        public override short Stamina => 1;

		public override short Dexterity => 1;

		public override short Speed => 1;

		public override short Health => 2;

        public override short Beauty => -2;

		public override short WillPower => -2;

		public override short Astral => -3;

		public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
		{
			new TrapDetect(40)
		};

		public override QualificationList Qualifications => new QualificationList
		{
			new TrackReadingAndHiding()
		};

		public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new Infravision(100),
            new UndergroundMasters(1),
            new BetterSniffing(12),
			new BetterHearing(2.5),
			new DragonSkin()
		};

        public override string ToString()
        {
            return Lng.Elem("White orc");
        }
    }
}
