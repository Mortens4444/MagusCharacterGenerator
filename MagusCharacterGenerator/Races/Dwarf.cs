using System.Collections.Generic;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
    class Dwarf : Race
    {
        public override short Strength => 1;

        public override short Stamina => 1;

        public override short Health => 1;

        public override short Beauty => -2;

        public override short Intelligence => -1;

        public override short Astral => -1;

        public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
        {
            new TrapDetect(35),
            new SecretDoorSearching(30)
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new Infravision(30),
            new PerfectTimeDetection(),
            new UndergroundMasters(2),
            new GoodBuildingAgeGuess()
        };

        public override string ToString()
        {
            return Lng.Elem("Dwarf");
        }
    }
}
