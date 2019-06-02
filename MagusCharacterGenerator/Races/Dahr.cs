using MagusCharacterGenerator.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/dahr-r51/
	/// </summary>
	class Dahr : Race
    {
        public override short Strength => -2;

        public override short Stamina => 1;

		public override short Speed => 2;

		public override short Health => -2;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			// Villámmágia
        };

        public override string ToString()
        {
            return Lng.Elem("Dahr");
        }
    }
}
