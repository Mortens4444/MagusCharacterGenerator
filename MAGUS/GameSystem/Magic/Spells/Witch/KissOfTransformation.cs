using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Átváltoztatás csókja (Boszorkány — Csókmágia, Első Törvénykönyv p.223). Transforms the victim
/// into an animal of the witch's choosing for the duration; the transformation itself (species,
/// physical changes) isn't modeled beyond the spell existing as a catalog entry. Book requires
/// both Asztrális and Mentális resistance rolls; Astral is modeled here. Book duration is "1 nap
/// (vagy lásd Csókmágia)" — the base 1-day figure is shown; the extension clause isn't modeled.
/// </summary>
public sealed class KissOfTransformation : ISpell
{
    public string Name => "Kiss of transformation";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 80;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
