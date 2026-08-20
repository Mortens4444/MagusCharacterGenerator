using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Őstűz észlelése (Tűzvarázsló, Első Törvénykönyv p.271). Reveals the total Strength (E) of
/// primal fire present within the caster's zone, including concealed fire. Deals no damage, so
/// Power is null.
/// </summary>
public sealed class DetectPrimalFire : ISpell
{
    public string Name => "Detect primal fire";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 3;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
