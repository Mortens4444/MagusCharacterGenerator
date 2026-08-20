using MAGUS.GameSystem;

namespace MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

/// <summary>
/// Őselem teremtése (p. 296). Creates a chosen primal element (Fire/Water/Earth/Air) at
/// Strength E, costing 4 Mp per E and dealing E dice of 1d6 Sp against creatures harmed by
/// that element.
/// </summary>
public sealed class PrimalElementCreation : IElementCreationMosaic
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Primal Element Creation";

    public int CastingTimeInSegments => 1;

    public int GetManaCost(int strength) => Validate(strength) * 4;

    public CreatedElement Create(OsElementType element, int strength)
    {
        Validate(strength);
        var damage = 0;
        for (var i = 0; i < strength; i++)
        {
            damage += diceThrow._1D6();
        }

        return new CreatedElement
        {
            OsElement = element,
            Strength = strength,
            Damage = damage
        };
    }

    private static int Validate(int strength) =>
        strength > 0 ? strength : throw new ArgumentOutOfRangeException(nameof(strength), "Strength (E) must be at least 1.");
}
