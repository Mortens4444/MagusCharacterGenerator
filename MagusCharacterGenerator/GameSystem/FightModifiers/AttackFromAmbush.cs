using MagusCharacterGenerator.GameSystem.FightModifier;

namespace MagusCharacterGenerator.GameSystem.FightModifiers
{
    class AttackFromAmbush : IFightModifier
    {
        public short InitiatingValue => short.MaxValue;

        public short AttackingValue => 30;

        public short DefendingValue => 0;

        public short AimingValue => 10;
    }
}
