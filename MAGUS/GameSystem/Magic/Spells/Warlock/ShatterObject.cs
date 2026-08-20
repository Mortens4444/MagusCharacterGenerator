using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szilánkokra robbantás (Boszorkánymester — Anyagmágia, Első Törvénykönyv p.244). Shatters a
/// solid object up to 3kg into shrapnel, damaging anyone within 1 láb of the blast.
/// </summary>
public sealed class ShatterObject : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Shatter object";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
