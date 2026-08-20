using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Fantom (Bárd — Fénymágia, Első Törvénykönyv p.140). The bard becomes invisible while their
/// reflected image is projected onto a nearby point (within 15 láb), perfectly mimicking their
/// movements. Self-buff (a decoy image of the bard); not wired into the enemy-targeting pipeline.
/// </summary>
public sealed class Phantom : ISpell
{
    public string Name => "Phantom";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 23;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
