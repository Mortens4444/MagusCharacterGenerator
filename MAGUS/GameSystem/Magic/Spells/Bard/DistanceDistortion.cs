using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Távolságtorzítás (Bárd — Fénymágia, Első Törvénykönyv p.145). Makes any distance in view look
/// larger or smaller than it truly is (up to 1:50), without changing the real distance.
/// </summary>
public sealed class DistanceDistortion : ISpell
{
    public string Name => "Distance distortion";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
