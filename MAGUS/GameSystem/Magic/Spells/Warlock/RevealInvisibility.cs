using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Láthatatlanság felfedezése (Boszorkánymester — Mentálmágia, Első Törvénykönyv p.255). Pinpoints
/// a suspected invisible creature's location via their thoughts.
/// </summary>
public sealed class RevealInvisibility : ISpell
{
    public string Name => "Reveal invisibility";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => 3;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 72;

    public int GetDamage() => 0;
}
