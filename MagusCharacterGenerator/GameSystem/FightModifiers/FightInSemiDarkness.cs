using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightInSemiDarkness : IFightModifier
    {
        public short InitiatingValue => -15;

        public short AttackingValue => -30;

        public short DefendingValue => -35;

        public short AimingValue => -70;
    }
}
