using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Tükör (Bárd — Fénymágia, Első Törvénykönyv p.147). Conjures a swirling light vortex that forms
/// into a perfect mirror (up to 2x2 láb). Duration is 3 kör/szint in the book; level-1 baseline
/// shown, not level-scaled. Also blocks light-based attacks like FocusedLight; not modeled as a
/// mechanical block, flavor only.
/// </summary>
public sealed class Mirror : ISpell
{
    public string Name => "Mirror";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 18;

    public int GetDamage() => 0;
}
