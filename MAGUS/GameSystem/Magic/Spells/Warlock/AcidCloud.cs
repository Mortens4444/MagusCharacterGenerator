using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Savfelhő (Boszorkánymester — Anyagmágia, Első Törvénykönyv p.244-245). Conjures a drifting
/// cloud of acid spray that burns anyone caught in it each round. Duration is kör/szint in the
/// book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class AcidCloud : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Acid cloud";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 13;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
