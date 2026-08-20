using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Mágikus ölelés (Boszorkány — Ölelésmágia, Első Törvénykönyv p.225). The witch's primary means
/// of regaining spent Mana-points; costs the witch 2 Stamina points per use (recoverable only by
/// sleep), and knocks her unconscious for k6×10 minutes if her Stamina drops below 6 — neither
/// cost is modeled here, this represents only the base act. Not wired into the enemy-targeting
/// combat pipeline (harmless to the partner).
/// </summary>
public sealed class MagicalEmbrace : ISpell
{
    public string Name => "Magical embrace";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
