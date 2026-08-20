using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Kém tűz (Tűzvarázsló, Első Törvénykönyv p.280). Deals no damage. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class SpyFire : ISpell
{
    public string Name => "Spy fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 8;

    public int GetDamage() => 0;
}
