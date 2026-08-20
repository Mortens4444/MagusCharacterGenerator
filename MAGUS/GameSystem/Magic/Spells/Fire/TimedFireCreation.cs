using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Időzített tűzteremtés (Tűzvarázsló, Első Törvénykönyv p.271). Like Fire creation, but the
/// flame ignites at a point in time the caster marks in advance rather than immediately.
/// Fire-school damage bypasses magic resistance entirely per the rulebook (p.267), hence Power
/// is null.
/// </summary>
public sealed class TimedFireCreation : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Timed fire creation";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 120;

    public int DurationInRounds => 6;

    [DiceThrow(ThrowType._1D6)]
    public int GetDamage() => diceThrow._1D6();
}
