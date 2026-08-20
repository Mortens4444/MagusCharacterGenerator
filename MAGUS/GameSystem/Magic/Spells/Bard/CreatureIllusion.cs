using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Lényalkotás (Bárd — Fénymágia, Első Törvénykönyv p.143). Conjures the illusory image of a
/// creature that can move freely (unlike Illúzió's fixed column) and obeys the bard's thoughts.
/// Duration is 15 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class CreatureIllusion : ISpell
{
    public string Name => "Creature illusion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
