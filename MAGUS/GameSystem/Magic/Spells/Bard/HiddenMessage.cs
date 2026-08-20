using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Rejtett üzenet (Bárd — Hangmágia, Első Törvénykönyv p.138). Lets the bard speak aloud, even in
/// a crowd, so only chosen listeners understand the scrambled words correctly.
/// </summary>
public sealed class HiddenMessage : ISpell
{
    public string Name => "Hidden message";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 120;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
