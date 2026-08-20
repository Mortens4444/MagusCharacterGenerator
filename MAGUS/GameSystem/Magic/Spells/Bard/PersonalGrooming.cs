using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Személyes varázs (Bárd — Fénymágia, Első Törvénykönyv p.148). Hides wounds, grime, stubble and
/// disheveled hair/clothing on the bard, letting them look presentable even fresh off a battle.
/// Duration is 15 perc/szint in the book; level-1 baseline shown, not level-scaled. Purely
/// cosmetic — wounds aren't actually healed.
/// </summary>
public sealed class PersonalGrooming : ISpell
{
    public string Name => "Personal grooming illusion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
