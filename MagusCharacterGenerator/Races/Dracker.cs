using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Scientific;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Races
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/dracker-r52/
	/// </summary>
	class Dracker : Race
    {
        public override short Strength => 1;

        public override short Stamina => 1;

		public override short Speed => 1;

		public override short Health => -1;

		public override QualificationList Qualifications => new QualificationList
		{
			new DressageTraining(),
			new Forestry(),
			new LanguageKnowledge(4),
			new LanguageKnowledge(3),
			new LanguageKnowledge(3),
		};

		public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
			new BetterSeeing(1.5),
			// Mágiaellenállás * 2,
			new Ultravision(25),
			new ResistanceToWaterMagic(-6)
		};

        public override string ToString()
        {
            return Lng.Elem("Dracker");
        }
    }
}
