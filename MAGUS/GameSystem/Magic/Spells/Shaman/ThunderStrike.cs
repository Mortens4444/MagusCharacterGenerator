using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Villám (Sámán — Természeti mágia, Második Törvénykönyv p.126). A muttered word during
/// Szellemtánc calls down an unavoidable bolt of lightning on a target the shaman can see; deals
/// 1D10 SP (scaling +1D10 per further 7 Mp, not modeled) and follows the M.A.G.U.S. Villámmágia
/// hit-location rules (p.174). No dodge/cover is possible per the book, hence Power is null.
/// </summary>
public sealed class ThunderStrike : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Thunder strike";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
