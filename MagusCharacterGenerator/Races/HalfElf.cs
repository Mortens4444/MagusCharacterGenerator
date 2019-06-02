using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Races
{
    class HalfElf : Race, IUseRangedWeapons
    {
        public override short Strength => -1;

        public override short Speed => 1;
		
        public override QualificationList Qualifications => new QualificationList
        {
            new Riding(QualificationLevel.Master),
            new DressageTraining(QualificationLevel.Master)
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new BetterHearing(1.5),
            new BetterSeeing(2),
            new GoodRunner(),
            new Infravision(10),
            new ResistanceToNecromantia(-6),
            new GoodArcher(10)
        };

        public override string ToString()
        {
            return Lng.Elem("Half-elf");
        }
    }
}
