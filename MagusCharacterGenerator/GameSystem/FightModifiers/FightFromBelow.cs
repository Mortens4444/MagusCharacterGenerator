using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightFromBelow : IFightModifier
    {
        public short InitiatingValue => -2;

        public short AttackingValue => -10;

        public short DefendingValue => 0;

        public short AimingValue => -5;
    }
}
