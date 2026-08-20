using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Zajkeltés (Bárd — Hangmágia, Első Törvénykönyv p.137). Conjures a brief, arbitrary noise from
/// a chosen direction (a creaking door, a distant footstep) — cheaper than full Sound creation.
/// </summary>
public sealed class NoiseCreation : ISpell
{
    public string Name => "Noise creation";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
