using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fényvért (Bárd — Fénymágia, Első Törvénykönyv p.146). Conjures the illusory image of armor and
/// a shield around the bard. Duration is 2 perc/szint in the book; level-1 baseline shown, not
/// level-scaled. Book gives attackers who don't realize it's illusion a -25 Támadó (attack)
/// penalty against the bard specifically; not modeled here since it's a self-buff, not an
/// enemy-targeted effect — isn't wired into the enemy-targeting combat pipeline, matching how
/// Blessing.cs (Priest) handles ally/self buffs.
/// </summary>
public sealed class LightArmor : ISpell
{
    public string Name => "Light armor illusion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
