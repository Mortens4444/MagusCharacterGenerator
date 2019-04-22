using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightWithHate : IFightModifier
    {
        public short InitiatingValue => 3;

        public short AttackingValue => 10;

        public short DefendingValue => -20;

        public short AimingValue => -20;
    }
}
