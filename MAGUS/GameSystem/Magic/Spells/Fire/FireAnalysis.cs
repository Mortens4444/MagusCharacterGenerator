using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzelemzés (Tűzvarázsló, Első Törvénykönyv p.271). Reveals information about a working fire
/// spell within the caster's zone: its Strength (E) and remaining duration, and whether the fire
/// is natural. Deals no damage, so Power is null.
/// </summary>
public sealed class FireAnalysis : ISpell
{
    public string Name => "Fire analysis";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
