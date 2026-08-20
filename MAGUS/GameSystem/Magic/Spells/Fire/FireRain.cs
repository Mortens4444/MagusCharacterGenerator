using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzeső (Tűzvarázsló, Első Törvénykönyv p.274-275). Burning clouds gather overhead and rain
/// fire down on a 5-step radius area for the spell's duration. Fire-school damage bypasses magic
/// resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireRain : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire rain";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
