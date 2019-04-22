using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Percentages;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;
using System.Collections.Generic;

namespace MagusCharacterGenerator.Race
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/faun-h%C3%BCll%C5%91-r63/
	/// </summary>
	class Reptile : Race
    {
        public override short Strength => 1;

        public override short Speed => 2;

        public override short Dexterity => 2;

        public override short Stamina => -1;

        public override short Beauty => -3;

        public override short WillPower => -1;

        public override short Intelligence => -1;

        public override short Astral => -2;

		public override List<PercentQualification> PercentQualifications => new List<PercentQualification>
		{
			new Climbing(40),
			new Jumping(30),
			new Falling(20)
		};

		public override QualificationList Qualifications => new QualificationList
		{
			new Running(),
			//new Akkrobatika(),
			//new Célzás(),
		};

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			new Infravision(50),
			new BetterSniffing(2)
			//Savas nyál naponta 2x (Té: +20, Sebzés: k6)
			// InvisibleFrom3rdLevelIfSorcerer
			// AlakváltásFrom7thLevelIfSorcerer
		};

        public override string ToString()
        {
            return Lng.Elem("Reptile");
        }
    }
}
