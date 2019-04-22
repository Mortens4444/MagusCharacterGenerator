using System.Collections.Generic;
using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Battle;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Race
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-k%C3%B6nyve-r62/
	/// </summary>
	class Draquon : Race
	{
		public override short Strength => 2;

		public override short Stamina => 1;

		public override short Health => 1;

		public override short Beauty => -1;

		public override short Astral => -2;

		public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
		{
			new Climbing((byte)((DiceThrow._1K6() + 4) * 10)),
			new Falling((byte)((DiceThrow._1K3() + 3) * 10)),
			new Stealth((byte)((DiceThrow._1K5() + 2) * 10)),
		};

		public override QualificationList Qualifications => new QualificationList
		{
			new Demonology(),
			new WeaponBreaking(QualificationLevel.Master),
		};

		public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			new CanFly(),
			new BetterSeeing(1.5),
			new Ultravision(50),
			new CantLearnPsi(),
			new ExtraMagicResistanceOnLevelUp(5),
			new CanUseTelepathy(),
			//new LockPicking(-30)
			//new PickPocketing(-30)
			new NotTolerateStrongLight(12, -20)
		};

        public override string ToString()
        {
            return Lng.Elem("Draquon");
        }
    }
}
