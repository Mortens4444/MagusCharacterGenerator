using MagusCharacterGenerator.GameSystem.Valuables;

namespace MagusCharacterGenerator.GameSystem.Weapons
{
    interface IWeapon
    {
        double AttacksPerRound { get; }

        byte InitiatingValue { get; }

        double Weight { get; }

        Money Price { get; }

        byte GetDamage();
    }
}
