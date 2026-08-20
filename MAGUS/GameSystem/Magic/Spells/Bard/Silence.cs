using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Csend (Bárd — Hangmágia, Első Törvénykönyv p.137). Silences an area up to 8 láb radius —
/// nothing inside can be heard, doubling other casters' spellcasting time within it. Duration is
/// 1 kör/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Silence : ISpell
{
    public string Name => "Silence";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
