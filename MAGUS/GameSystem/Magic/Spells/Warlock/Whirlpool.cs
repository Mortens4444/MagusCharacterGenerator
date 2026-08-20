using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Örvény (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.255). Only usable on the
/// open sea. Creates a massive whirlpool that drags small boats and swimmers toward its center.
/// Book models this as a Strength-check-based drowning hazard for anyone dragged toward the
/// vortex center; too specific to this codebase's mechanics to represent as a flat modifier, so
/// this is flavor-only, no OnHit.
/// </summary>
public sealed class Whirlpool : ISpell
{
    public string Name => "Whirlpool";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 50;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    public int GetDamage() => 0;
}
