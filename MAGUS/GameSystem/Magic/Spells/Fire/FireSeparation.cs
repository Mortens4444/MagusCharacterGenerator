using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzválasztás (Tűzvarázsló, Első Törvénykönyv p.275-276). Splits an existing mundane fire's
/// light and heat components spatially, letting the caster attack with invisible heat from a
/// point up to 10 steps away while the light stays behind (or the reverse, for illumination).
/// Deals the source fire's own damage on a successful attack roll rather than a separately
/// rollable amount, so GetDamage is 0 here. Fire-school damage bypasses magic resistance entirely
/// per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireSeparation : ISpell
{
    public string Name => "Fire separation";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
