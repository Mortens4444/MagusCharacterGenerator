using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Fire;

/// <summary>
/// Tűzpolip (Tűzvarázsló, Első Törvénykönyv p.286). A tűz nyolckarú polip alakját veszi fel,
/// mely a harctér fölött lebegve minden körben négyszer csap le ostorként sújtó karjaival. The
/// rulebook summons an autonomous elemental creature with its own combat stats (Harcmódosító,
/// multiple attacks per round, its own HP/FP) that fights independently for the spell's
/// duration — none of that is modeled here; GetDamage represents only a single hit's damage
/// from the creature's book stat block. Fire-school damage bypasses magic resistance entirely
/// per the rulebook (p.267), hence Power is null.
/// </summary>
public sealed class FireOctopus : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire octopus";

    public MagicSchool School => MagicSchool.Fire;

    public int? Power => null;

    public int ManaCost => 36;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 13;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
