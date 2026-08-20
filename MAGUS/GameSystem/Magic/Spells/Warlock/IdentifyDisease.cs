using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Betegség azonosítása (Boszorkánymester — Betegségmágia, Első Törvénykönyv p.257). Reveals full
/// information about a disease afflicting a touched creature: severity, effects, spread. This
/// codebase has no disease-progression simulation (severity stages, day/hour timelines,
/// contagion); this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect.
/// </summary>
public sealed class IdentifyDisease : ISpell
{
    public string Name => "Identify disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
