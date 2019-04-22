using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class Charge : IFightModifier
    {
        public short InitiatingValue => 0;

        public short AttackingValue => 20;

        public short DefendingValue => -25;

        public short AimingValue => -30;
    }
}
