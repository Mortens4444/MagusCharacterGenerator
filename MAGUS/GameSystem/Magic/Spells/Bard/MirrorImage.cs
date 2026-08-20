using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hasonmás (Bárd — Fénymágia, Első Törvénykönyv p.140-141). Creates illusory duplicates of the
/// bard, indistinguishable from the original, halving an attacker's Defense value against the
/// real bard until they realize the trick. Self-buff (creates duplicate images); not wired into
/// the enemy-targeting pipeline. Mana cost is per duplicate in the book; base cost for one shown.
/// </summary>
public sealed class MirrorImage : ISpell
{
    public string Name => "Mirror image";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
