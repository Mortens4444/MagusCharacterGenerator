using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szerelem varázs (Boszorkány — Asztrálmágia, Első Törvénykönyv p.209). Kindles genuine romantic
/// love toward the witch in a touched male of the same race. Book duration is "maradandó"
/// (permanent), approximated here as a long but finite value.
/// </summary>
public sealed class LoveSpell : ISpell
{
    public string Name => "Love spell";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 5;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
