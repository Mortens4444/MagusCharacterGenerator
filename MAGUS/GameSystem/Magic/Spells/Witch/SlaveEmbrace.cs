using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Rabszolga ölelés (Boszorkány — Ölelésmágia, Első Törvénykönyv p.225). Same effect as the
/// Csókmágia's Rabszolgaság csókja, but reached through intercourse rather than a kiss. Duration
/// is "1 nap (vagy a boszorkány akarata szerint)" in the book; the base 1-day figure is shown,
/// the "or as long as the witch wills it" extension isn't modeled.
/// </summary>
public sealed class SlaveEmbrace : ISpell
{
    public string Name => "Slave embrace";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 10;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
