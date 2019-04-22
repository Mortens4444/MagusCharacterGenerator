using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class AttackFromHalfBehind : IFightModifier
    {
        public short InitiatingValue => 2;

        public short AttackingValue => 5;

        public short DefendingValue => 0;

        public short AimingValue => 0;
    }
}
