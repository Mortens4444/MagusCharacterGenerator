using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Intő tűz (Tűzvarázsló, Első Törvénykönyv p.271). Marks multiple points within the caster's
/// zone, each igniting a Flame-creation-like flame, but deals no damage itself. Fire-school
/// effects bypass magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class WarningFire : ISpell
{
    public string Name => "Warning fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
