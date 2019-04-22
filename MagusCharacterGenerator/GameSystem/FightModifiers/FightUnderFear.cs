using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightUnderFear : IFightModifier
    {
        public short InitiatingValue => -10;

        public short AttackingValue => -15;

        public short DefendingValue => +5;

        public short AimingValue => -20;
    }
}
