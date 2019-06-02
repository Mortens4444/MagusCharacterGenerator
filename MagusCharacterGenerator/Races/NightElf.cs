using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/%C3%A9ji-elf-r54/
	/// </summary>
	class NightElf : Race, IUseRangedWeapons
    {
        public override short Strength => -2;

        public override short Stamina => -1;

		public override short Speed => 1;

        public override short Dexterity => 1;

		public override short WillPower => -1;

		public override short Astral => -1;

		public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new BetterHearing(1.5),
            new BetterSeeing(1.5),
            new Ultravision(10),
            new Invisibility(),
        };

		public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
		{
			new Sneaking(10),
			new Climbing(10),
			new Stealth(10)
		};

		public override string ToString()
        {
            return Lng.Elem("Night-elf");
        }
    }
}
