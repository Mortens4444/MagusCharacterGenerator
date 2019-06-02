using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Races
{
    class Elf : Race, IUseRangedWeapons
    {
        public override short Strength => -2;

        public override short Speed => 1;

        public override short Dexterity => 1;

        public override short Stamina => -1;

        public override short Beauty => 1;

        public override QualificationList Qualifications => new QualificationList
        {
            new Running(QualificationLevel.Master),
            new Forestry(QualificationLevel.Master),
            new DressageTraining(QualificationLevel.Master),
			new FishingAndHunting(QualificationLevel.Master),
			new TrackReadingAndHiding(QualificationLevel.Master)
        };

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new BetterHearing(2),
            new BetterSeeing(2.5),
            new Infravision(50),
            new ResistanceToNecromantia(-8),
            new GoodArcher(20)
        };

        public override string ToString()
        {
            return Lng.Elem("Elf");
        }
    }
}
