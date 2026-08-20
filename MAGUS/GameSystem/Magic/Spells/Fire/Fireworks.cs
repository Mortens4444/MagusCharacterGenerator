using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzijáték (Tűzvarázsló, Első Törvénykönyv p.279). Látványos tűzijátékot produkál az égen;
/// gyakorlati haszna nincs, deals no damage. Fire-school damage bypasses magic resistance
/// entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class Fireworks : ISpell
{
    public string Name => "Fireworks";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
