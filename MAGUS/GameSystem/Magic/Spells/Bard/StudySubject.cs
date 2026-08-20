using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Tanulmány (Bárd — Fénymágia, Első Törvénykönyv p.144). Etches a studied creature's shape,
/// movement, and basic behavior into the bard's mind, halving detection odds each time a
/// Lényalkotás/Lényteremtés-type illusion of it is later cast (further studies keep halving it
/// again). Book duration is "végleges" (permanent); approximated as a long but finite value.
/// </summary>
public sealed class StudySubject : ISpell
{
    public string Name => "Study subject";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 180;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
