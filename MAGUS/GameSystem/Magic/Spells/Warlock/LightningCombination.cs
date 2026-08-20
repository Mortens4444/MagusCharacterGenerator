using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Kombináció (Boszorkánymester — Villámmágia, Első Törvénykönyv p.243). Combines the
/// turning/reflecting properties onto Villámvarázs II/III. A meta-spell with no damage of its
/// own, flavor-only catalog entry.
/// </summary>
public sealed class LightningCombination : ISpell
{
    public string Name => "Lightning combination";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
