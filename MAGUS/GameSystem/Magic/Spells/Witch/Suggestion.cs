using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Sugallat (Boszorkány — Mentálmágia, Első Törvénykönyv p.217-218). A telepathic suggestion
/// planted in the target's mind on a failed Mental resistance roll; lasts until the suggested
/// task is carried out, approximated here as instantaneous.
/// </summary>
public sealed class Suggestion : ISpell
{
    public string Name => "Suggestion";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 1;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
