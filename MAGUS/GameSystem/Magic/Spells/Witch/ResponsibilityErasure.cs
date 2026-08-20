using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Felelősségérzet megszűntetése (Boszorkány — Asztrálmágia, Első Törvénykönyv p.211). Makes the
/// target purely self-interested, abandoning even close friends without hesitation. Duration is
/// level-difference-based (1 day per level the caster exceeds the target, else 1 hour) in the
/// book; approximated here as a flat 1-hour (360-round) duration.
/// </summary>
public sealed class ResponsibilityErasure : ISpell
{
    public string Name => "Responsibility erasure";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 7;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
