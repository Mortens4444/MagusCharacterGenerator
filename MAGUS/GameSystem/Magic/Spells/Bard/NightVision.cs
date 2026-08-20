using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Éjszakai látás (Bárd — Fénymágia, Első Törvénykönyv p.144). Grants true night vision (not
/// infravision) by amplifying incoming light, including color perception — needs at least a trace
/// of ambient light to work, useless in total darkness. Duration is 10 perc/szint in the book;
/// level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class NightVision : ISpell
{
    public string Name => "Night vision";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
