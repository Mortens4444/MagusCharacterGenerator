using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Méregismeret (Boszorkánymester — Méregmágia, Első Törvénykönyv p.252). Identifies any poison
/// and reveals its most effective use and exact effects.
/// </summary>
public sealed class PoisonKnowledge : ISpell
{
    public string Name => "Poison knowledge";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
