using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Üldözési mánia (Boszorkány — Asztrálmágia, Első Törvénykönyv p.213). Convinces victims that
/// everyone is out to kill them, making them isolate and refuse sustained cooperation with anyone.
/// No explicit duration given; a representative 60-round value is used here.
/// </summary>
public sealed class PersecutionMania : ISpell
{
    public string Name => "Persecution mania";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
