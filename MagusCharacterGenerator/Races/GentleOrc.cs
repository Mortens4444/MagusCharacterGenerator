using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	class GentleOrc : Race
    {
        public override short Strength => 2;

        public override short Stamina => 1;

        public override short Health => 2;

        public override short Beauty => -3;

        public override short Intelligence => -1;

        public override short Astral => -3;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new Infravision(45),
            new UndergroundMasters(12),
            new BetterSniffing(5)
        };

        public override string ToString()
        {
            return Lng.Elem("Gentle orc");
        }
    }
}
