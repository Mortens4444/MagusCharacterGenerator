using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Bűvhangszer (Bárd — Hangmágia, Első Törvénykönyv p.139). Changes the bard's instrument's
/// timbre to mimic any known instrument (or an invented one), and can multiply it into several
/// simulated players. Duration is 10 perc/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class MagicInstrument : ISpell
{
    public string Name => "Magic instrument";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
