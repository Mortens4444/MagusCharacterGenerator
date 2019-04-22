namespace MagusCharacterGenerator.GameSystem.FightModifier
{
    interface IFightModifier
    {
        short InitiatingValue { get; }

        short AttackingValue { get; }

        short DefendingValue { get; }

        short AimingValue { get; }
    }
}
