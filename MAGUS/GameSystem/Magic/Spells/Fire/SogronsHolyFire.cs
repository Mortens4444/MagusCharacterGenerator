using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Sogron szent tüze (Tűzvarázsló, Első Törvénykönyv p.277). Makes a mundane fire's effects
/// permanent - torches and lamps burn forever, hearths radiate heat for years - but has no
/// effect on a fire already magically altered. Book duration is "végleges" (permanent);
/// approximated here as a very long but finite DurationInRounds since the interface has no
/// permanence concept. Deals no damage and isn't wired into the enemy-targeting combat pipeline,
/// hence Power is null.
/// </summary>
public sealed class SogronsHolyFire : ISpell
{
    public string Name => "Sogron's holy fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
