using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzsárkány (Tűzvarázsló, Első Törvénykönyv p.286). A megidézett tűz egy sárkány alakját
/// veszi fel, mely 20 láb magasból lángot okád a tűzvarázsló ellenfeleire. The rulebook summons
/// an autonomous elemental creature with its own combat stats (Harcmódosító, multiple attacks
/// per round, its own HP/FP) that fights independently for the spell's duration — none of that
/// is modeled here; GetDamage represents only a single hit's damage from the creature's book
/// stat block. Fire-school damage bypasses magic resistance entirely per the rulebook (p.267),
/// hence Power is null.
/// </summary>
public sealed class FireDragon : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire dragon";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 42;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 11;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
