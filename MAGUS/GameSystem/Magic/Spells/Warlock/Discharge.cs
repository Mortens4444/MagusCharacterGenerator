using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Kisülés (Boszorkánymester — Villámmágia, Első Törvénykönyv p.241-242). Gathers raw pulsing
/// energy into the caster's palm, discharged into a touched victim on a successful attack. Book
/// lets the caster charge up to 4 rounds before releasing, scaling the damage; simplified to a
/// flat 1D10 released-on-touch effect.
/// </summary>
public sealed class Discharge : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Discharge";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 8;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
