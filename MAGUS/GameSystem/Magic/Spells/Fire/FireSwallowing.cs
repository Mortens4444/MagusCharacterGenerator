using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűznyelés (Tűzvarázsló, Első Törvénykönyv p.282-283). Absorbs an incoming fire attack and
/// reflects it back at the attacker at the same strength; reflects the source fire's own
/// damage rather than rolling its own, so GetDamage is 0 here. Fire-school damage bypasses
/// magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireSwallowing : ISpell
{
    public string Name => "Fire swallowing";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
