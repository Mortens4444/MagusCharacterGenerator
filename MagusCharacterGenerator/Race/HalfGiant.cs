using MagusCharacterGenerator.GameSystem.Qualifications;
using MagusCharacterGenerator.Qualifications;
using MagusCharacterGenerator.Qualifications.Laical;
using MagusCharacterGenerator.Qualifications.Specialities;
using Mtf.Languages;

namespace MagusCharacterGenerator.Race
{
	/// <summary>
	/// https://kalandozok.hu/cikkgyujtemeny/kieg%C3%A9sz%C3%ADt%C5%91k/fajok/j%C3%A1tszhat%C3%B3-fajok/f%C3%A9lork-goblin-r67/
	/// </summary>
	abstract class HalfGiant : Race
    {
        public override short Strength => 3;

        public override short Stamina => 2;

        public override short Health => 3;

        public override short Beauty => -1;

        public override short Intelligence => -1;

		public override short Speed => -1;

		public override short Astral => -3;

		public override QualificationList Qualifications => new QualificationList
		{
			new Running(),
			new FishingAndHunting(QualificationLevel.Master)
		};

		public override SpecialQualificationList SpecialQualifications => new SpecialQualificationList
        {
            new DoubledPainToleranceBase(),
            new AdditionalLifePoints(3),
        };

        public override string ToString()
        {
            return Lng.Elem("Half-giant");
        }
    }
}
