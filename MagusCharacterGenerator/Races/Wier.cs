using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	class Wier : Race
    {
        public override short Beauty => 1;

        public override short Intelligence => 1;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			new Infravision(30),
			new BetterHearing(2),
			new BetterSniffing(2)
		};

        public override string ToString()
        {
            return Lng.Elem("Wier");
        }
    }
}
