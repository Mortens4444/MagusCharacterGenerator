using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Enyészet posványa (Boszorkánymester — Rontás, Első Törvénykönyv p.251-252). Curses an area so
/// that rot and decay accelerate a hundredfold; organic matter and even stone crumble over time,
/// and creatures risk contracting disease. Book duration is "maradandó" (permanent); approximated
/// as a long but finite value. The decay/disease-risk effect on creatures in the zone isn't
/// modeled — flavor-only catalog entry.
/// </summary>
public sealed class SwampOfDecay : ISpell
{
    public string Name => "Swamp of decay";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
