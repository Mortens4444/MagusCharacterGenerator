using MagusCharacterGenerator.GameSystem.Qualifications;
using Mtf.Languages;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class Infravision : ISpecialQualification
    {
        public byte DistanceInMeters { get; }

        public Infravision(byte distanceInMeters)
        {
            DistanceInMeters = distanceInMeters;
        }

        public override string ToString() => Lng.Elem("Infravision");
    }
}
