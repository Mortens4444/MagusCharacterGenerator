using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámlánc (Boszorkánymester — Villámmágia, Első Törvénykönyv p.243). Book lets this bolt
/// chain from target to target within 20 láb at a cumulative accuracy penalty per jump; the
/// chaining mechanic isn't modeled here, this represents a single bolt's damage.
/// </summary>
public sealed class ChainLightning : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Chain lightning";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
