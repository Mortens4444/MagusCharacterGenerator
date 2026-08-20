using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűz észlelése (Tűzvarázsló, Első Törvénykönyv p.271). Reveals the combined Strength (E) of
/// all concealed and unconcealed primal and natural fire currently present in the caster's zone.
/// Deals no damage, so Power is null.
/// </summary>
public sealed class DetectFire : ISpell
{
    public string Name => "Detect fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
