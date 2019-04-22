using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class GoodArcher : ISpecialQualification
    {
        public byte AimingBase { get; }

        public GoodArcher(byte aimingBase)
        {
            AimingBase = aimingBase;
        }
    }
}
