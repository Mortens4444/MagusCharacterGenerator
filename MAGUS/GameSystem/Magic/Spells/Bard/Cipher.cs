using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Rejtjel (Bárd — Fénymágia, Első Törvénykönyv p.145). Scrambles the letters of a written text
/// (up to 3 parchment pages) so only a chosen reader sees it correctly. Book duration is 1 year;
/// approximated as a long but finite value.
/// </summary>
public sealed class Cipher : ISpell
{
    public string Name => "Cipher";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
