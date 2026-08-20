using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Illúzió talaj (Bárd — Fénymágia, Első Törvénykönyv p.144). Reshapes the appearance of up to a
/// 100×100 láb patch of ground into any terrain (pond, swamp, meadow, road...), though the actual
/// elevation can only shift by 1/2 láb — good for hiding traps, not for hills or cliffs. Duration
/// is 10 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class IllusoryTerrain : ISpell
{
    public string Name => "Illusory terrain";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
