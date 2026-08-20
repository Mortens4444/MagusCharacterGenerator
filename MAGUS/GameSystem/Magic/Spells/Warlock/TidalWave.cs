using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szökőár (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.254). Only usable near
/// large bodies of water (rivers, lakes, seas). Raises a tidal wave that capsizes ships and
/// sweeps away everything in its path.
/// </summary>
public sealed class TidalWave : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Tidal wave";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 90;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    [DiceThrow(ThrowType._15D6)]
    public int GetDamage() => diceThrow._15D6();
}
