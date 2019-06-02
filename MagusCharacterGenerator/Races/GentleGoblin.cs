﻿using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B3dexe-r61/
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
	/// </summary>
	class GentleGoblin : Race
    {
        public override short Strength => -2;

        public override short Stamina => 1;

        public override short Intelligence => -1;

		public override short Health => 1;

        public override short Beauty => -2;

		public override short Astral => -2;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new Infravision(20),
            new UndergroundMasters(5),
			new BetterSniffing(3)
        };

        public override string ToString()
        {
            return Lng.Elem("Gentle goblin");
        }
    }
}
