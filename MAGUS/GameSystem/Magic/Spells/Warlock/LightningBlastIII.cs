using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámvarázs III. (Boszorkánymester — Villámmágia, Első Törvénykönyv p.242). The deadliest
/// form of Villámvarázs. Most accurate version (+100 CÉ in the book), not modeled here.
/// </summary>
public sealed class LightningBlastIII : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning blast III";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 31;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 4;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
