using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class UndergroundMasters : ISpecialQualification
    {
        public byte DeviationInMeters { get; }

        public UndergroundMasters(byte deviationInMeters)
        {
            DeviationInMeters = deviationInMeters;
        }
    }
}
