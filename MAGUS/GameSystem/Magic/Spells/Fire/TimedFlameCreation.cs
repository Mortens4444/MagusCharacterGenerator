using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Időzített lángteremtés (Tűzvarázsló, Első Törvénykönyv p.271). Like Flame creation, but the
/// flame ignites at a point in time the caster marks in advance rather than immediately, and
/// deals no damage itself. Fire-school effects bypass magic resistance entirely per the rulebook
/// (p.267), hence Power is null.
/// </summary>
public sealed class TimedFlameCreation : ISpell
{
    public string Name => "Timed flame creation";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
