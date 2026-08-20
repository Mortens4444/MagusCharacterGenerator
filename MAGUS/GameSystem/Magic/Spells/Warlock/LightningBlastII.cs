using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámvarázs II. (Boszorkánymester — Villámmágia, Első Törvénykönyv p.242). A more reliable
/// version of Villámvarázs I. More accurate version (+70 CÉ in the book), not modeled here.
/// </summary>
public sealed class LightningBlastII : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning blast II";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
