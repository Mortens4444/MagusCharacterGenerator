using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Gyanú (Boszorkány — Asztrálmágia, Első Törvénykönyv p.213). Makes victims distrustful of
/// everyone, unwilling to cooperate even with allies. The book gives no explicit duration figure;
/// a representative 60-round value is used here.
/// </summary>
public sealed class Suspicion : ISpell
{
    public string Name => "Suspicion";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
