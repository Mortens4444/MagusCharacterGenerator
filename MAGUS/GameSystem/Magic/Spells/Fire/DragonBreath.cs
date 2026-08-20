using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// A Sárkány lehelete (Tűzvarázsló, Első Törvénykönyv p.278). A 20-láb hosszú, kiszélesedő
/// lángsugarat lehel a szájából, akárcsak egy sárkány. Fire-school damage bypasses magic
/// resistance entirely per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class DragonBreath : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Dragon's breath";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 42;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 7;

    public int DurationInRounds => 30;

    [DiceThrow(ThrowType._10D6)]
    public int GetDamage() => diceThrow._10D6();
}
