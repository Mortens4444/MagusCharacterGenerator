using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Betegség gyógyítása (Boszorkánymester — Betegségmágia, Első Törvénykönyv p.256-257). Cures
/// any disease of "Very severe" severity or lower with two minutes of concentration, touch range.
/// This codebase has no disease-progression simulation (severity stages, day/hour timelines,
/// contagion); this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect.
/// </summary>
public sealed class CureDisease : ISpell
{
    public string Name => "Cure disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 120;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
