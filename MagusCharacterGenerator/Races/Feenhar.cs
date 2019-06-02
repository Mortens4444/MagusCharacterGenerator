using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/feenhar-r64/
	/// Bestiárium 99. oldal
	/// </summary>
	class Feenhar : Race
    {
        public override short Dexterity => 1;

        public override short Speed => 1;

        public override short Beauty => -2;

		public override short Astral => -1;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new CanFly(),
            new BetterSeeing(2.5),
			new CantLearnPsi(),
			new CanUseTelepathy(),
			new GoodArcher(15),
			new NightVision(),
			new CanCallAirElemental(),
			new PoisionResistanceEqualWithHealth(),
			new MagicResistanceGrowWithLevelUp(),
			new CanCallBigBird(),
			new CanCallBirds()
		};

        public override string ToString()
        {
            return Lng.Elem("Feenhar");
        }
    }
}
