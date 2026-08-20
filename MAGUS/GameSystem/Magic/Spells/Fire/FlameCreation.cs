using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Lángteremtés (Tűzvarázsló, Első Törvénykönyv p.270). Conjures a small flame that can ignite
/// flammable objects but deals no damage itself. Fire-school effects bypass magic resistance
/// entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FlameCreation : ISpell
{
    public string Name => "Flame creation";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
