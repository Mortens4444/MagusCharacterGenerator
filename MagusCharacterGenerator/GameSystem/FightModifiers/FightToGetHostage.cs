using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightToGetHostage : IFightModifier
    {
        public short InitiatingValue => -5;

        public short AttackingValue => -5;

        public short DefendingValue => -15;

        public short AimingValue => 0;
    }
}
