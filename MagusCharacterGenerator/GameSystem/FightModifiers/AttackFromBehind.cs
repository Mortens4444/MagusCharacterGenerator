using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class AttackFromBehind : IFightModifier
    {
        public short InitiatingValue => 5;

        public short AttackingValue => 10;

        public short DefendingValue => 0;

        public short AimingValue => 0;
    }
}
