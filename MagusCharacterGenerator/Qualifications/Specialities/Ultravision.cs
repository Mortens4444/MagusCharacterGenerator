using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class Ultravision : ISpecialQualification
    {
        public byte DistanceInMeters { get; }

        public Ultravision(byte distanceInMeters)
        {
            DistanceInMeters = distanceInMeters;
        }

        public override string ToString() => Lng.Elem("Ultravision");
    }
}
