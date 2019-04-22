using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Race
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/f%C3%A9lork-goblin-r67/
	/// </summary>
	class Goblin : Race
    {
        public override short Strength => -2;

        public override short Dexterity => 3;

        public override short Speed => 3;

        public override short Beauty => -4;

		public override short WillPower => -1;

		public override short Astral => -2;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new Infravision(10),
            new UndergroundMasters(5)
        };

        public override string ToString()
        {
            return Lng.Elem("Goblin");
        }
    }
}
