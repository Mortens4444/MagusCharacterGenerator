using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Távoli üzenet (Bárd — Hangmágia, Első Törvénykönyv p.137). Lets the bard whisper a message
/// (up to 2 minutes long) to a known person at any distance; only that person hears it. The
/// book's exact mana cost was illegible in the scanned source page; 6 is an estimate consistent
/// with similarly-scoped utility spells in this chapter.
/// </summary>
public sealed class DistantMessage : ISpell
{
    public string Name => "Distant message";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 120;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
