using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Lángoszlopok (Boszorkány — Tűzmágia, Első Törvénykönyv p.206-207). A stronger version of
/// Tűzgejzír: double-height flame columns that burn for two rounds instead of one. Duration is
/// kör/szint; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class FlameColumns : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Flame columns";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._4D6)]
    public int GetDamage() => diceThrow._4D6();
}
