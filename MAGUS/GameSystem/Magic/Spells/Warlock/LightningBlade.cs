using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Villámpenge (Boszorkánymester — Villámmágia, Első Törvénykönyv p.242). Wraps a one-handed
/// blade in raw crackling lightning energy; damage is added to the weapon's own.
/// </summary>
public sealed class LightningBlade : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Lightning blade";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 5;

    [DiceThrow(ThrowType._1D10)]
    public int GetDamage() => diceThrow._1D10();
}
