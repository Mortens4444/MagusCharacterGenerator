using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Race
{
	class Amund : Race
    {
        public override short Strength => 1;

        public override short Stamina => 1;

        public override short Beauty => 3;

        public override short Astral => -1;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			new CantLearnPsi(),
			new ExtraMagicResistanceOnLevelUp(4),
			new MagicalResistanceRegeneration()
		};

        public override string ToString()
        {
            return Lng.Elem("Amund");
        }
    }
}
