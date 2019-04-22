using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightFromMovingHorse : IFightModifier
    {
        public short InitiatingValue => 5;

        public short AttackingValue => 10;

        public short DefendingValue => 20;

        public short AimingValue => -20;
    }
}
