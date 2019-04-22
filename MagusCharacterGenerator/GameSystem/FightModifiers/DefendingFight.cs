using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class DefendingFight : IFightModifier
    {
        public short InitiatingValue => short.MinValue;

        public short AttackingValue => 0;

        public short DefendingValue => 40;

        public short AimingValue => 0;
    }
}
