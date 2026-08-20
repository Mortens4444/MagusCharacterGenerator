using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámvarázs I. (Boszorkánymester — Villámmágia, Első Törvénykönyv p.242). Fires a single
/// bolt of lightning from the caster's fingertip, up to 20 láb in a straight line. Book gives
/// this a ranged Célzó Dobás (aim roll) bonus of +35 CÉ, not modeled here since ISpell has no
/// aim-bonus field.
/// </summary>
public sealed class LightningBlastI : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning blast I";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
