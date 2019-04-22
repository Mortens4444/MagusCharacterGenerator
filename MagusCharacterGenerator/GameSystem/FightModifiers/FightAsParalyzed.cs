using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightAsParalyzed : IFightModifier
    {
        public short InitiatingValue => -30;

        public short AttackingValue => -40;

        public short DefendingValue => -35;

        public short AimingValue => -15;
    }
}
