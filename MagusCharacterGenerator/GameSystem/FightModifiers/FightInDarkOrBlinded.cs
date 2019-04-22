using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightInDarkOrBlinded : IFightModifier
    {
        public short InitiatingValue => -20;

        public short AttackingValue => -60;

        public short DefendingValue => -70;

        public short AimingValue => -150;
    }
}
