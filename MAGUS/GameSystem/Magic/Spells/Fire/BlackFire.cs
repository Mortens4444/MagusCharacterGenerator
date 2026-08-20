using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Fekete tűz (Tűzvarázsló, Első Törvénykönyv p.276). Modifies an existing mundane fire's
/// light-heat balance in favor of heat: all its light vanishes and its damage output rises to
/// 1.5x the original (rounded up), rather than dealing damage itself. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class BlackFire : ISpell
{
    public string Name => "Black fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 5;

    public int GetDamage() => 0;
}
