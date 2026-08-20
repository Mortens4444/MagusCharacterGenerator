using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Sötétté gyalázás (Boszorkánymester — Lélekvarázs, Első Törvénykönyv p.256). Book requires both
/// Astral and Mental resistance rolls; ISpell only models one ResistanceType, so Astral is used
/// here. Turns the victim's alignment/allegiance dark; no combat mechanic modeled beyond the
/// resistance roll.
/// </summary>
public sealed class CorruptToDarkness : ISpell
{
    public string Name => "Corrupt to darkness";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => 10;

    public int ManaCost => 30;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
