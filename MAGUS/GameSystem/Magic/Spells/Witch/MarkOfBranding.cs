using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Megbélyegzés csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.223, Type: Anyagi
/// Mágia/Mentálmágia). Marks the victim so the witch always recognizes them — even in disguise or
/// changed form — and can later cast Megfigyelés/Kihallgatás/Üzenet-family spells on them from any
/// distance; that cross-spell prerequisite isn't enforced here. Book duration is "maradandó"
/// (permanent); approximated as a long but finite value.
/// </summary>
public sealed class MarkOfBranding : ISpell
{
    public string Name => "Mark of branding";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 12;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
