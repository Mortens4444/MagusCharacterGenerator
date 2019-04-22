using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class FightAsDizzily : IFightModifier
    {
        public short InitiatingValue => -15;

        public short AttackingValue => -20;

        public short DefendingValue => -25;

        public short AimingValue => -30;
    }
}
