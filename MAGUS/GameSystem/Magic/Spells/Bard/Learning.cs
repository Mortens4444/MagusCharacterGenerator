using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Tanulás (Bárd — Egyéb bárdmágiák, Első Törvénykönyv p.149, Type: Mentális). Lets the bard
/// instantly memorize a heard song or poem well enough to perform it immediately. Book duration
/// matches the performance length and is permanent thereafter; approximated as a long but finite
/// value.
/// </summary>
public sealed class Learning : ISpell
{
    public string Name => "Learning";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 6;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
