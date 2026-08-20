using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Hideg tűz (Tűzvarázsló, Első Törvénykönyv p.276). The mirror of Black fire: modifies an
/// existing mundane fire's light-heat balance in favor of light, turning it into a bright but
/// harmless illumination source, rather than dealing damage. Fire-school damage bypasses magic
/// resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class ColdFire : ISpell
{
    public string Name => "Cold fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
