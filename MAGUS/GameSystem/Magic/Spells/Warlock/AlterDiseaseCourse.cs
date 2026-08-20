using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Betegség befolyásolása (Boszorkánymester — Betegségmágia, Első Törvénykönyv p.257). Can worsen
/// or improve an existing disease's severity by touch. Book Mana cost scales with how many
/// severity categories the disease is shifted (worse or better); 12 is a representative mid-range
/// estimate. This codebase has no disease-progression simulation (severity stages, day/hour
/// timelines, contagion); this class exists only as a spellbook/catalog entry with no simulated
/// mechanical effect.
/// </summary>
public sealed class AlterDiseaseCourse : ISpell
{
    public string Name => "Alter disease course";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
