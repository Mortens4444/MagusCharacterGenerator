using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzzápor (Tűzvarázsló, Első Törvénykönyv p.275). Burning clouds up to 20 feet overhead shower
/// fire onto a 5-step radius area for the spell's duration. Fire-school damage bypasses magic
/// resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireShower : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire shower";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
