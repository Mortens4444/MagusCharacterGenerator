using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class ExtraPsiPointOnLevelUp : ISpecialQualification
    {
        public byte ExtraPoints { get; }

        public ExtraPsiPointOnLevelUp(byte extraPoints)
        {
			ExtraPoints = extraPoints;
        }
    }
}
