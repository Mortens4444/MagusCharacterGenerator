namespace MagusCharacterGenerator.GameSystem.Weapons
{
    interface IMeleeWeapon : IWeapon
    {
        byte AttackingValue { get; }

        byte DefendingValue { get; }
    }
}