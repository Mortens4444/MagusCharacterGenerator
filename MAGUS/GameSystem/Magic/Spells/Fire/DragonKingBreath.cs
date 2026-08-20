using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// A Sárkánykirály lehelete (Tűzvarázsló, Első Törvénykönyv p.278). A Sárkány lehelete
/// legerősebb változata: 30-láb hosszú, még szélesebb és perzselőbb lángsugár. Fire-school
/// damage bypasses magic resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class DragonKingBreath : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Dragon king's breath";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 55;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 9;

    public int DurationInRounds => 30;

    [DiceThrow(ThrowType._15D6)]
    public int GetDamage() => diceThrow._15D6();
}
