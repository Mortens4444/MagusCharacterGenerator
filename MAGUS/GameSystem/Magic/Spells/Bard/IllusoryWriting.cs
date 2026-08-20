using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// illúzió írás (Bárd — Fénymágia, Első Törvénykönyv p.145). Writes text (up to 3 pages) that is
/// either visible until a set condition hides it, or invisible until a set condition reveals it.
/// Book duration is "végleges" (permanent); approximated as a long but finite value.
/// </summary>
public sealed class IllusoryWriting : ISpell
{
    public string Name => "Illusory writing";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 300;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
