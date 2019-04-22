using MagusCharacterGenerator.GameSystem;
using MagusCharacterGenerator.GameSystem.FightModifier;
using MagusCharacterGenerator.GameSystem.Qualifications;

namespace MagusCharacterGenerator.Qualifications.Specialities
{
    class GladiatorFightInFrontOfAudience : ISpecialQualification, IFightModifier
    {
        public short InitiatingValue => 5;

        public short AttackingValue => 5;

        public short DefendingValue => 5;

        public short AimingValue => 0;
    }
}
