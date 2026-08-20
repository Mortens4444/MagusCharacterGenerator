using MAGUS.Enums;
using MAGUS.GameSystem.Attributes;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Tűzvihar (Boszorkánymester — Elemi mágia, Első Törvénykönyv p.240). Conjures a rain of tiny
/// searing flames in a 2-láb circle within 10 láb of the caster, burning everyone inside it
/// (except the caster) every round. Not to be confused with the Fire-school Firestorm — this is
/// a much smaller, cheaper Warlock version.
/// </summary>
public sealed class FireRainSquall : ISpell
{
    private readonly DiceThrow diceThrow = new();

    public string Name => "Fire rain squall";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 25;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 3;

    [DiceThrow(ThrowType._2D6)]
    public int GetDamage() => diceThrow._2D6();
}
