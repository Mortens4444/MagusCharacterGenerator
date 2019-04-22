using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightInOnePlace : IFightModifier
    {
        public short InitiatingValue => -20;

        public short AttackingValue => -15;

        public short DefendingValue => -5;

        public short AimingValue => 0;
    }
}
