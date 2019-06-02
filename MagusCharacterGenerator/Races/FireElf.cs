using MagusCharacterGenerator.GameSystem.FightMode;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/elf-t%C5%B1zelf-alfaj-r58/
	/// </summary>
	class FireElf : Race, IUseRangedWeapons
    {
        public override short Strength => -2;

        public override short Speed => 1;

        public override short Dexterity => 1;

        public override short Stamina => -1;

        public override short Beauty => 1;

        public override QualificationList Qualifications => new QualificationList
        {
            new DressageTraining(),
            new Forestry(QualificationLevel.Master),
            new Running(QualificationLevel.Master),
		};

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new BetterHearing(1.5),
            new BetterSeeing(2),
            new Infravision(30),
            new ResistanceToNecromantia(-8),
            new GoodArcher(15),
            new FireMagic()
		};

        public override string ToString()
        {
            return Lng.Elem("Fire-elf");
        }
    }
}
