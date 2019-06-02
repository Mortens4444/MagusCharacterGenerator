using MagusCharacterGenerator.GameSystem.Languages;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/fajok-az-%C3%BAt-szerint-r21/
	/// </summary>
	class Kyr : Race
    {
        public override short Strength => -2;

        public override short Beauty => 1;

        public override short Intelligence => -2;

		public override short WillPower => 1;

        public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new Infravision(50),
            new UndergroundMasters(2),
            new BetterSniffing(8)
        };

		public override QualificationList Qualifications => new QualificationList
		{
			new AntientLanguageKnowledge(AntientLanguage.Kyr),
			new Etiquette()
		};

		public override string ToString()
        {
            return Lng.Elem("Kyr");
        }
    }
}
